using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PointsSystemWebService.Classes.Core;
using System.Net;
using System.Text;
using System.IO;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class UserClass
    {
        public static List<string[]> headerRow = new List<string[]>()
       {
          new string[] { "رقم السطر"}
       };

        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Username { get; set; }
        [DataMember(Order = 3)]
        public string FullName { get; set; }
        [DataMember(Order = 4)]
        public string Email { get; set; }
        [DataMember(Order = 5)]
        public string Password { get; set; }
        [DataMember(Order = 6)]
        public string MobileNumber { get; set; }
        [DataMember(Order = 7)]
        public string CreateDate { get; set; }
        [DataMember(Order = 8)]
        public int UserType { get; set; }
        [DataMember(Order = 9)]
        public int CompanyId { get; set; }
        [DataMember(Order = 10)]
        public bool CanGrantPoints { get; set; }
        [DataMember(Order = 11)]
        public bool CanTakeOffers { get; set; }
        [DataMember(Order = 12)]
        public bool Disabled { get; set; }

        [DataMember(Order = 13)]
        public int GovernorateId { get; set; }
        [DataMember(Order = 14)]
        public int CityId { get; set; }
        [DataMember(Order = 15)]
        public int LocationId { get; set; }
        [DataMember(Order = 16)]
        public string Address1 { get; set; }
        [DataMember(Order = 17)]
        public string Address2 { get; set; }

        [DataMember(Order = 18)]
        public double TotalSent { get; set; }
        [DataMember(Order = 19)]
        public double TotalReceived { get; set; }
        [DataMember(Order = 20)]
        public double PointsBalance { get; set; }
        [DataMember(Order = 21)]
        public double TotalSent_Waiting { get; set; }
        [DataMember(Order = 22)]
        public double TotalReceived_Waiting { get; set; }
        [DataMember(Order = 23)]
        public string QRCode { get; set; }

        [DataMember(Order = 24)]
        public int PositionId { get; set; }
        [DataMember(Order = 25)]
        public int JobId { get; set; }
        [DataMember(Order = 26)]
        public int WorkDomainId { get; set; }
        [DataMember(Order = 27)]
        public int EducationLevelId { get; set; }

        [DataMember(Order = 28)]
        public string Birthdate { get; set; }
        [DataMember(Order = 29)]
        public string NickName { get; set; }
        [DataMember(Order = 30)]
        public int Gender { get; set; }
        [DataMember(Order = 31)]
        public int YearsOfExperience { get; set; }
        [DataMember(Order = 32)]
        public int StaffCount { get; set; }
        [DataMember(Order = 33)]
        public bool HasVocationalCertificate { get; set; }
        [DataMember(Order = 34)]
        public string Notes { get; set; }
        [DataMember(Order = 35)]
        public string CommercialName { get; set; }

        [DataMember(Order = 36)]
        public string AccessToken { get; set; }
        [DataMember(Order = 37)]
        public bool IsActive { get; set; }
        [DataMember(Order = 38)]
        public double OrdersPoints { get; set; }
        [DataMember(Order = 39)]
        public bool PermissionFromTemplate { get; set; }
        [DataMember(Order = 40)]
        public int CountryId { get; set; }

        //Missing LoggedUser prop

        [DataMember(Order = 41)]
        public int CountryCurrencyId { get; set; }
        [DataMember(Order = 42)]
        public bool LocationValidated { get; set; }
        [DataMember(Order = 43)]
        public bool VisibleOnMap { get; set; }
        [DataMember(Order = 44)]
        public double Latitude { get; set; }
        [DataMember(Order = 45)]
        public double Longitude { get; set; }

        [DataMember(Order = 46)]
        public double GiftsPoints { get; set; }
        [DataMember(Order = 47)]
        public double TotalReceivedGiftsPoints { get; set; }
        [DataMember(Order = 48)]
        public double TotalSentFromGiftsPoints { get; set; }

        //Missing UsersPermissionsTbl Class prop

        [DataMember(Order = 49)]
        public string UserTypeName { get; set; }

        [DataMember(Order = 50)]
        public string CompanyArabicName { get; set; }
        [DataMember(Order = 51)]
        public string CompanyEnglishName { get; set; }

        [DataMember(Order = 52)]
        public string LocationArabicName { get; set; }
        [DataMember(Order = 53)]
        public string LocationEnglishName { get; set; }
        [DataMember(Order = 54)]
        public string CityArabicName { get; set; }
        [DataMember(Order = 55)]
        public string CityEnglishName { get; set; }
        [DataMember(Order = 56)]
        public string GovernorateArabicName { get; set; }
        [DataMember(Order = 57)]
        public string GovernorateEnglishName { get; set; }

        [DataMember(Order = 58)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 59)]
        public string CountryEnglishName { get; set; }

        [DataMember(Order = 60)]
        public string JobArabicName { get; set; }
        [DataMember(Order = 61)]
        public string JobEnglishName { get; set; }

        [DataMember(Order = 62)]
        public string PositionArabicName { get; set; }
        [DataMember(Order = 63)]
        public string PositionEnglishName { get; set; }

        [DataMember(Order = 64)]
        public string WorkDomainArabicName { get; set; }
        [DataMember(Order = 65)]
        public string WorkDomainEnglishName { get; set; }

        [DataMember(Order = 67)]
        public string EducationLevelArabicName { get; set; }
        [DataMember(Order = 68)]
        public string EducationLevelEnglishName { get; set; }

        [DataMember(Order = 69)]
        public int LunchCount { get; set; }

        [DataMember(Order = 90)]
        public int CurrencyId { get; set; }
        [DataMember(Order = 64)]
        public string CurrencyArabicName { get; set; }
        [DataMember(Order = 65)]
        public string CurrencyEnglishName { get; set; }
        [DataMember(Order = 64)]
        public string CurrencyArabicCode { get; set; }
        [DataMember(Order = 65)]
        public string CurrencyEnglishCode { get; set; }


        [DataMember(Order = 70)]
        public string MobileCountryCode { get; set; }

        [DataMember(Order = 71)]
        public int Order { get; set; }
        [DataMember(Order = 72)]
        public bool HasOpenCart { get; set; }
        [DataMember(Order = 73)]
        public double OrdersPointsFromGifts { get; set; }
        [DataMember(Order = 74)]
        public string Street { get; set; }
        [DataMember(Order = 75)]
        public string Building { get; set; }
        [DataMember(Order = 76)]
        public string Floor { get; set; }
        [DataMember(Order = 77)]
        public string ApartmentNo { get; set; }


        [DataMember(Order = 78)]
        public string AddressNote { get; set; }
        [DataMember(Order = 78)]
        public string BlockNo { get; set; }

        [DataMember(Order = 78)]
        public int CurrentBranchId { get; set; }
        [DataMember(Order = 78)]
        public string CurrentBranchArabicName { get; set; }
        [DataMember(Order = 78)]
        public string CurrentBranchEnglishName { get; set; }

        [DataMember(Order = 78)]
        public string CardNumber { get; set; }
        [DataMember(Order = 78)]
        public string AccountNumber { get; set; }
        [DataMember(Order = 78)]
        public string CardType { get; set; }
        [DataMember(Order = 78)]
        public string MaritalStatus { get; set; }
        [DataMember(Order = 78)]
        public string ChildCount { get; set; }
        [DataMember(Order = 78)]
        public string Nationality { get; set; }
        [DataMember(Order = 78)]
        public string MobileNumber2 { get; set; }

        [DataMember(Order = 78)]
        public bool FilterByCountry{ get; set; }
        [DataMember(Order = 78)]
        public bool IsVerified { get; set; }
        [DataMember(Order = 78)]
        public double BalanceLimit { get; set; }
        [DataMember(Order = 78)]
        public bool Removed { get; set; }

        public bool ProcessUpdateUserNotifications(UserClass OldUserData)
        {
            try
            {
                ResultClass<List<NotificationTypesClass>> NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();
                List<NotificationTypesClass> ChangeUserTypeNotifications = new List<NotificationTypesClass>();


                if (NotificationsTypesResult.Result != null)
                {
                    List<NotificationTypesClass> NotificationsTypes = NotificationsTypesResult.Result;

                    if (OldUserData.UserType != UserType)
                    {
                        ChangeUserTypeNotifications = NotificationsTypes.FindAll(x => x.Id == 106);
                        string ChangeUserNotificationTitle = "";
                        string ChangeUserNtificationContent = "";
                        if (ChangeUserTypeNotifications.Count > 0)
                        {
                            ChangeUserNotificationTitle = "تغيير نوع المستخدم";
                            ChangeUserNtificationContent = ChangeUserTypeNotifications[0].Name;

                            WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                            request.Method = "POST";
                            request.ContentType = "application/json; charset=UTF-8";
                            var postData = "{\"Receivers\":[" + Id.ToString() + "],\"NotificationTitle\":\"" + ChangeUserNotificationTitle + "\",\"NotificationContent\":\"" + ChangeUserNtificationContent + "\",\"NotificationType\":\"106\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                            var data = Encoding.UTF8.GetBytes(postData);
                            request.ContentLength = data.Length;
                            var stream = request.GetRequestStream();
                            stream.Write(data, 0, data.Length);
                            WebResponse response = request.GetResponse();
                            StreamReader Reader = new StreamReader(response.GetResponseStream());
                            string onesignal_responseLine = Reader.ReadToEnd();
                        }
                    }

                    if ((OldUserData.UserType == 4) || (OldUserData.UserType == 5))
                    {
                        if ((OldUserData.LocationValidated == false) && (LocationValidated == true))
                        {
                            ChangeUserTypeNotifications = NotificationsTypes.FindAll(x => x.Id == 104);
                            string LocationValidationNotificationTitle = "";
                            string LocationValidationNotificationContent = "";
                            if (ChangeUserTypeNotifications.Count > 0)
                            {
                                LocationValidationNotificationTitle = "تأكيد تحديد موقع";
                                LocationValidationNotificationContent = ChangeUserTypeNotifications[0].Name;

                                WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                                request.Method = "POST";
                                request.ContentType = "application/json; charset=UTF-8";
                                var postData = "{\"Receivers\":[" + Id.ToString() + "],\"NotificationTitle\":\"" + LocationValidationNotificationTitle + "\",\"NotificationContent\":\"" + LocationValidationNotificationContent + "\",\"NotificationType\":\"104\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                                var data = Encoding.UTF8.GetBytes(postData);
                                request.ContentLength = data.Length;
                                var stream = request.GetRequestStream();
                                stream.Write(data, 0, data.Length);
                                WebResponse response = request.GetResponse();
                                StreamReader Reader = new StreamReader(response.GetResponseStream());
                                string onesignal_responseLine = Reader.ReadToEnd();
                            }
                        }
                    }

                    if ((OldUserData.UserType == 4) || (OldUserData.UserType == 5))
                    {
                        if ((OldUserData.VisibleOnMap == false) && (VisibleOnMap == true))
                        {
                            ChangeUserTypeNotifications = NotificationsTypes.FindAll(x => x.Id == 105);
                            string VisibleOnMapNotificationTitle = "";
                            string VisibleOnMapNotificationContent = "";
                            if (ChangeUserTypeNotifications.Count > 0)
                            {
                                VisibleOnMapNotificationTitle = "إدارج ضمن الدليل";
                                VisibleOnMapNotificationContent = ChangeUserTypeNotifications[0].Name;

                                WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                                request.Method = "POST";
                                request.ContentType = "application/json; charset=UTF-8";
                                var postData = "{\"Receivers\":[" + Id.ToString() + "],\"NotificationTitle\":\"" + VisibleOnMapNotificationTitle + "\",\"NotificationContent\":\"" + VisibleOnMapNotificationContent + "\",\"NotificationType\":\"105\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                                var data = Encoding.UTF8.GetBytes(postData);
                                request.ContentLength = data.Length;
                                var stream = request.GetRequestStream();
                                stream.Write(data, 0, data.Length);
                                WebResponse response = request.GetResponse();
                                StreamReader Reader = new StreamReader(response.GetResponseStream());
                                string onesignal_responseLine = Reader.ReadToEnd();
                            }
                        }
                    }

                    if ((OldUserData.IsActive == false) && (IsActive == true))
                    {
                        ChangeUserTypeNotifications = NotificationsTypes.FindAll(x => x.Id == 100);
                        string ActivateUserNotificationTitle = "";
                        string ActivateUserNotificationContent = "";
                        if (ChangeUserTypeNotifications.Count > 0)
                        {
                            ActivateUserNotificationTitle = "تفعيل المستخدم";
                            ActivateUserNotificationContent = "تم تفعيل المستخدم الخاص بكم";

                            WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                            request.Method = "POST";
                            request.ContentType = "application/json; charset=UTF-8";
                            var postData = "{\"Receivers\":[" + Id.ToString() + "],\"NotificationTitle\":\"" + ActivateUserNotificationTitle + "\",\"NotificationContent\":\"" + ActivateUserNotificationContent + "\",\"NotificationType\":\"100\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                            var data = Encoding.UTF8.GetBytes(postData);
                            request.ContentLength = data.Length;
                            var stream = request.GetRequestStream();
                            stream.Write(data, 0, data.Length);
                            WebResponse response = request.GetResponse();
                            StreamReader Reader = new StreamReader(response.GetResponseStream());
                            string onesignal_responseLine = Reader.ReadToEnd();
                        }
                    }

                    if ((OldUserData.IsActive == true) && (IsActive == false))
                    {
                        ChangeUserTypeNotifications = NotificationsTypes.FindAll(x => x.Id == 100);
                        string DeactivateUserNotificationTitle = "";
                        string DeactivateUserNotificationContent = "";
                        if (ChangeUserTypeNotifications.Count > 0)
                        {
                            DeactivateUserNotificationTitle = "تفعيل المستخدم";
                            DeactivateUserNotificationContent = "تم الغاء تفعيل المستخدم الخاص بكم";

                            WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                            request.Method = "POST";
                            request.ContentType = "application/json; charset=UTF-8";
                            var postData = "{\"Receivers\":[" + Id.ToString() + "],\"NotificationTitle\":\"" + DeactivateUserNotificationTitle + "\",\"NotificationContent\":\"" + DeactivateUserNotificationContent + "\",\"NotificationType\":\"900\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                            var data = Encoding.UTF8.GetBytes(postData);
                            request.ContentLength = data.Length;
                            var stream = request.GetRequestStream();
                            stream.Write(data, 0, data.Length);
                            WebResponse response = request.GetResponse();
                            StreamReader Reader = new StreamReader(response.GetResponseStream());
                            string onesignal_responseLine = Reader.ReadToEnd();
                        }
                    }

                    if ((OldUserData.Username != Username) || (OldUserData.Password != Password) || (OldUserData.AccessToken != AccessToken) || ((UserType == 5) && (OldUserData.MobileCountryCode != MobileCountryCode)))
                    {
                        ChangeUserTypeNotifications = NotificationsTypes.FindAll(x => x.Id == 102);
                        string UsernameOrPasswordNotificationTitle = "";
                        string UsernameOrPasswordNotificationContent = "";
                        if (ChangeUserTypeNotifications.Count > 0)
                        {

                            UsernameOrPasswordNotificationTitle = ChangeUserTypeNotifications[0].Name;
                            UsernameOrPasswordNotificationContent = ChangeUserTypeNotifications[0].Name;
                            WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                            request.Method = "POST";
                            request.ContentType = "application/json; charset=UTF-8";
                            var postData = "{\"Receivers\":[" + Id.ToString() + "],\"NotificationTitle\":\"" + UsernameOrPasswordNotificationTitle + "\",\"NotificationContent\":\"" + UsernameOrPasswordNotificationContent + "\",\"NotificationType\":\"102\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                            var data = Encoding.UTF8.GetBytes(postData);
                            request.ContentLength = data.Length;
                            var stream = request.GetRequestStream();
                            stream.Write(data, 0, data.Length);
                            WebResponse response = request.GetResponse();
                            StreamReader Reader = new StreamReader(response.GetResponseStream());
                            string onesignal_responseLine = Reader.ReadToEnd();
                        }
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

        public bool ProcessActivateUsersNotification(List<int> Users)
        {
            try
            {
                ResultClass<List<NotificationTypesClass>> NotificationsTypesResult = NotificationsHelperClass.GetNotificationsTypes();
                List<NotificationTypesClass> ChangeUserTypeNotifications = new List<NotificationTypesClass>();

                if (NotificationsTypesResult.Result != null)
                {
                    List<NotificationTypesClass> NotificationsTypes = NotificationsTypesResult.Result;
                    string usersList = "";

                    for (int i = 0; i < Users.Count; i++)
                    {
                        usersList = usersList + Users[i].ToString() + ",";
                    }

                    if (usersList.EndsWith(","))
                        usersList = usersList.Substring(0, usersList.Length - 1);

                    if (usersList.Trim() != "")
                    {
                        ChangeUserTypeNotifications = NotificationsTypes.FindAll(x => x.Id == 106);
                        string ActivateUserNotificationTitle = "";
                        string ActivateUserNotificationContent = "";
                        if (ChangeUserTypeNotifications.Count > 0)
                        {
                            ActivateUserNotificationTitle = "تفعيل المستخدم";
                            ActivateUserNotificationContent = "تم تفعيل المستخدم الخاص بكم";

                            WebRequest request = WebRequest.Create(Config.NotificationsAPIURL);
                            request.Method = "POST";
                            request.ContentType = "application/json; charset=UTF-8";
                            var postData = "{\"Receivers\":[" + usersList + "],\"NotificationTitle\":\"" + ActivateUserNotificationTitle + "\",\"NotificationContent\":\"" + ActivateUserNotificationContent + "\",\"NotificationType\":\"106\",\"Platform\":\"\",\"SourceId\":\"123\"}";
                            var data = Encoding.UTF8.GetBytes(postData);
                            request.ContentLength = data.Length;
                            var stream = request.GetRequestStream();
                            stream.Write(data, 0, data.Length);
                            WebResponse response = request.GetResponse();
                            StreamReader Reader = new StreamReader(response.GetResponseStream());
                            string onesignal_responseLine = Reader.ReadToEnd();
                        }
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

        public ResultClass<bool> ClearFCMRegistrationIdByUserId(int LoggedUser)
        {
            ResultClass<bool> result = new ResultClass<bool>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_ClearFCMRegistrationIdByUserId";
                    List<SqlParameter> Params = new List<SqlParameter>()
               {
                  new SqlParameter("LoggedUser", LoggedUser)
               };

                    cmd.Parameters.AddRange(Params.ToArray());
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, rd.FieldCount).Select(i => rd.GetName(i)).ToArray();
                        var dbResult = false;
                        rd.Read();
                        if (fieldNames.Contains("RESULT"))
                            if (!Convert.IsDBNull(rd["RESULT"]))
                                dbResult = Convert.ToBoolean(rd["RESULT"].ToString().ToLower());

                        result.Message = "";
                         result.Code = Errors.Success;
                        result.Result = dbResult;
                        return result;
                    }
                    else
                    {
                         result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = false;
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                int code;
                if (Int32.TryParse(e.Message, out code))
                {
                    result.Code = code;
                    result.Message = Errors.GetErrorMessage(code);
                }
                else
                {
                     result.Code = Errors.UnknownError;
                    result.Message = Errors.GetErrorMessage(result.Code);
                    Errors.LogError(-1, e.Message, e.StackTrace, "1.0.3", "API", "ClearFCMRegistrationIdByUserId", "", "");
                }
                result.Result = false;
                return result;
            }
        }

        public UserClass PopulateUser(string[] fieldNames, SqlDataReader reader, string prefix = "")
        {

            var user = new UserClass();

            if (fieldNames.Contains(prefix + "Id"))
                if (!Convert.IsDBNull(reader[prefix + "Id"]))
                    user.Id = Convert.ToInt32(reader[prefix + "Id"]);

            if (fieldNames.Contains(prefix + "Username"))
                if (!Convert.IsDBNull(reader[prefix + "Username"]))
                    user.Username = reader[prefix + "Username"].ToString();

            if (fieldNames.Contains(prefix + "FullName"))
                if (!Convert.IsDBNull(reader[prefix + "FullName"]))
                    user.FullName = reader[prefix + "FullName"].ToString();

            if (fieldNames.Contains(prefix + "Email"))
                if (!Convert.IsDBNull(reader[prefix + "Email"]))
                    user.Email = reader[prefix + "Email"].ToString();

            if (fieldNames.Contains(prefix + "MobileNumber"))
                if (!Convert.IsDBNull(reader[prefix + "MobileNumber"]))
                    user.MobileNumber = reader[prefix + "MobileNumber"].ToString();

            if (fieldNames.Contains(prefix + "CreateDate"))
                if (!Convert.IsDBNull(reader[prefix + "CreateDate"]))
                    user.CreateDate = reader[prefix + "CreateDate"].ToString();

            if (fieldNames.Contains(prefix + "UserType"))
                if (!Convert.IsDBNull(reader[prefix + "UserType"]))
                    user.UserType = Convert.ToInt32(reader[prefix + "UserType"]);

            if (fieldNames.Contains(prefix + "CompanyId"))
                if (!Convert.IsDBNull(reader[prefix + "CompanyId"]))
                    user.CompanyId = Convert.ToInt32(reader[prefix + "CompanyId"]);

            if (fieldNames.Contains(prefix + "CanGrantPoints"))
                if (!Convert.IsDBNull(reader[prefix + "CanGrantPoints"]))
                    user.CanGrantPoints = Convert.ToBoolean(reader[prefix + "CanGrantPoints"]);

            if (fieldNames.Contains(prefix + "CanTakeOffers"))
                if (!Convert.IsDBNull(reader[prefix + "CanTakeOffers"]))
                    user.CanTakeOffers = Convert.ToBoolean(reader[prefix + "CanTakeOffers"]);

            if (fieldNames.Contains(prefix + "Disabled"))
                if (!Convert.IsDBNull(reader[prefix + "Disabled"]))
                    user.Disabled = Convert.ToBoolean(reader[prefix + "Disabled"]);

            if (fieldNames.Contains(prefix + "GovernorateId"))
                if (!Convert.IsDBNull(reader[prefix + "GovernorateId"]))
                    user.GovernorateId = Convert.ToInt32(reader[prefix + "GovernorateId"]);

            if (fieldNames.Contains(prefix + "CityId"))
                if (!Convert.IsDBNull(reader[prefix + "CityId"]))
                    user.CityId = Convert.ToInt32(reader[prefix + "CityId"]);

            if (fieldNames.Contains(prefix + "LocationId"))
                if (!Convert.IsDBNull(reader[prefix + "LocationId"]))
                    user.LocationId = Convert.ToInt32(reader[prefix + "LocationId"]);

            if (fieldNames.Contains(prefix + "Address1"))
                if (!Convert.IsDBNull(reader[prefix + "Address1"]))
                    user.Address1 = reader[prefix + "Address1"].ToString();

            if (fieldNames.Contains(prefix + "Address2"))
                if (!Convert.IsDBNull(reader[prefix + "Address2"]))
                    user.Address2 = reader[prefix + "Address2"].ToString();

            if (fieldNames.Contains(prefix + "TotalSent"))
                if (!Convert.IsDBNull(reader[prefix + "TotalSent"]))
                    user.TotalSent = Convert.ToDouble(reader[prefix + "TotalSent"]);

            if (fieldNames.Contains(prefix + "TotalReceived"))
                if (!Convert.IsDBNull(reader[prefix + "TotalReceived"]))
                    user.TotalReceived = Convert.ToDouble(reader[prefix + "TotalReceived"]);

            if (fieldNames.Contains(prefix + "PointsBalance"))
                if (!Convert.IsDBNull(reader[prefix + "PointsBalance"]))
                    user.PointsBalance = Convert.ToDouble(reader[prefix + "PointsBalance"]);

            if (fieldNames.Contains(prefix + "TotalSent_Waiting"))
                if (!Convert.IsDBNull(reader[prefix + "TotalSent_Waiting"]))
                    user.TotalSent_Waiting = Convert.ToDouble(reader[prefix + "TotalSent_Waiting"]);

            if (fieldNames.Contains(prefix + "TotalReceived_Waiting"))
                if (!Convert.IsDBNull(reader[prefix + "TotalReceived_Waiting"]))
                    user.TotalReceived_Waiting = Convert.ToDouble(reader[prefix + "TotalReceived_Waiting"]);

            if (fieldNames.Contains(prefix + "QRCode"))
                if (!Convert.IsDBNull(reader[prefix + "QRCode"]))
                    user.QRCode = reader[prefix + "QRCode"].ToString();

            if (fieldNames.Contains(prefix + "PositionId"))
                if (!Convert.IsDBNull(reader[prefix + "PositionId"]))
                    user.PositionId = (int)reader[prefix + "PositionId"];

            if (fieldNames.Contains(prefix + "JobId"))
                if (!Convert.IsDBNull(reader[prefix + "JobId"]))
                    user.JobId = (int)reader[prefix + "JobId"]; ;

            if (fieldNames.Contains(prefix + "WorkDomainId"))
                if (!Convert.IsDBNull(reader[prefix + "WorkDomainId"]))
                    user.WorkDomainId = (int)reader[prefix + "WorkDomainId"];

            if (fieldNames.Contains(prefix + "EducationLevelId"))
                if (!Convert.IsDBNull(reader[prefix + "EducationLevelId"]))
                    user.EducationLevelId = (int)reader[prefix + "EducationLevelId"];

            if (fieldNames.Contains(prefix + "Birthdate"))
                if (!Convert.IsDBNull(reader[prefix + "Birthdate"]))
                    user.Birthdate = Convert.ToDateTime(reader[prefix + "Birthdate"]).ToString("yyyy-MM-dd");

            if (fieldNames.Contains(prefix + "NickName"))
                if (!Convert.IsDBNull(reader[prefix + "NickName"]))
                    user.NickName = reader[prefix + "NickName"].ToString();

            if (fieldNames.Contains(prefix + "Gender"))
                if (!Convert.IsDBNull(reader[prefix + "Gender"]))
                    user.Gender = (int)reader[prefix + "Gender"];

            if (fieldNames.Contains(prefix + "YearsOfExperience"))
                if (!Convert.IsDBNull(reader[prefix + "YearsOfExperience"]))
                    user.YearsOfExperience = (int)reader[prefix + "YearsOfExperience"];

            if (fieldNames.Contains(prefix + "StaffCount"))
                if (!Convert.IsDBNull(reader[prefix + "StaffCount"]))
                    user.StaffCount = (int)reader[prefix + "StaffCount"];

            if (fieldNames.Contains(prefix + "HasVocationalCertificate"))
                if (!Convert.IsDBNull(reader[prefix + "HasVocationalCertificate"]))
                    user.HasVocationalCertificate = (bool)reader[prefix + "HasVocationalCertificate"];

            if (fieldNames.Contains(prefix + "Notes"))
                if (!Convert.IsDBNull(reader[prefix + "Notes"]))
                    user.Notes = reader[prefix + "Notes"].ToString();

            if (fieldNames.Contains(prefix + "CommercialName"))
                if (!Convert.IsDBNull(reader[prefix + "CommercialName"]))
                    user.CommercialName = reader[prefix + "CommercialName"].ToString();

            if (fieldNames.Contains(prefix + "IsActive"))
                if (!Convert.IsDBNull(reader[prefix + "IsActive"]))
                    user.IsActive = (bool)reader[prefix + "IsActive"];

            if (fieldNames.Contains(prefix + "OrdersPoints"))
                if (!Convert.IsDBNull(reader[prefix + "OrdersPoints"]))
                    user.OrdersPoints = Convert.ToDouble(reader[prefix + "OrdersPoints"]);

            if (fieldNames.Contains(prefix + "PermissionFromTemplate"))
                if (!Convert.IsDBNull(reader[prefix + "PermissionFromTemplate"]))
                    user.PermissionFromTemplate = (bool)reader[prefix + "PermissionFromTemplate"];

            if (fieldNames.Contains(prefix + "CountryId"))
                if (!Convert.IsDBNull(reader[prefix + "CountryId"]))
                    user.CountryId = Convert.ToInt32(reader[prefix + "CountryId"]);

            if (fieldNames.Contains(prefix + "CountryCurrencyId"))
                if (!Convert.IsDBNull(reader[prefix + "CountryCurrencyId"]))
                    user.CountryCurrencyId = Convert.ToInt32(reader[prefix + "CountryCurrencyId"]);

            if (fieldNames.Contains(prefix + "LocationValidated"))
                if (!Convert.IsDBNull(reader[prefix + "LocationValidated"]))
                    user.LocationValidated = Convert.ToBoolean(reader[prefix + "LocationValidated"]);

            if (fieldNames.Contains(prefix + "VisibleOnMap"))
                if (!Convert.IsDBNull(reader[prefix + "VisibleOnMap"]))
                    user.VisibleOnMap = Convert.ToBoolean(reader[prefix + "VisibleOnMap"]);

            if (fieldNames.Contains(prefix + "Latitude"))
                if (!Convert.IsDBNull(reader[prefix + "Latitude"]))
                    user.Latitude = Convert.ToDouble(reader[prefix + "Latitude"]);

            if (fieldNames.Contains(prefix + "Longitude"))
                if (!Convert.IsDBNull(reader[prefix + "Longitude"]))
                    user.Longitude = Convert.ToDouble(reader[prefix + "Longitude"]);

            if (fieldNames.Contains(prefix + "GiftsPoints"))
                if (!Convert.IsDBNull(reader[prefix + "GiftsPoints"]))
                    user.GiftsPoints = Convert.ToDouble(reader[prefix + "GiftsPoints"]);

            if (fieldNames.Contains(prefix + "TotalReceivedGiftsPoints"))
                if (!Convert.IsDBNull(reader[prefix + "TotalReceivedGiftsPoints"]))
                    user.TotalReceivedGiftsPoints = Convert.ToDouble(reader[prefix + "TotalReceivedGiftsPoints"]);

            if (fieldNames.Contains(prefix + "TotalSentFromGiftsPoints"))
                if (!Convert.IsDBNull(reader[prefix + "TotalSentFromGiftsPoints"]))
                    user.TotalSentFromGiftsPoints = Convert.ToDouble(reader[prefix + "TotalSentFromGiftsPoints"]);

            if (fieldNames.Contains(prefix + "UserTypeName"))
                if (!Convert.IsDBNull(reader[prefix + "UserTypeName"]))
                    user.UserTypeName = reader[prefix + "UserTypeName"].ToString();

            if (fieldNames.Contains(prefix + "CompanyArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "CompanyArabicName"]))
                    user.CompanyArabicName = reader[prefix + "CompanyArabicName"].ToString();

            if (fieldNames.Contains(prefix + "CompanyEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "CompanyEnglishName"]))
                    user.CompanyEnglishName = reader[prefix + "CompanyEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "LocationArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "LocationArabicName"]))
                    user.LocationArabicName = reader[prefix + "LocationArabicName"].ToString();

            if (fieldNames.Contains(prefix + "LocationEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "LocationEnglishName"]))
                    user.LocationEnglishName = reader[prefix + "LocationEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "CityArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "CityArabicName"]))
                    user.CityArabicName = reader[prefix + "CityArabicName"].ToString();

            if (fieldNames.Contains(prefix + "CityEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "CityEnglishName"]))
                    user.CityEnglishName = reader[prefix + "CityEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "GovernorateArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "GovernorateArabicName"]))
                    user.GovernorateArabicName = reader[prefix + "GovernorateArabicName"].ToString();

            if (fieldNames.Contains(prefix + "GovernorateEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "GovernorateEnglishName"]))
                    user.GovernorateEnglishName = reader[prefix + "GovernorateEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "CountryArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "CountryArabicName"]))
                    user.CountryArabicName = reader[prefix + "CountryArabicName"].ToString();

            if (fieldNames.Contains(prefix + "CountryEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "CountryEnglishName"]))
                    user.CountryEnglishName = reader[prefix + "CountryEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "JobArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "JobArabicName"]))
                    user.JobArabicName = reader[prefix + "JobArabicName"].ToString();

            if (fieldNames.Contains(prefix + "JobEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "JobEnglishName"]))
                    user.JobEnglishName = reader[prefix + "JobEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "PositionArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "PositionArabicName"]))
                    user.PositionArabicName = reader[prefix + "PositionArabicName"].ToString();

            if (fieldNames.Contains(prefix + "PositionEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "PositionEnglishName"]))
                    user.PositionEnglishName = reader[prefix + "PositionEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "WorkDomainArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "WorkDomainArabicName"]))
                    user.WorkDomainArabicName = reader[prefix + "WorkDomainArabicName"].ToString();

            if (fieldNames.Contains(prefix + "WorkDomainEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "WorkDomainEnglishName"]))
                    user.WorkDomainEnglishName = reader[prefix + "WorkDomainEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "EducationLevelArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "EducationLevelArabicName"]))
                    user.EducationLevelArabicName = reader[prefix + "EducationLevelArabicName"].ToString();

            if (fieldNames.Contains(prefix + "EducationLevelEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "EducationLevelEnglishName"]))
                    user.EducationLevelEnglishName = reader[prefix + "EducationLevelEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "LunchCount"))
                if (!Convert.IsDBNull(reader[prefix + "LunchCount"]))
                    user.LunchCount = Convert.ToInt32(reader[prefix + "LunchCount"]);


            if (fieldNames.Contains(prefix + "CurrencyId"))
                if (!Convert.IsDBNull(reader[prefix + "CurrencyId"]))
                    user.CurrencyId = Convert.ToInt32(reader[prefix + "CurrencyId"]);

            if (fieldNames.Contains(prefix + "CurrencyArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "CurrencyArabicName"]))
                    user.CurrencyArabicName = reader[prefix + "CurrencyArabicName"].ToString();

            if (fieldNames.Contains(prefix + "CurrencyEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "CurrencyEnglishName"]))
                    user.CurrencyEnglishName = reader[prefix + "CurrencyEnglishName"].ToString();

            if (fieldNames.Contains(prefix + "MobileCountryCode"))
                if (!Convert.IsDBNull(reader[prefix + "MobileCountryCode"]))
                    user.MobileCountryCode = reader[prefix + "MobileCountryCode"].ToString();

            if (fieldNames.Contains(prefix + "HasOpenCart"))
                if (!Convert.IsDBNull(reader[prefix + "HasOpenCart"]))
                    user.HasOpenCart = (bool)reader[prefix + "HasOpenCart"];

            if (fieldNames.Contains(prefix + "OrdersPointsFromGifts"))
                if (!Convert.IsDBNull(reader[prefix + "OrdersPointsFromGifts"]))
                    user.OrdersPointsFromGifts = Convert.ToDouble(reader[prefix + "OrdersPointsFromGifts"]);

            if (fieldNames.Contains(prefix + "AccessToken"))
                if (!Convert.IsDBNull(reader[prefix + "AccessToken"]))
                    user.AccessToken = reader[prefix + "AccessToken"].ToString();

            if (fieldNames.Contains(prefix + "Street"))
                if (!Convert.IsDBNull(reader[prefix + "Street"]))
                    user.Street = reader[prefix + "Street"].ToString();

            if (fieldNames.Contains(prefix + "BlockNo"))
                if (!Convert.IsDBNull(reader[prefix + "BlockNo"]))
                    user.BlockNo = reader[prefix + "BlockNo"].ToString();

            if (fieldNames.Contains(prefix + "ApartmentNo"))
                if (!Convert.IsDBNull(reader[prefix + "ApartmentNo"]))
                    user.ApartmentNo = reader[prefix + "ApartmentNo"].ToString();

            if (fieldNames.Contains(prefix + "Floor"))
                if (!Convert.IsDBNull(reader[prefix + "Floor"]))
                    user.Floor = reader[prefix + "Floor"].ToString();

            if (fieldNames.Contains(prefix + "AddressNote"))
                if (!Convert.IsDBNull(reader[prefix + "AddressNote"]))
                    user.AddressNote = reader[prefix + "AddressNote"].ToString();

            if (fieldNames.Contains(prefix + "Building"))
                if (!Convert.IsDBNull(reader[prefix + "Building"]))
                    user.Building = reader[prefix + "Building"].ToString();

            if (fieldNames.Contains(prefix + "CurrentBranchId"))
                if (!Convert.IsDBNull(reader[prefix + "CurrentBranchId"]))
                    user.CurrentBranchId = (int)reader[prefix + "CurrentBranchId"];

            if (fieldNames.Contains(prefix + "CurrentBranchArabicName"))
                if (!Convert.IsDBNull(reader[prefix + "CurrentBranchArabicName"]))
                    user.CurrentBranchArabicName = reader[prefix + "CurrentBranchArabicName"].ToString();

            if (fieldNames.Contains(prefix + "CurrentBranchEnglishName"))
                if (!Convert.IsDBNull(reader[prefix + "CurrentBranchEnglishName"]))
                    user.CurrentBranchEnglishName = reader[prefix + "CurrentBranchEnglishName"].ToString();



            if (fieldNames.Contains(prefix + "AccountNumber"))
                if (!Convert.IsDBNull(reader[prefix + "AccountNumber"]))
                    user.AccountNumber = reader[prefix + "AccountNumber"].ToString();

            if (fieldNames.Contains(prefix + "CardNumber"))
                if (!Convert.IsDBNull(reader[prefix + "CardNumber"]))
                    user.CardNumber = reader[prefix + "CardNumber"].ToString();

            if (fieldNames.Contains(prefix + "CardType"))
                if (!Convert.IsDBNull(reader[prefix + "CardType"]))
                    user.CardType = reader[prefix + "CardType"].ToString();

            if (fieldNames.Contains(prefix + "MaritalStatus"))
                if (!Convert.IsDBNull(reader[prefix + "MaritalStatus"]))
                    user.MaritalStatus = reader[prefix + "MaritalStatus"].ToString();

            if (fieldNames.Contains(prefix + "Nationality"))
                if (!Convert.IsDBNull(reader[prefix + "Nationality"]))
                    user.Nationality = reader[prefix + "Nationality"].ToString();

            if (fieldNames.Contains(prefix + "MobileNumber2"))
                if (!Convert.IsDBNull(reader[prefix + "MobileNumber2"]))
                    user.MobileNumber2 = reader[prefix + "MobileNumber2"].ToString();

            if (fieldNames.Contains(prefix + "ChildCount"))
                if (!Convert.IsDBNull(reader[prefix + "ChildCount"]))
                    user.ChildCount = reader[prefix + "ChildCount"].ToString();

            if (fieldNames.Contains(prefix + "FilterByCountry"))
                if (!Convert.IsDBNull(reader[prefix + "FilterByCountry"]))
                    user.FilterByCountry = Convert.ToBoolean(reader[prefix + "FilterByCountry"]);

            if (fieldNames.Contains(prefix + "IsVerified"))
                if (!Convert.IsDBNull(reader[prefix + "IsVerified"]))
                    user.IsVerified = Convert.ToBoolean(reader[prefix + "IsVerified"]);


            if (fieldNames.Contains(prefix + "BalanceLimit"))
                if (!Convert.IsDBNull(reader[prefix + "BalanceLimit"]))
                    user.BalanceLimit = Convert.ToDouble(reader[prefix + "BalanceLimit"]);

            if (fieldNames.Contains(prefix + "Removed"))
                if (!Convert.IsDBNull(reader[prefix + "Removed"]))
                    user.Removed = (bool)reader[prefix + "Removed"];


            return user;
        }


        public static void PopulateUserReportForExcelHeaders(int LoggedUser, ExcelWorksheet worksheet, int offset, List<string> columnNameList)
        {
            //Clean Column Name
            var cleanColumnList = new List<string>();

            cleanColumnList = columnNameList;
            #region EnglishHeaderTemp

            headerRow[0] = cleanColumnList.ToArray();

            var lastAlpha = ServiceMethod.GetExcelColumnName(headerRow[0].Length);
            var englishheaderRange = "A" + (offset) + ":" + lastAlpha + (offset);
            worksheet.Cells[englishheaderRange].LoadFromArrays(headerRow);

            #endregion

            //Get Column Name in Arabic
            var resourceResult = ServiceMethod.GetTranslatedResource(cleanColumnList).Result;

            //Sort based on User Column Order
            //var orderedList = resourceResult.OrderBy(b => cleanColumnList.FindIndex(a => a == b.Keyword));

            var orderedList = from i in cleanColumnList
                              join o in resourceResult
                              on i.ToLower() equals o.Keyword.ToLower()
                              select o;

            var ColumnList = orderedList.Select(x => x.ArabicName);

            // return the result back to "headerRow"
            headerRow[0] = ColumnList.ToArray();

            // Determine the header range (e.g. A1:D1)
            // Popular header row data
            lastAlpha = ServiceMethod.GetExcelColumnName(headerRow[0].Length);
            string headerRange = "A" + offset + ":" + lastAlpha + offset;

            worksheet.Cells[headerRange].LoadFromArrays(headerRow);

            ExcelRange Rng = worksheet.Cells[headerRange];
            Rng.Style.Font.Bold = true;
            Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
            Rng.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            Rng.Style.Font.Color.SetColor(Color.Black);
            Rng.Style.ShrinkToFit = true;

            Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
            Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
            Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
            Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

        }

        public Dictionary<string, string> PopulateUserReportForExcel(string[] fieldNames, SqlDataReader reader, ExcelWorksheet worksheet, List<string> columnList, int lineInWorksheet)
        {
            //Fix ColumnList Naming  --> replace "." with "_" 
            var newColumnList = columnList.Select(s => s.Replace(".", "_")).ToList();

            var data = new Dictionary<string, string>();

            var UserboolPropList = ServiceMethod.GetClassBooleanProp(new UserClass());
            foreach (var column in newColumnList)
            {
                if (fieldNames.Contains(column))
                {
                    if (!Convert.IsDBNull(reader[column]))
                    {
                        //add check for gender and true false value and replace them 
                        if (column == "Gender")
                        {
                            string gender = String.Empty;
                            if (Convert.ToInt32(reader[column]) == 1)
                                gender = "ذكر";
                            else if (Convert.ToInt32(reader[column]) == 2)
                                gender = "انثى";

                            data.Add(column, gender);
                        }
                        else if (UserboolPropList.Contains(column.Substring(column.LastIndexOf('_') + 1)))
                        {
                            string boolText = String.Empty;

                            if (Convert.ToInt32(reader[column]) == 0)
                                boolText = "لا";
                            else if (Convert.ToInt32(reader[column]) == 1)
                                boolText = "نعم";

                            data.Add(column, boolText);
                        }
                        else //other column
                        {
                            data.Add(column, reader[column].ToString());
                        }
                    }
                    else //the column value is null
                    { data.Add(column, ""); }
                }
            }

            return data;
        }

    }

    [DataContract]
    public class UserClass_Short
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Username { get; set; }
        [DataMember(Order = 3)]
        public string FullName { get; set; }
        [DataMember(Order = 4)]
        public string NickName { get; set; }
        [DataMember(Order = 7)]
        public double Latitude { get; set; }
        [DataMember(Order = 8)]
        public double Longitude { get; set; }
        [DataMember(Order = 9)]
        public int Order { get; set; }
        [DataMember(Order = 10)]
        public string MobileCountryCode { get; set; }

        [DataMember(Order = 40)]
        public int CountryId { get; set; }

        [DataMember(Order = 13)]
        public int GovernorateId { get; set; }
        [DataMember(Order = 14)]
        public int CityId { get; set; }
        [DataMember(Order = 15)]
        public int LocationId { get; set; }
        [DataMember(Order = 16)]
        public string Address1 { get; set; }
        [DataMember(Order = 17)]
        public string Address2 { get; set; }


        [DataMember(Order = 78)]
        public string AddressNote { get; set; }
        [DataMember(Order = 52)]
        public string LocationArabicName { get; set; }
        [DataMember(Order = 53)]
        public string LocationEnglishName { get; set; }
        [DataMember(Order = 54)]
        public string CityArabicName { get; set; }
        [DataMember(Order = 55)]
        public string CityEnglishName { get; set; }
        [DataMember(Order = 56)]
        public string GovernorateArabicName { get; set; }
        [DataMember(Order = 57)]
        public string GovernorateEnglishName { get; set; }

        [DataMember(Order = 58)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 59)]
        public string CountryEnglishName { get; set; }
        [DataMember(Order = 59)]
        public bool Removed { get; set; }



        public UserClass_Short PopulateUser(UserClass user)
        {
            var result = new UserClass_Short
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
                NickName = user.NickName,
                Latitude = user.Latitude,
                Longitude = user.Longitude,
                MobileCountryCode = user.MobileCountryCode,
                Order = user.Order,


                Address1 = user.Address1,
                Address2 = user.Address2,
                AddressNote = user.AddressNote,

                GovernorateId = user.GovernorateId,
                CityId = user.CityId,
                LocationId = user.LocationId,
                CountryId = user.CountryId,


                GovernorateArabicName = user.GovernorateArabicName,
                GovernorateEnglishName = user.GovernorateEnglishName,
                LocationArabicName = user.LocationArabicName,
                LocationEnglishName = user.LocationEnglishName,
                CityArabicName = user.CityArabicName,
                CityEnglishName = user.CityEnglishName,
                CountryArabicName = user.CountryArabicName,
                CountryEnglishName = user.CountryEnglishName,
                Removed = user.Removed



            };

            return result;
        }

        public List<UserClass_Short> PopulateUsers(List<UserClass> users)
        {
            List<UserClass_Short> resultList = new List<UserClass_Short>();
            if (users != null)
            {
                foreach (var user in users)
                {
                    resultList.Add(new UserClass_Short
                    {
                        Id = user.Id,
                        Username = user.Username,
                        FullName = user.FullName,
                        NickName = user.NickName,
                        Latitude = user.Latitude,
                        Longitude = user.Longitude,
                        MobileCountryCode = user.MobileCountryCode,
                        Order = user.Order,

                        Address1 = user.Address1,
                        Address2 = user.Address2,
                        AddressNote = user.AddressNote,

                        GovernorateId = user.GovernorateId,
                        CityId = user.CityId,
                        LocationId = user.LocationId,
                        CountryId = user.CountryId,


                        GovernorateArabicName = user.GovernorateArabicName,
                        GovernorateEnglishName = user.GovernorateEnglishName,
                        LocationArabicName = user.LocationArabicName,
                        LocationEnglishName = user.LocationEnglishName,
                        CityArabicName = user.CityArabicName,
                        CityEnglishName = user.CityEnglishName,
                        CountryArabicName = user.CountryArabicName,
                        CountryEnglishName = user.CountryEnglishName,
                        Removed = user.Removed
                    });
                }
            }
            if (resultList.Count > 0)
                return resultList;
            else
                return null;
        }

    }
}