using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class ItemSerialClass
    {

        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public int ItemId { get; set; }

        [DataMember(Order = 3)]
        public string Serial { get; set; }

        [DataMember(Order = 4)]
        public bool IsScanned { get; set; }

        [DataMember(Order = 5)]
        public int ScannerUserId { get; set; }

        [DataMember(Order = 6)]
        public string ScanningDate { get; set; }

        [DataMember(Order = 7)]
        public int ScanningPoints { get; set; }

        [DataMember(Order = 8)]
        public bool Disabled { get; set; }

        [DataMember(Order = 9)]
        public string Notes { get; set; }

        [DataMember(Order = 10)]
        public bool IsChecked { get; set; }

        [DataMember(Order = 11)]
        public string CheckDate { get; set; }

        [DataMember(Order = 12)]
        public int CheckerUserId { get; set; }

        [DataMember(Order = 13)]
        public int CreatedBy { get; set; }

        [DataMember(Order = 14)]
        public string CreateDate { get; set; }

        [DataMember(Order = 15)]
        public string ArabicName { get; set; }

        [DataMember(Order = 16)]
        public string EnglishName { get; set; }

        [DataMember(Order = 17)]
        public string ScannerFullName { get; set; }

        [DataMember(Order = 18)]
        public string CheckerFullName { get; set; }

        [DataMember(Order = 19)]
        public string CreatedByFullName { get; set; }

        [DataMember(Order = 20)]
        public int Order { get; set; }

        [DataMember(Order = 21)]
        public int GiftedPoints { get; set; }
        [DataMember(Order = 21)]
        public string Code { get; set; }
        [DataMember(Order = 21)]
        public int OrderId { get; set; }
        [DataMember(Order = 21)]
        public string OrderUserFullName { get; set; }
        [DataMember(Order = 21)]
        public string OrderDate { get; set; }
        public ItemSerialClass PopulateItemSerial(string[] fieldNames, SqlDataReader reader)
        {
            var itemSerial = new ItemSerialClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemSerial.Id = (int)reader["Id"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    itemSerial.ItemId = (int)reader["ItemId"];

            if (fieldNames.Contains("Serial"))
                if (!Convert.IsDBNull(reader["Serial"]))
                    itemSerial.Serial = reader["Serial"].ToString();

            if (fieldNames.Contains("IsScanned"))
                if (!Convert.IsDBNull(reader["IsScanned"]))
                    itemSerial.IsScanned = Convert.ToBoolean(reader["IsScanned"]);

            if (fieldNames.Contains("ScannerUserId"))
                if (!Convert.IsDBNull(reader["ScannerUserId"]))
                    itemSerial.ScannerUserId = (int)reader["ScannerUserId"];

            if (fieldNames.Contains("ScanningDate"))
                if (!Convert.IsDBNull(reader["ScanningDate"]))
                    itemSerial.ScanningDate = reader["ScanningDate"].ToString();

            if (fieldNames.Contains("ScanningPoints"))
                if (!Convert.IsDBNull(reader["ScanningPoints"]))
                    itemSerial.ScanningPoints = (int)reader["ScanningPoints"];

            if (fieldNames.Contains("Disabled"))
                if (!Convert.IsDBNull(reader["Disabled"]))
                    itemSerial.Disabled = Convert.ToBoolean(reader["Disabled"]);

            if (fieldNames.Contains("Notes"))
                if (!Convert.IsDBNull(reader["Notes"]))
                    itemSerial.Notes = reader["Notes"].ToString();

            if (fieldNames.Contains("IsChecked"))
                if (!Convert.IsDBNull(reader["IsChecked"]))
                    itemSerial.IsChecked = Convert.ToBoolean(reader["IsChecked"]);

            if (fieldNames.Contains("CheckDate"))
                if (!Convert.IsDBNull(reader["CheckDate"]))
                    itemSerial.CheckDate = reader["CheckDate"].ToString();

            if (fieldNames.Contains("CheckerUserId"))
                if (!Convert.IsDBNull(reader["CheckerUserId"]))
                    itemSerial.CheckerUserId = (int)reader["CheckerUserId"];


            if (fieldNames.Contains("CreatedBy"))
                if (!Convert.IsDBNull(reader["CreatedBy"]))
                    itemSerial.CreatedBy = (int)reader["CreatedBy"];

            if (fieldNames.Contains("CreateDate"))
                if (!Convert.IsDBNull(reader["CreateDate"]))
                    itemSerial.CreateDate = reader["CreateDate"].ToString();

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    itemSerial.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    itemSerial.EnglishName = reader["EnglishName"].ToString();

            if (fieldNames.Contains("ScannerFullName"))
                if (!Convert.IsDBNull(reader["ScannerFullName"]))
                    itemSerial.ScannerFullName = reader["ScannerFullName"].ToString();

            if (fieldNames.Contains("CheckerFullName"))
                if (!Convert.IsDBNull(reader["CheckerFullName"]))
                    itemSerial.CheckerFullName = reader["CheckerFullName"].ToString();

            if (fieldNames.Contains("CreatedByFullName"))
                if (!Convert.IsDBNull(reader["CreatedByFullName"]))
                    itemSerial.CreatedByFullName = reader["CreatedByFullName"].ToString();

            if (fieldNames.Contains("GiftedPoints"))
                if (!Convert.IsDBNull(reader["GiftedPoints"]))
                    itemSerial.GiftedPoints = (int)reader["GiftedPoints"];

            if (fieldNames.Contains("Code"))
                if (!Convert.IsDBNull(reader["Code"]))
                    itemSerial.Code = reader["Code"].ToString();

            if (fieldNames.Contains("OrderId"))
                if (!Convert.IsDBNull(reader["OrderId"]))
                    itemSerial.OrderId = (int)reader["OrderId"];

            if (fieldNames.Contains("OrderUserFullName"))
                if (!Convert.IsDBNull(reader["OrderUserFullName"]))
                    itemSerial.OrderUserFullName = reader["OrderUserFullName"].ToString();

            if (fieldNames.Contains("OrderDate"))
                if (!Convert.IsDBNull(reader["OrderDate"]))
                    itemSerial.OrderDate = reader["OrderDate"].ToString();


            return itemSerial;
        }
    }
}