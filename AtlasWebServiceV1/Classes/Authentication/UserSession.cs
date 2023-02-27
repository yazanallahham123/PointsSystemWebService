using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes.Authentication
{
   public class UserSession
   {
      public static ResultClass<SessionClass> UpdateUserSession(int LoggedUser)
      {
         ResultClass<SessionClass> result = new ResultClass<SessionClass>();

         if (Config.ExcludedMethodName.Contains(Config.GetRequestMethodName()))
         {
             result.Code = Errors.Success;
            result.Message = "";
            result.Result = null;
            return result;
         }

         try
         {
            using (SqlConnection conn = ConnectionClass.GetDataConnection())
            {
               conn.Open();
               SqlCommand cmd = new SqlCommand();
               cmd.Connection = conn;
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.CommandText = "Admin_UpdateUserSession";

               List<SqlParameter> Params = new List<SqlParameter>()
                  {new SqlParameter("LoggedUser",LoggedUser)};

               cmd.Parameters.AddRange(Params.ToArray());

               SqlDataReader reader = cmd.ExecuteReader();
               if (reader.HasRows)
               {
                  SessionClass userSession;
                  int order = 0;
                  reader.Read();
                  {
                     order += 1;
                     var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                     userSession = new SessionClass().PopulateSessionClass(fieldNames, reader);

                     userSession.Order = order;
                  }
                   result.Code = Errors.Success;
                  result.Message = "";
                  result.Result = userSession;
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
               Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "UpdateUserSession", e.Source, "");
            }
            result.Result = null;
            return result;
         }
      }



   }
}