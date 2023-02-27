using Nexmo.Api;
using PointsSystemWebService.Classes;
using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web;

namespace PointsSystemWebService
{
   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DeveloperAPI" in code, svc and config file together.
   // NOTE: In order to launch WCF Test Client for testing this service, please select DeveloperAPI.svc or DeveloperAPI.svc.cs at the Solution Explorer and start debugging.
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class DeveloperAPI : IDeveloperAPI
   {
      //TESTING Shoud be deleted on Release
      public ResultClass<CheckMobileVerificationCodeClass> CheckMobileVerificationCode_Test(string MobileNo, string requestid, string code)
      {
         ResultClass<CheckMobileVerificationCodeClass> result = new ResultClass<CheckMobileVerificationCodeClass>();
         try
         {
            result.Result = new CheckMobileVerificationCodeClass();
            NumberVerify.CheckResponse check = new NumberVerify.CheckResponse { status = "0" };
            result.Result.status = "0";
            if (check.status != "0")
            {
               if (check.status == "10")
                  result.Result.error_text =
                     "لا يسمح بالتحققات المتزامنة لنفس الرقم. يرجى الإنتظار لمدة 10 دقائق و إعادة المحاولة";
               else if (check.status == "16")
                  result.Result.error_text = "الرمز المدخل غير صحيح. يرجى إعادة المحاولة بعد 5 دقائق";
               else if (check.status == "17")
                  result.Result.error_text =
                     "تم إدخال الرمز بشكل خاطئ ثلاث مرات يرجى  الإنتظار لمدة 10 دقائق و إعادة المحاولة";
               else
                  result.Result.error_text =
                     "خطأ غير معروف. يرجى إعادة المحاولة قد يكون الخطأ بسبب مشكلة في الشبكة أو الإتصال" + " " +
                     check.error_text;
               result.Message = result.Result.error_text;
               result.Result.IsAlreadyRegistered = false;
               result.Result.User = null;
               return result;
            }
            else
            {
               try
               {
                  using (SqlConnection conn = ConnectionClass.GetDataConnection())
                  {
                     conn.Open();
                     SqlCommand cmd = new SqlCommand();
                     cmd.Connection = conn;
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     cmd.CommandText = "Admin_GetUserByMobileNumber";
                     List<SqlParameter> Params = new List<SqlParameter>()
                     {
                        new SqlParameter("MobileNumber", MobileNo)
                     };

                     cmd.Parameters.AddRange(Params.ToArray());
                     SqlDataReader reader = cmd.ExecuteReader();

                     if (reader.HasRows)
                     {
                        UserClass user;
                        reader.Read();
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        user = new UserClass().PopulateUser(fieldNames, reader);

                        user.Order = 1;

                         result.Code = Errors.Success;
                        result.Message = "";
                        result.Result.IsAlreadyRegistered = true;
                        result.Result.User = user;

                        return result;
                     }
                     else
                     {
                         result.Code = Errors.Success;
                        result.Message = "";
                        result.Result.IsAlreadyRegistered = false;
                        result.Result.User = null;
                        return result;
                     }
                  }
               }
               catch (Exception e)
               {
                  int errorcode;
                  if (Int32.TryParse(e.Message, out errorcode))
                  {
                     result.Code = errorcode;
                     result.Message = Errors.GetErrorMessage(errorcode);
                  }
                  else
                  {
                      result.Code = Errors.UnknownError;
                     result.Message = Errors.GetErrorMessage(result.Code);
                     Errors.LogError(-1, e.Message, e.StackTrace, "1.0.3", "API", "CheckMobileVerificationCode",
                        e.Source, "");
                  }
                  result.Result = null;
                  return result;
               }
            }
         }
         catch (Exception e)
         {
             result.Code = Errors.UnknownError;
            result.Message = "Error";
            result.Result = null;
            Errors.LogError(-1, e.Message, e.StackTrace, "1.0.3", "API", "CheckMobileVerificationCode", e.Source, "");
            return result;
         }
      }

      public void deleteUserColumn_Fortesting()
      {
         using (SqlConnection conn = ConnectionClass.GetDataConnection())
         {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Admin_DeleteUserColumn_ForTesting";

            SqlDataReader reader = cmd.ExecuteReader();

         }
      }


      public ResultClass<UserClass> DeleteUser_Dev(int UserId, string MobileNumber)
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
               cmd.CommandText = "Admin_DeleteUser_Dev";


               List<SqlParameter> Params = new List<SqlParameter>()
               {
                  new SqlParameter("LoggedUser", 7)
               };

               if (UserId > 0)
                  cmd.Parameters.Add(new SqlParameter("Id", UserId));

               if (!string.IsNullOrWhiteSpace(MobileNumber))
                  cmd.Parameters.Add(new SqlParameter("MobileNumber", MobileNumber));

               cmd.Parameters.AddRange(Params.ToArray());
               SqlDataReader reader = cmd.ExecuteReader();
               if (reader.HasRows)
               {
                  var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                  reader.Read();

                  UserClass user = new UserClass().PopulateUser(fieldNames, reader);

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
               Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "DeleteUser", e.Source, "");
            }
            result.Result = null;
            return result;
         }
      }


   }
}
