using PointsSystemWebService.Classes.Authentication;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PointsSystemWebService.Classes.Core
{
    public static class Signin
    {
        public static ResultClass<UserClass> InitializeLogin(LoginClass Login)
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
                    cmd.CommandText = "Login";

                    string Password = "";
                    if (Login.Password.Trim() != "")
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Login.Password, "MD5");


                    List<SqlParameter> Params = new List<SqlParameter>()
                    {
                        new SqlParameter("Username", Login.Username),
                        new SqlParameter("Password", Password),
                        new SqlParameter("MobileCountryCode", Login.MobileCountryCode)
                    };

                    cmd.Parameters.AddRange(Params.ToArray());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                        reader.Read();
                        UserClass user = new UserClass().PopulateUser(fieldNames, reader);

                        if (fieldNames.Contains("AccessToken"))
                            if (!Convert.IsDBNull(reader["AccessToken"]))
                                user.AccessToken = reader["AccessToken"].ToString();

                        user.Order = 1;

                         result.Code = Errors.Success;
                        result.Result = user;
                        return result;
                    }
                    else
                    {
                         result.Code = Errors.Success;
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
                    Errors.LogError(-1, e.Message, e.StackTrace, "1.0.3", "API", "GetUsers", e.Source, "Login");
                }
                result.Result = null;
                return result;
            }
        }

        public static ResultClass<UserClass> InitializeAppLogin(LoginClass Login)
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
                    cmd.CommandText = "AppLogin";

                    string Password = "";
                    if (Login.Password.Trim() != "")
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Login.Password, "MD5");


                    List<SqlParameter> Params = new List<SqlParameter>()
                    {
                        new SqlParameter("Username", Login.Username.TrimStart('0')),
                        new SqlParameter("Password", Password),
                        new SqlParameter("MobileCountryCode", Login.MobileCountryCode)
                    };

                    cmd.Parameters.AddRange(Params.ToArray());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        reader.Read();
                        UserClass user = new UserClass().PopulateUser(fieldNames, reader);

                        if (fieldNames.Contains("AccessToken"))
                            if (!Convert.IsDBNull(reader["AccessToken"]))
                                user.AccessToken = reader["AccessToken"].ToString();

                        user.Order = 1;

                         result.Code = Errors.Success;
                        result.Result = user;
                        return result;
                    }
                    else
                    {
                         result.Code = Errors.Success;
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
                    Errors.LogError(-1, e.Message, e.StackTrace, "1.0.3", "API", "AppLogin", e.Source, "");
                }
                result.Result = null;
                return result;
            }
        }

    }
}