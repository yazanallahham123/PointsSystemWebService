using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemDepartmentImageClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int ItemDepartmentId { get; set; }
        [DataMember(Order = 3)]
        public int ReferenceId { get; set; }
        [DataMember(Order = 3)]
        public int ReferenceTypeId { get; set; }
        [DataMember(Order = 4)]
        public string ImageURL { get; set; }
        [DataMember(Order = 4)]
        public string WebImageURL { get; set; }
        [DataMember(Order = 5)]
        public int Order { get; set; }
        [DataMember(Order = 3)]
        public string ReferenceName { get; set; }

        [DataMember(Order = 3)]
        public List<ItemDepartmentImageCountryClass> ItemDepartmentImageCountries { get; set; }



        public ItemDepartmentImageClass PopulateItemDepartmentImage(string[] fieldNames, SqlDataReader reader)
        {
            var itemDepartmentImage = new ItemDepartmentImageClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemDepartmentImage.Id = Convert.ToInt32(reader["Id"]);


            if (fieldNames.Contains("ItemDepartmentId"))
                if (!Convert.IsDBNull(reader["ItemDepartmentId"]))
                    itemDepartmentImage.ItemDepartmentId = Convert.ToInt32(reader["ItemDepartmentId"]);

            if (fieldNames.Contains("ReferenceId"))
                if (!Convert.IsDBNull(reader["ReferenceId"]))
                    itemDepartmentImage.ReferenceId = Convert.ToInt32(reader["ReferenceId"]);


            if (fieldNames.Contains("ReferenceTypeId"))
                if (!Convert.IsDBNull(reader["ReferenceTypeId"]))
                    itemDepartmentImage.ReferenceTypeId = Convert.ToInt32(reader["ReferenceTypeId"]);

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    itemDepartmentImage.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("WebImageURL"))
                if (!Convert.IsDBNull(reader["WebImageURL"]))
                    itemDepartmentImage.WebImageURL = reader["WebImageURL"].ToString();

            if (fieldNames.Contains("ReferenceName"))
                if (!Convert.IsDBNull(reader["ReferenceName"]))
                    itemDepartmentImage.ReferenceName = reader["ReferenceName"].ToString();

            return itemDepartmentImage;
        }
    }
}