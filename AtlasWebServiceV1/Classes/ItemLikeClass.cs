using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ItemLikeClass
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
      public int Order { get; set; }
      [DataMember(Order = 12)]
      public int TotalLike { get; set; }

      [DataMember(Order = 13)]
      public bool HasOffer { get; set; }


      public ItemLikeClass PopulateItemLike(string[] fieldNames, SqlDataReader reader)
      {
         var itemLike = new ItemLikeClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               itemLike.Id = (int)reader["Id"];

         if (fieldNames.Contains("ItemId"))
            if (!Convert.IsDBNull(reader["ItemId"]))
               itemLike.ItemId = (int)reader["ItemId"];

         if (fieldNames.Contains("UserId"))
            if (!Convert.IsDBNull(reader["UserId"]))
               itemLike.UserId = (int)reader["UserId"];

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               itemLike.ArabicName = reader["ArabicName"].ToString();

         if (fieldNames.Contains("EnglishName"))
            if (!Convert.IsDBNull(reader["EnglishName"]))
               itemLike.EnglishName = reader["EnglishName"].ToString();

         if (fieldNames.Contains("Code"))
            if (!Convert.IsDBNull(reader["Code"]))
               itemLike.Code = reader["Code"].ToString();

         if (fieldNames.Contains("FullName"))
            if (!Convert.IsDBNull(reader["FullName"]))
               itemLike.FullName = reader["FullName"].ToString();

         if (fieldNames.Contains("CreateDate"))
            if (!Convert.IsDBNull(reader["CreateDate"]))
               itemLike.CreateDate = reader["CreateDate"].ToString();

         if (fieldNames.Contains("ImageURL"))
            if (!Convert.IsDBNull(reader["ImageURL"]))
               itemLike.ImageURL = reader["ImageURL"].ToString();

         if (fieldNames.Contains("TotalLike"))
            if (!Convert.IsDBNull(reader["TotalLike"]))
               itemLike.TotalLike = Convert.ToInt32(reader["TotalLike"]);

         if (fieldNames.Contains("HasOffer"))
            if (!Convert.IsDBNull(reader["HasOffer"]))
               itemLike.HasOffer = Convert.ToBoolean(reader["HasOffer"]);

         return itemLike;
      }

   }
}