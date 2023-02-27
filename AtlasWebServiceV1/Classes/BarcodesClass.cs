using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class BarcodesClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Barcode { get; set; }
        [DataMember(Order = 3)]
        public string ColorCode { get; set; }
        [DataMember(Order = 4)]
        public int ColorId { get; set; }
        [DataMember(Order = 5)]
        public string SizeCode { get; set; }
        [DataMember(Order = 6)]
        public int SizeId { get; set; }
        [DataMember(Order = 7)]
        public double Quantity { get; set; }
        [DataMember(Order = 8)]
        public int ItemId { get; set; }
        [DataMember(Order = 9)]
        public string Barcode2 { get; set; }
        [DataMember(Order = 10)]
        public string ServerId { get; set; }
        [DataMember(Order = 11)]
        public int Order { get; set; }
        [DataMember(Order = 12)]
        public string ItemCode { get; set; }



        public BarcodesClass PopulateBarcodes(string[] fieldNames, SqlDataReader reader)
        {
            var barcode = new BarcodesClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    barcode.Id = (int)reader["Id"];

            if (fieldNames.Contains("Barcode"))
                if (!Convert.IsDBNull(reader["Barcode"]))
                    barcode.Barcode = reader["Barcode"].ToString();

            if (fieldNames.Contains("ColorCode"))
                if (!Convert.IsDBNull(reader["ColorCode"]))
                    barcode.ColorCode = reader["ColorCode"].ToString();

            if (fieldNames.Contains("ColorId"))
                if (!Convert.IsDBNull(reader["ColorId"]))
                    barcode.ColorId = (int)reader["ColorId"];

            if (fieldNames.Contains("SizeCode"))
                if (!Convert.IsDBNull(reader["SizeCode"]))
                    barcode.SizeCode = reader["SizeCode"].ToString();

            if (fieldNames.Contains("SizeId"))
                if (!Convert.IsDBNull(reader["SizeId"]))
                    barcode.SizeId = (int)reader["SizeId"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    barcode.ItemId = (int)reader["ItemId"];



            if (fieldNames.Contains("Quantity"))
                if (!Convert.IsDBNull(reader["Quantity"]))
                    barcode.Quantity = (double)reader["Quantity"];



            if (fieldNames.Contains("Barcode2"))
                if (!Convert.IsDBNull(reader["Barcode2"]))
                    barcode.Barcode2 = reader["Barcode2"].ToString();

            if (fieldNames.Contains("ServerId"))
                if (!Convert.IsDBNull(reader["ServerId"]))
                    barcode.ServerId = reader["ServerId"].ToString();


            if (fieldNames.Contains("Code"))
                if (!Convert.IsDBNull(reader["Code"]))
                    barcode.ItemCode = reader["Code"].ToString();




            return barcode;
        }
        public BarcodesClass PopulateFailBarcodes(string[] fieldNames, SqlDataReader reader)
        {
            var barcode = new BarcodesClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    barcode.Id = (int)reader["Id"];

            if (fieldNames.Contains("Barcode"))
                if (!Convert.IsDBNull(reader["Barcode"]))
                    barcode.Barcode = reader["Barcode"].ToString();

            if (fieldNames.Contains("Color"))
                if (!Convert.IsDBNull(reader["Color"]))
                    barcode.ColorCode = reader["Color"].ToString();

            if (fieldNames.Contains("ColorId"))
                if (!Convert.IsDBNull(reader["ColorId"]))
                    barcode.ColorId = (int)reader["ColorId"];

            if (fieldNames.Contains("Size"))
                if (!Convert.IsDBNull(reader["Size"]))
                    barcode.SizeCode = reader["Size"].ToString();

            if (fieldNames.Contains("SizeId"))
                if (!Convert.IsDBNull(reader["SizeId"]))
                    barcode.SizeId = (int)reader["SizeId"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    barcode.ItemId = (int)reader["ItemId"];



            if (fieldNames.Contains("Quantity"))
                if (!Convert.IsDBNull(reader["Quantity"]))
                    barcode.Quantity = (double)reader["Quantity"];



            if (fieldNames.Contains("Barcode2"))
                if (!Convert.IsDBNull(reader["Barcode2"]))
                    barcode.Barcode2 = reader["Barcode2"].ToString();

            if (fieldNames.Contains("ServerId"))
                if (!Convert.IsDBNull(reader["ServerId"]))
                    barcode.ServerId = reader["ServerId"].ToString();


            if (fieldNames.Contains("Item"))
                if (!Convert.IsDBNull(reader["Item"]))
                    barcode.ItemCode = reader["Item"].ToString();




            return barcode;
        }

    }
}