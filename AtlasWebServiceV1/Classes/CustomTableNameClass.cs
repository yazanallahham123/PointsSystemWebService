using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class CustomTableNameClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string TableName { get; set; }
      [DataMember(Order = 3)]
      public string CustomName { get; set; }
      [DataMember(Order = 4)]
      public int Order { get; set; }


      public CustomTableNameClass PopulateCustomTableName(string[] fieldNames, SqlDataReader reader)
      {
         var customTableName = new CustomTableNameClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               customTableName.Id = (int)reader["Id"];

         if (fieldNames.Contains("TableName"))
            if (!Convert.IsDBNull(reader["TableName"]))
               customTableName.TableName = reader["TableName"].ToString();

         if (fieldNames.Contains("CustomName"))
            if (!Convert.IsDBNull(reader["CustomName"]))
               customTableName.CustomName = reader["CustomName"].ToString();

         return customTableName;
      }
   }
}