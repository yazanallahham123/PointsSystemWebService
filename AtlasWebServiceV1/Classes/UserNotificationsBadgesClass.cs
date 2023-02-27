using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   public class UserNotificationsBadgesClass
   {
      [DataMember(Order = 0)]
      public int UserId { get; set; }

      [DataMember(Order = 1)]
      public int AllNotificationsCount { get; set; }

      [DataMember(Order = 2)]
      public int GeneralBalanceChargeNotificationsCount { get; set; }

      [DataMember(Order = 3)]
      public int GeneralBalanceIsLowNotificationsCount { get; set; }

      [DataMember(Order = 4)]
      public int ReceivedTransfersNotificationsCount { get; set; }

      [DataMember(Order = 5)]
      public int SentTransfersNotificationsCount { get; set; }

      [DataMember(Order = 6)]
      public int ReceivedWaitingTransfersNotificationsCount { get; set; }

      [DataMember(Order = 7)]
      public int UserNeedsActivationNotificationsCount { get; set; }

      [DataMember(Order = 8)]
      public int Order_WaitingToStart { get; set; }

      [DataMember(Order = 9)]
      public int Order_Started { get; set; }

      [DataMember(Order = 10)]
      public int Order_Shipping { get; set; }

      [DataMember(Order = 11)]
      public int Order_Delivered { get; set; }

      [DataMember(Order = 12)]
      public int Order_Canceled { get; set; }

      [DataMember(Order = 13)]
      public int Order_Refused { get; set; }

      [DataMember(Order = 14)]
      public int PrivateNotification { get; set; }

      [DataMember(Order = 15)]
      public int UserActivation { get; set; }

      [DataMember(Order = 16)]
      public int UserDeactivation { get; set; }

      [DataMember(Order = 17)]
      public int ExcelReports { get; set; }

      [DataMember(Order = 18)]
      public int UserLocationNeedValidation { get; set; }
      [DataMember(Order = 19)]
      public int UserLocationActivation { get; set; }



      public UserNotificationsBadgesClass PopulateUserNotificationsBadges(string[] fieldNames, SqlDataReader reader)
      {
         UserNotificationsBadgesClass UserNotificationsBadges = new UserNotificationsBadgesClass();

         if (fieldNames.Contains("UserId"))
            if (!Convert.IsDBNull(reader["UserId"]))
               UserNotificationsBadges.UserId = (int)reader["UserId"];

         if (fieldNames.Contains("AllNotificationsCount"))
            if (!Convert.IsDBNull(reader["AllNotificationsCount"]))
               UserNotificationsBadges.AllNotificationsCount = (int)reader["AllNotificationsCount"];

         if (fieldNames.Contains("GeneralBalanceChargeNotificationsCount"))
            if (!Convert.IsDBNull(reader["GeneralBalanceChargeNotificationsCount"]))
               UserNotificationsBadges.GeneralBalanceChargeNotificationsCount = (int)reader["GeneralBalanceChargeNotificationsCount"];

         if (fieldNames.Contains("GeneralBalanceIsLowNotificationsCount"))
            if (!Convert.IsDBNull(reader["GeneralBalanceIsLowNotificationsCount"]))
               UserNotificationsBadges.GeneralBalanceIsLowNotificationsCount = (int)reader["GeneralBalanceIsLowNotificationsCount"];

         if (fieldNames.Contains("ReceivedTransfersNotificationsCount"))
            if (!Convert.IsDBNull(reader["ReceivedTransfersNotificationsCount"]))
               UserNotificationsBadges.ReceivedTransfersNotificationsCount = (int)reader["ReceivedTransfersNotificationsCount"];

         /*Yazan 12-08-2017 : Added Sent Notifications */
         if (fieldNames.Contains("ReceivedTransfersNotificationsCount"))
            if (!Convert.IsDBNull(reader["ReceivedTransfersNotificationsCount"]))
               UserNotificationsBadges.SentTransfersNotificationsCount = (int)reader["SentTransfersNotificationsCount"];

         if (fieldNames.Contains("ReceivedWaitingTransfersNotificationsCount"))
            if (!Convert.IsDBNull(reader["ReceivedWaitingTransfersNotificationsCount"]))
               UserNotificationsBadges.ReceivedWaitingTransfersNotificationsCount = (int)reader["ReceivedWaitingTransfersNotificationsCount"];

         /*Yazan 12-08-2017 : Added Not Active User Notifications */
         if (fieldNames.Contains("UserNeedsActivationNotificationsCount"))
            if (!Convert.IsDBNull(reader["UserNeedsActivationNotificationsCount"]))
               UserNotificationsBadges.UserNeedsActivationNotificationsCount = (int)reader["UserNeedsActivationNotificationsCount"];


         //Orders
         if (fieldNames.Contains("Order_WaitingToStart"))
            if (!Convert.IsDBNull(reader["Order_WaitingToStart"]))
               UserNotificationsBadges.Order_WaitingToStart = (int)reader["Order_WaitingToStart"];

         if (fieldNames.Contains("Order_Started"))
            if (!Convert.IsDBNull(reader["Order_Started"]))
               UserNotificationsBadges.Order_Started = (int)reader["Order_Started"];

         if (fieldNames.Contains("Order_Shipping"))
            if (!Convert.IsDBNull(reader["Order_Shipping"]))
               UserNotificationsBadges.Order_Shipping = (int)reader["Order_Shipping"];

         if (fieldNames.Contains("Order_Delivered"))
            if (!Convert.IsDBNull(reader["Order_Delivered"]))
               UserNotificationsBadges.Order_Delivered = (int)reader["Order_Delivered"];

         if (fieldNames.Contains("Order_Canceled"))
            if (!Convert.IsDBNull(reader["Order_Canceled"]))
               UserNotificationsBadges.Order_Canceled = (int)reader["Order_Canceled"];

         if (fieldNames.Contains("Order_Refused"))
            if (!Convert.IsDBNull(reader["Order_Refused"]))
               UserNotificationsBadges.Order_Refused = (int)reader["Order_Refused"];

         if (fieldNames.Contains("PrivateNotification"))
            if (!Convert.IsDBNull(reader["PrivateNotification"]))
               UserNotificationsBadges.PrivateNotification = (int)reader["PrivateNotification"];

         if (fieldNames.Contains("UserActivation"))
            if (!Convert.IsDBNull(reader["UserActivation"]))
               UserNotificationsBadges.UserActivation = (int)reader["UserActivation"];

         if (fieldNames.Contains("UserDeactivation"))
            if (!Convert.IsDBNull(reader["UserDeactivation"]))
               UserNotificationsBadges.UserDeactivation = (int)reader["UserDeactivation"];

         if (fieldNames.Contains("ExcelReports"))
            if (!Convert.IsDBNull(reader["ExcelReports"]))
               UserNotificationsBadges.ExcelReports = (int)reader["ExcelReports"];

         if (fieldNames.Contains("UserLocationNeedValidation"))
            if (!Convert.IsDBNull(reader["UserLocationNeedValidation"]))
               UserNotificationsBadges.UserLocationNeedValidation = (int)reader["UserLocationNeedValidation"];

         if (fieldNames.Contains("UserLocationActivation"))
            if (!Convert.IsDBNull(reader["UserLocationActivation"]))
               UserNotificationsBadges.UserLocationActivation = (int)reader["UserLocationActivation"];

         return UserNotificationsBadges;
      }
   }
}