using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class NotificationsHelperClass
    {
        public static ResultClass<List<NotificationTypesClass>> GetNotificationsTypes()
        {
            ResultClass<List<NotificationTypesClass>> result = new ResultClass<List<NotificationTypesClass>>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetNotificationsTypes";
                    SqlParameter Param = new SqlParameter("LoggedUser", "7");
                    cmd.Parameters.Add(Param);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                        List<NotificationTypesClass> typesList = new List<NotificationTypesClass>();
                        NotificationTypesClass notificationType;
                        int order = 0;
                        while (reader.Read())
                        {
                            order += 1;
                            notificationType = new NotificationTypesClass().PopulateNotificationType(fieldNames, reader);

                            notificationType.Order = order;
                            typesList.Add(notificationType);
                        }

                        result.Message = "";
                         result.Code = Errors.Success;
                        result.Result = typesList;
                        return result;
                    }
                    else
                    {
                         result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = null;
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
                }
                result.Result = null;
                return result;
            }
        }

        public static ResultClass<List<int>> GetAdminNotificationsUsers(int NotificationTypeId)
        {
            ResultClass<List<int>> result = new ResultClass<List<int>>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetAdminNotificationsReceivers";
                    SqlParameter Param = new SqlParameter("NotificationTypeId", NotificationTypeId);
                    cmd.Parameters.Add(Param);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                        List<int> usersList = new List<int>();
                        while (reader.Read())
                        {
                            if (fieldNames.Contains("Id"))
                                if (!Convert.IsDBNull(reader["Id"]))
                                    usersList.Add((int)reader["Id"]);
                        }

                        result.Message = "";
                         result.Code = Errors.Success;
                        result.Result = usersList;
                        return result;
                    }
                    else
                    {
                         result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = null;
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
                }
                result.Result = null;
                return result;
            }
        }

        public static ResultClass<List<string>> GetAdminNotificationsUsersEmail(int NotificationTypeId)
        {
            ResultClass<List<string>> result = new ResultClass<List<string>>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetAdminNotificationsReceivers";
                    SqlParameter Param = new SqlParameter("NotificationTypeId", NotificationTypeId);
                    cmd.Parameters.Add(Param);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                        List<string> usersList = new List<string>();
                        while (reader.Read())
                        {
                            if (fieldNames.Contains("Email"))
                                if (!Convert.IsDBNull(reader["Email"]))
                                    if (reader["Email"].ToString() != null)
                                        if (reader["Email"].ToString().Trim() != "")
                                            usersList.Add(reader["Email"].ToString());
                        }

                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = usersList;
                        return result;
                    }
                    else
                    {
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = null;
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
                }
                result.Result = null;
                return result;
            }
        }

        public static ResultClass<NotificationClass> CreateNotification(NotificationClass Notification)
        {
            ResultClass<NotificationClass> result = new ResultClass<NotificationClass>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_InsertNotification";
                    List<SqlParameter> Params = new List<SqlParameter>()
                    {
                        new SqlParameter("LoggedUser", HttpContext.Current.Request.Headers["LoggedUser"]),
                        new SqlParameter("Title", Notification.NotificationTitle),
                        new SqlParameter("Content", Notification.NotificationContent),
                        new SqlParameter("TypeId", Notification.Type),
                        new SqlParameter("UserId", Notification.ToUser),
                    };

                    if (Notification.ReferenceType != null)
                        Params.Add(new SqlParameter("ReferenceType", Notification.ReferenceType));

                    if (Notification.ReferenceId != null)
                        Params.Add(new SqlParameter("ReferenceId", Notification.ReferenceId));
                    
                    cmd.Parameters.AddRange(Params.ToArray()); 
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        NotificationClass n = new NotificationClass();    
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                        reader.Read();
                        {
                            n.PopulateNotification(fieldNames, reader);
                        }

                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = n;
                        return result;
                    }
                    else
                    {
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = null;
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
                }
                result.Result = null;
                return result;
            }
        }
    }
}