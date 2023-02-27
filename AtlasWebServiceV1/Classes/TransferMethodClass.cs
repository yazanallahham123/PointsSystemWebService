using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class TransferMethodClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string Name { get; set; }
      [DataMember(Order = 3)]
      public int Order { get; set; }


      public TransferMethodClass PopulateTransferMethod(string[] fieldNames, SqlDataReader reader)
      {
         var transferMethod = new TransferMethodClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               transferMethod.Id = (int)reader["Id"];

         if (fieldNames.Contains("Name"))
            if (!Convert.IsDBNull(reader["Name"]))
               transferMethod.Name = reader["Name"].ToString();

         return transferMethod;
      }
   }
}