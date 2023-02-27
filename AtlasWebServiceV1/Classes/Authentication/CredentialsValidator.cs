using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PointsSystemWebService.Classes.Authentication
{
    /// <summary>
    /// When I wrote this, only God and I understood what I was doing
    /// Now, God only knows
    /// </summary>

    public static class CredentialsValidator
    {
        public static ResultClass<string> Authenticate(LoginClass Credentials)
        {
            ResultClass<string> result = new ResultClass<string>();

            if (IsValid(Credentials))
            {
                result.Code = Errors.Success;
                result.Message = "";
                result.Result = new TokenBuilder().Build(Credentials);
                return result;
            }
            else
            {
                return UnAuthorizeAccess(Errors.NotValidAccessToken);
            }
        }

        public static bool IsValid(LoginClass creds)
        {
            var apiResult = GetUserData(creds);

            if (apiResult.Code != Errors.Success)
                return false;
            if (apiResult.Result == null)
                return false;
            if (creds.Username != apiResult.Result.Username)
                return false;

            //Pass!!
            return true;
        }

        public static int IsValidTokenInDB(LoginClass creds, string token)
        {
            var apiResult = GetUserData(creds);
            if (apiResult != null)
            {
                try
                {
                    if (apiResult?.Code != Errors.Success) //added to return error code
                        return apiResult.Code;

                    if (apiResult?.Result?.AccessToken == token)
                        return Errors.Success;
                }
                catch (Exception)
                {

                } //it will throw exception in case code =200 cause result =null
            }
            return Errors.NotValidAccessToken;
        }

        public static ResultClass<UserClass> GetUserData(LoginClass creds)
        {
            bool SystemWasDown = false;
            if (!Config.IsSystemUp)
            { ServiceMethod.ActivateSystem(); SystemWasDown = true; }

            var result = Signin.InitializeLogin(creds); //We can use "InitializeLogin" or "InitializeAppLogin"

            if (SystemWasDown)
                ServiceMethod.DeactivateSystem();

            return result;
        }

        public static ResultClass<string> UnAuthorizeAccess(int code = Errors.NotValidAccessToken)
        {
            ResultClass<string> result = new ResultClass<string>();

            result.Code = code;
            result.Message = Errors.GetErrorMessage(result.Code);
            result.Result = null;

            return result;
        }


        public static string UnAuthorizeAccessJson(int code)
        {
            string mName = "";
            var urlPath = HttpContext.Current.Request.Url.PathAndQuery;

            /*Yazan 12-08-2017 : returned MethodName + "Result" so it will appear on client side 
            as if the same method returned the accesstoken error so client's won't have check the returned json method name
            */
            int lastSlashIndex = urlPath.LastIndexOf(@"/");
            int firstQuestionMarkIndex = urlPath.IndexOf(@"?");

            if (firstQuestionMarkIndex == -1)
                firstQuestionMarkIndex = urlPath.Length;

            if ((lastSlashIndex > 0) && (firstQuestionMarkIndex >= 0))
            {
                int methodNameLen = firstQuestionMarkIndex - lastSlashIndex;

                var methodName2 = urlPath.Substring(lastSlashIndex + 1, methodNameLen - 1);

                if (methodName2 != null)
                {
                    mName = methodName2;
                }

                var result = UnAuthorizeAccess(code);
                //        var json = new JavaScriptSerializer().Serialize(result);
                //Yazan 11-08-2017 to Return Method name in the JSON Format so deserializer on clients won't return NULL when parsing method name
                var json = "{\"" + mName + "Result" + "\":{" + "\"Code" + "\":" + result.Code + ",\"Message" + "\":" + "\"" + result.Message + "\"," + "\"Result" + "\":null" + "}}";
                return json;
            }
            else
                return "";
        }

    }
}