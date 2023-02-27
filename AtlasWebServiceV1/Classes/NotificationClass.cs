using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   public class NotificationClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }

      [DataMember(Order = 2)]
      public int Type { get; set; }

      [DataMember(Order = 3)]
      public string CreateDate { get; set; }

      [DataMember(Order = 4)]
      public int ToUser { get; set; }

      [DataMember(Order = 5)]
      public string FCMRegistrationId { get; set; }

      [DataMember(Order = 6)]
      public string NotificationContent { get; set; }

      [DataMember(Order = 7)]
      public bool Notified { get; set; }

      [DataMember(Order = 8)]
      public string NotificationTitle { get; set; }

      [DataMember(Order = 9)]
      public double TotalSent { get; set; }

      [DataMember(Order = 10)]
      public double TotalReceived { get; set; }

      [DataMember(Order = 11)]
      public double PointsBalance { get; set; }

      [DataMember(Order = 12)]
      public double TotalSent_Waiting { get; set; }

      [DataMember(Order = 13)]
      public double TotalReceived_Waiting { get; set; }

      [DataMember(Order = 14)]
      public string Platform { get; set; }

      [DataMember(Order = 15)]
      public int SourceId { get; set; }

      [DataMember(Order = 16)]
      public int QuantityReservationRenewalCount { get; set; }

      [DataMember(Order = 17)]
      public string FullName { get; set; }

      [DataMember(Order = 18)]
      public int Fail { get; set; }

      [DataMember(Order = 19)]
      public int Order { get; set; }
        [DataMember(Order = 20)]
        public string ImageURL { get; set; }
        [DataMember(Order = 21)]
        public string ReferenceId { get; set; }
        [DataMember(Order = 22)]
        public string ReferenceType { get; set; }




        public NotificationClass PopulateNotification(string[] fieldNames, SqlDataReader reader)
      {
         var notificationClass = new NotificationClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               notificationClass.Id = (int)reader["Id"];

         if (fieldNames.Contains("Type"))
            if (!Convert.IsDBNull(reader["Type"]))
               notificationClass.Type = (int)reader["Type"];

         if (fieldNames.Contains("CreateDate"))
            if (!Convert.IsDBNull(reader["CreateDate"]))
               notificationClass.CreateDate = reader["CreateDate"].ToString();

         if (fieldNames.Contains("ToUser"))
            if (!Convert.IsDBNull(reader["ToUser"]))
               notificationClass.ToUser = (int)reader["ToUser"];

         if (fieldNames.Contains("FCMRegistrationId"))
            if (!Convert.IsDBNull(reader["FCMRegistrationId"]))
               notificationClass.FCMRegistrationId = reader["FCMRegistrationId"].ToString();

         if (fieldNames.Contains("NotificationContent"))
            if (!Convert.IsDBNull(reader["NotificationContent"]))
               notificationClass.NotificationContent = reader["NotificationContent"].ToString();

         if (fieldNames.Contains("Notified"))
            if (!Convert.IsDBNull(reader["Notified"]))
               notificationClass.Notified = Convert.ToBoolean(reader["Notified"]);

         if (fieldNames.Contains("NotificationTitle"))
            if (!Convert.IsDBNull(reader["NotificationTitle"]))
               notificationClass.NotificationTitle = reader["NotificationTitle"].ToString();

         if (fieldNames.Contains("TotalSent"))
            if (!Convert.IsDBNull(reader["TotalSent"]))
               notificationClass.TotalSent = Convert.ToDouble(reader["TotalSent"]);

         if (fieldNames.Contains("TotalReceived"))
            if (!Convert.IsDBNull(reader["TotalReceived"]))
               notificationClass.TotalReceived = Convert.ToDouble(reader["TotalReceived"]);


         if (fieldNames.Contains("PointsBalance"))
            if (!Convert.IsDBNull(reader["PointsBalance"]))
               notificationClass.PointsBalance = Convert.ToDouble(reader["PointsBalance"]);

         if (fieldNames.Contains("TotalSent_Waiting"))
            if (!Convert.IsDBNull(reader["TotalSent_Waiting"]))
               notificationClass.TotalSent_Waiting = Convert.ToDouble(reader["TotalSent_Waiting"]);

         if (fieldNames.Contains("Platform"))
            if (!Convert.IsDBNull(reader["Platform"]))
               notificationClass.Platform = reader["Platform"].ToString();

         if (fieldNames.Contains("SourceId"))
            if (!Convert.IsDBNull(reader["SourceId"]))
               notificationClass.SourceId = (int)reader["SourceId"];

         if (fieldNames.Contains("QuantityReservationRenewalCount"))
            if (!Convert.IsDBNull(reader["QuantityReservationRenewalCount"]))
               notificationClass.QuantityReservationRenewalCount = (int)reader["QuantityReservationRenewalCount"];

         if (fieldNames.Contains("FullName"))
            if (!Convert.IsDBNull(reader["FullName"]))
               notificationClass.FullName = reader["FullName"].ToString();

         if (fieldNames.Contains("Fail"))
            if (!Convert.IsDBNull(reader["Fail"]))
               notificationClass.Fail = Convert.ToInt32(reader["Fail"]);

        if (fieldNames.Contains("ImageURL"))
            if (!Convert.IsDBNull(reader["ImageURL"]))
                notificationClass.ImageURL = reader["ImageURL"].ToString();

        if (fieldNames.Contains("ReferenceId"))
            if (!Convert.IsDBNull(reader["ReferenceId"]))
                notificationClass.ReferenceId = reader["ReferenceId"].ToString();

        if (fieldNames.Contains("ReferenceType"))
            if (!Convert.IsDBNull(reader["ReferenceType"]))
                    notificationClass.ReferenceType = reader["ReferenceType"].ToString();

            return notificationClass;
      }
   }
}