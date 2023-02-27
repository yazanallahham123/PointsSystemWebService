using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class TransferStatusClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string Name { get; set; }
      [DataMember(Order = 3)]
      public int Order { get; set; }


      public TransferStatusClass PopulateTransferStatus(string[] fieldNames, SqlDataReader reader)
      {
         var transferStatus = new TransferStatusClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               transferStatus.Id = (int)reader["Id"];

         if (fieldNames.Contains("Name"))
            if (!Convert.IsDBNull(reader["Name"]))
               transferStatus.Name = reader["Name"].ToString();

         return transferStatus;
      }

   }
}