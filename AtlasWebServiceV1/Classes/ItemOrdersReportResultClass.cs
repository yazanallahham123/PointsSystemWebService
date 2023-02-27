using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ItemOrdersReportResultClass
   {
      [DataMember(Order = 1)]
      public List<ItemOrdersClass> ItemOrders { get; set; }
      [DataMember(Order = 2)]
      public ItemOrdersSummery Summery { get; set; }
   }

   public class ItemOrdersClass
   {
      [DataMember(Order = 1)]
      public OrderClass OrderClass { get; set; }
      [DataMember(Order = 2)]
      public OrderDetailClass OrderDetail { get; set; }
      [DataMember(Order = 3)]
      public int Order { get; set; }
   }

   public class ItemOrdersSummery
   {
      [DataMember(Order = 1)]
      public double TotalQTY { get; set; }
      [DataMember(Order = 2)]
      public int LinesNo { get; set; }
      [DataMember(Order = 3)]
      public double TotalPoints { get; set; }

      public ItemOrdersSummery PopulateItemOrdersSummery(string[] fieldNames, SqlDataReader reader)
      {
         var itemOrdersSummery = new ItemOrdersSummery();

         if (fieldNames.Contains("TotalQTY"))
            if (!Convert.IsDBNull(reader["TotalQTY"]))
               itemOrdersSummery.TotalQTY = (double)reader["TotalQTY"];

         if (fieldNames.Contains("LinesNo"))
            if (!Convert.IsDBNull(reader["LinesNo"]))
               itemOrdersSummery.LinesNo = (int)reader["LinesNo"];

         if (fieldNames.Contains("TotalPoints"))
            if (!Convert.IsDBNull(reader["TotalPoints"]))
               itemOrdersSummery.TotalPoints = (double)reader["TotalPoints"];

         return itemOrdersSummery;
      }
   }
}