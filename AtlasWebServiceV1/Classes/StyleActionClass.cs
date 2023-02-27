using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class StyleActionClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int StyleId { get; set; }
        [DataMember(Order = 3)]
        public int TagId { get; set; }
        [DataMember(Order = 4)]
        public string TagArabicName { get; set; }
        [DataMember(Order = 5)]
        public string TagEnglishName { get; set; }
        [DataMember(Order = 6)]
        public int Order { get; set; }
        [DataMember(Order = 6)]
        public string ImageURL { get; set; }
        [DataMember(Order = 6)]
        public string WebImageURL { get; set; }
        [DataMember(Order = 6)]
        public string ArabicName { get; set; }
        [DataMember(Order = 6)]
        public string EnglishName { get; set; }

        public StyleActionClass PopulateStyleAction(string[] fieldNames, SqlDataReader reader)
        {
            var styleAction = new StyleActionClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    styleAction.Id = (int)reader["Id"];

            if (fieldNames.Contains("StyleId"))
                if (!Convert.IsDBNull(reader["StyleId"]))
                    styleAction.StyleId = (int)reader["StyleId"];

            if (fieldNames.Contains("TagId"))
                if (!Convert.IsDBNull(reader["TagId"]))
                    styleAction.TagId = (int)reader["TagId"];

            if (fieldNames.Contains("TagArabicName"))
                if (!Convert.IsDBNull(reader["TagArabicName"]))
                    styleAction.TagArabicName = reader["TagArabicName"].ToString();

            if (fieldNames.Contains("TagEnglishName"))
                if (!Convert.IsDBNull(reader["TagEnglishName"]))
                    styleAction.TagEnglishName = reader["TagEnglishName"].ToString();

            if (fieldNames.Contains("Order"))
                if (!Convert.IsDBNull(reader["Order"]))
                    styleAction.Order = (int)reader["Order"];

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    styleAction.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("WebImageURL"))
                if (!Convert.IsDBNull(reader["WebImageURL"]))
                    styleAction.WebImageURL = reader["WebImageURL"].ToString();

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    styleAction.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    styleAction.EnglishName = reader["EnglishName"].ToString();

            return styleAction;

        }
    }
}