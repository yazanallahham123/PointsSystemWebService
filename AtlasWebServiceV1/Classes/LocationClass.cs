using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class LocationClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int GovernorateId { get; set; }

        [DataMember(Order = 3)]
        public int CityId { get; set; }

        [DataMember(Order = 4)]
        public string ArabicName { get; set; }
        [DataMember(Order = 5)]
        public string EnglishName { get; set; }

        [DataMember(Order = 6)]
        public double DeliveryCost { get; set; }
        [DataMember(Order = 7)]
        public bool HasImmediateDelivdery { get; set; }
        [DataMember(Order = 8)]
        public double ImmediateDeliveryCost { get; set; }

        [DataMember(Order = 9)]
        public List<LocationDaysClass> LocationDays { get; set; }
        [DataMember(Order = 6)]
        public int Order { get; set; }

        public LocationClass PopulateLocation(string[] fieldNames, SqlDataReader reader)
        {
            LocationClass location = new LocationClass();


            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    location.Id = (int)reader["Id"];


            if (fieldNames.Contains("GovernorateId"))
                if (!Convert.IsDBNull(reader["GovernorateId"]))
                    location.GovernorateId = (int)reader["GovernorateId"];


            if (fieldNames.Contains("CityId"))
                if (!Convert.IsDBNull(reader["CityId"]))
                    location.CityId = (int)reader["CityId"];


            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    location.EnglishName = reader["EnglishName"].ToString();


            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    location.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("DeliveryCost"))
                if (!Convert.IsDBNull(reader["DeliveryCost"]))
                    location.DeliveryCost = (double)reader["DeliveryCost"];

            if (fieldNames.Contains("HasImmediateDelivdery"))
                if (!Convert.IsDBNull(reader["HasImmediateDelivdery"]))
                    location.HasImmediateDelivdery = (bool)reader["HasImmediateDelivdery"];

            if (fieldNames.Contains("ImmediateDeliveryCost"))
                if (!Convert.IsDBNull(reader["ImmediateDeliveryCost"]))
                    location.ImmediateDeliveryCost = (double)reader["ImmediateDeliveryCost"];

            return location;
        }
    }
}