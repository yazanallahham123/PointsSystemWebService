using CipherLibrary.Cipher;
using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes.Authentication
{
    /// <summary>
    /// When I wrote this, only God and I understood what I was doing
    /// Now, God only knows
    /// </summary>
    public class TokenBuilder
    {
        public static string SaltsToken = "{B709CE08-D2DE-4201-962B-3BBAC74C5952}";
        public string Build(LoginClass creds)
        {
            var dbResult = CredentialsValidator.GetUserData(creds).Result;
            dbResult.Password = creds.Password; //Add password to UserClass Result

            return GenerateToken(dbResult);
        }

        /// <summary>
        /// Don't Use This one !!!! To Make sure your request go through the right pipeline
        /// Use "Build()" instead
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GenerateToken(UserClass user)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            string plainText = user.Username + '-' + user.Password + '-' + user.Id + '-' + user.MobileCountryCode + '-' + rand.Next();

            //Encrypt
            return StringCipher.Encrypt(plainText, SaltsToken);
        }

        public ResultClass<UserClass> UpdateToken(int LoggedUser, UserClass User)
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
                    cmd.CommandText = "Admin_UpdateToken";

                    List<SqlParameter> Params = new List<SqlParameter>()
                    {
                        new SqlParameter("Id", User.Id),
                        new SqlParameter("AccessToken", User.AccessToken)
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
                    Errors.LogError(LoggedUser, e.Message, e.StackTrace, "1.0.3", "API", "UpdateToken", e.Source, "");
                }
                result.Result = null;
                return result;
            }
        }
    }
}