using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ItemRatingClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int UserId { get; set; }
      [DataMember(Order = 3)]
      public int ItemId { get; set; }
      [DataMember(Order = 4)]
      public double Rating { get; set; }
      [DataMember(Order = 5)]
      public int Order { get; set; }


      public ItemRatingClass PopulateItemClass(string[] fieldNames, SqlDataReader reader)
      {
         var item = new ItemRatingClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               item.Id = (int)reader["Id"];

         if (fieldNames.Contains("UserId"))
            if (!Convert.IsDBNull(reader["UserId"]))
               item.UserId = (int)reader["UserId"];

         if (fieldNames.Contains("ItemId"))
            if (!Convert.IsDBNull(reader["ItemId"]))
               item.ItemId = (int)reader["ItemId"];

         if (fieldNames.Contains("AvgRating"))
            if (!Convert.IsDBNull(reader["AvgRating"]))
               item.Rating = Convert.ToDouble(reader["AvgRating"]);

         return item;
      }
   }
}