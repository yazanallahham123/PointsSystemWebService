using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class StyleTagClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int StyleId { get; set; }
        [DataMember(Order = 3)]
        public int TagId { get; set; }
        [DataMember(Order = 4)]
        public string TagArabicName{ get; set; }
        [DataMember(Order = 5)]
        public string TagEnglishName { get; set; }
        [DataMember(Order = 6)]
        public int Order { get; set; }
        public StyleTagClass PopulateTag(string[] fieldNames, SqlDataReader reader)
        {
            var styleTag = new StyleTagClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    styleTag.Id = (int)reader["Id"];

            if (fieldNames.Contains("StyleId"))
                if (!Convert.IsDBNull(reader["StyleId"]))
                    styleTag.StyleId = (int)reader["StyleId"];

            if (fieldNames.Contains("TagId"))
                if (!Convert.IsDBNull(reader["TagId"]))
                    styleTag.TagId = (int)reader["TagId"];


            if (fieldNames.Contains("TagArabicName"))
                if (!Convert.IsDBNull(reader["TagArabicName"]))
                    styleTag.TagArabicName = reader["TagArabicName"].ToString();

            if (fieldNames.Contains("TagEnglishName"))
                if (!Convert.IsDBNull(reader["TagEnglishName"]))
                    styleTag.TagEnglishName = reader["TagEnglishName"].ToString();

            return styleTag;
        }
    }
}