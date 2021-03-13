using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreService.Models
{
    public class DataStoreContext
    {
        public string ConnectionString { get; set; }

        public DataStoreContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<List<Data>> GetAllData()
        {

            List<List<Data>> listoflist = new List<List<Data>>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string querydataSchema = "SELECT tableId FROM dataSchema;";
                MySqlCommand dataSchema = new MySqlCommand(querydataSchema, conn);

                

                List<string> tableIds = new List<string>();
                using (var reader = dataSchema.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tableIds.Add(reader["tableId"].ToString());
                    }
                }

                foreach( string t in tableIds)
                {
                    List<Data> list = new List<Data>();
                    string myselection = t;
                    string SQL = "SELECT * FROM data WHERE Id='" + myselection + "';";
                    MySqlCommand cmd = new MySqlCommand(SQL, conn);
                
                    using (var reader2 = cmd.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            list.Add(new Data()
                            {
                                id = reader2["Id"].ToString(),
                                data = reader2["data"].ToString()
                            });
                        }
                    }
                    listoflist.Add(list);
                }
            }
            return listoflist;
        }

        public string GetDataByKey(string table, string primaryKey)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                //MySqlCommand comm = conn.CreateCommand();
                string SQL = "SELECT * FROM data JOIN tables ON tables.table_id=data.table_id WHERE table_name='" + table + "' AND JSON_VALUE(data, '$.code')  ='" + primaryKey + "';";
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                Data data = new Data();
                string d = "";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data = new Data()
                        {
                            id = reader["table_name"].ToString(),
                            data = reader["data"].ToString()
                        };
                        d = reader["data"].ToString();
                    }
                }
                conn.Close();
                return d;
            }
        }

        public void PostData(string tableId, IDictionary<string, JToken> data)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                // CHECK IF TABLE EXISTS
                MySqlCommand comm = conn.CreateCommand();
                string SQL = "SELECT * FROM tables WHERE table_name='" + tableId + "';";
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                string table_id = "";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        table_id = reader["table_id"].ToString();
                    }
                }
                // IF TABLE DOES NOT EXISTS THEN INSERT TABLE
                /*if(table_id == "")
                {
                    SQL = "INSERT INTO tables(table_name) VALUES(tableId)";
                    cmd = new MySqlCommand(SQL, conn);
                }*/
                // IF TABLE EXISTS THEN INSERT TO DATA
                if (table_id != "")
                {
                    comm.CommandText = "INSERT INTO data(table_id,data) VALUES(@id, @data)";
                    comm.Parameters.AddWithValue("@id", table_id);
                    comm.Parameters.AddWithValue("@data", JsonConvert.SerializeObject(data));
                }
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void PutData(DataDescriptor descriptor)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                try
                {
                    string json_replace = "";
                    foreach (var data in descriptor.Data)
                    {
                        json_replace = ", '$." + data.Key + "', " + data.Value ;
                    }
                    comm.CommandText = "UPDATE data JOIN tables ON data.table_id = tables.table_id SET data.data = " +
                        "JSON_REPLACE(data.data" + json_replace + ") " +
                        "WHERE tables.table_name = '" + descriptor.Table_Name + "' AND JSON_VALUE(data, '$.code')  ='" + descriptor.PrimaryKey + "';";
                    //comm.Parameters.AddWithValue("@id", tableId);
                    //comm.Parameters.AddWithValue("@code", JsonConvert.SerializeObject(data.code));
                    //comm.Parameters.AddWithValue("@quantity", JsonConvert.SerializeObject(data.quantity));
                    int rowsEffected = comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught exception: " + ex.Message);
                }
                conn.Close();
            }
        }
        public List<tableStructure> getTables()
        {
            List<tableStructure> tables = new List<tableStructure>();
            List<tableTable> t = getTableData();
            foreach(tableTable table in t)
            {
                tables.Add(getTable(table.table_id));
            }
            return tables;
        }
        public tableStructure getTable(string table_id)
        {
            return new tableStructure()
            {
                id = table_id,
                name = getTableName(table_id),
                rows = getData(table_id),
                fields = getFieldsData(table_id)
            };
        }
        public string getTableName(string table_id)
        {
            string name = "";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                string SQL = "SELECT * FROM tables WHERE table_id='" + table_id + "';";
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        name = reader["table_name"].ToString();
                    }
                }
                conn.Close();
            }
            return name;
        }
        public List<tableTable> getTableData()
        {
            List<tableTable> tables = new List<tableTable>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                string SQL = "SELECT * FROM tables;";
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                string table_id = "";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tables.Add(new tableTable() {
                            table_id = reader["table_id"].ToString(),
                            table_name = reader["table_name"].ToString()
                        });

                    }
                }
                conn.Close();
            }
            return tables;
        }
        public List<IDictionary<string, string>> getData(string table_id)
        {
            List<IDictionary<string, string>> d = new List<IDictionary<string, string>>() { };
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                string SQL = "SELECT * FROM data WHERE table_id='" + table_id + "';";
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                //string table_id = "";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //table_id = reader["table_id"].ToString();
                        //data.Add(reader["data"].ToString());
                        var deserialized = JsonConvert.DeserializeObject<IDictionary<string, string>>(reader["data"].ToString());
                        d.Add(deserialized);
                    }
                }
                conn.Close();
            }

            return d;
        }
        public List<field> getFieldsData(string table_id)
        {
            List<field> field = new List<field>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                string SQL = "SELECT * FROM fields WHERE table_id='" + table_id + "';";
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                //string table_id = "";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //table_id = reader["table_id"].ToString();
                        //fields_name.Add(reader["field_name"].ToString());
                        field.Add( new field()
                            {
                                id = reader["field_id"].ToString(),
                                name = reader["field_name"].ToString()
                            }
                        );
                    }
                }
                conn.Close();
            }
            return field;
        }
        public void InsertData(string table_name, string table_id, string data)
        {
            this.InsertIntoTables(table_name);
        }
        public void InsertTable(string table_name)
        {
            this.InsertIntoTables(table_name);
        }

        public void InsertIntoData(string table_id, string data)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                try
                {
                    comm.CommandText = "INSERT INTO data(table_id,data) VALUES(@id, @data)";
                    comm.Parameters.AddWithValue("@id", table_id);
                    comm.Parameters.AddWithValue("@data", data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught exception: " + ex.Message);
                }
                conn.Close();
            }
        }
        public string InsertIntoTables(string table_name)
        {
            string modified ="";
            using (MySqlConnection conn = GetConnection())
            {
                MySqlCommand comm = conn.CreateCommand();
                try
                {
                    conn.Open();
                    // CHECK IF TABLE EXISTS
                    string SQL = "SELECT * FROM tables WHERE table_name='" + table_name + "';";
                    MySqlCommand cmd = new MySqlCommand(SQL, conn);
                    string id = "";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader["table_id"].ToString();
                        }
                    }
                    // IF TABLE DOES NOT EXISTS THEN INSERT TABLE
                    if (id == "")
                    {
                        comm.CommandText = "INSERT INTO tables(table_name) VALUES(@table_name);  SELECT LAST_INSERT_ID();";
                        comm.Parameters.AddWithValue("@table_name", table_name);
                        comm.ExecuteNonQuery();
                    }
                    SQL = "SELECT table_id FROM tables WHERE table_name='" + table_name + "';";
                    cmd = new MySqlCommand(SQL, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            modified = reader["table_id"].ToString();
                        }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught exception: " + ex.Message);
                }
            }
            return modified;
        }
        public void InsertIntoFields(string table_id, string field_name)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                // CHECK IF TABLE EXISTS
                MySqlCommand comm = conn.CreateCommand();
                string SQL = "SELECT * FROM fields WHERE table_id='" + table_id + "' AND field_name='" + field_name + "';";
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                string id = "";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader["table_id"].ToString();
                    }
                }
                // IF TABLE DOES NOT EXISTS THEN INSERT TABLE
                if(id == "")
                {
                    comm.CommandText = "INSERT INTO fields(table_id,field_name) VALUES(@id, @field_name)";
                    comm.Parameters.AddWithValue("@id", table_id);
                    comm.Parameters.AddWithValue("@field_name", field_name);
                }
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateField(string field_id, string field_name)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                try
                {
                    comm.CommandText = "UPDATE fields SET field_name = '" + field_name + "' WHERE field_id = '" + field_id + "';";
                    int rowsEffected = comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught exception: " + ex.Message);
                }
                conn.Close();
            }
        }
        public void UpdateTableName(string table_id, string table_name)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                try
                {
                    comm.CommandText = "UPDATE tables SET table_name = '" + table_name + "' WHERE table_id = '" + table_id + "';";
                    int rowsEffected = comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught exception: " + ex.Message);
                }
                conn.Close();
            }
        }

        public class data
        {
            [JsonExtensionData]
            public IDictionary<string, string> _additionalData;
        }
    }
}
