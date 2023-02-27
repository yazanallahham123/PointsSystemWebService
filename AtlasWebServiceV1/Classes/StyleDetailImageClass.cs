using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class StyleDetailImageClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int StyleDetailId { get; set; }
        [DataMember(Order = 3)]
        public string ImageURL { get; set; }
        [DataMember(Order = 4)]
        public string WebImageURL { get; set; }
        [DataMember(Order = 5)]
        public int Order{ get; set; }
        [DataMember(Order = 6)]
        public int StyleId { get; set; }

        public StyleDetailImageClass PopulateStyleDetailImage(string[] fieldNames, SqlDataReader reader)
        {
            var styleDetailImage = new StyleDetailImageClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    styleDetailImage.Id = (int)reader["Id"];

            if (fieldNames.Contains("StyleDetailId"))
                if (!Convert.IsDBNull(reader["StyleDetailId"]))
                    styleDetailImage.StyleDetailId = (int)reader["StyleDetailId"];

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    styleDetailImage.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("WebImageURL"))
                if (!Convert.IsDBNull(reader["WebImageURL"]))
                    styleDetailImage.WebImageURL = reader["WebImageURL"].ToString();

            if (fieldNames.Contains("StyleId"))
                if (!Convert.IsDBNull(reader["StyleId"]))
                    styleDetailImage.StyleId = (int)reader["StyleId"];

            return styleDetailImage;
        }
    }
}