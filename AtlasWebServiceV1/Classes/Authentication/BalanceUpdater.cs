using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes.Authentication
{
    public class BalanceUpdater
    {
        public static ResultClass<UserClass> SendUpdatedBalance(int LoggedUser)
        {
            return GetUserPoints(LoggedUser);
        }

        private static ResultClass<UserClass> GetUserPoints(int LoggedUser)
        {
            ResultClass<UserClass> result = new ResultClass<UserClass>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetUsers";
                    SqlParameter Param = new SqlParameter("UserId", LoggedUser);
                    cmd.Parameters.Add(Param);
                    Param = new SqlParameter("LoggedUser", LoggedUser);
                    cmd.Parameters.Add(Param);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                        List<UserClass> Users = new List<UserClass>();
                        UserClass user;
                        reader.Read();
                        user = new UserClass().PopulateUser(fieldNames, reader);


                         result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = user;
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
                    Errors.LogError(LoggedUser, e.Message, e.StackTrace, "1.0.3", "API", "GetUser", e.Source, "");
                }
                result.Result = null;
                return result;
            }
        }

        public static ResultClass<UserBadgesClass> GetUserBadges(int LoggedUser)
        {
            ResultClass<UserBadgesClass> result = new ResultClass<UserBadgesClass>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetUserBadges";

                    List<SqlParameter> Params = new List<SqlParameter>()
                    {
                       new SqlParameter("LoggedUser", LoggedUser),
                    };

                    cmd.Parameters.AddRange(Params.ToArray());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        UserBadgesClass userBadge;
                        reader.Read();
                        userBadge = new UserBadgesClass().PopulateUserBadges(fieldNames, reader);


                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = userBadge;
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
                    Errors.LogError(-1, e.Message, e.StackTrace, "1.0.3", "API", "GetUserBadges", e.Source, "");
                }
                result.Result = null;
                return result;
            }
        }
    }
}