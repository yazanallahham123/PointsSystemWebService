using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class StyleDetailClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int StyleId { get; set; }
        [DataMember(Order = 3)]
        public string ArabicDescription { get; set; }
        [DataMember(Order = 4)]
        public string EnglishDescription { get; set; }
        [DataMember(Order = 5)]
        public string StyleArabicName { get; set; }
        [DataMember(Order = 6)]
        public string StyleEnglishName { get; set; }
        [DataMember(Order = 7)]
        public int Order { get; set; }

        public StyleDetailClass PopulateStyleDetail(string[] fieldNames, SqlDataReader reader)
        {
            var styleDetail = new StyleDetailClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    styleDetail.Id = (int)reader["Id"];

            if (fieldNames.Contains("StyleId"))
                if (!Convert.IsDBNull(reader["StyleId"]))
                    styleDetail.StyleId = (int)reader["StyleId"];

            if (fieldNames.Contains("ArabicDescription"))
                if (!Convert.IsDBNull(reader["ArabicDescription"]))
                    styleDetail.ArabicDescription = reader["ArabicDescription"].ToString();

            if (fieldNames.Contains("EnglishDescription"))
                if (!Convert.IsDBNull(reader["EnglishDescription"]))
                    styleDetail.EnglishDescription = reader["EnglishDescription"].ToString();

            if (fieldNames.Contains("StyleArabicName"))
                if (!Convert.IsDBNull(reader["StyleArabicName"]))
                    styleDetail.StyleArabicName = reader["StyleArabicName"].ToString();

            if (fieldNames.Contains("StyleEnglishName"))
                if (!Convert.IsDBNull(reader["StyleEnglishName"]))
                    styleDetail.StyleEnglishName = reader["StyleEnglishName"].ToString();

            return styleDetail;
        }
    }
}