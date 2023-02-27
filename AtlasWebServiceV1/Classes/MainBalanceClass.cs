using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class MainBalanceClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int UserId { get; set; }
        [DataMember(Order = 3)]
        public string Date { get; set; }
        [DataMember(Order = 4)]
        public double Amount { get; set; }
        [DataMember(Order = 5)]
        public string Notes { get; set; }
        [DataMember(Order = 6)]
        public string UserFullName { get; set; }
        [DataMember(Order = 7)]
        public int Order { get; set; }

        public bool ProcessInsertMainBalanceNotification()
        {
            try
            {
                List<int> admins;
                string adminsUsers = "";
                ResultClass<List<NotificationTypesClass>> NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();
                List<NotificationTypesClass> MainBalanceNotifications = new List<NotificationTypesClass>();
                if (NotificationsTypesResult.Result != null)
                {
                    List<NotificationTypesClass> NotificationsTypes = NotificationsTypesResult.Result;
                    MainBalanceNotifications = NotificationsTypes.FindAll(x => x.Id == 6);
                    string MainBalanceNotificationTitle = "";
                    string MainBalanceNtificationContent = "";
                    if (MainBalanceNotifications.Count > 0)
                    {
                        MainBalanceNotificationTitle = MainBalanceNotifications[0].Name;
                        MainBalanceNtificationContent = "تم " + "إضافة " + MainBalanceNotificationTitle + " : " + UserFullName + " و هو " + Amount.ToString();

                        //get Sender and admins users
                        admins = NotificationsHelperClass.GetAdminNotificationsUsers(6).Result;

                        if (admins == null)
                            admins = new List<int>();

                        for (int i = 0; i < admins.Count; i++)
                        {
                            adminsUsers = adminsUsers + admins[i].ToString() + ",";
                        }

                        if (adminsUsers.EndsWith(","))
                            adminsUsers = adminsUsers.Substring(0, adminsUsers.Length - 1);

                        WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                        request.Method = "POST";
                        request.ContentType = "application/json; charset=UTF-8";
                        var postData = "{\"Receivers\":[" + adminsUsers + "],\"NotificationTitle\":\"" + "إضافة " + MainBalanceNotificationTitle + "\",\"NotificationContent\":\"" + MainBalanceNtificationContent + "\",\"NotificationType\":\"6\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                        var data = Encoding.UTF8.GetBytes(postData);
                        request.ContentLength = data.Length;
                        var stream = request.GetRequestStream();
                        stream.Write(data, 0, data.Length);
                        WebResponse response = request.GetResponse();
                        StreamReader Reader = new StreamReader(response.GetResponseStream());
                        string onesignal_responseLine = Reader.ReadToEnd();
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ProcessUpdateMainBalanceNotification()
        {
            try
            {
                List<int> admins;
                string adminsUsers = "";
                ResultClass<List<NotificationTypesClass>> NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();
                List<NotificationTypesClass> MainBalanceNotifications = new List<NotificationTypesClass>();
                if (NotificationsTypesResult.Result != null)
                {
                    List<NotificationTypesClass> NotificationsTypes = NotificationsTypesResult.Result;
                    MainBalanceNotifications = NotificationsTypes.FindAll(x => x.Id == 6);
                    string MainBalanceNotificationTitle = "";
                    string MainBalanceNtificationContent = "";
                    if (MainBalanceNotifications.Count > 0)
                    {
                        MainBalanceNotificationTitle = MainBalanceNotifications[0].Name;
                        MainBalanceNtificationContent = "تم " + "تعديل " + MainBalanceNotificationTitle + " : " + UserFullName + " و هو " + Amount.ToString();

                        //get Sender and admins users
                        admins = NotificationsHelperClass.GetAdminNotificationsUsers(6).Result;

                        if (admins == null)
                            admins = new List<int>();

                        for (int i = 0; i < admins.Count; i++)
                        {
                            adminsUsers = adminsUsers + admins[i].ToString() + ",";
                        }

                        if (adminsUsers.EndsWith(","))
                            adminsUsers = adminsUsers.Substring(0, adminsUsers.Length - 1);

                        WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                        request.Method = "POST";
                        request.ContentType = "application/json; charset=UTF-8";
                        var postData = "{\"Receivers\":[" + adminsUsers + "],\"NotificationTitle\":\"" + "تعديل " + MainBalanceNotificationTitle + "\",\"NotificationContent\":\"" + MainBalanceNtificationContent + "\",\"NotificationType\":\"6\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                        var data = Encoding.UTF8.GetBytes(postData);
                        request.ContentLength = data.Length;
                        var stream = request.GetRequestStream();
                        stream.Write(data, 0, data.Length);
                        WebResponse response = request.GetResponse();
                        StreamReader Reader = new StreamReader(response.GetResponseStream());
                        string onesignal_responseLine = Reader.ReadToEnd();
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ProcessDeleteMainBalanceNotification()
        {
            try
            {
                List<int> admins;
                string adminsUsers = "";
                ResultClass<List<NotificationTypesClass>> NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();
                List<NotificationTypesClass> MainBalanceNotifications = new List<NotificationTypesClass>();
                if (NotificationsTypesResult.Result != null)
                {
                    List<NotificationTypesClass> NotificationsTypes = NotificationsTypesResult.Result;
                    MainBalanceNotifications = NotificationsTypes.FindAll(x => x.Id == 6);
                    string MainBalanceNotificationTitle = "";
                    string MainBalanceNtificationContent = "";
                    if (MainBalanceNotifications.Count > 0)
                    {
                        MainBalanceNotificationTitle = MainBalanceNotifications[0].Name;
                        MainBalanceNtificationContent = "تم " + "حذف " + MainBalanceNotificationTitle + " : " + UserFullName + " و هو " + Amount.ToString();

                        //get Sender and admins users
                        admins = NotificationsHelperClass.GetAdminNotificationsUsers(6).Result;

                        if (admins == null)
                            admins = new List<int>();

                        for (int i = 0; i < admins.Count; i++)
                        {
                            adminsUsers = adminsUsers + admins[i].ToString() + ",";
                        }

                        if (adminsUsers.EndsWith(","))
                            adminsUsers = adminsUsers.Substring(0, adminsUsers.Length - 1);

                        WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                        request.Method = "POST";
                        request.ContentType = "application/json; charset=UTF-8";
                        var postData = "{\"Receivers\":[" + adminsUsers + "],\"NotificationTitle\":\"" + "حذف " + MainBalanceNotificationTitle + "\",\"NotificationContent\":\"" + MainBalanceNtificationContent + "\",\"NotificationType\":\"6\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                        var data = Encoding.UTF8.GetBytes(postData);
                        request.ContentLength = data.Length;
                        var stream = request.GetRequestStream();
                        stream.Write(data, 0, data.Length);
                        WebResponse response = request.GetResponse();
                        StreamReader Reader = new StreamReader(response.GetResponseStream());
                        string onesignal_responseLine = Reader.ReadToEnd();
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public MainBalanceClass PopulateMainBalance(string[] fieldNames, SqlDataReader reader)
        {
            var mainBalance = new MainBalanceClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    mainBalance.Id = (int)reader["Id"];

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    mainBalance.UserId = Convert.ToInt32(reader["UserId"]);

            if (fieldNames.Contains("Date"))
                if (!Convert.IsDBNull(reader["Date"]))
                    mainBalance.Date = ((DateTime)reader["Date"]).ToString("yyyy-MM-dd");

            if (fieldNames.Contains("Amount"))
                if (!Convert.IsDBNull(reader["Amount"]))
                    mainBalance.Amount = Convert.ToDouble(reader["Amount"]);

            if (fieldNames.Contains("Notes"))
                if (!Convert.IsDBNull(reader["Notes"]))
                    mainBalance.Notes = reader["Notes"].ToString();

            if (fieldNames.Contains("UserFullName"))
                if (!Convert.IsDBNull(reader["UserFullName"]))
                    mainBalance.UserFullName = reader["UserFullName"].ToString();

            return mainBalance;
        }
    }
}