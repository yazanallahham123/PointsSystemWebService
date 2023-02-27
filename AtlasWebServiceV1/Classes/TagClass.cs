using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class TagClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string ArabicName { get; set; }
        [DataMember(Order = 3)]
        public string EnglishName { get; set; }
        [DataMember(Order = 4)]
        public int TagTypeId { get; set; }
        [DataMember(Order = 5)]
        public int Order { get; set; }

        public TagClass PopulateTag(string[] fieldNames, SqlDataReader reader)
        {
            var tag = new TagClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    tag.Id = (int)reader["Id"];

            if (fieldNames.Contains("TagTypeId"))
                if (!Convert.IsDBNull(reader["TagTypeId"]))
                    tag.TagTypeId = (int)reader["TagTypeId"];

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    tag.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    tag.EnglishName = reader["EnglishName"].ToString();


            return tag;
        }

    }
}