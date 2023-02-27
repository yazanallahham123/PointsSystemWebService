using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class TagTypeClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string ArabicName { get; set; }
        [DataMember(Order = 3)]
        public string EnglishName { get; set; }
        [DataMember(Order = 4)]
        public int Order { get; set; }

        public TagTypeClass PopulateTagType(string[] fieldNames, SqlDataReader reader)
        {
            var tagType = new TagTypeClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    tagType.Id = (int)reader["Id"];

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    tagType.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    tagType.EnglishName = reader["EnglishName"].ToString();


            return tagType;
        }

    }
}