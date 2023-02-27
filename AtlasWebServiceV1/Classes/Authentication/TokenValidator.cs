using CipherLibrary.Cipher;
using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes.Authentication
{
    /// <summary>
    /// Dear maintainer:
    /// Once you are done trying to 'optimize' this routine,
    /// and have realized what a terrible mistake that was,
    /// please increment the following counter as a warning to the next guy:
    /// 
    /// total_hours_wasted_here = 42
    /// </summary>

    public static class TokenValidator
    {
        /*public static int IsValidateToken()
        {
            var token = HttpContext.Current.Request.Headers["AccessToken"];
            var Register = HttpContext.Current.Request.Headers["Register"];
            //Check If Login, AppLogin or GetAppName Methods are being called So it's okay to not have the Access Token
            var urlPath = HttpContext.Current.Request.Url.PathAndQuery;


            if (HttpContext.Current.Request.Url.PathAndQuery.StartsWith("/v1/rest"))
            {
                return Errors.Success;
            }

            if (HttpContext.Current.Request.Url.PathAndQuery.StartsWith("/api-docs"))
            {
                return Errors.Success;
            }
            if (HttpContext.Current.Request.Url.PathAndQuery == ("/PointsServiceAPI.svc"))
            {
                return Errors.Success;
            }
            if (HttpContext.Current.Request.Url.PathAndQuery.StartsWith("/PointsServiceAPI.svc?"))
            {
                return Errors.Success;
            }


            string mName = "";
            int lastSlashIndex = urlPath.LastIndexOf(@"/");
            int firstQuestionMarkIndex = urlPath.IndexOf(@"?");

            if (firstQuestionMarkIndex == -1)
                firstQuestionMarkIndex = urlPath.Length;

            if ((lastSlashIndex >= 0) && (firstQuestionMarkIndex >= 0))
            {
                int methodNameLen = firstQuestionMarkIndex - lastSlashIndex;

                var methodName2 = urlPath.Substring(lastSlashIndex + 1, methodNameLen - 1);

                if (methodName2 != null)
                {
                    mName = methodName2;
                }
            }

            if (mName != "")
            {
                if ((mName == "UpdateUser") && (!String.IsNullOrEmpty(Register)))
                    if (Register == "true")
                        return Errors.Success;

                if (Config.ExcludedMethodName.Contains(mName, StringComparer.OrdinalIgnoreCase)) //Check request method name if it's in Excluded List
                    return Errors.Success;
            }

            if (token != null)
            {
                return IsValid(token);
            }

            return Errors.NotValidAccessToken; //"Your token failed!"
        }*/

        public static int IsValidateToken()
        {
            var token = HttpContext.Current.Request.Headers["AccessToken"];
            var Register = HttpContext.Current.Request.Headers["Register"];
            //var IsDeliveryUser = HttpContext.Current.Request.Headers["IsDeliveryUser"];
            //Check If Login, AppLogin or GetAppName Methods are being called So it's okay to not have the Access Token
            var urlPath = HttpContext.Current.Request.Url.PathAndQuery;


            /*if (HttpContext.Current.Request.Url.PathAndQuery.ToLower().StartsWith("/api/v1/rest"))
            {
                return Errors.Success;
            }

            if (HttpContext.Current.Request.Url.PathAndQuery.ToLower().StartsWith("/api/api-docs"))
            {
                return Errors.Success;
            }
            if (HttpContext.Current.Request.Url.PathAndQuery.ToLower() == ("/api/pointsserviceapi.svc"))
            {
                return Errors.Success;
            }
            if (HttpContext.Current.Request.Url.PathAndQuery.ToLower().StartsWith("/api/pointsserviceapi.svc?"))
            {
                return Errors.Success;
            }*/

            if ((HttpContext.Current.Request.Url.PathAndQuery.ToLower().StartsWith("/api/pointsserviceapi.svc/json/")) || (HttpContext.Current.Request.Url.PathAndQuery.ToLower().StartsWith("/pointsserviceapi.svc/json/")))
            {
                string mName = "";
                int lastSlashIndex = urlPath.LastIndexOf(@"/");
                int firstQuestionMarkIndex = urlPath.IndexOf(@"?");

                if (firstQuestionMarkIndex == -1)
                    firstQuestionMarkIndex = urlPath.Length;

                if ((lastSlashIndex >= 0) && (firstQuestionMarkIndex >= 0))
                {
                    int methodNameLen = firstQuestionMarkIndex - lastSlashIndex;

                    var methodName2 = urlPath.Substring(lastSlashIndex + 1, methodNameLen - 1);

                    if (methodName2 != null)
                    {
                        mName = methodName2;
                    }
                }

                if (mName != "")
                {
                    if ((mName == "UpdateUser") && (!String.IsNullOrEmpty(Register)))
                        if (Register == "true")
                            return Errors.Success;

                    if (Config.ExcludedMethodName.Contains(mName, StringComparer.OrdinalIgnoreCase)) //Check request method name if it's in Excluded List
                        return Errors.Success;
                }

                if (token != null)
                {
                    return IsValid(token);
                }

                return Errors.NotValidAccessToken; //"Your token failed!"
            }

            return Errors.Success;
        }

        private static int IsValid(string token)
        {
            try
            {//Decrypt
                string decryptedstring = StringCipher.Decrypt(token, TokenBuilder.SaltsToken);
                return CheckCredentials(decryptedstring, token);
            }
            catch (Exception)
            {
                return Errors.NotValidAccessToken;
            }
        }

        private static int CheckCredentials(string text, string token)
        {
            string userName = text.Split('-')[0].ToLower();
            string password = text.Split('-')[1];
            string LoggedUser = text.Split('-')[2].ToLower();
            string mobileCountryCode = text.Split('-')[3];

            //Check For Access Token valid with logged User 
            if (HttpContext.Current.Request.Headers["LoggedUser"] != LoggedUser)
                return Errors.NotValidAccessToken;   //the logged user dont match the access token !!


            LoginClass creds = new LoginClass { Username = userName, Password = password, MobileCountryCode = mobileCountryCode };

            return CredentialsValidator.IsValidTokenInDB(creds, token);

        }

    }
}