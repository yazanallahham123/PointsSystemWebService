using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data.SqlClient;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class CityClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int GovernorateId { get; set; }
        [DataMember(Order = 3)]
        public string ArabicName { get; set; }
        [DataMember(Order = 4)]
        public string EnglishName { get; set; }
        [DataMember(Order = 5)]
        public int Order { get; set; }

        public CityClass PopulateCity(string[] fieldNames, SqlDataReader reader)
        {
            var city = new CityClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    city.Id = (int)reader["Id"];

            if (fieldNames.Contains("GovernorateId"))
                if (!Convert.IsDBNull(reader["GovernorateId"]))
                    city.GovernorateId = (int)reader["GovernorateId"];

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    city.EnglishName = reader["EnglishName"].ToString();

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    city.ArabicName = reader["ArabicName"].ToString();

            return city;
        }
    }
}