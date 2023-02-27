using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ItemWishlistClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int ItemId { get; set; }
      [DataMember(Order = 3)]
      public int UserId { get; set; }
      [DataMember(Order = 4)]
      public string CreateDate { get; set; }
      [DataMember(Order = 5)]
      public string Notes { get; set; }
      [DataMember(Order = 6)]
      public string ArabicName { get; set; }
      [DataMember(Order = 7)]
      public string EnglishName { get; set; }
      [DataMember(Order = 8)]
      public string Code { get; set; }
      [DataMember(Order = 9)]
      public string FullName { get; set; }
      [DataMember(Order = 10)]
      public string ImageURL { get; set; }
      [DataMember(Order = 11)]
      public double AvgRating { get; set; }
      [DataMember(Order = 12)]
      public bool HasOffer { get; set; }
      [DataMember(Order = 13)]
      public int Order { get; set; }


      public ItemWishlistClass PopulateItemWishlist(string[] fieldNames, SqlDataReader reader)
      {
         var itemWishlist = new ItemWishlistClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               itemWishlist.Id = (int)reader["Id"];

         if (fieldNames.Contains("ItemId"))
            if (!Convert.IsDBNull(reader["ItemId"]))
               itemWishlist.ItemId = (int)reader["ItemId"];

         if (fieldNames.Contains("UserId"))
            if (!Convert.IsDBNull(reader["UserId"]))
               itemWishlist.UserId = (int)reader["UserId"];

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               itemWishlist.ArabicName = reader["ArabicName"].ToString();

         if (fieldNames.Contains("EnglishName"))
            if (!Convert.IsDBNull(reader["EnglishName"]))
               itemWishlist.EnglishName = reader["EnglishName"].ToString();

         if (fieldNames.Contains("Code"))
            if (!Convert.IsDBNull(reader["Code"]))
               itemWishlist.Code = reader["Code"].ToString();

         if (fieldNames.Contains("FullName"))
            if (!Convert.IsDBNull(reader["FullName"]))
               itemWishlist.FullName = reader["FullName"].ToString();

         if (fieldNames.Contains("ImageURL"))
            if (!Convert.IsDBNull(reader["ImageURL"]))
               itemWishlist.ImageURL = reader["ImageURL"].ToString();

         if (fieldNames.Contains("CreateDate"))
            if (!Convert.IsDBNull(reader["CreateDate"]))
               itemWishlist.CreateDate = reader["CreateDate"].ToString();

         if (fieldNames.Contains("AvgRating"))
            if (!Convert.IsDBNull(reader["AvgRating"]))
               itemWishlist.AvgRating = Convert.ToDouble(reader["AvgRating"]);

         if (fieldNames.Contains("HasOffer"))
            if (!Convert.IsDBNull(reader["HasOffer"]))
               itemWishlist.HasOffer = Convert.ToBoolean(reader["HasOffer"]);

         return itemWishlist;
      }

   }
}