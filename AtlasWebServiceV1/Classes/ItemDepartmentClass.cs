using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemDepartmentClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int ItemDepartmentId { get; set; }
        [DataMember(Order = 3)]
        public string ArabicName { get; set; }
        [DataMember(Order = 4)]
        public string EnglishName { get; set; }
        [DataMember(Order = 5)]
        public string ImageURL { get; set; }
        [DataMember(Order = 6)]
        public string WebImageURL { get; set; }
        [DataMember(Order = 7)]
        public int Order { get; set; }
        public ItemDepartmentClass PopulateItemDepartment(string[] fieldNames, SqlDataReader reader)
        {
            var itemDepartment = new ItemDepartmentClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemDepartment.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("ItemDepartmentId"))
                if (!Convert.IsDBNull(reader["ItemDepartmentId"]))
                    itemDepartment.ItemDepartmentId = Convert.ToInt32(reader["ItemDepartmentId"]);

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    itemDepartment.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    itemDepartment.EnglishName = reader["EnglishName"].ToString();

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    itemDepartment.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("WebImageURL"))
                if (!Convert.IsDBNull(reader["WebImageURL"]))
                    itemDepartment.WebImageURL = reader["WebImageURL"].ToString();

            return itemDepartment;
        }
    }
}