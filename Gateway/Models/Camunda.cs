using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Models
{
    public class CompleteExternalTask
    {
        /// <summary>
        /// The id of the worker that completes the task. Must match the id of the worker who has most recently locked the task.
        /// </summary>
        public string WorkerId;

        /// <summary>
        /// Dictionary containing variable key-value pairs.
        /// </summary>
        public Dictionary<string, Variable> Variables;

        /// <summary>
        /// Dictionary containing variable key-value pairs. Local variables are set only in the scope of external task.
        /// </summary>
        public Dictionary<string, Variable> LocalVariables;

        /*public CompleteExternalTask SetVariable(string name, object value)
        {
            Variables = (Variables ?? new Dictionary<string, string>()).Set(name, value);
            return this;
        }

        /// <summary>
        /// Local variables are set only in the scope of external task.
        /// </summary>
        public CompleteExternalTask SetLocalVariable(string name, object value)
        {
            LocalVariables = (LocalVariables ?? new Dictionary<string, VariableValue>()).Set(name, value);
            return this;
        }*/
    }

    public class ExternalTask
    {
        //public ExternalTask();

        public string ActivityId { get; set; }
        public string ActivityInstanceId { get; set; }
        public string ProcessInstanceId { get; set; }
        public string ProcessDefinitionId { get; set; }
        public string Id { get; set; }
        public int? Retries { get; set; }
        public Dictionary<string, Variable> Variables { get; set; }
        public string TopicName { get; set; }
        public string WorkerId { get; set; }
        public int? Priority { get; set; }

        //public override string ToString();
    }

    public class Variable
    {
        //public Variable();

        public string Type { get; set; }
        public object Value { get; set; }
        public object ValueInfo { get; set; }
    }

    public class ExternalTaskDescriptor
    {
        public ExternalTask externalTask { get; set; }
        public Dictionary<string, object> resultVariables { get; set; }
    }
}
