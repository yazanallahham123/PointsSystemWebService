using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class DayClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Code { get; set; }

        [DataMember(Order = 3)]
        public string ArabicName { get; set; }
        [DataMember(Order = 4)]
        public string EnglishName { get; set; }
        [DataMember(Order = 5)]
        public int Order { get; set; }
        public DayClass PopulateDay(string[] fieldNames, SqlDataReader reader)
        {
            var day = new DayClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    day.Id = (int)reader["Id"];

            if (fieldNames.Contains("Code"))
                if (!Convert.IsDBNull(reader["Code"]))
                    day.Code = reader["Code"].ToString();

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    day.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    day.EnglishName = reader["EnglishName"].ToString();

            return day;
        }
    }
}