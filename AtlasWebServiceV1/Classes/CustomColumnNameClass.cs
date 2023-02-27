using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class CustomColumnNameClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string ColumnName { get; set; }
      [DataMember(Order = 3)]
      public string CustomName { get; set; }
      [DataMember(Order = 4)]
      public int TableId { get; set; }
      [DataMember(Order = 5)]
      public int Order { get; set; }


      public CustomColumnNameClass PopulateCustomColumnName(string[] fieldNames, SqlDataReader reader)
      {
         var customColumnName = new CustomColumnNameClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               customColumnName.Id = (int)reader["Id"];

         if (fieldNames.Contains("ColumnName"))
            if (!Convert.IsDBNull(reader["ColumnName"]))
               customColumnName.ColumnName = reader["ColumnName"].ToString();

         if (fieldNames.Contains("CustomName"))
            if (!Convert.IsDBNull(reader["CustomName"]))
               customColumnName.CustomName = reader["CustomName"].ToString();

         if (fieldNames.Contains("TableId"))
            if (!Convert.IsDBNull(reader["TableId"]))
               customColumnName.TableId = Convert.ToInt32(reader["TableId"]);

         return customColumnName;
      }
   }
}