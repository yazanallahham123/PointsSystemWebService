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
    public class ExcelReportClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public int UserId { get; set; }

        [DataMember(Order = 3)]
        public string ReportName { get; set; }

        [DataMember(Order = 4)]
        public string ReportURL { get; set; }

        [DataMember(Order = 5)]
        public string CreateDate { get; set; }

        [DataMember(Order = 6)]
        public int Order { get; set; }

        public bool ProcessExcelReportNotification()
        {
            try
            {
                ResultClass<List<NotificationTypesClass>> NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();
                List<NotificationTypesClass> ExcelReportNotifications = new List<NotificationTypesClass>();
                if (NotificationsTypesResult.Result != null)
                {
                    List<NotificationTypesClass> NotificationsTypes = NotificationsTypesResult.Result;
                    ExcelReportNotifications = NotificationsTypes.FindAll(x => x.Id == 2000);
                    string ExcelReportNotificationTitle = "";
                    string ExcelReportNtificationContent = "";
                    if (ExcelReportNotifications.Count > 0)
                    {
                        ExcelReportNotificationTitle = ExcelReportNotifications[0].Name;
                        ExcelReportNtificationContent = ExcelReportNotificationTitle + " الخاص بـ " + ReportName;


                        WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                        request.Method = "POST";
                        request.ContentType = "application/json; charset=UTF-8";
                        var postData = "{\"Receivers\":[" + UserId + "],\"NotificationTitle\":\"" + ExcelReportNotificationTitle + "\",\"NotificationContent\":\"" + ExcelReportNtificationContent + "\",\"NotificationType\":\"2000\",\"Platform\":\"\",\"SourceId\":\"123\"}";
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

        public ExcelReportClass PopulateExcelReportClass(string[] fieldNames, SqlDataReader reader)
        {
            var excelReport = new ExcelReportClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    excelReport.Id = (int)reader["Id"];

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    excelReport.UserId = (int)reader["UserId"];

            if (fieldNames.Contains("ReportName"))
                if (!Convert.IsDBNull(reader["ReportName"]))
                    excelReport.ReportName = reader["ReportName"].ToString();

            if (fieldNames.Contains("ReportURL"))
                if (!Convert.IsDBNull(reader["ReportURL"]))
                    excelReport.ReportURL = reader["ReportURL"].ToString();

            if (fieldNames.Contains("CreateDate"))
                if (!Convert.IsDBNull(reader["CreateDate"]))
                    excelReport.CreateDate = reader["CreateDate"].ToString();
            return excelReport;
        }

    }
}