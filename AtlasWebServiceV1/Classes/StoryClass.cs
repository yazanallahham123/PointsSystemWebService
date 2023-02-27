using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class StoryClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int TypeId { get; set; }
        [DataMember(Order = 3)]
        public int ReferenceId { get; set; }
        [DataMember(Order = 4)]
        public string ArabicTitle { get; set; }
        [DataMember(Order = 5)]
        public string EnglishTitle { get; set; }
        [DataMember(Order = 6)]
        public string ImageURL { get; set; }
        [DataMember(Order = 7)]
        public string StartDate { get; set; }
        [DataMember(Order = 8)]
        public string EndDate { get; set; }
        [DataMember(Order = 9)]
        public int VisitsCount { get; set; }
        [DataMember(Order = 10)]
        public string ReferenceArabicName { get; set; }
        [DataMember(Order = 11)]
        public string ReferenceEnglishName { get; set; }
        [DataMember(Order = 12)]
        public int Order { get; set; }

        public StoryClass PopulateStory(string[] fieldNames, SqlDataReader reader)
        {
            var story = new StoryClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    story.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("TypeId"))
                if (!Convert.IsDBNull(reader["TypeId"]))
                    story.TypeId = Convert.ToInt32(reader["TypeId"]);

            if (fieldNames.Contains("ReferenceId"))
                if (!Convert.IsDBNull(reader["ReferenceId"]))
                    story.ReferenceId = Convert.ToInt32(reader["ReferenceId"]);

            if (fieldNames.Contains("ArabicTitle"))
                if (!Convert.IsDBNull(reader["ArabicTitle"]))
                    story.ArabicTitle = reader["ArabicTitle"].ToString();

            if (fieldNames.Contains("EnglishTitle"))
                if (!Convert.IsDBNull(reader["EnglishTitle"]))
                    story.EnglishTitle = reader["EnglishTitle"].ToString();

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    story.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("StartDate"))
                if (!Convert.IsDBNull(reader["StartDate"]))
                    story.StartDate = reader["StartDate"].ToString();

            if (fieldNames.Contains("EndDate"))
                if (!Convert.IsDBNull(reader["EndDate"]))
                    story.EndDate = reader["EndDate"].ToString();

            if (fieldNames.Contains("VisitsCount"))
                if (!Convert.IsDBNull(reader["VisitsCount"]))
                    story.VisitsCount = Convert.ToInt32(reader["VisitsCount"]);

            if (fieldNames.Contains("ReferenceArabicName"))
                if (!Convert.IsDBNull(reader["ReferenceArabicName"]))
                    story.ReferenceArabicName = reader["ReferenceArabicName"].ToString();

            if (fieldNames.Contains("ReferenceEnglishName"))
                if (!Convert.IsDBNull(reader["ReferenceEnglishName"]))
                    story.ReferenceEnglishName = reader["ReferenceEnglishName"].ToString();

            if (fieldNames.Contains("Order"))
                if (!Convert.IsDBNull(reader["Order"]))
                    story.Order = Convert.ToInt32(reader["Order"]);

            return story;
        }
    }
}