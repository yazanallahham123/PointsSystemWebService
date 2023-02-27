

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class CategoryClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string ArabicName { get; set; }
        [DataMember(Order = 3)]
        public string EnglishName { get; set; }
        [DataMember(Order = 4)]
        public string Code { get; set; }
        [DataMember(Order = 5)]
        public int Type { get; set; }
        [DataMember(Order = 6)]
        public string ArabicDescription { get; set; }
        [DataMember(Order = 7)]
        public string EnglishDescription { get; set; }
        [DataMember(Order = 8)]
        public int ParentId { get; set; }
        [DataMember(Order = 9)]
        public bool Disabled { get; set; }
        [DataMember(Order = 10)]
        public string Notes { get; set; }
        [DataMember(Order = 11)]
        public string ImageURL { get; set; }
        [DataMember(Order = 12)]
        public string TypeArabicName { get; set; }
        [DataMember(Order = 13)]
        public string TypeEnglishName { get; set; }
        [DataMember(Order = 14)]
        public string ParentArabicName { get; set; }
        [DataMember(Order = 15)]
        public string ParentEnglishName { get; set; }
        [DataMember(Order = 16)]
        public int SonsCount { get; set; }
        [DataMember(Order = 17)]
        public int TotalCount { get; set; }
        [DataMember(Order = 18)]
        public bool ShowName { get; set; }
        [DataMember(Order = 19)]
        public int Order { get; set; }

        public CategoryClass PopulateCategory(string[] fieldNames, SqlDataReader reader)
        {
            var category = new CategoryClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    category.Id = (int)reader["Id"];

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    category.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    category.EnglishName = reader["EnglishName"].ToString();

            if (fieldNames.Contains("Code"))
                if (!Convert.IsDBNull(reader["Code"]))
                    category.Code = reader["Code"].ToString();

            if (fieldNames.Contains("Type"))
                if (!Convert.IsDBNull(reader["Type"]))
                    category.Type = Convert.ToInt32(reader["Type"]);

            if (fieldNames.Contains("ArabicDescription"))
                if (!Convert.IsDBNull(reader["ArabicDescription"]))
                    category.ArabicDescription = reader["ArabicDescription"].ToString();

            if (fieldNames.Contains("EnglishDescription"))
                if (!Convert.IsDBNull(reader["EnglishDescription"]))
                    category.EnglishDescription = reader["EnglishDescription"].ToString();

            if (fieldNames.Contains("ParentId"))
                if (!Convert.IsDBNull(reader["ParentId"]))
                    category.ParentId = Convert.ToInt32(reader["ParentId"]);

            if (fieldNames.Contains("Disabled"))
                if (!Convert.IsDBNull(reader["Disabled"]))
                    category.Disabled = Convert.ToBoolean(reader["Disabled"]);

            if (fieldNames.Contains("Notes"))
                if (!Convert.IsDBNull(reader["Notes"]))
                    category.Notes = reader["Notes"].ToString();

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    category.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("TypeArabicName"))
                if (!Convert.IsDBNull(reader["TypeArabicName"]))
                    category.TypeArabicName = reader["TypeArabicName"].ToString();

            if (fieldNames.Contains("TypeEnglishName"))
                if (!Convert.IsDBNull(reader["TypeEnglishName"]))
                    category.TypeEnglishName = reader["TypeEnglishName"].ToString();

            if (fieldNames.Contains("ParentArabicName"))
                if (!Convert.IsDBNull(reader["ParentArabicName"]))
                    category.ParentArabicName = reader["ParentArabicName"].ToString();

            if (fieldNames.Contains("ParentEnglishName"))
                if (!Convert.IsDBNull(reader["ParentEnglishName"]))
                    category.ParentEnglishName = reader["ParentEnglishName"].ToString();

            if (fieldNames.Contains("SonsCount"))
                if (!Convert.IsDBNull(reader["SonsCount"]))
                    category.SonsCount = Convert.ToInt32(reader["SonsCount"]);

            if (fieldNames.Contains("TotalCount"))
                if (!Convert.IsDBNull(reader["TotalCount"]))
                    category.TotalCount = Convert.ToInt32(reader["TotalCount"]);

            if (fieldNames.Contains("ShowName"))
                if (!Convert.IsDBNull(reader["ShowName"]))
                    category.ShowName = (bool)reader["ShowName"];

            return category;
        }
    }
}