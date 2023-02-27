using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class StyleClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string ArabicName { get; set; }
        [DataMember(Order = 3)]
        public string EnglishName { get; set; }
        [DataMember(Order = 4)]
        public string ImageURL { get; set; }
        [DataMember(Order = 5)]
        public bool Disabled { get; set; }
        [DataMember(Order = 6)]
        public int StyleTypeId { get; set; }
        [DataMember(Order = 7)]
        public string StyleTypeName { get; set; }
        [DataMember(Order = 8)]
        public int Order { get; set; }
        [DataMember(Order = 9)]
        public int DepartmentId { get; set; }
        [DataMember(Order = 10)]
        public string DepartmentArabicName { get; set; }
        [DataMember(Order = 11)]
        public string DepartmentEnglishName { get; set; }
        [DataMember(Order = 12)]
        public string WebImageURL { get; set; }
        [DataMember(Order = 13)]
        public bool ShowItems { get; set; }

        [DataMember(Order = 14)]
        public int StoryDetailId { get; set; }
        public StyleClass PopulateStyle(string[] fieldNames, SqlDataReader reader)
        {
            var style = new StyleClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    style.Id = (int)reader["Id"];

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    style.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    style.EnglishName = reader["EnglishName"].ToString();

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    style.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("Disabled"))
                if (!Convert.IsDBNull(reader["Disabled"]))
                    style.Disabled = Convert.ToBoolean(reader["Disabled"]);

            if (fieldNames.Contains("StyleTypeId"))
                if (!Convert.IsDBNull(reader["StyleTypeId"]))
                    style.StyleTypeId = (int)reader["StyleTypeId"];

            if (fieldNames.Contains("StyleTypeName"))
                if (!Convert.IsDBNull(reader["StyleTypeName"]))
                    style.StyleTypeName = reader["StyleTypeName"].ToString();

            if (fieldNames.Contains("DepartmentId"))
                if (!Convert.IsDBNull(reader["DepartmentId"]))
                    style.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);

            if (fieldNames.Contains("DepartmentArabicName"))
                if (!Convert.IsDBNull(reader["DepartmentArabicName"]))
                    style.DepartmentArabicName = reader["DepartmentArabicName"].ToString();

            if (fieldNames.Contains("DepartmentEnglishName"))
                if (!Convert.IsDBNull(reader["DepartmentEnglishName"]))
                    style.DepartmentEnglishName = reader["DepartmentEnglishName"].ToString();

            if (fieldNames.Contains("WebImageURL"))
                if (!Convert.IsDBNull(reader["WebImageURL"]))
                    style.WebImageURL = reader["WebImageURL"].ToString();

            if (fieldNames.Contains("ShowItems"))
                if (!Convert.IsDBNull(reader["ShowItems"]))
                    style.ShowItems = Convert.ToBoolean(reader["ShowItems"]);

            if (fieldNames.Contains("StoryDetailId"))
                if (!Convert.IsDBNull(reader["StoryDetailId"]))
                    style.StoryDetailId = Convert.ToInt32(reader["StoryDetailId"]);

            return style;
        }

    }
}