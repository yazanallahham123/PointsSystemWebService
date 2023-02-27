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
    [DataContract]
    public class TransferResultClass
    {
        [DataMember(Order = 1)]
        public string Receiver_UserId { get; set; }
        [DataMember(Order = 2)]
        public string Amount { get; set; } //Change Amount to String to allow return error Amount
        [DataMember(Order = 3)]
        public string Note { get; set; }
        [DataMember(Order = 4)]
        public int TransferResultStatus { get; set; }
        [DataMember(Order = 5)]
        public int TransferErrorCode { get; set; }
        [DataMember(Order = 6)]
        public string TransferErrorMessage { get; set; }

        [DataMember(Order = 7)]
        public string TransferExcelGuid { get; set; }

        [DataMember(Order = 8)]
        public string Receiver_UserFullName { get; set; }

        [DataMember(Order = 9)]
        public string Sender_UserFullName { get; set; }

        [DataMember(Order = 10)]
        public string Sender_UserId { get; set; }

        [DataMember(Order = 11)]
        public int TransferStatusId { get; set; }

        [DataMember(Order = 12)]
        public int Order { get; set; }


        public bool ProcessInsertSingleTransferNotifications()
        {
            try
            {
                List<int> admins;
                string adminsUsers = "";

                ResultClass<List<NotificationTypesClass>> NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();

                if (NotificationsTypesResult.Result != null)
                {
                    List<NotificationTypesClass> ReceiverNotifications = new List<NotificationTypesClass>();
                    List<NotificationTypesClass> SenderNotifications = new List<NotificationTypesClass>();

                    List<NotificationTypesClass> NotificationsTypes = NotificationsTypesResult.Result;
                    //Get Notifications Title and Content
                    string ReceiverNotificationTitle = "";
                    string ReceiverNotificationContent = "";
                    string SenderNotificationTitle = "";
                    string SenderNotificationContent = "";

                    if (TransferStatusId == 1)
                    {
                        ReceiverNotifications = NotificationsTypes.FindAll(x => x.Id == 1);
                        SenderNotifications = NotificationsTypes.FindAll(x => x.Id == 4);

                        if (ReceiverNotifications.Count > 0)
                        {
                            ReceiverNotificationTitle = ReceiverNotifications[0].Name;
                            ReceiverNotificationContent = " تم " + ReceiverNotificationTitle + " من المستخدم : " + Sender_UserFullName + " الرصيد المحول هو : " + Amount.ToString() + " نقطة";
                        }

                        if (SenderNotifications.Count > 0)
                        {
                            SenderNotificationTitle = SenderNotifications[0].Name;
                            SenderNotificationContent = " تم " + SenderNotificationTitle + " من المستخدم : " + Sender_UserFullName + " الرصيد المحول هو : " + Amount.ToString() + " نقطة" + " إلى المستخدم : " + Receiver_UserFullName;
                        }

                        //get Sender and admins users
                        admins = NotificationsHelperClass.GetAdminNotificationsUsers(4).Result;

                        if (admins == null)
                            admins = new List<int>();

                        admins.Add(int.Parse(Sender_UserId));

                        for (int i = 0; i < admins.Count; i++)
                        {
                            adminsUsers = adminsUsers + admins[i].ToString() + ",";
                        }

                        if (adminsUsers.EndsWith(","))
                            adminsUsers = adminsUsers.Substring(0, adminsUsers.Length - 1);

                    }

                    if (TransferStatusId == 2)
                    {
                        ReceiverNotifications = NotificationsTypes.FindAll(x => x.Id == 2);
                        SenderNotifications = NotificationsTypes.FindAll(x => x.Id == 8);

                        if (ReceiverNotifications.Count > 0)
                        {
                            ReceiverNotificationTitle = ReceiverNotifications[0].Name;
                            ReceiverNotificationContent = " تم " + ReceiverNotificationTitle + " من المستخدم : " + Sender_UserFullName + " الرصيد المحول هو : " + Amount.ToString() + " نقطة";
                        }

                        if (SenderNotifications.Count > 0)
                        {
                            SenderNotificationTitle = SenderNotifications[0].Name;
                            SenderNotificationContent = " تم " + SenderNotificationTitle + " الى المستخدم : " + Receiver_UserFullName + " الرصيد المحول هو : " + Amount.ToString() + " نقطة";
                        }

                        //get Sender
                        admins = new List<int>();
                        adminsUsers = Sender_UserId;
                    }

                    if (TransferStatusId == 3)
                    {
                        ReceiverNotifications = NotificationsTypes.FindAll(x => x.Id == 3);
                        SenderNotifications = null;
                        admins = new List<int>();
                        adminsUsers = "";

                        if (ReceiverNotifications.Count > 0)
                        {
                            ReceiverNotificationTitle = ReceiverNotifications[0].Name;
                            ReceiverNotificationContent = " تم " + ReceiverNotificationTitle + " من المستخدم : " + Sender_UserFullName + " الرصيد المحول هو : " + Amount.ToString() + " نقطة";
                        }

                    }

                    if (TransferStatusId == 5)
                    {
                        ReceiverNotifications = NotificationsTypes.FindAll(x => x.Id == 3);
                        SenderNotifications = NotificationsTypes.FindAll(x => x.Id == 3);
                        admins = new List<int>();
                        adminsUsers = Sender_UserId;

                        if (ReceiverNotifications.Count > 0)
                        {
                            ReceiverNotificationTitle = ReceiverNotifications[0].Name;
                            ReceiverNotificationContent = "تم " + ReceiverNotificationTitle + " الى المستخدم : " + Sender_UserFullName + " الرصيد الملغى هو : " + Amount.ToString() + " نقطة";
                        }

                        if (SenderNotifications.Count > 0)
                        {
                            SenderNotificationTitle = SenderNotifications[0].Name;
                            SenderNotificationContent = "تم إعادة الرصيد المحول اليكم من المستخدم : " + Receiver_UserFullName + " الرصيد المعاد هو : " + Amount.ToString() + " نقطة";
                        }



                    }

                    if (TransferStatusId == 6)
                    {
                        ReceiverNotifications = NotificationsTypes.FindAll(x => x.Id == 11);
                        SenderNotifications = NotificationsTypes.FindAll(x => x.Id == 10);

                        //get Sender
                        admins = new List<int>();
                        adminsUsers = Sender_UserId;

                        if (ReceiverNotifications.Count > 0)
                        {
                            ReceiverNotificationTitle = ReceiverNotifications[0].Name;
                            ReceiverNotificationContent = " تم " + ReceiverNotificationTitle + " من المستخدم : " + Sender_UserFullName + " الرصيد المحول هو : " + Amount.ToString() + " نقطة";
                        }

                        if (SenderNotifications.Count > 0)
                        {
                            SenderNotificationTitle = SenderNotifications[0].Name;
                            SenderNotificationContent = " تم " + SenderNotificationTitle + " الى المستخدم : " + Receiver_UserFullName + " الرصيد المحول هو : " + Amount.ToString() + " نقطة";
                        }
                    }

                    if (TransferStatusId == 7)
                    {
                        ReceiverNotifications = NotificationsTypes.FindAll(x => x.Id == 13);
                        SenderNotifications = NotificationsTypes.FindAll(x => x.Id == 12);

                        //get Sender
                        admins = new List<int>();
                        adminsUsers = Sender_UserId;

                        if (ReceiverNotifications.Count > 0)
                        {
                            ReceiverNotificationTitle = ReceiverNotifications[0].Name;
                            ReceiverNotificationContent = " تم " + ReceiverNotificationTitle + " من المستخدم : " + Sender_UserFullName + " الرصيد المحول هو : " + Amount.ToString() + " نقطة";
                        }

                        if (SenderNotifications.Count > 0)
                        {
                            SenderNotificationTitle = SenderNotifications[0].Name;
                            SenderNotificationContent = " تم " + SenderNotificationTitle + " الى المستخدم : " + Receiver_UserFullName + " الرصيد المسحوب هو : " + Amount.ToString() + " نقطة";
                        }
                    }

                    //Send receiver notification
                    WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                    request.Method = "POST";
                    request.ContentType = "application/json; charset=UTF-8";
                    var postData = "{\"Receivers\":[" + Receiver_UserId + "],\"NotificationTitle\":\"" + ReceiverNotificationTitle + "\",\"NotificationContent\":\"" + ReceiverNotificationContent + "\",\"NotificationType\":\"1\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                    var data = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = data.Length;
                    var stream = request.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    WebResponse response = request.GetResponse();
                    StreamReader Reader = new StreamReader(response.GetResponseStream());
                    string onesignal_responseLine = Reader.ReadToEnd();

                    //Send Admins
                    request = WebRequest.Create(Config.NotificationsAPIURL);
                    request.Method = "POST";
                    request.ContentType = "application/json; charset=UTF-8";
                    postData = "{\"Receivers\":[" + adminsUsers + "],\"NotificationTitle\":\"" + SenderNotificationTitle + "\",\"NotificationContent\":\"" + SenderNotificationContent + "\",\"NotificationType\":\"4\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                    data = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = data.Length;
                    stream = request.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    response = request.GetResponse();

                    Reader = new StreamReader(response.GetResponseStream());
                    onesignal_responseLine = Reader.ReadToEnd();
                    return false;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TransferResultClass PopulateTransferResult(string[] fieldNames, SqlDataReader reader)
        {
            var transferResult = new TransferResultClass();

            if (fieldNames.Contains("Receiver_UserId"))
                if (!Convert.IsDBNull(reader["Receiver_UserId"]))
                    transferResult.Receiver_UserId = reader["Receiver_UserId"].ToString();


            if (fieldNames.Contains("Sender_UserId"))
                if (!Convert.IsDBNull(reader["Sender_UserId"]))
                    transferResult.Sender_UserId = reader["Sender_UserId"].ToString();


            if (fieldNames.Contains("Receiver_UserFullName"))
                if (!Convert.IsDBNull(reader["Receiver_UserFullName"]))
                    transferResult.Receiver_UserFullName = reader["Receiver_UserFullName"].ToString();


            if (fieldNames.Contains("Sender_UserFullName"))
                if (!Convert.IsDBNull(reader["Sender_UserFullName"]))
                    transferResult.Sender_UserFullName = reader["Sender_UserFullName"].ToString();


            if (fieldNames.Contains("Amount"))
                if (!Convert.IsDBNull(reader["Amount"]))
                    transferResult.Amount = reader["Amount"].ToString();

            if (fieldNames.Contains("Note"))
                if (!Convert.IsDBNull(reader["Note"]))
                    transferResult.Note = reader["Note"].ToString();

            if (fieldNames.Contains("TransferResultStatus"))
                if (!Convert.IsDBNull(reader["TransferResultStatus"]))
                    transferResult.TransferResultStatus = Convert.ToInt32(reader["TransferResultStatus"]);

            if (fieldNames.Contains("TransferErrorCode"))
                if (!Convert.IsDBNull(reader["TransferErrorCode"]))
                    transferResult.TransferErrorCode = Convert.ToInt32(reader["TransferErrorCode"]);

            //Populate Error Message
            if (transferResult.TransferErrorCode > 0)
                transferResult.TransferErrorMessage = Errors.GetErrorMessage(transferResult.TransferErrorCode);

            if (fieldNames.Contains("TransferExcelGuid"))
                if (!Convert.IsDBNull(reader["TransferExcelGuid"]))
                    transferResult.TransferExcelGuid = reader["TransferExcelGuid"].ToString();


            if (fieldNames.Contains("TransferStatusId"))
                if (!Convert.IsDBNull(reader["TransferStatusId"]))
                    transferResult.TransferStatusId = (int)reader["TransferStatusId"];

            return transferResult;
        }

    }
}