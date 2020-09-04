using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Gateway.Models
{
    [DataContract]
    public class Forecast
    {
        [DataMember(Name = "latitude")]
        public float Latitude { get; set; }
        [DataMember(Name = "longitude")]
        public float Longitude { get; set; }
        [DataMember(Name = "timezone")]
        public string TimeZone { get; set; }
        [DataMember(Name = "offset")]
        public double TimeZoneOffset { get; set; }
        [DataMember(Name = "currently")]
        public CurrentDataPoint Currently { get; set; }
        [DataMember(Name = "minutely")]
        public MinutelyForecast Minutely { get; set; }
        [DataMember(Name = "hourly")]
        public HourlyForecast Hourly { get; set; }
        [DataMember(Name = "daily")]
        public DailyForecast Daily { get; set; }
        [DataMember(Name = "flags")]
        public Flags Flags { get; set; }
        [DataMember(Name = "alerts")]
        public IList<Alert> Alerts { get; set; }
    }

    [DataContract]
    public class Flags
    {

        [DataMember(Name = "sources")]
        public IList<string> Sources { get; set; }
        [DataMember(Name = "darksky-stations")]
        public IList<string> DarkSkyStations { get; set; }
        [DataMember(Name = "datapoint-stations")]
        public IList<string> DataPointStations { get; set; }
        [DataMember(Name = "isd-stations")]
        public IList<string> IsdStations { get; set; }
        [DataMember(Name = "lamp-stations")]
        public IList<string> LampStations { get; set; }
        [DataMember(Name = "metar-stations")]
        public IList<string> MetarStations { get; set; }
        [DataMember(Name = "madis-stations")]
        public IList<string> MadisStations { get; set; }
        [DataMember(Name = "metno-license")]
        public string MetnoLicense { get; set; }
        [DataMember(Name = "units")]
        public string Units { get; set; }
    }

    [DataContract]
    public class CurrentDataPoint
    {

        [DataMember(Name = "ozone")]
        public float Ozone { get; set; }
        [DataMember(Name = "pressure")]
        public float Pressure { get; set; }
        [DataMember(Name = "cloudCover")]
        public float CloudCover { get; set; }
        [DataMember(Name = "visibility")]
        public float Visibility { get; set; }
        [DataMember(Name = "windBearing")]
        public float WindBearing { get; set; }
        [DataMember(Name = "windSpeed")]
        public float WindSpeed { get; set; }
        [DataMember(Name = "humidity")]
        public float Humidity { get; set; }
        [DataMember(Name = "dewPoint")]
        public float DewPoint { get; set; }
        [DataMember(Name = "uvIndex")]
        public float UVIndex { get; set; }
        [DataMember(Name = "apparentTemperature")]
        public float ApparentTemperature { get; set; }
        [DataMember(Name = "precipType")]
        public string PrecipitationType { get; set; }
        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }
        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }
        [DataMember(Name = "nearestStormBearing")]
        public float NearestStormBearing { get; set; }
        [DataMember(Name = "nearestStormDistance")]
        public float NearestStormDistance { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        public DateTimeOffset Time { get; set; }
        [DataMember(Name = "temperature")]
        public float Temperature { get; set; }
        [DataMember(Name = "windGust")]
        public float WindGust { get; set; }
    }

    [DataContract]
    public class MinutelyForecast
    {
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "data")]
        public IList<MinuteDataPoint> Minutes { get; set; }
    }

    [DataContract]
    public class HourlyForecast
    {

        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "data")]
        public IList<HourDataPoint> Hours { get; set; }
    }

    [DataContract]
    public class DailyForecast
    {

        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "data")]
        public DayDataPoint[] Days { get; set; }
    }

    [DataContract]
    public class Alert
    {

        [DataMember(Name = "title")]
        public string Title { get; set; }
        //public Severity Severity { get; }
        public DateTimeOffset Time { get; set; }
        [DataMember(Name = "regions")]
        public string[] Regions { get; set; }
        public DateTimeOffset Expires { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
    }

    [DataContract]
    public class MinuteDataPoint
    {
        public DateTimeOffset Time { get; set; }
        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }
        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }
        [DataMember(Name = "precipType")]
        public string PrecipitationType { get; set; }
    }

    [DataContract]
    public class HourDataPoint
    {

        [DataMember(Name = "ozone")]
        public float Ozone { get; set; }
        [DataMember(Name = "pressure")]
        public float Pressure { get; set; }
        [DataMember(Name = "cloudCover")]
        public float CloudCover { get; set; }
        [DataMember(Name = "visibility")]
        public float Visibility { get; set; }
        [DataMember(Name = "windBearing")]
        public float WindBearing { get; set; }
        [DataMember(Name = "windSpeed")]
        public float WindSpeed { get; set; }
        [DataMember(Name = "humidity")]
        public float Humidity { get; set; }
        [DataMember(Name = "dewPoint")]
        public float DewPoint { get; set; }
        [DataMember(Name = "apparentTemperature")]
        public float ApparentTemperature { get; set; }
        [DataMember(Name = "temperature")]
        public float Temperature { get; set; }
        [DataMember(Name = "precipAccumulation")]
        public float PrecipitationAccumulation { get; set; }
        [DataMember(Name = "precipType")]
        public string PrecipitationType { get; set; }
        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }
        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        public DateTimeOffset Time { get; set; }
        [DataMember(Name = "uvIndex")]
        public float UVIndex { get; set; }
        [DataMember(Name = "windGust")]
        public float WindGust { get; set; }
    }

    [DataContract]
    public class DayDataPoint
    {
        [Obsolete("Deprecated - consider using LowTemperatureTime instead.")]
        public DateTimeOffset MinTemperatureTime { get; set; }
        [DataMember(Name = "temperatureMax")]
        [Obsolete("Deprecated - consider using HighTemperature instead.")]
        public float MaxTemperature { get; set; }
        [Obsolete("Deprecated - consider using HighTemperatureTime instead.")]
        public DateTimeOffset MaxTemperatureTime { get; set; }
        [DataMember(Name = "apparentTemperatureMin")]
        [Obsolete("Deprecated - consider using ApparentLowTemperature instead.")]
        public float ApparentMinTemperature { get; set; }
        [Obsolete("Deprecated - consider using ApparentLowTemperatureTime instead.")]
        public DateTimeOffset ApparentMinTemperatureTime { get; set; }
        [DataMember(Name = "apparentTemperatureMax")]
        [Obsolete("Deprecated - consider using ApparentHighTemperature instead.")]
        public float ApparentMaxTemperature { get; set; }
        [Obsolete("Deprecated - consider using ApparentHighTemperatureTime instead.")]
        public DateTimeOffset ApparentMaxTemperatureTime { get; set; }
        [DataMember(Name = "dewPoint")]
        public float DewPoint { get; set; }
        [DataMember(Name = "humidity")]
        public float Humidity { get; set; }
        [DataMember(Name = "windSpeed")]
        public float WindSpeed { get; set; }
        [DataMember(Name = "windBearing")]
        public float WindBearing { get; set; }
        [DataMember(Name = "windGust")]
        public float WindGust { get; set; }
        public DateTimeOffset WindGustTime { get; set; }
        [DataMember(Name = "visibility")]
        public float Visibility { get; set; }
        [DataMember(Name = "cloudCover")]
        public float CloudCover { get; set; }
        [DataMember(Name = "pressure")]
        public float Pressure { get; set; }
        [DataMember(Name = "ozone")]
        public float Ozone { get; set; }
        [DataMember(Name = "temperatureMin")]
        [Obsolete("Deprecated - consider using LowTemperature instead.")]
        public float MinTemperature { get; set; }
        [DataMember(Name = "temperature")]
        public float Temperature { get; set; }
        public DateTimeOffset HighTemperatureTime { get; set; }
        [DataMember(Name = "temperatureHigh")]
        public float HighTemperature { get; set; }
        public DateTimeOffset Time { get; set; }
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        public DateTimeOffset SunsetTime { get; set; }
        public DateTimeOffset SunriseTime { get; set; }
        [DataMember(Name = "moonPhase")]
        public float MoonPhase { get; set; }
        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }
        [DataMember(Name = "precipIntensityMax")]
        public float MaxPrecipitationIntensity { get; set; }
        [DataMember(Name = "uvIndex")]
        public float UVIndex { get; set; }
        [DataMember(Name = "precipType")]
        public string PrecipitationType { get; set; }
        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }
        [DataMember(Name = "precipAccumulation")]
        public float PrecipitationAccumulation { get; set; }
        [DataMember(Name = "apparentTemperatureLow")]
        public float ApparentLowTemperature { get; set; }
        public DateTimeOffset ApparentLowTemperatureTime { get; set; }
        [DataMember(Name = "apparentTemperatureHigh")]
        public float ApparentHighTemperature { get; set; }
        public DateTimeOffset ApparentHighTemperatureTime { get; set; }
        [DataMember(Name = "temperatureLow")]
        public float LowTemperature { get; set; }
        public DateTimeOffset LowTemperatureTime { get; set; }
        public DateTimeOffset MaxPrecipitationIntensityTime { get; set; }
        public DateTimeOffset UVIndexTime { get; set; }
    }
}
