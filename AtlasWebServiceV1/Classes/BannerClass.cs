using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class BannerClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string ArabicTitle { get; set; }
      [DataMember(Order = 3)]
      public string EnglishTitle { get; set; }
      [DataMember(Order = 4)]
      public string ImageURL { get; set; }
      [DataMember(Order = 5)]
      public string StartShowDate { get; set; }
      [DataMember(Order = 6)]
      public string EndShowDate { get; set; }
      [DataMember(Order = 7)]
      public bool HasEndDate { get; set; }
      [DataMember(Order = 8)]
      public bool Disabled { get; set; }
      [DataMember(Order = 9)]
      public int Type { get; set; }               //1: Item, 2:Brand, 3:Category, 4:(nothing) Only picture 
      [DataMember(Order = 10)]
      public int TypeId { get; set; }
      [DataMember(Order = 11)]
      public string ArabicName { get; set; }
      [DataMember(Order = 12)]
      public int Order { get; set; }

    [DataMember(Order = 13)]
    public bool IsVideo { get; set; }



        public BannerClass PopulateBanner(string[] fieldNames, SqlDataReader reader)
      {
         var banner = new BannerClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               banner.Id = (int)reader["Id"];

         if (fieldNames.Contains("ArabicTitle"))
            if (!Convert.IsDBNull(reader["ArabicTitle"]))
               banner.ArabicTitle = reader["ArabicTitle"].ToString();

         if (fieldNames.Contains("EnglishTitle"))
            if (!Convert.IsDBNull(reader["EnglishTitle"]))
               banner.EnglishTitle = reader["EnglishTitle"].ToString();

         if (fieldNames.Contains("ImageURL"))
            if (!Convert.IsDBNull(reader["ImageURL"]))
               banner.ImageURL = reader["ImageURL"].ToString();

         if (fieldNames.Contains("StartShowDate"))
            if (!Convert.IsDBNull(reader["StartShowDate"]))
               banner.StartShowDate = reader["StartShowDate"].ToString();

         if (fieldNames.Contains("EndShowDate"))
            if (!Convert.IsDBNull(reader["EndShowDate"]))
               banner.EndShowDate = reader["EndShowDate"].ToString();

         if (fieldNames.Contains("HasEndDate"))
            if (!Convert.IsDBNull(reader["HasEndDate"]))
               banner.HasEndDate = Convert.ToBoolean(reader["HasEndDate"]);

         if (fieldNames.Contains("Disabled"))
            if (!Convert.IsDBNull(reader["Disabled"]))
               banner.Disabled = Convert.ToBoolean(reader["Disabled"]);

         if (fieldNames.Contains("Type"))
            if (!Convert.IsDBNull(reader["Type"]))
               banner.Type = Convert.ToInt32(reader["Type"]);

         if (fieldNames.Contains("TypeId"))
            if (!Convert.IsDBNull(reader["TypeId"]))
               banner.TypeId = Convert.ToInt32(reader["TypeId"]);

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               banner.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("IsVideo"))
                if (!Convert.IsDBNull(reader["IsVideo"]))
                    banner.IsVideo = Convert.ToBoolean(reader["IsVideo"]);
            return banner;
      }
   }
}