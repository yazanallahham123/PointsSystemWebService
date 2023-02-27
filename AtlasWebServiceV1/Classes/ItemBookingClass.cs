using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemBookingClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int ItemId { get; set; }
        [DataMember(Order = 3)]
        public int UserId { get; set; }
        [DataMember(Order = 4)]
        public string VisitDate { get; set; }
        [DataMember(Order = 5)]
        public string Note { get; set; }
        [DataMember(Order = 6)]
        public string ItemArabicName { get; set; }
        [DataMember(Order = 7)]
        public string ItemEnglishName { get; set; }
        [DataMember(Order = 8)]
        public string UserFullName { get; set; }
        [DataMember(Order = 9)]
        public int Order { get; set; }
        public ItemBookingClass PopulateItemBooking(string[] fieldNames, SqlDataReader reader)
        {
            var itemBooking = new ItemBookingClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemBooking.Id = (int)reader["Id"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    itemBooking.ItemId = (int)reader["ItemId"];

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    itemBooking.UserId = (int)reader["UserId"];

            if (fieldNames.Contains("VisitDate"))
                if (!Convert.IsDBNull(reader["VisitDate"]))
                    itemBooking.VisitDate = reader["VisitDate"].ToString();

            if (fieldNames.Contains("Note"))
                if (!Convert.IsDBNull(reader["Note"]))
                    itemBooking.Note = reader["Note"].ToString();

            if (fieldNames.Contains("ItemArabicName"))
                if (!Convert.IsDBNull(reader["ItemArabicName"]))
                    itemBooking.ItemArabicName = reader["ItemArabicName"].ToString();
            if (fieldNames.Contains("ItemEnglishName"))
                if (!Convert.IsDBNull(reader["ItemEnglishName"]))
                    itemBooking.ItemEnglishName = reader["ItemEnglishName"].ToString();

            if (fieldNames.Contains("UserFullName"))
                if (!Convert.IsDBNull(reader["UserFullName"]))
                    itemBooking.UserFullName = reader["UserFullName"].ToString();

            return itemBooking;
        }

    }
}