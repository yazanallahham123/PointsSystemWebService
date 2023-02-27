using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class AuditLogClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string Type { get; set; }
      [DataMember(Order = 3)]
      public string TableName { get; set; }
      [DataMember(Order = 4)]
      public string PrimaryKeyField { get; set; }
      [DataMember(Order = 5)]
      public string FieldName { get; set; }
      [DataMember(Order = 6)]
      public string OldValue { get; set; }
      [DataMember(Order = 7)]
      public string NewValue { get; set; }
      [DataMember(Order = 8)]
      public string UpdateDate { get; set; }
      [DataMember(Order = 9)]
      public string LoggedUser { get; set; }
      [DataMember(Order = 10)]
      public string CustomName { get; set; }
      [DataMember(Order = 11)]
      public string OperationGUID { get; set; }
      [DataMember(Order = 12)]
      public string Username { get; set; }
      [DataMember(Order = 12)]
      public string FullName { get; set; }
      [DataMember(Order = 13)]
      public string ArabicName { get; set; }
      [DataMember(Order = 14)]
      public int Order { get; set; }


      public AuditLogClass PopulateAuditLog(string[] fieldNames, SqlDataReader reader)
      {
         var auditLog = new AuditLogClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               auditLog.Id = (int)reader["Id"];

         if (fieldNames.Contains("Type"))
            if (!Convert.IsDBNull(reader["Type"]))
               auditLog.Type = reader["Type"].ToString();

         if (fieldNames.Contains("TableName"))
            if (!Convert.IsDBNull(reader["TableName"]))
               auditLog.TableName = reader["TableName"].ToString();

         if (fieldNames.Contains("PrimaryKeyField"))
            if (!Convert.IsDBNull(reader["PrimaryKeyField"]))
               auditLog.PrimaryKeyField = reader["PrimaryKeyField"].ToString();

         if (fieldNames.Contains("FieldName"))
            if (!Convert.IsDBNull(reader["FieldName"]))
               auditLog.FieldName = reader["FieldName"].ToString();

         if (fieldNames.Contains("OldValue"))
            if (!Convert.IsDBNull(reader["OldValue"]))
               auditLog.OldValue = reader["OldValue"].ToString();

         if (fieldNames.Contains("NewValue"))
            if (!Convert.IsDBNull(reader["NewValue"]))
               auditLog.NewValue = reader["NewValue"].ToString();

         if (fieldNames.Contains("UpdateDate"))
            if (!Convert.IsDBNull(reader["UpdateDate"]))
               auditLog.UpdateDate = reader["UpdateDate"].ToString();

         if (fieldNames.Contains("LoggedUser"))
            if (!Convert.IsDBNull(reader["LoggedUser"]))
               auditLog.LoggedUser = reader["LoggedUser"].ToString();

         if (fieldNames.Contains("CustomName"))
            if (!Convert.IsDBNull(reader["CustomName"]))
               auditLog.CustomName = reader["CustomName"].ToString();

         if (fieldNames.Contains("OperationGUID"))
            if (!Convert.IsDBNull(reader["OperationGUID"]))
               auditLog.OperationGUID = reader["OperationGUID"].ToString();

         if (fieldNames.Contains("Username"))
            if (!Convert.IsDBNull(reader["Username"]))
               auditLog.Username = reader["Username"].ToString();

         if (fieldNames.Contains("FullName"))
            if (!Convert.IsDBNull(reader["FullName"]))
               auditLog.FullName = reader["FullName"].ToString();

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               auditLog.ArabicName = reader["ArabicName"].ToString();

         return auditLog;
      }
   }
}