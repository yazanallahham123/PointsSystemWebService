using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class TableColumnsClass
   {
      [DataMember(Order = 1)]
      public int UserTypeId { get; set; }

      [DataMember(Order = 2)]
      public int UserId { get; set; }

      [DataMember(Order = 3)]
      public string TableName { get; set; }

      [DataMember(Order = 4)]
      public List<ColumnClass> MobileColumns { get; set; }

      [DataMember(Order = 5)]
      public List<ColumnClass> StandardColumns { get; set; }

      [DataMember(Order = 6)]
      public int Order { get; set; }

      public TableColumnsClass PopulateTableColumns(string[] fieldNames, SqlDataReader reader)
      {
         var tableColumns = new TableColumnsClass();
         tableColumns.MobileColumns = new List<ColumnClass>();
         tableColumns.StandardColumns = new List<ColumnClass>();

         if (fieldNames.Contains("UserTypeID"))
            if (!Convert.IsDBNull(reader["UserTypeID"]))
               tableColumns.UserTypeId = (int)reader["UserTypeID"];

         if (fieldNames.Contains("UserId"))
            if (!Convert.IsDBNull(reader["UserId"]))
               tableColumns.UserId = (int)reader["UserId"];

         if (fieldNames.Contains("TableName"))
            if (!Convert.IsDBNull(reader["TableName"]))
               tableColumns.TableName = reader["TableName"].ToString();

         return tableColumns;
      }
   }
}