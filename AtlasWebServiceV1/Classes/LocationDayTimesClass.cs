using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class LocationDayTimesClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int LocationDayId { get; set; }
        [DataMember(Order = 3)]
        public string DeliveryPeriodFrom { get; set; }
        [DataMember(Order = 4)]
        public string DeliveryPeriodTo { get; set; }
        [DataMember(Order = 5)]
        public int Order { get; set; }
        public LocationDayTimesClass PopulateLocationDayTime(string[] fieldNames, SqlDataReader reader)
        {
            var locationDayTime = new LocationDayTimesClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    locationDayTime.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("LocationDayId"))
                if (!Convert.IsDBNull(reader["LocationDayId"]))
                    locationDayTime.LocationDayId = Convert.ToInt32(reader["LocationDayId"]);

            if (fieldNames.Contains("DeliveryPeriodFrom"))
                if (!Convert.IsDBNull(reader["DeliveryPeriodFrom"]))
                    locationDayTime.DeliveryPeriodFrom = reader["DeliveryPeriodFrom"].ToString();

            if (fieldNames.Contains("DeliveryPeriodTo"))
                if (!Convert.IsDBNull(reader["DeliveryPeriodTo"]))
                    locationDayTime.DeliveryPeriodTo = reader["DeliveryPeriodTo"].ToString();

            return locationDayTime;
        }
    }
}