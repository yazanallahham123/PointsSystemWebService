using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class ItemSeriesClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public int ItemId { get; set; }

        [DataMember(Order = 3)]
        public string ItemCode { get; set; }

        [DataMember(Order = 4)]
        public string ItemArabicName { get; set; }

        [DataMember(Order = 5)]
        public string ItemEnglishName { get; set; }

        [DataMember(Order = 6)]
        public int ItemColorId { get; set; }

        [DataMember(Order = 7)]
        public string ColorCode { get; set; }

        [DataMember(Order = 8)]
        public string ColorArabicName { get; set; }

        [DataMember(Order = 9)]
        public string ColorEnglishName { get; set; }

        [DataMember(Order = 10)]
        public int ItemSizeId { get; set; }

        [DataMember(Order = 11)]
        public string SizeCode { get; set; }

        [DataMember(Order = 12)]
        public string SizeArabicName { get; set; }

        [DataMember(Order = 13)]
        public string SizeEnglishName { get; set; }

        [DataMember(Order = 14)]
        public int Quantity { get; set; }

        [DataMember(Order = 15)]
        public int Order { get; set; }

        [DataMember(Order = 16)]
        public int ColorId { get; set; }

        [DataMember(Order = 17)]
        public int SizeId { get; set; }
        [DataMember(Order = 18)]
        public string ColorImageURL { get; set; }
        [DataMember(Order = 19)]
        public string ColorHexValue { get; set; }
        [DataMember(Order = 20)]
        public int OrderDetailId { get; set; }

        public ItemSeriesClass PopulateItemSeries(string[] fieldNames, SqlDataReader reader)
        {
            var itemSeries = new ItemSeriesClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemSeries.Id = (int)reader["Id"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    itemSeries.ItemId = (int)reader["ItemId"];

            if (fieldNames.Contains("ItemCode"))
                if (!Convert.IsDBNull(reader["ItemCode"]))
                    itemSeries.ItemCode = reader["ItemCode"].ToString();

            if (fieldNames.Contains("ItemArabicName"))
                if (!Convert.IsDBNull(reader["ItemArabicName"]))
                    itemSeries.ItemArabicName = reader["ItemArabicName"].ToString();

            if (fieldNames.Contains("ItemEnglishName"))
                if (!Convert.IsDBNull(reader["ItemEnglishName"]))
                    itemSeries.ItemEnglishName = reader["ItemEnglishName"].ToString();

            if (fieldNames.Contains("ColorId"))
                if (!Convert.IsDBNull(reader["ColorId"]))
                    itemSeries.ColorId = (int)reader["ColorId"];

            if (fieldNames.Contains("ItemColorId"))
                if (!Convert.IsDBNull(reader["ItemColorId"]))
                    itemSeries.ItemColorId = (int)reader["ItemColorId"];

            if (fieldNames.Contains("ColorCode"))
                if (!Convert.IsDBNull(reader["ColorCode"]))
                    itemSeries.ColorCode = reader["ColorCode"].ToString();

            if (fieldNames.Contains("ColorArabicName"))
                if (!Convert.IsDBNull(reader["ColorArabicName"]))
                    itemSeries.ColorArabicName = reader["ColorArabicName"].ToString();

            if (fieldNames.Contains("ColorEnglishName"))
                if (!Convert.IsDBNull(reader["ColorEnglishName"]))
                    itemSeries.ColorEnglishName = reader["ColorEnglishName"].ToString();

            if (fieldNames.Contains("SizeId"))
                if (!Convert.IsDBNull(reader["SizeId"]))
                    itemSeries.SizeId = (int)reader["SizeId"];

            if (fieldNames.Contains("ItemSizeId"))
                if (!Convert.IsDBNull(reader["ItemSizeId"]))
                    itemSeries.ItemSizeId = (int)reader["ItemSizeId"];

            if (fieldNames.Contains("SizeCode"))
                if (!Convert.IsDBNull(reader["SizeCode"]))
                    itemSeries.SizeCode = reader["SizeCode"].ToString();

            if (fieldNames.Contains("SizeArabicName"))
                if (!Convert.IsDBNull(reader["SizeArabicName"]))
                    itemSeries.SizeArabicName = reader["SizeArabicName"].ToString();

            if (fieldNames.Contains("SizeEnglishName"))
                if (!Convert.IsDBNull(reader["SizeEnglishName"]))
                    itemSeries.SizeEnglishName = reader["SizeEnglishName"].ToString();

            if (fieldNames.Contains("Quantity"))
                if (!Convert.IsDBNull(reader["Quantity"]))
                    itemSeries.Quantity = (int)reader["Quantity"];

            if (fieldNames.Contains("ColorImageURL"))
                if (!Convert.IsDBNull(reader["ColorImageURL"]))
                    itemSeries.ColorImageURL = reader["ColorImageURL"].ToString();

            if (fieldNames.Contains("HexValue"))
                if (!Convert.IsDBNull(reader["HexValue"]))
                    itemSeries.ColorHexValue = reader["HexValue"].ToString();

            if (fieldNames.Contains("OrderDetailId"))
                if (!Convert.IsDBNull(reader["OrderDetailId"]))
                    itemSeries.OrderDetailId = (int)reader["OrderDetailId"];

            return itemSeries;
        }

    }
}