using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class StyleDetailItemClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int StyleDetailId { get; set; }
        [DataMember(Order = 3)]
        public int ItemId { get; set; }
        [DataMember(Order = 4)]
        public int ItemColorId { get; set; }
        [DataMember(Order = 5)]
        public string ItemArabicName { get; set; }
        [DataMember(Order = 6)]
        public string ItemEnglishName { get; set; }
        [DataMember(Order = 7)]
        public int Order { get; set; }
        [DataMember(Order = 8)]
        public string ImageURL { get; set; }
        [DataMember(Order = 9)]
        public string ColorArabicName { get; set; }
        [DataMember(Order = 10)]
        public string ColorEnglishName { get; set; }
        [DataMember(Order = 11)]
        public int ColorId { get; set; }
        [DataMember(Order = 12)]
        public int StyleId { get; set; }

        public StyleDetailItemClass PopulateStyleDetailItem(string[] fieldNames, SqlDataReader reader)
        {
            var styleDetailItem = new StyleDetailItemClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    styleDetailItem.Id = (int)reader["Id"];

            if (fieldNames.Contains("StyleDetailId"))
                if (!Convert.IsDBNull(reader["StyleDetailId"]))
                    styleDetailItem.StyleDetailId = (int)reader["StyleDetailId"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    styleDetailItem.ItemId = (int)reader["ItemId"];

            if (fieldNames.Contains("ItemColorId"))
                if (!Convert.IsDBNull(reader["ItemColorId"]))
                    styleDetailItem.ItemColorId = (int)reader["ItemColorId"];

            if (fieldNames.Contains("ItemArabicName"))
                if (!Convert.IsDBNull(reader["ItemArabicName"]))
                    styleDetailItem.ItemArabicName = reader["ItemArabicName"].ToString();

            if (fieldNames.Contains("ItemEnglishName"))
                if (!Convert.IsDBNull(reader["ItemEnglishName"]))
                    styleDetailItem.ItemEnglishName = reader["ItemEnglishName"].ToString();

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    styleDetailItem.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("ColorArabicName"))
                if (!Convert.IsDBNull(reader["ColorArabicName"]))
                    styleDetailItem.ColorArabicName = reader["ColorArabicName"].ToString();

            if (fieldNames.Contains("ColorEnglishName"))
                if (!Convert.IsDBNull(reader["ColorEnglishName"]))
                    styleDetailItem.ColorEnglishName = reader["ColorEnglishName"].ToString();

            if (fieldNames.Contains("ColorId"))
                if (!Convert.IsDBNull(reader["ColorId"]))
                    styleDetailItem.ColorId = (int)reader["ColorId"];

            if (fieldNames.Contains("StyleId"))
                if (!Convert.IsDBNull(reader["StyleId"]))
                    styleDetailItem.StyleId = (int)reader["StyleId"];


            return styleDetailItem;
        }
    }
}