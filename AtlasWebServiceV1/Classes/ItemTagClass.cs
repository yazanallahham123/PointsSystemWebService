using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemTagClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int ItemId { get; set; }
        [DataMember(Order = 3)]
        public int TagId { get; set; }
        [DataMember(Order = 4)]
        public string TagArabicName { get; set; }
        [DataMember(Order = 5)]
        public string TagEnglishName { get; set; }

        [DataMember(Order = 6)]
        public int Order { get; set; }

        public ItemTagClass PopulateItemTag(string[] fieldNames, SqlDataReader reader)
        {
            var ItemTag = new ItemTagClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    ItemTag.Id = (int)reader["Id"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    ItemTag.ItemId = (int)reader["ItemId"];

            if (fieldNames.Contains("TagId"))
                if (!Convert.IsDBNull(reader["TagId"]))
                    ItemTag.TagId = (int)reader["TagId"];


            if (fieldNames.Contains("TagArabicName"))
                if (!Convert.IsDBNull(reader["TagArabicName"]))
                    ItemTag.TagArabicName = reader["TagArabicName"].ToString();

            if (fieldNames.Contains("TagEnglishName"))
                if (!Convert.IsDBNull(reader["TagEnglishName"]))
                    ItemTag.TagEnglishName = reader["TagEnglishName"].ToString();

            return ItemTag;
        }
    }
}