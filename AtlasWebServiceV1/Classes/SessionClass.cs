using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class SessionClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int UserId { get; set; }
      [DataMember(Order = 3)]
      public string CreatedDate { get; set; }
      [DataMember(Order = 4)]
      public string UpdatedDate { get; set; }
      [DataMember(Order = 5)]
      public int Order { get; set; }

      public SessionClass PopulateSessionClass(string[] fieldNames, SqlDataReader reader)
      {
         var sessionClass = new SessionClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               sessionClass.Id = (int)reader["Id"];

         if (fieldNames.Contains("UserId"))
            if (!Convert.IsDBNull(reader["UserId"]))
               sessionClass.UserId = (int)reader["UserId"];

         if (fieldNames.Contains("CreatedDate"))
            if (!Convert.IsDBNull(reader["CreatedDate"]))
               sessionClass.CreatedDate = reader["CreatedDate"].ToString();

         if (fieldNames.Contains("UpdatedDate"))
            if (!Convert.IsDBNull(reader["UpdatedDate"]))
               sessionClass.UpdatedDate = reader["UpdatedDate"].ToString();

         return sessionClass;
      }
   }
}