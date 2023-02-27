using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ItemImageClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int ItemId { get; set; }
      [DataMember(Order = 3)]
      public string ImageUrl { get; set; }
      [DataMember(Order = 4)]
      public int Order { get; set; }
        [DataMember(Order = 5)]
        public bool ShowInItemCarousel { get; set; }
        [DataMember(Order = 6)]
        public bool ShowInItemGallery { get; set; }
        [DataMember(Order = 7)]
        public int ColorId { get; set; }
        [DataMember(Order = 8)]
        public string ColorArabicName { get; set; }
        [DataMember(Order = 9)]
        public string ColorEnglishName { get; set; }


        public ItemImageClass PopulateItemImage(string[] fieldNames, SqlDataReader reader)
      {
         var itemImage = new ItemImageClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               itemImage.Id = (int)reader["Id"];

         if (fieldNames.Contains("ItemId"))
            if (!Convert.IsDBNull(reader["ItemId"]))
               itemImage.ItemId = Convert.ToInt32(reader["ItemId"]);

         if (fieldNames.Contains("ImageUrl"))
            if (!Convert.IsDBNull(reader["ImageUrl"]))
               itemImage.ImageUrl = reader["ImageUrl"].ToString();

            if (fieldNames.Contains("ShowInItemCarousel"))
                if (!Convert.IsDBNull(reader["ShowInItemCarousel"]))
                    itemImage.ShowInItemCarousel = Convert.ToBoolean(reader["ShowInItemCarousel"]);

            if (fieldNames.Contains("ShowInItemGallery"))
                if (!Convert.IsDBNull(reader["ShowInItemGallery"]))
                    itemImage.ShowInItemGallery = Convert.ToBoolean(reader["ShowInItemGallery"]);

            if (fieldNames.Contains("ColorId"))
                if (!Convert.IsDBNull(reader["ColorId"]))
                    itemImage.ColorId = (int)reader["ColorId"];

            if (fieldNames.Contains("ColorArabicName"))
                if (!Convert.IsDBNull(reader["ColorArabicName"]))
                    itemImage.ColorArabicName = reader["ColorArabicName"].ToString();

            if (fieldNames.Contains("ColorEnglishName"))
                if (!Convert.IsDBNull(reader["ColorEnglishName"]))
                    itemImage.ColorEnglishName = reader["ColorEnglishName"].ToString();

            return itemImage;
      }
   }
}