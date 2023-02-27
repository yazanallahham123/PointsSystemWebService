using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemBookingDayTimeClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int ItemBookingDayId { get; set; }
        [DataMember(Order = 3)]
        public string Time { get; set; }
        [DataMember(Order = 4)]
        public string Note { get; set; }
        [DataMember(Order = 4)]
        public int Order { get; set; }
        public ItemBookingDayTimeClass PopulateItemBookingDayTime(string[] fieldNames, SqlDataReader reader)
        {
            var itemBookingDayTime = new ItemBookingDayTimeClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemBookingDayTime.Id = (int)reader["Id"];

            if (fieldNames.Contains("ItemBookingDayId"))
                if (!Convert.IsDBNull(reader["ItemBookingDayId"]))
                    itemBookingDayTime.ItemBookingDayId = (int)reader["ItemBookingDayId"];

            if (fieldNames.Contains("Time"))
                if (!Convert.IsDBNull(reader["Time"]))
                    itemBookingDayTime.Time = reader["Time"].ToString();

            if (fieldNames.Contains("Note"))
                if (!Convert.IsDBNull(reader["Note"]))
                    itemBookingDayTime.Note = reader["Note"].ToString();

            return itemBookingDayTime;

        }
    }
}