using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes.Core
{
    public static class Config
    {
        //Calligra

        /*public static string StaticURL = "https://yallaasouq.com:9995/";
        public const string ServerRoot = @"D:\CalligraTest\CalligraTestUploads\";
        public static string ServerPhysicalImagePath = @"D:\CalligraTest\CalligraTestUploads\Photos\";
        public static string ServerPhysicalExcelPath = @"D:\CalligraTest\CalligraTestUploads\Excel\";
        public static string NotificationsAPIURL = @"https://www.yallaasouq.com:9994/NotificationsServiceAPI.svc/JSON/SendNotification";
        */

        //Demo Server
        /*public const string StaticURL = "https://matjardemo.technoplusplus.com:8885/";
        public const string ServerRoot = @"C:\MatjarPlatform\MatjarUploads\";
        public static string ServerPhysicalImagePath = ServerRoot + @"Photos\";
        public static string ServerPhysicalExcelPath = ServerRoot + @"Excel\";
        public static string NotificationsAPIURL = @"https://matjardemo.technoplusplus.com:8884/NotificationsServiceAPI.svc/JSON/SendNotification";
        */

        public static bool IsSystemUp = true;
        public static DateTime? NextLicenseCheck = null;

        public static string StaticURL = System.Configuration.ConfigurationManager.AppSettings["StaticURL"];//"https://yallaasouq.com:8766/";        
        public static string ServerRoot = @System.Configuration.ConfigurationManager.AppSettings["ServerRoot"];//@"D:\MatjarPlatform\MatjarUploads\";
        public static string ServerPhysicalImagePath = ServerRoot + @System.Configuration.ConfigurationManager.AppSettings["ServerPhysicalImagePath"];//@"Photos\";
        public static string ServerPhysicalExcelPath = ServerRoot + @System.Configuration.ConfigurationManager.AppSettings["ServerPhysicalExcelPath"];//@"Excel\";
        public static string NotificationsAPIURL = @System.Configuration.ConfigurationManager.AppSettings["NotificationsAPIURL"];//@"https://www.yallaasouq.com:6545/NotificationsServiceAPI.svc/JSON/SendNotification";       
        public static string EmailUsername = @System.Configuration.ConfigurationManager.AppSettings["EmailUsername"];
        public static string EmailPassword = @System.Configuration.ConfigurationManager.AppSettings["EmailPassword"];
        public static string EmailSMTPHost = @System.Configuration.ConfigurationManager.AppSettings["EmailSMTPHost"];
        public static string EmailSMTPPort = @System.Configuration.ConfigurationManager.AppSettings["EmailSMTPPort"];
        public static string GoogleCredentialPath = "";
        public static string FirebaseClient = "";
        
        public static string FatoraCreatePayment = @System.Configuration.ConfigurationManager.AppSettings["FatoraCreatePayment"];
        public static string FatoraCheckPayment = @System.Configuration.ConfigurationManager.AppSettings["FatoraCheckPayment"];
        public static string FatoraCancelPayment = @System.Configuration.ConfigurationManager.AppSettings["FatoraCancelPayment"];
        public static string FatoraTerminalId = @System.Configuration.ConfigurationManager.AppSettings["FatoraTerminalId"];
        public static string FatoraUsername = @System.Configuration.ConfigurationManager.AppSettings["FatoraUsername"];
        public static string FatoraPassword = @System.Configuration.ConfigurationManager.AppSettings["FatoraPassword"];

        public static string ECashCreatePayment = @System.Configuration.ConfigurationManager.AppSettings["ECashCreatePayment"];
        public static string ECashTerminalKey = @System.Configuration.ConfigurationManager.AppSettings["ECashTerminalKey"];
        public static string ECashMerchantId = @System.Configuration.ConfigurationManager.AppSettings["ECashMerchantId"];
        public static string ECashMerchantSecret = @System.Configuration.ConfigurationManager.AppSettings["ECashMerchantSecret"];

        public static bool fcmStatus = false;

        public static bool CheckAccessToken = true;
        public static bool CheckApplicationToken = false;
        public static bool CheckSessionTimeout = false;
        public static bool PaypassLoggedUserInSwagger = true;

        public const string ApplicationToken = "354C5848-C6B9-4D5C-AEA2-D39F0CD292AB"; //random GUID generated from DB

        public const string LicenseSaltsToken = "23F9B7C0-D787-4BC9-BABD-B77B8BC4A7C8";


        public static List<NotificationClass> IndexNotificationList = new List<NotificationClass>();

        public static List<NotificationClass> CurrentNotificationList = new List<NotificationClass>();

        public static List<string> ExcludedMethodName = new List<string>
      {
         "Login", "AppLogin", "VerifyCaptcha", "GetAppName", "VerifyMobileNumberBySMS",
         "CheckMobileVerificationCode", "CreateUser", "GetJobs", "ClearFCMRegistrationId",
         "GetWorkDomains", "GetGovernorates", "GetCities",
         "GetLocations", "GetEducationLevels", "GetPositions", "SubmitDeviceLog",
         "GetUserNotificationsBadges", "SubmitFCMRegistrationId","FetchUserNotifications", /*201-12-21 added for allow not active user*/
         "CheckIfUsernameAvailable", "CheckIfMobileAvailable" ,"SignUp_ForMatjar",
         "RequestVerifyCode" ,"CheckMobileVerificationCode_Test","GetCountries",
         "VerifyInvisibleCaptcha",
         "GetConfig","GetItemFiltersForPublic", "SearchItemsForPublic",
         /*For Public*/
         "GetItemsWithMapForPublic","GetItemDataForPublic","GetFeatureItemsForPublic",
         "GetCategoriesWithMapForPublic","GetBestSellingItemsForPublic","GetBanners",
         "GetFeatureCategories","GetCategoriesTreeForPublic","NewSearchUsers_ForMapPage",
         "GetPeopleAlsoLikeItemsForPublic","GetItemsForPublic","GetItems_ShortForPublic",

         "GetUserProfileColumns", "SearchItems_MultiForPublic", "SearchItems_Multi_ShortForPublic",

         "GetCountryCurrencies","GetSignupCountries", "GetBranches"
         /*For Development*/
        ,"DeleteUser_Dev", "SetUserLanguage", "ImportFromFlo", "GetGovernorateCities", "AddWooCommerceProduct",
         "GetItemDepartmentsData","GetItemTypesByDepartment", "GetColors", "GetSizes", "GetItemDepartments",
         "SearchItems_MultiWithFiltersForPublic", "GetItemFiltersForPublic", "GetPrestigakMainData", "GetPrestigakStyleDetailsData",
         "GetStoryDetails", "GetItemTypesData","RecordUsageData","GetStyles","GetStylesData","GetStories","GetBrandsByDepartment",
            "GetStyleData","GetStylesDataNew", "GetItemDepartmentsDataForPublic", "GetItemDepartmentDataForPublic", "GetItemDepartmentForPublic", 
            "GetItemDepartmentsForPublic", "GetBrands", "SubmitFCMForUnknown", "ECashCallBack"
      };


        public static string GetRequestMethodName()
        {
            var urlPath = HttpContext.Current.Request.Url.PathAndQuery;
            string mName = String.Empty;

            int lastSlashIndex = urlPath.LastIndexOf(@"/");
            int firstQuestionMarkIndex = urlPath.IndexOf(@"?");

            if (firstQuestionMarkIndex == -1)
                firstQuestionMarkIndex = urlPath.Length;

            if ((lastSlashIndex > 0) && (firstQuestionMarkIndex >= 0))
            {
                int methodNameLen = firstQuestionMarkIndex - lastSlashIndex;

                var methodName2 = urlPath.Substring(lastSlashIndex + 1, methodNameLen - 1);

                if (methodName2 != null)
                    mName = methodName2;
            }

            return mName;
        }

        public static void ReturnErrorResponse<T>(int code, ResultClass<T> result = null)
        {
            try
            {
                HttpContext.Current.Response.AddHeader("Content-Type", "application/json; charset=utf-8");
                HttpContext.Current.Response.AddHeader("Access", HttpContext.Current.Request.ToString());

                var response = Config.GetErrorJson(code, result);
                HttpContext.Current.Response.Write(response);

                try { HttpContext.Current.Response.Flush(); } catch (Exception) { }

                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception) { }
        }

        public static void ReturnErrorResponse(int code, string json)
        {
            HttpContext.Current.Response.AddHeader("Content-Type", "application/json; charset=utf-8");
            HttpContext.Current.Response.AddHeader("Access", HttpContext.Current.Request.ToString());

            HttpContext.Current.Response.Write(json);

            try { HttpContext.Current.Response.Flush(); } catch (Exception) { }

            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }



        private static string GetErrorJson<T>(int code, ResultClass<T> result = null)
        {
            string mName = "";
            var urlPath = HttpContext.Current.Request.Url.PathAndQuery;

            int lastSlashIndex = urlPath.LastIndexOf(@"/");
            int firstQuestionMarkIndex = urlPath.IndexOf(@"?");

            if (firstQuestionMarkIndex == -1)
                firstQuestionMarkIndex = urlPath.Length;

            if ((lastSlashIndex > 0) && (firstQuestionMarkIndex >= 0))
            {
                int methodNameLen = firstQuestionMarkIndex - lastSlashIndex;

                var methodName2 = urlPath.Substring(lastSlashIndex + 1, methodNameLen - 1);

                if (methodName2 != null)
                    mName = methodName2;

                string json = String.Empty;
                if (result != null)
                    json = "{\"" + mName + "Result" + "\":{" + "\"Code" + "\":" + result.Code + ",\"Message" + "\":" + "\"" + result.Message + "\"," + "\"Result" + "\":null" + "}}";
                else
                    json = "{\"" + mName + "Result" + "\":{" + "\"Code" + "\":" + code + ",\"Message" + "\":" + "\"" + Errors.GetErrorMessage(code) + "\"," + "\"Result" + "\":null" + "}}";

                return json;
            }
            else
                return "";
        }


    }
}