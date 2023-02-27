using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   public class ColumnClass
   {
      [DataMember(Order = 1)]
      public int Order { get; set; }

      [DataMember(Order = 2)]
      public string Name { get; set; }

      [DataMember(Order = 3)]
      public double Width { get; set; }

      public ColumnClass PopulateColumn(string[] fieldNames, SqlDataReader reader)
      {
         var column = new ColumnClass();

         if (fieldNames.Contains("ColumnName"))
            if (!Convert.IsDBNull(reader["ColumnName"]))
               column.Name = reader["ColumnName"].ToString();

         if (fieldNames.Contains("ColumnOrder"))
            if (!Convert.IsDBNull(reader["ColumnOrder"]))
               column.Order = Convert.ToInt32(reader["ColumnOrder"]);

         if (fieldNames.Contains("ColumnWidth"))
            if (!Convert.IsDBNull(reader["ColumnWidth"]))
               column.Width = Convert.ToDouble(reader["ColumnWidth"]);

         return column;
      }
   }
}