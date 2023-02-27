using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace PointsSystemWebService.Classes
{
   public class FCMClass
   {
      public static void initSQLDep()
      {
         /*  try
           {
               using (SqlConnection conn = ConnectionClass.DataConnection())
               {
                   conn.Open();
                   SqlCommand cmd = new SqlCommand();
                   cmd.Connection = conn;
                   cmd.CommandText = "SELECT Id FROM dbo.[NotificationsTbl]";
                   cmd.Notification = null;
                   SqlDependency dp = new SqlDependency(cmd);
                   dp.OnChange += Dp_OnChange;
                   cmd.ExecuteReader();
               }
           }
           catch (Exception e)
           {
           } */
      }
      public static string FCMServerKey = "AAAAP2GQm2g:APA91bGZSpJAfOx4mWP204G6lUoCJAEx4r6bgh-TESmit5Z-bpMdFJE_-OPMmZVbngB0PjKazYa6X-BmK06bHEaKWF4jywFiWDZTVYZBpLTudMg8-WCefX7Bhpu4MSbdBDdwRHkDFdoG";

      private static void Dp_OnChange(object sender, SqlNotificationEventArgs e)
      {

         /*  try
           {
               using (SqlConnection conn = ConnectionClass.DataConnection())
               {
                   conn.Open();
                   SqlCommand cmd = new SqlCommand();
                   cmd.Connection = conn;
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.CommandText = "Admin_GetNewNotifications";

                   SqlDataReader reader = cmd.ExecuteReader();

                   if (reader.HasRows)
                   {
                       List<NotificationClass> notificationsList = new List<NotificationClass>();
                       NotificationClass notification;
                       while (reader.Read())
                       {
                           notification = new NotificationClass();
                           if (!Convert.IsDBNull(reader["Id"]))
                               notification.Id = (int)reader["Id"];

                           if (!Convert.IsDBNull(reader["CreateDate"]))
                               notification.CreateDate = reader["CreateDate"].ToString();

                           if (!Convert.IsDBNull(reader["FCMRegistrationId"]))
                               notification.FCMRegistrationId = reader["FCMRegistrationId"].ToString();

                           if (!Convert.IsDBNull(reader["ToUser"]))
                               notification.ToUser = (int)reader["ToUser"];

                           if (!Convert.IsDBNull(reader["Type"]))
                               notification.Type = (int)reader["Type"];

                           if (!Convert.IsDBNull(reader["NotificationContent"]))
                               notification.NotificationContent = reader["NotificationContent"].ToString();

                           if (!Convert.IsDBNull(reader["NotificationTitle"]))
                               notification.NotificationTitle = reader["NotificationTitle"].ToString();

                           if (!Convert.IsDBNull(reader["Notified"]))
                               notification.Notified = (bool)reader["Notified"];

                           if (!Convert.IsDBNull(reader["Platform"]))
                               notification.Platform = reader["Platform"].ToString();

                           //Balances
                           if (!Convert.IsDBNull(reader["TotalSent"]))
                               notification.TotalSent = Convert.ToDouble(reader["TotalSent"]);

                           if (!Convert.IsDBNull(reader["TotalReceived"]))
                               notification.TotalReceived = Convert.ToDouble(reader["TotalReceived"]);

                           if (!Convert.IsDBNull(reader["PointsBalance"]))
                               notification.PointsBalance = Convert.ToDouble(reader["PointsBalance"]);

                           if (!Convert.IsDBNull(reader["TotalSent_Waiting"]))
                               notification.TotalSent_Waiting = Convert.ToDouble(reader["TotalSent_Waiting"]);

                           if (!Convert.IsDBNull(reader["TotalReceived_Waiting"]))
                               notification.TotalReceived_Waiting = Convert.ToDouble(reader["TotalReceived_Waiting"]);

                           if (!Convert.IsDBNull(reader["QuantityReservationRenewalCount"]))
                               notification.QuantityReservationRenewalCount = (int)reader["QuantityReservationRenewalCount"];

                           if (!Convert.IsDBNull(reader["SourceId"]))
                               notification.SourceId = (int)reader["SourceId"];

                           notificationsList.Add(notification);

                       }

                       foreach (NotificationClass Notification in notificationsList)
                       {
                           if (Notification.Platform == null)
                               Notification.Platform = "";

                           //New Added For dublicated Notification
                           //Add To static List
                           if (!Config.IndexNotificationList.Exists(x => x.Id.Equals(Notification.Id)))
                           {
                               Config.IndexNotificationList.Add(Notification);
                               Config.CurrentNotificationList.Add(Notification);

                               //Task.Delay(300).ContinueWith(x => FCMClass.SendNotification(Notification));
                               //FCMClass.SendNotification(Notification);
                           }
                       }
                       if (Config.fcmStatus == false)
                           ProcessFCM();
                   }
               }
           }
           catch (Exception err) { Config.fcmStatus = false; }

           initSQLDep(); */
      }

      static void ProcessFCM()
      {
         Config.fcmStatus = true;
         while (Config.CurrentNotificationList.Count > 0)
         {
            Thread.Sleep(150);

            int noOfTries = 0;
            Config.CurrentNotificationList.Sort((p, q) => p.Id.CompareTo(q.Id));
            NotificationClass currentNotification = Config.CurrentNotificationList[0];
            bool removed = false;
            while (noOfTries <= 3)
            {
               string descriptiveResult;
               string res = FCMClass.SendNotification(currentNotification);
               if (currentNotification.Platform.ToLower() != "ios")
               {
                  int index = res.IndexOf("success") + "success".Length + 2; //+2 for ("success":)
                  descriptiveResult = res.Substring(index, 1);
               }
               else
               {
                  int index = res.IndexOf("error");
                  if (index > 0)  //It has error in response then Failed
                     descriptiveResult = "-1";
                  else
                     descriptiveResult = "1";
               }
               if (Convert.ToInt32(descriptiveResult) > 0) //res is succed                                                           
               {
                  Config.CurrentNotificationList.RemoveAt(0);
                  removed = true;
                  break;
               }
               else
                  noOfTries++;
            }
            if (!removed)
               Config.CurrentNotificationList.RemoveAt(0);
            Config.fcmStatus = false;
         }
      }
      public static void CallDb_OnChange()
      {
         Dp_OnChange(null, null);
      }
      public static string SendNotification(NotificationClass notification)
      {
         /*string deviceId = notification.FCMRegistrationId;
         string userPointsBalance = notification.PointsBalance.ToString();
         string userTotalSent = notification.TotalSent.ToString();
         string userTotalReceived = notification.TotalReceived.ToString();
         string userTotalReceivedWaiting = notification.TotalReceived_Waiting.ToString();

         string fcm_response =

         "{ \"registration_ids\": [ \"" + deviceId + "\" ], " +
           "\"priority\":\"" + "high" + "\"" +
           "\"notification\": {\"sound\":\"" + "default" + "\"," + "\"click_action\":\"" + "FCM_PLUGIN_ACTIVITY" + "\"," +
                       "\"body\":\"" + notification.NotificationContent + "\",\"title\":\"" + notification.NotificationTitle + "\"}" +
             "\"data\": {\"body\":\"" + notification.NotificationContent + "\",\"title\":\"" + notification.NotificationTitle + "\"," +
             "\"Type\":\"" + notification.Type + "\"," +
             "\"userPointsBalance\":\"" + userPointsBalance + "\"," +
             "\"userTotalSent\":\"" + userTotalSent + "\"," +
             "\"userTotalReceived\":\"" + userTotalReceived + "\"," +
             "\"content\":\"" + notification.NotificationContent + "\"," +
             "\"sourceId\":\"" + notification.SourceId + "\"," +
             "\"quantityReservationRenewalCount\":\"" + notification.QuantityReservationRenewalCount + "\"," +
             "\"notification\": {\"sound\":\"" + "default" + "\"," +
                       "\"body\":\"" + notification.NotificationContent + "\",\"title\":\"" + notification.NotificationTitle + "\"}" +
             "\"userTotalReceivedWaiting\":\"" + userTotalReceivedWaiting + "\"}}";


         string fcm_response_web =

        "{ \"registration_ids\": [ \"" + deviceId + "\" ], " +
          "\"priority\":\"" + "high" + "\"" +
           "\"data\": {\"body\":\"" + notification.NotificationContent + "\",\"title\":\"" + notification.NotificationTitle + "\"," +
            "\"Type\":\"" + notification.Type + "\"," +
            "\"userPointsBalance\":\"" + userPointsBalance + "\"," +
            "\"userTotalSent\":\"" + userTotalSent + "\"," +
            "\"userTotalReceived\":\"" + userTotalReceived + "\"," +
            "\"content\":\"" + notification.NotificationContent + "\"," +
            "\"sourceId\":\"" + notification.SourceId + "\"," +
            "\"quantityReservationRenewalCount\":\"" + notification.QuantityReservationRenewalCount + "\"," +
            "\"notification\": {\"sound\":\"" + "default" + "\"," +
                      "\"body\":\"" + notification.NotificationContent + "\",\"title\":\"" + notification.NotificationTitle + "\"}" +
            "\"userTotalReceivedWaiting\":\"" + userTotalReceivedWaiting + "\"}}";


         string Content = notification.NotificationContent;
         if (Content.Trim() == "")
             Content = "Atlas App";

         string onesignal_response = "{"
                                     + "\"app_id\": \"426fb3c6-777e-4b07-a1bd-e96884f2022d\","
                                     + "\"data\": {\"Type\": \"" + notification.Type + "\",\"userPointsBalance\": \"" + userPointsBalance + "\",\"userTotalSent\": \"" + userTotalSent + "\",\"userTotalReceived\": \"" + userTotalReceived + "\",\"content\": \"" + notification.NotificationContent + "\",\"userTotalReceivedWaiting\": \"" + userTotalReceivedWaiting + "\",\"sourceId\": \"" + notification.SourceId + "\",\"quantityReservationRenewalCount\": \"" + notification.QuantityReservationRenewalCount + "\"},"
                                     + "\"contents\": {\"en\": \"" + Content + "\"},"
                                     + "\"include_player_ids\": [\"" + deviceId + "\"]}";


         if (notification.Platform.ToLower() == "web")
         {
             return SendFCMNotification("Basic ZTI0OGRkN2MtOWMyNC00NGVkLTgyYTAtZDQ4NDcxODljYmMy", "AIzaSyCW5PHmQtijnfeTqI3W3TfVmCPNX2Q4_2k", onesignal_response, fcm_response_web, notification.Platform);
         }
         else
             return SendFCMNotification("Basic ZTI0OGRkN2MtOWMyNC00NGVkLTgyYTAtZDQ4NDcxODljYmMy", "AIzaSyCW5PHmQtijnfeTqI3W3TfVmCPNX2Q4_2k", onesignal_response, fcm_response, notification.Platform);
         //return response; */
         return "";
      }
      /* public static string SendFCMNotification(string apiKey, string postData, string postDataContentType = "application/json")
       {
           ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);

           //
           //  MESSAGE CONTENT
           byte[] byteArray = Encoding.UTF8.GetBytes(postData);

           //
           //  CREATE REQUEST
           HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
           Request.Method = "POST";
           Request.KeepAlive = false;
           Request.ContentType = postDataContentType;
           Request.Headers.Add(string.Format("Authorization: key={0}", FCMServerKey));
           Request.ContentLength = byteArray.Length;

           Stream dataStream = Request.GetRequestStream();
           dataStream.Write(byteArray, 0, byteArray.Length);
           dataStream.Close();

           //
           //  SEND MESSAGE
           try
           {
               WebResponse Response = Request.GetResponse();
               HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
               if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
               {
                   return "Unauthorized - need new token";
               }
               else if (!ResponseCode.Equals(HttpStatusCode.OK))
               {
                   return "Response from web service isn't OK";
               }

               StreamReader Reader = new StreamReader(Response.GetResponseStream());
               string responseLine = Reader.ReadToEnd();
               Reader.Close();

               return responseLine;
           }
           catch (Exception e)
           {
               Errors.LogError(-1, e.Message, e.StackTrace, "1.0.3", "API", "SendFCMNotification", e.Source, "");
               return e.Message;
           }

       } */

      public static string SendFCMNotification(string onesignal_apiKey, string fcm_apiKey, string onesignal_response, string fcm_response, string platform, string postDataContentType = "application/json; charset=utf-8")
      {
         /* ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);
          HttpWebRequest Request;
          Stream dataStream;
          byte[] byteArray;
          string fcm_responseLine = "";
          string onesignal_responseLine = "";
          // *****************************************Android - FCM
          if ((platform.Trim() == "") || (platform.ToLower() == "android") || (platform.ToLower() == "web"))
          {
              //  MESSAGE CONTENT
              byteArray = Encoding.UTF8.GetBytes(fcm_response);


              //  CREATE REQUEST
              Request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
              Request.Method = "POST";
              Request.KeepAlive = true;
              Request.ContentType = postDataContentType;
              Request.Headers.Add(string.Format("Authorization: key={0}", fcm_apiKey));
              Request.ContentLength = byteArray.Length;

              dataStream = Request.GetRequestStream();
              dataStream.Write(byteArray, 0, byteArray.Length);
              dataStream.Close();

              //
              //  SEND MESSAGE
              try
              {
                  WebResponse Response = Request.GetResponse();
                  HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                  if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                  {
                      return "Unauthorized - need new token";
                  }
                  else if (!ResponseCode.Equals(HttpStatusCode.OK))
                  {
                      return "Response from web service isn't OK";
                  }

                  StreamReader Reader = new StreamReader(Response.GetResponseStream());
                  fcm_responseLine = Reader.ReadToEnd();
                  Reader.Close();
              }
              catch (Exception e)
              {
                  Errors.LogError(-1, e.Message, e.StackTrace, "1.0.3", "API", "SendFCMNotification", e.Source, "");
                  fcm_responseLine = e.Message;
              }
          }

          //***********************************************IOS - one_signal
          if ((platform.Trim() == "") || (platform.ToLower() == "ios"))
          {

              //  MESSAGE CONTENT
              byteArray = Encoding.UTF8.GetBytes(onesignal_response);

              //
              //  CREATE REQUEST
              Request = (HttpWebRequest)WebRequest.Create("https://onesignal.com/api/v1/notifications");
              Request.Method = "POST";
              Request.KeepAlive = true;
              Request.ContentType = postDataContentType;
              Request.Headers.Add(string.Format("Authorization: key={0}", onesignal_apiKey));
              Request.ContentLength = byteArray.Length;

              dataStream = Request.GetRequestStream();
              dataStream.Write(byteArray, 0, byteArray.Length);
              dataStream.Close();
              //
              //  SEND MESSAGE
              try
              {
                  WebResponse Response = Request.GetResponse();
                  HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                  if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                  {
                      return "Unauthorized - need new token";
                  }
                  else if (!ResponseCode.Equals(HttpStatusCode.OK))
                  {
                      return "Response from web service isn't OK";
                  }

                  StreamReader Reader = new StreamReader(Response.GetResponseStream());
                  onesignal_responseLine = Reader.ReadToEnd();
                  Reader.Close();
              }
              catch (Exception e)
              {
                  Errors.LogError(-1, e.Message, e.StackTrace, "1.0.3", "API", "SendFCMNotification", e.Source, "");
                  onesignal_responseLine = e.Message;
              }
          }

          return onesignal_responseLine + " - " + fcm_responseLine; */

         return "";
      }


      public static bool ValidateServerCertificate(
                                                  object sender,
                                                  X509Certificate certificate,
                                                  X509Chain chain,
                                                  SslPolicyErrors sslPolicyErrors)
      {
         return true;
      }
   }
}