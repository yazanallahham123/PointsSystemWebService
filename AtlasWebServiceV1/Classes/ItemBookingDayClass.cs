using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemBookingDayClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int ItemId { get; set; }
        [DataMember(Order = 3)]
        public string ItemArabicName { get; set; }
        [DataMember(Order = 4)]
        public string ItemEnglishName { get; set; }
        [DataMember(Order = 5)]
        public int DayId { get; set; }
        [DataMember(Order = 6)]
        public string DayArabicName { get; set; }
        [DataMember(Order = 7)]
        public string DayEnglishName { get; set; }
        [DataMember(Order = 8)]
        public List<ItemBookingDayTimeClass> ItemBookingDayTime { get; set; }
        [DataMember(Order = 9)]
        public int Order { get; set; }
        public ItemBookingDayClass PopulateItemBookingDay(string[] fieldNames, SqlDataReader reader)
        {
            var itemBookingDay = new ItemBookingDayClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemBookingDay.Id = (int)reader["Id"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    itemBookingDay.ItemId = (int)reader["ItemId"];

            if (fieldNames.Contains("ItemArabicName"))
                if (!Convert.IsDBNull(reader["ItemArabicName"]))
                    itemBookingDay.ItemArabicName = reader["ItemArabicName"].ToString();

            if (fieldNames.Contains("ItemEnglishName"))
                if (!Convert.IsDBNull(reader["ItemEnglishName"]))
                    itemBookingDay.ItemEnglishName = reader["ItemEnglishName"].ToString();

            if (fieldNames.Contains("DayId"))
                if (!Convert.IsDBNull(reader["DayId"]))
                    itemBookingDay.DayId = (int)reader["DayId"];

            if (fieldNames.Contains("DayArabicName"))
                if (!Convert.IsDBNull(reader["DayArabicName"]))
                    itemBookingDay.DayArabicName = reader["DayArabicName"].ToString();


            if (fieldNames.Contains("DayEnglishName"))
                if (!Convert.IsDBNull(reader["DayEnglishName"]))
                    itemBookingDay.DayEnglishName = reader["DayEnglishName"].ToString();


            itemBookingDay.ItemBookingDayTime = new List<ItemBookingDayTimeClass>();
            return itemBookingDay;

        }

    }
}