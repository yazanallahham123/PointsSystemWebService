using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class LocationDaysClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int LocationId { get; set; }
        [DataMember(Order = 3)]
        public string LocationArabicName { get; set; }
        [DataMember(Order = 4)]
        public string LocationEnglishName { get; set; }
        [DataMember(Order = 5)]
        public int DayId { get; set; }
        [DataMember(Order = 6)]
        public string DayArabicName { get; set; }
        [DataMember(Order = 7)]
        public string DayEnglishName { get; set; }
        [DataMember(Order = 7)]
        public List<LocationDayTimesClass> LocationDayTimes { get; set; }
        [DataMember(Order = 9)]
        public int Order { get; set; }
        public LocationDaysClass PopulateLocationDay(string[] fieldNames, SqlDataReader reader)
        {
            var locationDay = new LocationDaysClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    locationDay.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("LocationId"))
                if (!Convert.IsDBNull(reader["LocationId"]))
                    locationDay.LocationId = Convert.ToInt32(reader["LocationId"]);

            if (fieldNames.Contains("LocationArabicName"))
                if (!Convert.IsDBNull(reader["LocationArabicName"]))
                    locationDay.LocationArabicName = reader["LocationArabicName"].ToString();

            if (fieldNames.Contains("LocationEnglishName"))
                if (!Convert.IsDBNull(reader["LocationEnglishName"]))
                    locationDay.LocationEnglishName = reader["LocationEnglishName"].ToString();

            if (fieldNames.Contains("DayId"))
                if (!Convert.IsDBNull(reader["DayId"]))
                    locationDay.DayId = Convert.ToInt32(reader["DayId"]);

            if (fieldNames.Contains("DayArabicName"))
                if (!Convert.IsDBNull(reader["DayArabicName"]))
                    locationDay.DayArabicName = reader["DayArabicName"].ToString();

            if (fieldNames.Contains("DayEnglishName"))
                if (!Convert.IsDBNull(reader["DayEnglishName"]))
                    locationDay.DayEnglishName = reader["DayEnglishName"].ToString();

            if (fieldNames.Contains("Order"))
                if (!Convert.IsDBNull(reader["Order"]))
                    locationDay.Order = Convert.ToInt32(reader["Order"]);
            locationDay.LocationDayTimes = new List<LocationDayTimesClass>();
            return locationDay;
        }
    }

}