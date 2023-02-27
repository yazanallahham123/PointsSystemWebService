using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class StoryDetailClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int StoryId { get; set; }
        [DataMember(Order = 3)]
        public int VisitsCount { get; set; }
        [DataMember(Order = 4)]
        public string ImageURL { get; set; }
        [DataMember(Order = 5)]
        public int Order { get; set; }
        [DataMember(Order = 6)]
        public int TypeId { get; set; }
        [DataMember(Order = 7)]
        public int ReferenceId { get; set; }
        [DataMember(Order = 8)]
        public string ReferenceArabicName { get; set; }
        [DataMember(Order = 9)]
        public string ReferenceEnglishName { get; set; }
        [DataMember(Order = 10)] 
        public StyleClass Style { get; set; }

        public StoryDetailClass PopulateStoryDetail(string[] fieldNames, SqlDataReader reader)
        {
            var storyDetail = new StoryDetailClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    storyDetail.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("StoryId"))
                if (!Convert.IsDBNull(reader["StoryId"]))
                    storyDetail.StoryId = Convert.ToInt32(reader["StoryId"]);

            if (fieldNames.Contains("VisitsCount"))
                if (!Convert.IsDBNull(reader["VisitsCount"]))
                    storyDetail.VisitsCount = Convert.ToInt32(reader["VisitsCount"]);
            
            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    storyDetail.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("TypeId"))
                if (!Convert.IsDBNull(reader["TypeId"]))
                    storyDetail.TypeId = Convert.ToInt32(reader["TypeId"]);

            if (fieldNames.Contains("ReferenceId"))
                if (!Convert.IsDBNull(reader["ReferenceId"]))
                    storyDetail.ReferenceId = Convert.ToInt32(reader["ReferenceId"]);

            if (fieldNames.Contains("ReferenceArabicName"))
                if (!Convert.IsDBNull(reader["ReferenceArabicName"]))
                    storyDetail.ReferenceArabicName = reader["ReferenceArabicName"].ToString();

            if (fieldNames.Contains("ReferenceEnglishName"))
                if (!Convert.IsDBNull(reader["ReferenceEnglishName"]))
                    storyDetail.ReferenceEnglishName = reader["ReferenceEnglishName"].ToString();

            return storyDetail;
        }
    }
}