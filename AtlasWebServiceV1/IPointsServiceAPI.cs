using PointsSystemWebService.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SwaggerWcf.Attributes;
using System.Net;
using PointsSystemWebService.Classes.Flo;
using WooCommerceNET.WooCommerce.Legacy;
using System.Threading.Tasks;

namespace PointsSystemWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPointsServiceAPI" in both code and config file together.    

    [ServiceContract]
    public interface IPointsServiceAPI
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetAppName")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get App Name", Description = "Return Application Name", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Get App Name in String Format",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        string GetAppName();

        //Captcha
        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/VerifyCaptcha")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Verify Captcha", Description = "Get Captcha Token", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Get Captcha Token",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        //[SwaggerWcfProperty(Default = "0", Description = "0", Title = "title")]
        ResultClass<string> VerifyCaptcha(string response);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/VerifyInvisibleCaptcha")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Verify Invisible Captcha", Description = "Get Captcha Token", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Get Captcha Token",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<string> VerifyInvisibleCaptcha(string response);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SignUp_ForMatjar")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "SignUp for MATJAR", Description = "Creat User Data in MATJAR System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserClass> SignUp_ForMatjar(UserClass User);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/Login")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "User Login", Description = "Get the User's Class and Generate Access Token for User, This API only for management", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserClass> Login(LoginClass Login);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/AppLogin")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "User Login", Description = "Get the User's Class and Generate Access Token for This User, This API only for Clients", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserClass> AppLogin(LoginClass Login);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CheckIfUsernameAvailable")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Check the UserName if Available", Description = "Check if the UserName is Available or Taken Before When the User's Signing Up", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Name Available Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UsernameAvailableClass> CheckIfUsernameAvailable(string Username, string FullName, string Birthdate);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CheckIfMobileAvailable")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Check the Mobile Number if Available", Description = "Check if the Mobile Number is Available or Taken Before When the User's Signing Up", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Mobile Available Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<MobileAvailableClass> CheckIfMobileAvailable(string MobileNumber, string MobileCountryCode);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/RequestVerifyCode")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Request Verify Code", Description = "Request the verification Code When User Sign Up or When Forget Password", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Verify Mobile Number Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<VerifyMobileNumberClass> RequestVerifyCode(string MobileNo, string MobileCountryCode);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/VerifyMobileNumberBySMS")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Verify Mobile Number By SMS", Description = "Requist Mobile Number Verification Code By SMS", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Verify Mobile Number Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<VerifyMobileNumberClass> VerifyMobileNumberBySMS(string MobileNo, string Brand = "Atlas Club App");

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CheckMobileVerificationCode")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Check Mobile Verification Code", Description = "Checking If the Verification Code is Right and if the User is already Registered or Not", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CheckMobileVerificationCodeClass> CheckMobileVerificationCode(string MobileNo, string requestid, string code);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/ChangePassword")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Change Password", Description = "Changing Password Without Asking for the Old Password in MATJAR System Used When User's not loged in and Forget Password", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserClass> ChangePassword(int LoggedUser, string NewPassword);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CheckAndChangePassword")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Check And Change Password", Description = "Checking for the Old Password if True and Changing Password in MATJAR System Used When User's loged in", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserClass> CheckAndChangePassword(int LoggedUser, string CurrentPassword, string NewPassword);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/ResetUserPassword")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Check And Change Password", Description = "Changing Password in ATLAS System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return boolean Success or Fail",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<bool> ResetUserPassword(UserPasswordClass UserPassword);



        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetSignupCountries")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Signup Countries", Description = "Get All The Countries Informations", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Country View Model",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CountryViewModel>> GetSignupCountries();

        //Authenticate
        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //ResponseFormat = WebMessageFormat.Json,
        //BodyStyle = WebMessageBodyStyle.Wrapped,
        //RequestFormat = WebMessageFormat.Json,
        //UriTemplate = "JSON/Authenticate")]
        //ResultClass<string> Authenticate(LoginClass Credentials);

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //ResponseFormat = WebMessageFormat.Json,
        //BodyStyle = WebMessageBodyStyle.Wrapped,
        //RequestFormat = WebMessageFormat.Json,
        //UriTemplate = "JSON/IsValidateToken")]
        //int IsValidateToken();

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //ResponseFormat = WebMessageFormat.Json,
        //BodyStyle = WebMessageBodyStyle.Wrapped,
        //RequestFormat = WebMessageFormat.Json,
        //UriTemplate = "JSON/UnAutohrizeAccess")]
        //ResultClass<string> UnAutohrizeAccess();

        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SendRabbitMQ")]
        void SendRabbitMQ();

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/FixOffersBalances")]
        ResultClass<bool> FixOffersBalances();

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/FixUserBalances")]
        ResultClass<bool> FixUserBalances();

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/FixUsersBalances")]
        ResultClass<bool> FixUsersBalances();

        //AppConfig
        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetConfig")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Configuration", Description = "Get MATJAR System Configuration Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Config Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ConfigClass> GetConfig();

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateConfig")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Configuration", Description = "Update MATJAR System Configuration Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Config Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ConfigClass> UpdateConfig(int LoggedUser, ConfigClass config);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CopyPrices")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Copy and Change Prices", Description = "Copy or Change Items Prices From One Price To Another", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return boolean Success or Fail",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<bool> CopyPrices(int LoggedUser, int FromCountryCurrencyId, int FromPriceTypeId, int ToCountryCurrencyId, int ToPriceTypeId, bool? UpdateIfAvailable, int? Factor, List<int> Items);


        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/RoundCurrencies")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Round Prices", Description = "Round the Item's Prices According to Number Which the User Has Entered.", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return boolean Success or Fail",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<bool> RoundCurrencies(int LoggedUser, int? Factor, List<int> Items);



        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchUsers?LoggedUser={LoggedUser}&Text={Text}&Type={Type}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Search Users", Description = "searching For Users By UserName, QR Code, Phone Number", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Search Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserSearchClass> SearchUsers(
            [SwaggerWcfParameter(Required = true, Description = "The User Identifier in System", ParameterType = typeof(int))] int LoggedUser,
            [SwaggerWcfParameter(Required = false, Description = "The Search Text Which the User Has Entered", ParameterType = typeof(string))] string Text,
            [SwaggerWcfParameter(Required = false, Description = "User Type (Sender or Receiver)", ParameterType = typeof(int))] int Type);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/NewSearchUsers")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "New Search Users", Description = "Searching For Users By All User's Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Users Classes",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserClass>> NewSearchUsers(int LoggedUser,
          bool FilterByUsername, string Username,
          bool FilterByFullName, string FullName,
          bool FilterByEmail, string Email,
          bool FilterByMobileNumber, string MobileNumber, string MobileCountryCode,
          bool FilterByText, string Text,
          bool FilterByDisabled, bool Disabled,
          bool FilterByHasVocationalCertificate, bool HasVocationalCertificate,
          bool FilterByIsActive, bool IsActive,
          bool FilterByAddress1, string Address1,
          bool FilterByAddress2, string Address2,
          bool FilterByNickname, string Nickname,
          bool FilterByYearsOfExperience, int FromFilterByYearsOfExperience, int ToFilterByYearsOfExperience,
          bool FilterByStaffCount, int FromStaffCount, int ToStaffCount,
          bool FilterByNotes, string Notes,
          bool FilterByCommercialName, string CommercialName,
          bool FilterByUserTypeIds, List<int> UserTypeIds,
          bool FilterByCompanyIds, List<int> CompanyIds,
          bool FilterByGovernorateIds, List<int> GovernorateIds,
          bool FilterByCityIds, List<int> CityIds,
          bool FilterByLocationIds, List<int> LocationIds,
          bool FilterByPositionIds, List<int> PositionIds,
          bool FilterByJobIds, List<int> JobIds,
          bool FilterByWorkDomainIds, List<int> WorkDomainIds,
          bool FilterByGender, int Gender,
          bool FilterByEducationLevelIds, List<int> EducationLevelIds,
          bool FilterByCreateDate, string FromCreateDate, string ToCreateDate,
          bool FilterByBirthdate, string FromBirthdate, string ToBirthdate,
          bool FilterByLunchCount, int FromLunchCount, int ToLunchCount,
          bool SearchForSenders, bool SearchForReceivers,
          bool FilterByCountryIds, List<int> CountryIds,
          int PageId = 1, int RecordsCount = 10000,
          bool ForReports = false,
          bool NotForAdmins = false,
          bool ForTransfers = false,
          int TransferStatusId = 1,
          bool FilterByVisibleOnMap = false,
          bool VisibleOnMap = false,
          bool FilterByLocationValidated = false,
          bool LocationValidated = false,
          bool FilterByIsVerified = false,
          bool IsVerified = false);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/NewSearchUsers_Short")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Short New Search Users", Description = "Searching For Users By All User's Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Short Users Classes",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserClass_Short>> NewSearchUsers_Short(int LoggedUser,
          bool FilterByUsername, string Username,
          bool FilterByFullName, string FullName,
          bool FilterByEmail, string Email,
          bool FilterByMobileNumber, string MobileNumber, string MobileCountryCode,
          bool FilterByText, string Text,
          bool FilterByDisabled, bool Disabled,
          bool FilterByHasVocationalCertificate, bool HasVocationalCertificate,
          bool FilterByIsActive, bool IsActive,
          bool FilterByAddress1, string Address1,
          bool FilterByAddress2, string Address2,
          bool FilterByNickname, string Nickname,
          bool FilterByYearsOfExperience, int FromFilterByYearsOfExperience, int ToFilterByYearsOfExperience,
          bool FilterByStaffCount, int FromStaffCount, int ToStaffCount,
          bool FilterByNotes, string Notes,
          bool FilterByCommercialName, string CommercialName,
          bool FilterByUserTypeIds, List<int> UserTypeIds,
          bool FilterByCompanyIds, List<int> CompanyIds,
          bool FilterByGovernorateIds, List<int> GovernorateIds,
          bool FilterByCityIds, List<int> CityIds,
          bool FilterByLocationIds, List<int> LocationIds,
          bool FilterByPositionIds, List<int> PositionIds,
          bool FilterByJobIds, List<int> JobIds,
          bool FilterByWorkDomainIds, List<int> WorkDomainIds,
          bool FilterByGender, int Gender,
          bool FilterByEducationLevelIds, List<int> EducationLevelIds,
          bool FilterByCreateDate, string FromCreateDate, string ToCreateDate,
          bool FilterByBirthdate, string FromBirthdate, string ToBirthdate,
          bool FilterByLunchCount, int FromLunchCount, int ToLunchCount,
          bool SearchForSenders, bool SearchForReceivers,
          bool FilterByCountryIds, List<int> CountryIds,
          int PageId = 1, int RecordsCount = 10000,
          bool ForReports = false,
          bool NotForAdmins = false,
          bool ForTransfers = false,
          int TransferStatusId = 1,
          bool FilterByVisibleOnMap = false,
          bool VisibleOnMap = false,
          bool FilterByLocationValidated = false,
          bool LocationValidated = false,
          bool FilterByIsVerified = false,
          bool IsVerified = false);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchUsers_ForUserPage")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass>> SearchUsers_ForUserPage(int LoggedUser, string Text,
          bool FilterByGovernorate, List<int> GovernoratesIDs,
          bool FilterByCompany, List<int> CompaniesIDs,
          bool FilterByCountry, List<int> CountriesIDs,
          bool FilterByUserType, List<int> UserTypesIDs,
          bool FilterByDisabled = false, bool ShowDisabled = false,
          bool FilterByIsActive = false, bool IsActive = false,
          int PageId = 1, int RecordsCount = 10000);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchUserSenders")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass>> SearchUserSenders(int LoggedUser, string Text,
          bool ForNotAdmins,
          bool FilterByGovernorate, List<int> GovernoratesIDs,
          bool FilterByCompany, List<int> CompaniesIDs,
          bool FilterByUserType, List<int> UserTypesIDs,
          bool ShowDisabled = false, bool IsActive = false,
          int PageId = 1, int RecordsCount = 10000);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SearchUserSenders_Short")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass_Short>> SearchUserSenders_Short(int LoggedUser, string Text,
          bool ForNotAdmins,
          bool FilterByGovernorate, List<int> GovernoratesIDs,
          bool FilterByCompany, List<int> CompaniesIDs,
          bool FilterByUserType, List<int> UserTypesIDs,
          bool ShowDisabled = false, bool IsActive = false,
          int PageId = 1, int RecordsCount = 10000);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SearchUserReceivers")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass>> SearchUserReceivers(int LoggedUser, string Text,
          bool FilterByGovernorate, List<int> GovernoratesIDs,
          bool FilterByCompany, List<int> CompaniesIDs,
          bool FilterByUserType, List<int> UserTypesIDs,
          bool ShowDisabled = false, bool IsActive = false,
          int PageId = 1, int RecordsCount = 10000);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SearchUserReceivers_Short")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass_Short>> SearchUserReceivers_Short(int LoggedUser, string Text,
          bool FilterByGovernorate, List<int> GovernoratesIDs,
          bool FilterByCompany, List<int> CompaniesIDs,
          bool FilterByUserType, List<int> UserTypesIDs,
          bool ShowDisabled = false, bool IsActive = false,
          int PageId = 1, int RecordsCount = 10000);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SearchUsersForPrivateNotification")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass>> SearchUsersForPrivateNotification(int LoggedUser, string Text,
          bool FilterByGovernorate, List<int> GovernoratesIDs,
          bool FilterByCompany, List<int> CompaniesIDs,
          bool FilterByUserType, List<int> UserTypesIDs,
          bool ShowDisabled = false, bool IsActive = false,
          bool NotAdminUsers = false,
          int PageId = 1, int RecordsCount = 10000);

        //Users
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate =
          "JSON/GetUsers?LoggedUser={LoggedUser}&ShowDisabled={ShowDisabled}&IsActive={IsActive}&NotAdminUsers={NotAdminUsers}&PageId={PageId}&RecordsCount={RecordsCount}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Users", Description = "Get Users Classes According to the Enterd Filters", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserClass>> GetUsers(int LoggedUser, bool ShowDisabled, bool IsActive, bool NotAdminUsers = false, int PageId = 1, int RecordsCount = 10000);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate =
          "JSON/GetUsers_Short?LoggedUser={LoggedUser}&ShowDisabled={ShowDisabled}&IsActive={IsActive}&NotAdminUsers={NotAdminUsers}&PageId={PageId}&RecordsCount={RecordsCount}")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass_Short>> GetUsers_Short(int LoggedUser, bool ShowDisabled, bool IsActive,
          bool NotAdminUsers = false, int PageId = 1, int RecordsCount = 10000);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUser?LoggedUser={LoggedUser}&UserId={UserId}&WithAccessToken={WithAccessToken}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User", Description = "Get User Class", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserClass> GetUser(
            [SwaggerWcfParameter(Required = true, Description = "The User Identifier in System", ParameterType = typeof(int))] int LoggedUser,
            [SwaggerWcfParameter(Required = true, Description = "The Required User ID", ParameterType = typeof(int))] int UserId,
            [SwaggerWcfParameter(Required = false, Description = "To Get User AccessToken", ParameterType = typeof(bool))] bool WithAccessToken);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUser_Short?LoggedUser={LoggedUser}&UserId={UserId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Short", Description = "Get Short User Class", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Short User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserClass_Short> GetUser_Short(
            [SwaggerWcfParameter(Required = true, Description = "The User Identifier in System", ParameterType = typeof(int))] int LoggedUser,
            [SwaggerWcfParameter(Required = true, Description = "The Required User ID", ParameterType = typeof(int))] int UserId);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCompanyUsers?LoggedUser={LoggedUser}&CompanyId={CompanyId}&PageId={PageId}&RecordsCount={RecordsCount}")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass>> GetCompanyUsers(int LoggedUser, int CompanyId, int PageId = 1, int RecordsCount = 10000);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateUser")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Creat User", Description = "Create User By Entering User Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserClass> CreateUser(int LoggedUser, UserClass User);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateUser")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User", Description = "Edit User's Information in the User Class", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserClass> UpdateUser(int LoggedUser, UserClass User, bool WithAccessToken = false);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteUser")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User", Description = "Delete the User which has the Entered ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserClass> DeleteUser(int LoggedUser, int User);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetAdminUsers")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass>> GetAdminUsers(int LoggedUser);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetAdminUsers_Short")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass_Short>> GetAdminUsers_Short(int LoggedUser);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserSenders?LoggedUser={LoggedUser}&ForNotAdmins={ForNotAdmins}&ForReports={ForReports}&PageId={PageId}&RecordsCount={RecordsCount}")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass>> GetUserSenders(int LoggedUser, bool ForNotAdmins = true, bool ForReports = false, int PageId = 1, int RecordsCount = 10000);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserReceivers?LoggedUser={LoggedUser}&PageId={PageId}&RecordsCount={RecordsCount}")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass>> GetUserReceivers(int LoggedUser, int PageId = 1, int RecordsCount = 10000);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/ActivateUsers")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Activate Users", Description = "replace the IsActivated column from False to True in the User Class For the Users which has the enterd IDs", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return boolean Success or Fail",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<bool> ActivateUsers(int LoggedUser, List<int> Users);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUsersByIds")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Users By IDs", Description = "Ask for Users Classes By Users IDs (Used in Users Browsing Page)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Users Classes",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserClass>> GetUsersByIds(int LoggedUser, List<int> Ids, int PageId, int RecordsCount);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/NewSearchUsers_ForMapPage")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "New Search Users For Map Page", Description = "Get Users After Applying (UserName, Job) Filters to Show Users In the Map Page", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Users Classes",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserClass>> NewSearchUsers_ForMapPage(int LoggedUser,
          bool FilterByUsername, string Username,
          bool FilterByJobIds,
          List<int> JobIds,
          int PageId = 1, int RecordsCount = 10000);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateUserGeolocation")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Geolocation", Description = "Edit Users longitude and latitude in User Class", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Short User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserClass_Short> UpdateUserGeolocation(int LoggedUser, UserClass_Short User);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/ValidateUsersGeoLocation")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Validate Users Geolocatiom", Description = "change the Users Location status Which has the Enterd IDs to Valid Location", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Users Classes",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserClass>> ValidateUsersGeoLocation(int LoggedUser, List<int> Ids);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/ShowUsersOnMap")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserClass>> ShowUsersOnMap(int LoggedUser, List<int> Ids);

        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/GetUserBadges")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Badges", Description = "Get The User's (likes, Wish List, Cart, Notifications) Badges", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Badges Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserBadgesClass> GetUserBadges(int LoggedUser);

        //UserTypes
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUsersTypes?LoggedUser={LoggedUser}&ForNotAdmins={ForNotAdmins}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Users Types", Description = "", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserTypeClass>> GetUsersTypes(int LoggedUser, bool ForNotAdmins);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserType?UserTypeId={UserTypeId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Type", Description = "", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Type Class",
          Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
          ResponseTypeOverride = typeof(string))]
        ResultClass<UserTypeClass> GetUserType(int UserTypeId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateUserPermission")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Permission", Description = "Edit User Permission Information in the User Permission Class", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Permission Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserPermissionClass> UpdateUserPermission(int LoggedUser, UserPermissionClass UserPermission);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserPermission?LoggedUser={LoggedUser}&UserId={UserId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Permission", Description = "Get All the User Permission Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Permission Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserPermissionClass> GetUserPermission(int LoggedUser, int UserId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateUserPermission_ForMatjar")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<UserPermissionClass> UpdateUserPermission_ForMatjar(int LoggedUser, UserPermissionClass UserPermission);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserPermissionTemplate?LoggedUser={LoggedUser}&TemplateId={TemplateId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Permission Template", Description = "Get All the User Permission Template Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Permission Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserPermissionClass> GetUserPermissionTemplate(int LoggedUser, int TemplateId);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserPermissionTemplates?LoggedUser={LoggedUser}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Permission Templates", Description = "Get All the User Permission Template Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Permission Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserPermissionClass>> GetUserPermissionTemplates(int LoggedUser);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateUserPermissionTemplate")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Permission Template", Description = "Edit User Permission Template Information in the User Permission Class", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Permission Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserPermissionClass> UpdateUserPermissionTemplate(int LoggedUser, UserPermissionClass UserPermission);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SetUserColumns")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Set User Columns", Description = "Set The User Columns customization (Order, Name, Width For each Column)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Columns Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserTypeColumnsClass>> SetUserColumns(int LoggedUser, UserTypeColumnsClass UserTypeColumns);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserColumns")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Columns", Description = "Get All The Columns That the User has Permission To See", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Type Columns Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserTypeColumnsClass>> GetUserColumns(int LoggedUser, int UserId);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateUserColumnsTemplate")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Columns Template", Description = "Update The Users Columns Template customization (Order, Name, Width For each Column)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Columns Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserTypeColumnsClass>> UpdateUserColumnsTemplate(int LoggedUser, List<UserTypeColumnsClass> UserTypeColumns);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserColumnsTemplates")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Columns Templates", Description = "Get The User Columns Templates customization (Order, Name, Width For each Column)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Columns Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserTypeColumnsClass>> GetUserColumnsTemplates(int LoggedUser);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserColumnsTemplate")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Columns Template", Description = "Get The User Columns Template customization For a Specific User Type (Order, Name, Width For each Column)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Columns Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserTypeColumnsClass>> GetUserColumnsTemplate(int LoggedUser, int UserType);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserProfileColumns")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Columns Template", Description = "Get The User Columns Names That We Should Use Or Show", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Profile Column Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserProfileColumnClass>> GetUserProfileColumns();

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateUserProfileColumns")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Columns Template", Description = "Update The User Columns That We Should Use Or Show", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Profile Column Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserProfileColumnClass>> UpdateUserProfileColumns(int LoggedUser, List<string> Columns);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteUserProfileColumns")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Columns Template", Description = "Delete The User Columns Names That We Should Use Or Show", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Profile Column Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserProfileColumnClass>> DeleteUserProfileColumns(int LoggedUser, List<int> Ids);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserCustomColumnsNames")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Custom Columns Names", Description = "Get The User Columns Names That We Can Use Or Show", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Resource Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ResourceClass>> GetUserCustomColumnsNames();


        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserNotificationsBadges")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Notification Badges", Description = "Get The User's Notifications Badges", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Notifications Badges Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserNotificationsBadgesClass> GetUserNotificationsBadges(int LoggedUser);


        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SetUserNotificationsSeen")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Set User Notifications Seen", Description = "Set the Notified (Opened) Notifications as Seen", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Boolean True Or False",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<bool> SetUserNotificationsSeen(int LoggedUser, int Type);


        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetNotificationsTypes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Notifications Types", Description = "Return all The Types Of Notifications In The System For Administrator only", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Notification Types Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<NotificationTypesClass>> GetNotificationsTypes(int LoggedUser);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          RequestFormat = WebMessageFormat.Json,
          UriTemplate = "JSON/GetUserNotification")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Notification", Description = "Get User Notifications Filterd By (Notification Type, From/to Date, Content, Title)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Notification Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<NotificationClass>> GetUserNotification(UserNotificationClass userNotfication);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetUserNotifications")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Notifications", Description = "Get User Notifications Filterd By (Notification Type)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Notification Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<NotificationClass>> GetUserNotifications(int LoggedUser, int Type);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/FetchUserNotifications")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Fetch User Notifications", Description = "Get UnNotified User Notifications and Changes their Status to 'Notified'", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Notification Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<NotificationClass>> FetchUserNotifications(int LoggedUser, int PageId = 1, int RecordsCount = 99999999);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateNotification")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Notification", Description = "Notify the System That the Notification Successfully Received", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Notification Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<NotificationClass> UpdateNotification(int Id, int Fail);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/SendFCMMsgs")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Send FCM Messages", Description = "Send Privet Notification For a Particular User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Notification Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<bool> SendFCMMsgs(int LoggedUser, List<int> UsersId, string Title, string Content, string ImageURL, string ReferenceType, string ReferenceId);



        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetNotificationsUsers")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Notifications Users", Description = "Get The Users That They Have Permission To Get This Notification Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return  List of User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserClass>> GetNotificationsUsers(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateNotificationsUsers")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Notifications Users", Description = "Add Permission To the Selected Users So They Get This Notification Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return  List of User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserClass>> CreateNotificationsUsers(int LoggedUser, int NotificationsTypeId, List<int> UsersId);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteNotificationsUsers")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Notifications Users", Description = "Remove Permission From the Selected Users So They Don't Get This Notification Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return  List of User Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserClass>> DeleteNotificationsUsers(int LoggedUser, int NotificationsTypeId, List<int> UsersId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SubmitDeviceRegisterationId")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Submit Device Registeration Id", Description = "Send The User's Registeration Id (Token) To DataBase", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Boolean True Or False",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<bool> SubmitDeviceRegisterationId(DeviceNotificationToken Token);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SubmitFCMRegistrationId")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Submit FCM Registeration Id", Description = "Send The User's FCM Registeration Id (Token) + Device Platorm To DataBase", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return FCM Registeration Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<FCMRegistrationClass> SubmitFCMRegistrationId(FCMRegistrationClass FCMRegistration);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/ClearFCMRegistrationId")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Clear FCM Registeration Id", Description = "Clear The User's FCM Registeration Id (Token) From DataBase", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return String True Or False",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<string> ClearFCMRegistrationId(int LoggedUser, string RegistrationId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/ClearFCMRegistrationIdByUserId")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Clear FCM Registeration Id", Description = "Clear The User's FCM Registeration Id (Token) From DataBase", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Boolean True Or False",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<bool> ClearFCMRegistrationIdByUserId(int LoggedUser);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SendFCMMsg")]
        [SwaggerWcfPath(Deprecated = true)]
        string SendFCMMsg(NotificationClass notification);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SubmitDeviceLog")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Submit Device Log", Description = "Count the Number Of Users Who Opens The Application (Users and Guests)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Boolean True Or False",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<bool> SubmitDeviceLog(DeviceLogClass DeviceLog);


        //Branches
        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetBranches")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Branches", Description = "Get The Branches With Filters (ID & Active)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Branche Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<BrancheClass>> GetBranches(int CountryId, int Id, bool FilterByActive, bool ShowActive);


        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/CreateBranche")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Branche", Description = "Create Branche By Entering Branche Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Branche Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BrancheClass> CreateBranche(int LoggedUser, BrancheClass Branche);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/UpdateBranche")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Branche", Description = "Edite Branche Class By Editing Branche Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Branche Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BrancheClass> UpdateBranche(int LoggedUser, BrancheClass Branche);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/DeleteBranche")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Branche", Description = "Delete Branche", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Branche Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BrancheClass> DeleteBranche(int LoggedUser, int Id);



        //Cities
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCities?GovernorateId={GovernorateId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Cities", Description = "Get The Cities For The given Governorate ID (Single)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of City Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CityClass>> GetCities(int GovernorateId);

        //Cities
        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetGovernorateCities")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Cities", Description = "Get The Cities For The given Governorate ID (Single)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of City Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CityClass>> GetGovernorateCities(int GovernorateId);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCitiesNew")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Cities New", Description = "Get The Cities For The given Governorate IDs (Multi)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of City Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CityClass>> GetCitiesNew(List<int> GovernorateIds);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCity?CityId={CityId}")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<CityClass> GetCity(int CityId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateCity")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create City", Description = "Add New City To The given Governorate ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return City Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CityClass> CreateCity(int LoggedUser, CityClass City);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateCity")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update City", Description = "Edite City Information in The City Class", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return City Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CityClass> UpdateCity(int LoggedUser, CityClass City);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteCity")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete City", Description = "Delete The City Which Has The Enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return City Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CityClass> DeleteCity(int LoggedUser, int City);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetGovernorates")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Governorates", Description = "Get The Governorates For The given Country ID (Single)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Governorate Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<GovernorateClass>> GetGovernorates(int? CountryId);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/GetGovernoratesNew")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Governorates New", Description = "Get The Governorates For The given Country IDs (Multi)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Governorate Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<GovernorateClass>> GetGovernoratesNew(List<int> CountryIds);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetGovernorate")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<GovernorateClass> GetGovernorate(int? CountryId, int GovernorateId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateGovernorate")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Governorate", Description = "Add New Governorate To The given Country ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Governorate Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<GovernorateClass> CreateGovernorate(int LoggedUser, GovernorateClass Governorate);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateGovernorate")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Governorate", Description = "Edite Governorate Class By Editing Governorate Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Governorate Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<GovernorateClass> UpdateGovernorate(int LoggedUser, GovernorateClass Governorate);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteGovernorate")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Governorate", Description = "Delete The Governorate Which Has The Enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Governorate Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<GovernorateClass> DeleteGovernorate(int LoggedUser, int Governorate);

        //Locations
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetLocations?GovernorateId={GovernorateId}&CityId={CityId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Locations", Description = "Get The Locations For The given Governorate ID & Country ID (Single)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Location Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<LocationClass>> GetLocations(int GovernorateId, int CityId);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetLocationsNew")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Locations New", Description = "Get The Locations For The given Governorate IDs & Country IDs (Multi)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Location Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<LocationClass>> GetLocationsNew(List<int> GovernorateIds, List<int> CityIds);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetLocation?LocationId={LocationId}")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<LocationClass> GetLocation(int LocationId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateLocation")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Governorate", Description = "Add New Governorate To The given Country ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Governorate Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<LocationClass> CreateLocation(int LoggedUser, LocationClass Location);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateLocation")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Location", Description = "Edite Location Class By Editing Location Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Location Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<LocationClass> UpdateLocation(int LoggedUser, LocationClass Location);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteLocation")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Location", Description = "Delete The Location Which Has The Enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Location Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<LocationClass> DeleteLocation(int LoggedUser, int Location);

        //Companies
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCompanies?LoggedUser={LoggedUser}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Companies", Description = "Get All Companies In the Application", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Companies Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CompanyClass>> GetCompanies(int LoggedUser);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCompany?CompanyId={CompanyId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Company", Description = "Get The Company With The Enterd ID", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Company Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CompanyClass> GetCompany(int CompanyId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateCompany")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Company", Description = "Create Company By Entering Company Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Company Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CompanyClass> CreateCompany(int LoggedUser, CompanyClass Company);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateCompany")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Company", Description = "Edite Company Class By Editing Company Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Company Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CompanyClass> UpdateCompany(int LoggedUser, CompanyClass Company);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteCompany")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Company", Description = "Delete The Company Which Has The Enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Company Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CompanyClass> DeleteCompany(int LoggedUser, int Company);

        //Transfers
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetTransfers")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Transfers", Description = "Get All the Transfers Operations in the System", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Transfer Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<TransferClass>> GetTransfers();

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetTransfer?TransferId={TransferId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Transfer", Description = "Get The Transfer Operation For The given Transfer ID", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Transfer Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<TransferClass> GetTransfer(int TransferId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateTransfer")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Transfer", Description = "Create Transfer By Entering Transfer Operation Information", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Transfer Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<TransferClass> CreateTransfer(int LoggedUser, TransferClass Transfer);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateUndoTransfer")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Undo Transfer", Description = "cancel The Transfer Operation Which Has The Enterd Id After Checking The Transfer Operation Time (is it Allowd To Cancel The Operation After this Period ?)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Transfer Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<TransferClass> CreateUndoTransfer(int LoggedUser, int TransferId, string Note);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateMultipleTransfer")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Multiple Transfer", Description = "Create Multi Transfer By Entering Transfer Operation Information And a List of Receiver IDs", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Transfer Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<TransferResultClass>> CreateMultipleTransfer(int LoggedUser, string Date, int Sender_UserId, double Amount, string Notes, int TransferStatusId, List<int> Receivers_UserId);

        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/CreateMultipleTransferFromExcelNew")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Multiple Transfer From Excel New", Description = "Create Multi Transfer By Entering Transfer Operation Information From an External Excel File", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Transfer Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<TransferResultClass>> CreateMultipleTransferFromExcelNew(int LoggedUser, List<TransferResultClass> TransferDataList);


        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //ResponseFormat = WebMessageFormat.Json,
        //BodyStyle = WebMessageBodyStyle.Wrapped,
        //UriTemplate = "JSON/UpdateTransfer")]
        //ResultClass<TransferClass> UpdateTransfer(int LoggedUser, TransferClass Transfer);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteTransfer")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Transfer", Description = "Delete The Transfer Operation Which Has The Enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Transfer Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<TransferClass> DeleteTransfer(int LoggedUser, int TransferId);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetTransferStatus")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Transfer Status", Description = "Get All The Transfer Status in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Transfer Status Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<TransferStatusClass>> GetTransferStatus();

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetTransferMethods")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Transfer Methods", Description = "Get All The Transfer Methods in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return list of Transfer Methods Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<TransferMethodClass>> GetTransferMethods();

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateMultipleTransferFromExcel")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<TransferResultClass>> CreateMultipleTransferFromExcel(int LoggedUser, string Url, string WorksheetName, int firstRow, string UserColumn, string PointColumn);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetTransfersListFromExcel")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Transfers List From Excel", Description = "Get The Users and The Value Of Transfer Operation For Each User From Excel File", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return list of Transfer Result Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<TransferResultClass>> GetTransfersListFromExcel(int LoggedUser, string Url, string WorksheetName, int firstRow, string UserColumn, string PointColumn, string NoteColumn);



        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetMainBalances?LoggedUser={LoggedUser}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Main Balances", Description = "Get The Main Balance Charges Operations and The Users Who Charges The Main Balance", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return list of Main Balances Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<MainBalanceClass>> GetMainBalances(int LoggedUser);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetMainBalance?MainBalanceId={MainBalanceId}&LoggedUser={LoggedUser}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Main Balance", Description = "Get The Main Balance Charges Operations and The Users Who Made The Operation", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return list of Main Balances Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<MainBalanceClass> GetMainBalance(int LoggedUser, int MainBalanceId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateMainBalance")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Main Balance", Description = "Create a New Main Balance Charge Operation By Entering The Operation Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Main Balances Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<MainBalanceClass> CreateMainBalance(MainBalanceClass MainBalance);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateMainBalance")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Main Balance", Description = "Update Main Balance Charge Operation By Editing The Operation Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Main Balances Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<MainBalanceClass> UpdateMainBalance(MainBalanceClass MainBalance);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteMainBalance")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Main Balance", Description = "Delete a Main Balance Charge Operation", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Main Balances Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<MainBalanceClass> DeleteMainBalance(int LoggedUser, int MainBalanceId);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetTotalMainBalance")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Total Main Balance", Description = "Get The Number Of All The Main Balance Charges Operations", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return a Number 'Double'",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<double> GetTotalMainBalance();

        //Jobs
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetJobs")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Jobs", Description = "Get All The Jobs Information in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Job Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<JobClass>> GetJobs();

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetJob?JobId={JobId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Job", Description = "Get The Job Information which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Job Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<JobClass> GetJob(int JobId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateJob")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Job", Description = "Create a New Job By Entering The Job Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Job Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<JobClass> CreateJob(int LoggedUser, JobClass Job);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateJob")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Job", Description = "Update Job By Editing The Job Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Job Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<JobClass> UpdateJob(int LoggedUser, JobClass Job);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteJob")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Job", Description = "Delete The Job which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Job Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<JobClass> DeleteJob(int LoggedUser, int Job);

        //Positions
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetPositions")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Positions", Description = "Get All The Positions in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Position Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<PositionClass>> GetPositions();

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetPosition?PositionId={PositionId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Position", Description = "Get The Position Information which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Position Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<PositionClass> GetPosition(int PositionId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreatePosition")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Position", Description = "Create a New Position By Entering The Position Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Position Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<PositionClass> CreatePosition(int LoggedUser, PositionClass Position);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdatePosition")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Position", Description = "Update Position By Editing The Position Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Position Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<PositionClass> UpdatePosition(int LoggedUser, PositionClass Position);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeletePosition")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Position", Description = "Delete The Position which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Position Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<PositionClass> DeletePosition(int LoggedUser, int Position);

        //WorkDomains
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetWorkDomains")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Work Domains", Description = "Get All The Work Domains in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Work Domain Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<WorkDomainClass>> GetWorkDomains();

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetWorkDomain?WorkDomainId={WorkDomainId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Work Domain", Description = "Get The Work Domain Information which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Work Domain Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<WorkDomainClass> GetWorkDomain(int WorkDomainId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateWorkDomain")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Work Domain", Description = "Create a New Work Domain By Entering The Work Domain Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Work Domain Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<WorkDomainClass> CreateWorkDomain(int LoggedUser, WorkDomainClass WorkDomain);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateWorkDomain")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Work Domain", Description = "Update Work Domain By Editing The Work Domain Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Work Domain Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<WorkDomainClass> UpdateWorkDomain(int LoggedUser, WorkDomainClass WorkDomain);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteWorkDomain")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Work Domain", Description = "Delete The Work Domain which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Work Domain Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<WorkDomainClass> DeleteWorkDomain(int LoggedUser, int WorkDomain);

        //EducationLevels
        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetEducationLevels")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Education Levels", Description = "Get All The Education Levels in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Education Level Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<EducationLevelClass>> GetEducationLevels();

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetEducationLevel?EducationLevelId={EducationLevelId}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Education Level", Description = "Get The Education Level Information which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Education Level Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<EducationLevelClass> GetEducationLevel(int EducationLevelId);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateEducationLevel")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Education Level", Description = "Create a New Education Level By Entering The Education Level Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Education Level Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<EducationLevelClass> CreateEducationLevel(int LoggedUser, EducationLevelClass EducationLevel);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateEducationLevel")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Education Level", Description = "Update Education Level By Editing The Education Level Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Education Level Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<EducationLevelClass> UpdateEducationLevel(int LoggedUser, EducationLevelClass EducationLevel);

        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteEducationLevel")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Education Level", Description = "Delete The Education Level which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Education Level Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<EducationLevelClass> DeleteEducationLevel(int LoggedUser, int EducationLevel);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetBrands")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Brands", Description = "Get All The Brands in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Brand Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<BrandClass>> GetBrands();

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetBrand")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Brand", Description = "Get The Brand Information which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Brand Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BrandClass> GetBrand(int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateBrand")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Brand", Description = "Create a New Brand By Entering The Brand Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Brand Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BrandClass> CreateBrand(int LoggedUser, BrandClass Brand);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateBrand")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Brand", Description = "Update Brand By Editing The Brand Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Brand Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BrandClass> UpdateBrand(int LoggedUser, BrandClass Brand);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteBrand")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Brand", Description = "Delete The Brand which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Brand Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BrandClass> DeleteBrand(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetColors")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Colors", Description = "Get All The Colors in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Colors Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ColorClass>> GetColors();

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetColor")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Color", Description = "Get The Color Information which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Color Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ColorClass> GetColor(int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateColor")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Color", Description = "Create a New Color By Entering The Color Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Color Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ColorClass> CreateColor(int LoggedUser, ColorClass Color);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateColor")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Color", Description = "Update Color By Editing The Color Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Color Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ColorClass> UpdateColor(int LoggedUser, ColorClass Color);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteColor")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Color", Description = "Delete The Color which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Color Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ColorClass> DeleteColor(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCountries")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Countries", Description = "Get All The Countries in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Countries Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CountryClass>> GetCountries(bool? ForSignUp);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCountry")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Country", Description = "Get The Country Information which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Country Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CountryClass> GetCountry(int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateCountry_ForMatjar")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Country For Matjar", Description = "Create a New Country By Entering The Country Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Country Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CountryClass> CreateCountry_ForMatjar(int LoggedUser, CountryClass Country);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateCountry")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<CountryClass> CreateCountry(int LoggedUser, CountryClass Country);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateCountry")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Country", Description = "Update Country By Editing The Country Information", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Country Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CountryClass> UpdateCountry(int LoggedUser, CountryClass Country);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateCountry_ForMatjar")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Country For Matjar", Description = "Update Country By Editing The Country Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Country Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CountryClass> UpdateCountry_ForMatjar(int LoggedUser, CountryClass Country);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteCountry")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Country", Description = "Delete The Country which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Country Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CountryClass> DeleteCountry(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCurrencies")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Currencies", Description = "Get All The Currencies in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Currency Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CurrencyClass>> GetCurrencies(bool FilterByDisabled, bool ShowDisabled);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCurrency")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Currency", Description = "Get The Currency Information which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Currency Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CurrencyClass> GetCurrency(int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateCurrency")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Currency", Description = "Create a New Currency By Entering The Currency Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Currency Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CurrencyClass> CreateCurrency(int LoggedUser, CurrencyClass Currency);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateCurrency")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Currency", Description = "Update Currency By Editing The Currency Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Currency Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CurrencyClass> UpdateCurrency(int LoggedUser, CurrencyClass Currency);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteCurrency")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Currency", Description = "Delete The Currency which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Currency Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CurrencyClass> DeleteCurrency(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCountryCurrencies")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Country Currencies", Description = "Get The Currencies of the Country With The Enterd Id Or The Countries For The Currency With The Enterd Id", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Country Currency Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CountryCurrencyClass>> GetCountryCurrencies(int? CountryId, int? CurrencyId, bool FilterByDisabled, bool ShowDisabled);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateCountryCurrencies")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Country Currencies", Description = "Create a New Country Currencies Relation By Entering Currency IDs and Country ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Country Currency Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CountryCurrencyClass>> CreateCountryCurrencies(int LoggedUser, int CountryId, List<int> CurrencyIds, bool Disabled);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteCountryCurrencies")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Country Currency", Description = "Delete The Country Currency Relation which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Country Currency Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CountryCurrencyClass>> DeleteCountryCurrencies(int LoggedUser, List<int> Ids);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCategory")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Category", Description = "Get The Category Information which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Category Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CategoryClass> GetCategory(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCategoryData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Category", Description = "Get The Category Information which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Category Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CategoryDataClass> GetCategoryData(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateCategory")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Category", Description = "Create a New Category By Entering The Category Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Category Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CategoryClass> CreateCategory(int LoggedUser, CategoryClass Category);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateCategoryData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Category", Description = "Create a New Category By Entering The Category Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Category Class",
          Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
          ResponseTypeOverride = typeof(string))]
        ResultClass<CategoryDataClass> CreateCategoryData(int LoggedUser, CategoryClass Category, List<int> Countries);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateCategory")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Category", Description = "Update Category By Editing The Category Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Category Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CategoryClass> UpdateCategory(int LoggedUser, CategoryClass Category);

        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/UpdateCategoryData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Category", Description = "Update Category By Editing The Category Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Category Class",
           Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
           ResponseTypeOverride = typeof(string))]
        ResultClass<CategoryDataClass> UpdateCategoryData(int LoggedUser, CategoryClass Category, List<int> Countries);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/DeleteCategory")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Category", Description = "Delete The Category which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Category Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CategoryClass> DeleteCategory(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCategories")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Categories", Description = "Get All The Categories in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Category Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CategoryClass>> GetCategories(int LoggedUser, bool FilterByParentId, int ParentId, int Type, int PageId, int RecordsCount, bool FilterByDisabled, bool ShowDisabled);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetMainCategoriesForCategory")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Main Categories For Category", Description = "Get All The Categories in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Category Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CategoryClass>> GetMainCategoriesForCategory(int CategoryId);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCategoriesWithMap")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Categories With Map", Description = "Get The Sons Categories For the Given Parent Category ID With All The Parents Categories", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Categories With Map Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CategoriesWithMapClass> GetCategoriesWithMap(int LoggedUser, string CountryName, bool FilterByParentId,
          int ParentId, int Type, int PageId, int RecordsCount);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/SearchCategories")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Search Categories", Description = "Get Categories By Arabic Name or Code or Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Category Classes",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CategoryClass>> SearchCategories(int LoggedUser, bool FilterByParentId, int ParentId, int Type, int PageId, int RecordsCount, string ArabicName, string Code);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCategoriesTree")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Categories Tree", Description = "Get All Categories Ordered By hierarchy", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Categories Tree Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<IEnumerable<CategoryTreeClass<CategoryClass>>> GetCategoriesTree(int LoggedUser, string CountryName, int PageId, int RecordsCount, string Language = "ar");


        /*end of omar section */

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItem")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Item", Description = "Get The Item Information which has the enterd ID", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemClass> GetItem(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItems")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Items", Description = "Get All The Items in The Category with the Enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Items Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass>> GetItems(int LoggedUser, int CategoryId, int PageId, int RecordsCount, bool IsLikes, bool IsWishlist);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItems_Short")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Items Short", Description = "Get All The Items in The Category with the Enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Items Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass_Short>> GetItems_Short(int LoggedUser, int CategoryId, int PageId, int RecordsCount, bool IsLikes, bool IsWishlist);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItem")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemClass> CreateItem(int LoggedUser, ItemClass Item);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItem")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemClass> UpdateItem(int LoggedUser, ItemClass Item);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteItem")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Item", Description = "Delete The Item which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemClass> DeleteItem(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchItems")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Search Items", Description = "Get Items After Applying (Category, Brand, Color, Country, Size, Name, Code, Description, ItemsWithOffers) Filters", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Item Classes",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass>> SearchItems(int LoggedUser, bool FilterByCategoryId, int CategoryId,
            bool FilterByBrandId, int BrandId, bool FilterByColorId, int ColorId, bool FilterByCountryId, int CountryId,
            string Size, bool ShowOnlyItemsWithOffers, string Name, string Code, string Description, int PageId,
            int RecordsCount, int? PriceCountryId, int? PriceCurrencyId, int? PriceTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchItems_Multi")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Search Items Multi", Description = "Get Items Filtering By Item Search Class", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Item Classes",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass>> SearchItems_Multi(int LoggedUser, ItemSearchClass itemSearch, int PageId, int RecordsCount,
            int? PriceCountryId, int? PriceCurrencyId, int? PriceTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchItems_Short")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemClass_Short>> SearchItems_Short(int LoggedUser, bool FilterByCategoryId, int CategoryId,
            bool FilterByBrandId, int BrandId, bool FilterByColorId, int ColorId, bool FilterByCountryId, int CountryId,
            string Size, bool ShowOnlyItemsWithOffers, string Name, string Code, string Description, int PageId,
            int RecordsCount, int? PriceCountryId, int? PriceCurrencyId, int? PriceTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchItems_Multi_Short")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Search Items Multi", Description = "Get Items Filtering By Item Search Class", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List Of Short Item Classes",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass_Short>> SearchItems_Multi_Short(int LoggedUser, ItemSearchClass itemSearch, int PageId,
            int RecordsCount, int? PriceCountryId, int? PriceCurrencyId, int? PriceTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemFilters")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Item Filters", Description = "Get The Brand Information which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Filters Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemFiltersClass> GetItemFilters(int LoggedUser, int CategoryId, bool FilterByDisabled, bool ShowDisabled,
            List<int> itemsIds);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Item Data", Description = "Get the Information of the Enterd ID Item", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Items Data Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemsDataClass> GetItemData(int LoggedUser, int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Item Data", Description = "Create a New Item By Entering The Item Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Data Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemsDataClass> CreateItemData(int LoggedUser, ItemClass Item, List<int> Governorates, List<int> Companies, 
            List<int> UserTypes, List<ItemImageClass> Images, List<ItemColorClass> Colors, List<ItemSizeClass> Sizes, List<ItemPriceClass> Prices, List<int> Countries, List<ItemBookingDayClass> BookingDays, List<ItemSeriesClass> Series,
             List<ItemSerialClass> Serials, List<ItemTagClass> Tags, List<ItemSizePriceAddClass> SizesPrices, List<ItemColorPriceAddClass> ColorsPrices, List<int> MatchedItems);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Item Data", Description = "Update Item By Editing The Item Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Data Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemsDataClass> UpdateItemData(int LoggedUser, ItemClass Item, List<int> Governorates, List<int> Companies,
            List<int> UserTypes, List<ItemImageClass> Images, List<ItemColorClass> Colors, List<ItemSizeClass> Sizes, 
            List<ItemPriceClass> Prices, List<int> Countries, List<ItemBookingDayClass> BookingDays, 
            List<ItemSeriesClass> Series, List<ItemSerialClass> Serials, List<ItemTagClass> Tags, List<ItemSizePriceAddClass> SizesPrices, 
            List<ItemColorPriceAddClass> ColorsPrices, List<int> MatchedItems);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOrUpdateItemData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Or Update Item Data", Description = "Update Item By Editing The Item Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Data Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemsDataClass> CreateOrUpdateItemData(int LoggedUser, ItemClass Item, List<int> Governorates,
       List<int> Companies, List<int> UserTypes, List<ItemImageClass> Images, List<ItemColorClass> Colors, List<ItemSizeClass> Sizes, 
       List<ItemPriceClass> Prices, List<int> Countries, 
       List<ItemBookingDayClass> BookingDays, List<ItemSeriesClass> Series, List<ItemSerialClass> Serials,
       List<ItemTagClass> Tags, List<ItemSizePriceAddClass> SizesPrices, List<ItemColorPriceAddClass> ColorsPrices,
       List<int> MatchedItems);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetFeatureItems")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Feature Items", Description = "Get the Most Liked Items in The System or in a specific Category", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass>> GetFeatureItems(int LoggedUser, int? CategoryId, string CountryName, int PageId, int RecordsCount);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetBestSellingItems")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Feature Items", Description = "Get the Most Liked Items in The System or in a specific Category", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass>> GetBestSellingItems(int LoggedUser, int? CategoryId, string CountryName, int PageId, int RecordsCount);



        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemsFromExcel")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Feature Items", Description = "Get the Most Liked Items in The System or in a specific Category", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ResultClass<ItemsDataClass>>> CreateItemsFromExcel(int LoggedUser, string Url);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemsWithMap")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Items With Map", Description = "Get All The Items in the System (if Without Category ID) OR Get the Items in the Selected Category With it's Parents(if With Category ID)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Items With Map Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemsWithMapClass> GetItemsWithMap(int LoggedUser, int? CategoryId, string CountryName, int PageId, int RecordsCount, bool OrderByKey, string OrderKey);





        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemsGovernorate")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsGovernorateClass> GetItemsGovernorate(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemsGovernorates")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemsGovernorateClass>> GetItemsGovernorates(int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemsGovernorate")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsGovernorateClass> CreateItemsGovernorate(int LoggedUser, ItemsGovernorateClass ItemsGovernorate);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemsGovernorates")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemsGovernorateClass>> CreateItemsGovernorates(int LoggedUser, int ItemId, List<int> Governorates);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemsGovernorate")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsGovernorateClass> UpdateItemsGovernorate(int LoggedUser, ItemsGovernorateClass ItemsGovernorate);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemsGovernorates")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemsGovernorateClass>> UpdateItemsGovernorates(int LoggedUser, int ItemId, List<int> Governorates);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteItemsGovernorate")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsGovernorateClass> DeleteItemsGovernorate(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemsCompany")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsCompanyClass> GetItemsCompany(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemsCompanies")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemsCompanyClass>> GetItemsCompanies(int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemsCompany")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsCompanyClass> CreateItemsCompany(int LoggedUser, ItemsCompanyClass ItemsCompany);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemsCompanies")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemsCompanyClass>> CreateItemsCompanies(int LoggedUser, int ItemId, List<int> Companies);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemsCompany")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsCompanyClass> UpdateItemsCompany(int LoggedUser, ItemsCompanyClass ItemsCompany);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemsCompanies")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemsCompanyClass>> UpdateItemsCompanies(int LoggedUser, int ItemId, List<int> Companies);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteItemsCompany")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsCompanyClass> DeleteItemsCompany(int LoggedUser, int Id);

        /*
        GetItemsCountry
        GetItemsCountries
        CreateItemsCountry
        CreateItemsCountry
        UpdateItemsCountry
        UpdateItemsCountries
        DeleteItemsCountry
            */

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemsUsersType")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsUsersTypeClass> GetItemsUsersType(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemsUsersTypes")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemsUsersTypeClass>> GetItemsUsersTypes(int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemsUsersType")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsUsersTypeClass> CreateItemsUsersType(int LoggedUser, ItemsUsersTypeClass ItemsUsersType);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemsUsersTypes")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemsUsersTypeClass>> CreateItemsUsersTypes(int LoggedUser, int ItemId, List<int> UserTypes);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemsUsersType")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsUsersTypeClass> UpdateItemsUsersType(int LoggedUser, ItemsUsersTypeClass ItemsUsersType);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemsUsersTypes")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemsUsersTypeClass>> UpdateItemsUsersTypes(int LoggedUser, int ItemId, List<int> UserTypes);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteItemsUsersType")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemsUsersTypeClass> DeleteItemsUsersType(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetCountriesCurrenciesPriceTypes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Countries Currencies Price Types", Description = "Gets all country currencies prices in 2 arrays (one for main prices that depends on config country and currency) and 2nd one is normal prices for all countries and currencies except config country and currency", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return array of Item Price Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CountryCurrencyPriceTypeClass> GetCountriesCurrenciesPriceTypes();

        //ItemImages

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemImages")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemImageClass>> GetItemImages(int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemColor")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemColorClass> GetItemColor(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemColors")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemColorClass>> GetItemColors(int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemColor")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemColorClass> CreateItemColor(int LoggedUser, ItemColorClass ItemColor);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemColor")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemColorClass> UpdateItemColor(int LoggedUser, ItemColorClass ItemColor);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteItemColor")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemColorClass> DeleteItemColor(int LoggedUser, int Id);



        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemSize")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemSizeClass> GetItemSize(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemSizes")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemSizeClass>> GetItemSizes(int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemSize")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemSizeClass> CreateItemSize(int LoggedUser, ItemSizeClass ItemSize);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemSize")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemSizeClass> UpdateItemSize(int LoggedUser, ItemSizeClass ItemSize);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteItemSize")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemSizeClass> DeleteItemSize(int LoggedUser, int Id);




        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/LikeItem")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Like Item", Description = "Increase The Total Likes By One For The Selected Item", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Like Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemLikeClass> LikeItem(int LoggedUser, int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/RemoveLikeItem")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Remove Like Item", Description = "Decrease The Total Likes By One For The Selected Item", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Like Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemLikeClass> RemoveLikeItem(int LoggedUser, int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemLikes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Item Likes", Description = "Gets The Number of Likes for The Selected Item", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Like Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemLikeClass>> GetItemLikes(int UserId, int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchItemLikes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Search Item Likes", Description = "Filter For Item Likes By User ID (The Same Logged User) and From/To Date", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Like Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemLikeClass>> SearchItemLikes(int LoggedUser,
            bool FilterByItemId, List<int> ItemIds,
            bool FilterByUserId, List<int> UserIds,
            bool FilterByDates, string FromDate, string ToDate,
            int PageId, int RecordsCount);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetPeopleAlsoLikeItems")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get People Also Like Items", Description = "Get The Items That Another Users Likes and They Like The Selected Item (Orderd By The Most Common)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass>> GetPeopleAlsoLikeItems(int LoggedUser, int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/WishlistItem")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Wish list Item", Description = "Increase The Total Wishes By One For The Selected Item", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Wish list Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemWishlistClass> WishlistItem(int LoggedUser, int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/RemoveWishlistItem")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Remove Wish list Item", Description = "Decrease The Total Wishes By One For The Selected Item", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Wish list Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemWishlistClass> RemoveWishlistItem(int LoggedUser, int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchItemWishlists")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Search Item Wish list", Description = "Filter For Item Wish list By User ID (The Same Logged User) and From/To Date", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Wish list Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemWishlistClass>> SearchItemWishlists(int LoggedUser,
           bool FilterByItemId, List<int> ItemIds,
           bool FilterByUserId, List<int> UserIds,
           bool FilterByDates, string FromDate, string ToDate,
           int PageId, int RecordsCount);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemWishlists")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Item Wish list", Description = "Gets The Number of Wishes for The Selected Item", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Wish list Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemWishlistClass>> GetItemWishlists(int UserId, int ItemId);




        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemRating")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Item Rating", Description = "Submit Rate on the Selected Item and Return The Total Rating percentage For the Item", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Rating Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemRatingClass> CreateItemRating(int LoggedUser, int ItemId, double Rating);





        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetSizesGroup")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Sizes Group", Description = "Get The Selected Size Group Information ", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Sizes Group Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<SizesGroupClass> GetSizesGroup(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetSizesGroups")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Sizes Group", Description = "Get All The Sizes Groupes In The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Sizes Group Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<SizesGroupClass>> GetSizesGroups();

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateSizesGroup")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Sizes Group", Description = "Create a New Size Group By Entering The Size Group Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Sizes Group Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<SizesGroupClass> CreateSizesGroup(int LoggedUser, SizesGroupClass SizesGroup);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateSizesGroup")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Sizes Group", Description = "Update Size Group By Editing The Size Group Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Sizes Group Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<SizesGroupClass> UpdateSizesGroup(int LoggedUser, SizesGroupClass SizesGroup);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteSizesGroup")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Sizes Group", Description = "Delete The Size Group which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Sizes Group Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<SizesGroupClass> DeleteSizesGroup(int LoggedUser, int Id);





        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetPriceTypes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Price Types", Description = "Get All The Price Types In The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Price Type Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<PriceTypeClass>> GetPriceTypes(int? Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreatePriceType")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Price Type", Description = "Create a New Price Type By Entering The Price Type Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Price Type Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<PriceTypeClass> CreatePriceType(int LoggedUser, PriceTypeClass PriceType);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdatePriceType")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Price Type", Description = "Update Price Type By Editing The Price Type Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Price Type Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<PriceTypeClass> UpdatePriceType(int LoggedUser, PriceTypeClass PriceType);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeletePriceType")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Price Type", Description = "Delete The Price Type which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Price Type Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<PriceTypeClass> DeletePriceType(int LoggedUser, int Id);





        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetSize")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Size", Description = "Get The Selected Size Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Size Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<SizeClass> GetSize(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetSizes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Sizes", Description = "Get The Sizes For the Selected Size Group ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Size Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<SizeClass>> GetSizes(int SizeGroupId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetAllSizes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get All Sizes", Description = "Get All The Sizes in The System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Size Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<SizeClass>> GetAllSizes();

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateSize")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Size", Description = "Create a New Size By Entering The Size Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Size Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<SizeClass> CreateSize(int LoggedUser, SizeClass Size);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateSize")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Size", Description = "Update Size By Editing The Size Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Size Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<SizeClass> UpdateSize(int LoggedUser, SizeClass Size);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteSize")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Size", Description = "Delete The Size which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Size Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<SizeClass> DeleteSize(int LoggedUser, int Id);


        //Items Barcodes
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetBarcodes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Barcodes", Description = "Get All the Colors and Sizes correlations with their Barcodes for the Selected Item", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Barcodes Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<BarcodesClass>> GetBarcodes(int LoggedUser, int ItemId);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemsBarcodes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Items Barcodes", Description = "Modify the Selected Item's (Barcodes, Quantitiy, Color Code, Item Code) from BarcodesTbl", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Barcodes Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<BarcodesClass>> UpdateItemsBarcodes(int LoggedUser, int ItemId, List<BarcodesClass> Barcodes);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/ImportBarcodes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Import Barcodes", Description = "Insert the Item's Barcode Data form the Excel File to the Database", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Tow Listes of Barcode Result Class (Success List, Failed List)",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BarcodeResultClass> ImportBarcodes(int LoggedUser, List<BarcodesClass> Barcodes, bool FromExcel = false);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/ImportBarcodesFromExcel")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Import Barcodes From Excel", Description = "Create the Item's Barcodes Data Objects from the Enterd Excel File and Calls 'ImportBarcodes' API", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Tow Listes of Barcode Result Class (Success List, Failed List)",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BarcodeResultClass> ImportBarcodesFromExcel(int LoggedUser, string Url,
          string WorksheetName, int firstRow, string ItemColumn, string ColorColumn, string SizeColumn, string QuantityColumn, string BarcodeColumn);



        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetBanner")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Banner", Description = "Get The Selected Banner Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Banner Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BannerClass> GetBanner(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetBanners")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Banners", Description = "Get All The Banners in the System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Banner Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<BannerClass>> GetBanners(bool ForClients);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateBanner")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Banner", Description = "Create a New Banner By Entering The Banner Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Banner Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BannerClass> CreateBanner(int LoggedUser, BannerClass Banner);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateBanner")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Banner", Description = "Update Banner By Editing The Banner Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Banner Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BannerClass> UpdateBanner(int LoggedUser, BannerClass Banner);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteBanner")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Banner", Description = "Delete The Banner which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Banner Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<BannerClass> DeleteBanner(int LoggedUser, int Id);

        // offers

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOffers")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Offers", Description = "Get All The Offers in the System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Offer Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<OfferClass>> GetOffers();

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOffer")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OfferClass> GetOffer(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOffer")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OfferClass> CreateOffer(int LoggedUser, OfferClass Offer);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOffer")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OfferClass> UpdateOffer(int LoggedUser, OfferClass Offer);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteOffer")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Offer", Description = "Delete The Offer which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Offer Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OfferClass> DeleteOffer(int LoggedUser, int Id);






        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOfferData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Offer Data", Description = "Get The Selected Offer Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Offer Data Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OfferDataClass> GetOfferData(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOfferData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Offer Data", Description = "Create a New Offer By Entering The Offer Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Offer Data Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OfferDataClass> CreateOfferData(int LoggedUser, OfferClass Offer, List<int> Governorates, List<int> Companies, List<int> UserTypes, List<int> Countries);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOfferData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Offer Data", Description = "Update Offer By Editing The Offer Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Offer Data Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OfferDataClass> UpdateOfferData(int LoggedUser, OfferClass Offer, List<int> Governorates, List<int> Companies, List<int> UserTypes, List<int> Countries);


        [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "JSON/GetOfferTypes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Offer Types", Description = "Get All The Offer Types in the System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Offer Type Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<OfferTypeClass>> GetOfferTypes();



        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOffersGovernorate")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersGovernorateClass> GetOffersGovernorate(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOffersGovernorates")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<OffersGovernorateClass>> GetOffersGovernorates(int OfferId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOffersGovernorate")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersGovernorateClass> CreateOffersGovernorate(int LoggedUser, OffersGovernorateClass OffersGovernorate);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOffersGovernorates")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<OffersGovernorateClass>> CreateOffersGovernorates(int LoggedUser, int OfferId, List<int> Governorates);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOffersGovernorate")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersGovernorateClass> UpdateOffersGovernorate(int LoggedUser, OffersGovernorateClass OffersGovernorate);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOffersGovernorates")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<OffersGovernorateClass>> UpdateOffersGovernorates(int LoggedUser, int OfferId, List<int> Governorates);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteOffersGovernorate")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersGovernorateClass> DeleteOffersGovernorate(int LoggedUser, int Id);





        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOffersCompany")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersCompanyClass> GetOffersCompany(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOffersCompanies")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<OffersCompanyClass>> GetOffersCompanies(int OfferId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOffersCompany")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersCompanyClass> CreateOffersCompany(int LoggedUser, OffersCompanyClass OffersCompany);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOffersCompanies")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<OffersCompanyClass>> CreateOffersCompanies(int LoggedUser, int OfferId, List<int> Companies);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOffersCompany")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersCompanyClass> UpdateOffersCompany(int LoggedUser, OffersCompanyClass OffersCompany);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOffersCompanies")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<OffersCompanyClass>> UpdateOffersCompanies(int LoggedUser, int OfferId, List<int> Companies);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteOffersCompany")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersCompanyClass> DeleteOffersCompany(int LoggedUser, int Id);

        /*
        GetOffersCountries
        GetOffersCountry
        CreateOffersCountry
        CreateOffersCountries
        UpdateOffersCountry
        UpdateOffersCountries
        DeleteOffersCountry
        */

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOffersUsersType")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersUsersTypeClass> GetOffersUsersType(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOffersUsersTypes")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<OffersUsersTypeClass>> GetOffersUsersTypes(int OfferId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOffersUsersType")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersUsersTypeClass> CreateOffersUsersType(int LoggedUser, OffersUsersTypeClass OffersUsersType);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOffersUsersTypes")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<OffersUsersTypeClass>> CreateOffersUsersTypes(int LoggedUser, int OfferId, List<int> UserTypes);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOffersUsersType")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersUsersTypeClass> UpdateOffersUsersType(int LoggedUser, OffersUsersTypeClass OffersUsersType);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOffersUsersTypes")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<OffersUsersTypeClass>> UpdateOffersUsersTypes(int LoggedUser, int OfferId, List<int> UserTypes);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteOffersUsersType")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersUsersTypeClass> DeleteOffersUsersType(int LoggedUser, int Id);






        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOffersDetail")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OffersDetailClass> GetOffersDetail(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOffersDetails")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Offers Details", Description = "Get The Included Items In the Selected Offer", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Offers Details Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<OffersDetailClass>> GetOffersDetails(int OfferId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOffersDetail")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Offers Detail", Description = "Include New Item And It's Information For The Selected Offer", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Offers Details Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OffersDetailClass> CreateOffersDetail(int LoggedUser, OffersDetailClass OffersDetail);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOffersDetail")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Offers Detail", Description = "Change Item or Edite It's Information in The Selected Offer", Deprecated = true)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Offers Details Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OffersDetailClass> UpdateOffersDetail(int LoggedUser, OffersDetailClass OffersDetail);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteOffersDetail")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Offers Detail", Description = "Remove The Selected Item From The Selected Offer", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Offers Details Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OffersDetailClass> DeleteOffersDetail(int LoggedUser, int Id);

        //GetOfferDetailData





        // Orders
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOrders")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Orders", Description = "Get All the Orders in the System According to Filters (Posted, Status, User, Date, Note) With Paging", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Order Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<OrderClass>> GetOrders(int LoggedUser, bool FilterByPosted, bool IsPosted,
            bool FilterByStatusId, int StatusId, bool FilterByUserId, List<int> UserId,
            bool FilterByDate, string FromDate, string ToDate,
            bool FilterByNote, string Note,
            int PageId = 1, int RecordsCount = 20, bool ForApprove = false, int Id = 0);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOrdersNew")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Orders", Description = "Get All the Orders in the System According to Filters (Posted, Status, User, Date, Note) With Paging", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Order Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<OrderClass>> GetOrdersNew(int LoggedUser, bool FilterByPosted, bool IsPosted,
       bool FilterByStatusId, List<int> StatusIds,
       bool FilterByOrderTypeId, List<int> OrderTypeIds,
       bool FilterByPaymentTypeId, List<int> PaymentTypeIds,
       bool FilterByBranchId, List<int> BranchIds,
       bool FilterByUserId, List<int> UserIds,
       bool FilterByDate, string FromDate, string ToDate,
       bool FilterByNote, string Note,
       int PageId = 1, int RecordsCount = 20, bool ForApprove = false);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOrder")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Order", Description = "Get the Order's Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Order Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OrderClass> GetOrder(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOrder")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OrderClass> CreateOrder(int LoggedUser, OrderClass Order);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOrder")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Order", Description = "Update Order By Editing The Order Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Order Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OrderClass> UpdateOrder(int LoggedUser, OrderClass Order);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteOrder")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Order", Description = "Delete The Order which has the enterd ID", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Order Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OrderClass> DeleteOrder(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetLastOpenOrderForClient")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Last Open Order For Client", Description = "Get the Client's Cart (Last Open Order For the Client) Information", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Order Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OrderClass> GetLastOpenOrderForClient(int LoggedUser);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetLastOpenOrderBadge")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Last Open Order For Badge", Description = "Get The Number of Carts That the Client has", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Integer Number",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<int> GetLastOpenOrderBadge(int LoggedUser);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SetOrderPosted")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Set Order Posted", Description = "Change the Order Status To Posted", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Order Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OrderClass> SetOrderPosted(int LoggedUser, int OrderId, int OrderDetailId, bool Posted, int OrderTypeId, int PaymentTypeId, int BranchId, string UserNote,
           string LocationDeliveryDate, bool IsImmediateDelivery, int LocationDayTimesId, int CouponId, int AgentId);




        //OrderDetails
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOrderDetails")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Order Details", Description = "Get The Items Details Information in The Selected Order", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Order Detail Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<OrderDetailClass>> GetOrderDetails(int OrderId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOrderDetail")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OrderDetailClass> GetOrderDetail(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOrderDetail")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Order Detail", Description = "Add New Item For The Selected Order", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Order Detail Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OrderDetailClass> CreateOrderDetail(int LoggedUser, OrderDetailClass OrderDetail);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOrderDetailForClient")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<OrderDetailClass>> CreateOrderDetailForClient(int LoggedUser, OrderDetailClass OrderDetail);

        [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "JSON/UpdateOrderDetail")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Order Detail", Description = "Edite Item's User Note And Delivery Adress In the Selected Order", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Order Detail Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OrderDetailClass> UpdateOrderDetail(int LoggedUser, OrderDetailClass OrderDetail);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/RenewQuantityReservationCount")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Renew Quantity Reservation Count", Description = "Reset The Item's Timing in the Selected Order", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Order Detail Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OrderDetailClass> RenewQuantityReservationCount(int LoggedUser, int OrderDetailId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteOrderDetail")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Order Detail", Description = "Delete an Item From The Selected Order", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Order Detail Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OrderDetailClass> DeleteOrderDetail(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOrderDetailForClient_ForMatjar")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Order Detail For Client For Matjar", Description = "Add an Item For the Client's Cart (Order)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Order Detail Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<OrderDetailClass>> CreateOrderDetailForClient_ForMatjar(int LoggedUser, OrderDetailClass OrderDetail);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOrderDetail_ForMatjar")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OrderDetailClass> CreateOrderDetail_ForMatjar(int LoggedUser, OrderDetailClass OrderDetail);






        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UploadImages?Type={Type}")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Upload Images", Description = "Save The Images From The Requist To The Server", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Upload Result Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UploadResultClass>> UploadImages([SwaggerWcfParameter(Required = true, Description = "The Image Type (Banner, Item, Category)", ParameterType = typeof(int))]int Type);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UploadExcelFile")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ExcelFileClass> UploadExcelFile();

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UploadExcel")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Upload Excel", Description = "Save The Excel File From The Requist To The Server", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Upload Result Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UploadResultClass> UploadExcel();

        [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "JSON/CheckUploadImage")]
        ResultClass<List<string>> CheckUploadImage(List<string> ImagesList);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UploadItemImages")]
        ResultClass<List<ItemImageClass>> UploadItemImages();

        //Reports

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetDeviceLogReport")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Device Log Report", Description = "Get The User's Informations Who Opend The Application and their Devises and The Application's Total Visites with a Feature that Allows the User to Filter Through Multiple Options (Date, User)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Device Log Report Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<DeviceLogReportClass> GetDeviceLogReport(int LoggedUser, string FromDate, string ToDate, List<int> UserIds, int RecordsCount = 9999999, int PageId = 1);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/TransfersReport")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Transfer Report", Description = "Get All the Transfers Operations Between Users With the User's Information in the System with a feature that allows the user to filter through multiple options (Date, Sender User, Receiver User, Transfer Method)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Transfer Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<TransferClass>> TransfersReport(int LoggedUser, TransfersReportParamsClass ReportParams, int RecordsCount = 99999999, int PageId = 1);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemOrdersReport")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemOrdersReportResultClass> GetItemOrdersReport(int LoggedUser, ItemOrdersReportClass ItemOrdersReport);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemOrdersReport_Multi")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Item Orders Report Multi", Description = "Get The Selected Items's Orders Details And (Orders Number, Total Points, Total Quantity) with a feature that allows the user to filter through multiple options (Date, User)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Orders Report Result Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemOrdersReportResultClass> GetItemOrdersReport_Multi(int LoggedUser, ItemOrdersReportClass ItemOrdersReport, int RecordsCount = 99999999, int PageId = 1);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOrderDetailsReport")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Order Details Report", Description = "Get The Selected Offers's Orders Details with a feature that allows the user to filter through multiple options (Date, User)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Order Details Report Result Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<OrderDetailsReportResultClass>> GetOrderDetailsReport(int LoggedUser, OrderDetailsReport OrderDetailsReport, int RecordsCount = 99999999, int PageId = 1);





        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetTotalUserBalanceReport")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Total User Balance Report", Description = "Get All the User's Balances with a feature that allows the user to filter through multiple options (Date, Sender User, Receiver User, studied User, Users's Blance Status 'Used Before or Not')", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Total User Balance Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<TotalUserBalanceReportClass>> GetTotalUserBalanceReport(int LoggedUser,
            bool FilterByDate, string FromDate, string ToDate,
            List<int> UserIds, List<int> Sender_UserIds, List<int> Receiver_UserIds,
            bool ShowUsersWhoHaveResultsOnly, int RecordsCount = 99999999, int PageId = 1);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/PointsReport")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Points Report", Description = "Get All the User's Points Operations with a feature that allows the user to filter through multiple options (Date, Sender User, Receiver User, studied User, Operation Type)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Points Report Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<PointsReportClass>> PointsReport(int LoggedUser,
            bool FilterByDate, string FromDate, string ToDate,
            List<int> UserIds, bool FilterBySendersIds, List<int> SendersIds, bool FilterByReceiversIds, List<int> ReceiversIds,
            bool FilterByOperations, List<int> OperationsIds, int RecordsCount = 99999999, int PageId = 1);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/TotalPointsReportApp")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Total Points Report App", Description = "Get All the User's Points Operations 'Send and/or Receive' With the Operations Totals with a feature that allows the user to filter through multiple options (Date, Sender User, Receiver User, studied User)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Total Points Report App Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<TotalPointsReportAppClass> TotalPointsReportApp(int LoggedUser,
            bool FilterByDate, string FromDate, string ToDate,
            List<int> UserIds, bool FilterBySendersIds, List<int> SendersIds, bool FilterByReceiversIds, List<int> ReceiversIds,
            bool FilterByOperations, List<int> OperationsIds, int RecordsCount = 99999999, int PageId = 1);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/TotalPointsReport")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<TotalPointsReportClass>> TotalPointsReport(int LoggedUser,
            bool FilterByDate, string FromDate, string ToDate,
            List<int> UserIds, bool FilterBySendersIds, List<int> SendersIds, bool FilterByReceiversIds, List<int> ReceiversIds,
            bool FilterByOperations, List<int> OperationsIds, int RecordsCount = 99999999, int PageId = 1);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UserSessionsReport")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "User Sessions Report", Description = "Get The Number of Users They Opened The Application in The Selected Date By Day or Hour with a feature that allows the user to filter By Users and The Viewed Result (Only Registerd, Only Guests, All Users)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Session Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserSessionClass>> UserSessionsReport(int LoggedUser,
            bool FilterByUserId, List<int> UserIds,
            bool FilterByDates, string FromDate, string ToDate,
            bool FilterByTimes, string FromTime, string ToTime,
            bool FilterByUserType, bool ShowGuest, bool ShowRegisteredUser,
            bool GroupByDay, bool GroupByHour,
            int PageId = 1, int RecordsCount = 10000);



        //Auditing

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetAuditLog")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Audit Log", Description = "Get All the System Modifications with Modifier User and the Modification Type and it's Date", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Audit Log Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<AuditLogClass>> GetAuditLog(int LoggedUser, int PageId = 1, int RecordsCount = 10000);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetAuditLogDetails")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Audit Log Details", Description = "Get the Selected Modification Details (Modified Field, Table Name, Old Value, New Value)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Audit Log Details Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<AuditLogClass>> GetAuditLogDetails(int LoggedUser, string Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchAuditLog")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<AuditLogClass>> SearchAuditLog(int LoggedUser,
            bool FilterByUserId, int UserId,
            bool FilterByCustomName, string CustomName,
            bool FilterByType, string Type,
            bool FilterDates, string FromDate, string ToDate,
            int PageId = 1, int RecordsCount = 10000);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchAuditLog_Multi")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Search Audit Log Multi", Description = "Get Audit Log With Filters (User ID, Table Name, Field Name, Modifid Value, Modification Type, Date)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Audit Log Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<AuditLogClass>> SearchAuditLog_Multi(int LoggedUser,
            bool FilterByUserId, List<int> UserIds,
            bool FilterByCustomName, string CustomName,
            bool FilterByFieldName, string FieldName,
            bool FilterByValue, string Value,
            bool FilterByType, string Type,
            bool FilterDates, string FromDate, string ToDate,
            int PageId = 1, int RecordsCount = 10000);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetTablesCustomName")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Tables Custom Name", Description = "Get All The Tables Names in the System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Custom Table Name Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CustomTableNameClass>> GetTablesCustomName(int LoggedUser);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetColumnsCustomName")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Columns Custom Name", Description = "Get the Columns Names for the Selected Table", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Custom Columns Name Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CustomColumnNameClass>> GetColumnsCustomName(int LoggedUser, int TableId);





        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/ExportToExcel")]
        [SwaggerWcfPath(Deprecated = true)]
        Stream ExportToExcel();




        //EXCEL
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUserExcelReports")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Excel Reports", Description = "Get the Reports that the User Had Exported to Excel", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Excel Report Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ExcelReportClass>> GetUserExcelReports(int LoggedUser);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserExcelReports")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ExcelReportClass> CreateUserExcelReports(int LoggedUser, string ReportName, string ReportURL);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserExcelReports")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ExcelReportClass> DeleteUserExcelReports(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchUserExcelReports")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Search User Excel Reports", Description = "Search in User's Excel Rrports By Date and Report Name", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Excel Report Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ExcelReportClass>> SearchUserExcelReports(int LoggedUser,
            bool FilterByDate, string FromDate, string ToDate,
            bool FilterByReportName, List<string> ReportsName);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserExcelReports_Multi")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Excel Reports Multi", Description = "Delete the Selected Exported Excel Report", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Excel Report Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ExcelReportClass>> DeleteUserExcelReports_Multi(int LoggedUser, List<int> Ids);




        //For Public
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemsForPublic")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemClass>> GetItemsForPublic(int CategoryId, int PageId, int RecordsCount);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItems_ShortForPublic")]
        [SwaggerWcfPath(Summary = "Get Items Short For Public", Description = "Get The Items in the Selected Category", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Class Short Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass_Short>> GetItems_ShortForPublic(int CategoryId, int PageId, int RecordsCount);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemsWithMapForPublic")]
        [SwaggerWcfPath(Summary = "Get Items With Map For Public", Description = "Get The Items in the Selected Category and the their Categories Map with Ordering Feature", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Items With Map Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemsWithMapClass> GetItemsWithMapForPublic(int? CategoryId, string CountryName, int PageId, int RecordsCount, bool OrderByKey, string OrderKey);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemDataForPublic")]
        [SwaggerWcfPath(Summary = "Get Item Data For Public", Description = "Get All the Data for the Selected Item", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Items Data Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemsDataClass> GetItemDataForPublic(int CountryId, int ItemId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetFeatureItemsForPublic")]
        [SwaggerWcfPath(Summary = "Get Feature Items For Public", Description = "Get the Most Liked Items", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass>> GetFeatureItemsForPublic(int? CategoryId, string CountryName, int PageId, int RecordsCount);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetBestSellingItemsForPublic")]
        [SwaggerWcfPath(Summary = "Get Best Selling Items For Public", Description = "Get the Most Orderd Items", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass>> GetBestSellingItemsForPublic(int? CategoryId, int CountryId, int PageId, int RecordsCount);

        [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "JSON/GetPeopleAlsoLikeItemsForPublic")]
        ResultClass<List<ItemClass>> GetPeopleAlsoLikeItemsForPublic(int CountryId, int ItemId);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchItemsForPublic")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemClass>> SearchItemsForPublic(bool FilterByCategoryId, int CategoryId,
            bool FilterByBrandId, int BrandId, bool FilterByColorId, int ColorId, int CountryId,
            string Size, bool ShowOnlyItemsWithOffers, string Name, string Code, string Description, int PageId,
            int RecordsCount);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchItems_MultiForPublic")]
        [SwaggerWcfPath(Summary = "Search Items Multi For Public", Description = "Get Items With Filtering By each Property of Item Search Class Properties", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass>> SearchItems_MultiForPublic(int CountryId, ItemSearchClass itemSearch, int PageId,
        int RecordsCount, int? PriceCountryId, int? PriceCurrencyId, int? PriceTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SearchItems_Multi_ShortForPublic")]
        [SwaggerWcfPath(Summary = "Search Items Multi Short For Public", Description = "Get Items With Filtering By each Property of Item Search Class Properties", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Class Short Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass_Short>> SearchItems_Multi_ShortForPublic(int CountryId, ItemSearchClass itemSearch, int PageId,
            int RecordsCount, int? PriceCountryId, int? PriceCurrencyId, int? PriceTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemFiltersForPublic")]
        [SwaggerWcfPath(Summary = "Get Item Filters For Public", Description = "Get All the Item's Filters or the Filters for the Selected Category", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Item Filters Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<ItemFiltersClass> GetItemFiltersForPublic(int CountryId, int CategoryId, List<int> itemsIds);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetCategoriesWithMapForPublic")]
        [SwaggerWcfPath(Summary = "Get Categories With Map For Public", Description = "Get the Parentes Map and the Sub Categories for the Selected Category", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Categories With Map Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<CategoriesWithMapClass> GetCategoriesWithMapForPublic(string CountryName, bool FilterByParentId, int ParentId, int Type, int PageId, int RecordsCount);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetFeatureCategories")]
        [SwaggerWcfPath(Summary = "Get Feature Categories", Description = "Get the Categories of The Most Liked Items", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Category Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<CategoryClass>> GetFeatureCategories(int? CategoryId, string CountryName, int PageId, int RecordsCount);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetCategoriesTreeForPublic")]
        [SwaggerWcfPath(Summary = "Get Categories Tree For Public", Description = "Get each Category's Tree of Categories", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Category Tree Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<IEnumerable<CategoryTreeClass<CategoryClass>>> GetCategoriesTreeForPublic(string CountryName, int PageId, int RecordsCount, string Language = "ar");

        /*START NOT USED ANYMORE*/
        //OfferDetailsPrices

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOfferDetailPrices")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<OfferDetailPriceClass>> GetOfferDetailPrices(int? Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOfferDetailPrice")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OfferDetailPriceClass> CreateOfferDetailPrice(int LoggedUser, OfferDetailPriceClass OfferDetailPrice);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOfferDetailPrice")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OfferDetailPriceClass> UpdateOfferDetailPrice(int LoggedUser, OfferDetailPriceClass OfferDetailPrice);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteOfferDetailPrice")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<OfferDetailPriceClass> DeleteOfferDetailPrice(int LoggedUser, int Id);

        /*END NOT USED ANYMORE*/

        /*START Not used Anymore*/

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemPrices")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<ItemPriceClass>> GetItemPrices(int ItemId, int CountryId, int? TypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemPrice")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemPriceClass> CreateItemPrice(int LoggedUser, ItemPriceClass ItemPrice);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemPrice")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemPriceClass> UpdateItemPrice(int LoggedUser, ItemPriceClass ItemPrice);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteItemPrice")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<ItemPriceClass> DeleteItemPrice(int LoggedUser, int Id);

        /*End Not used Anymore*/


        [SwaggerWcfPath("Create book", "Create a book on the store")]
        [WebInvoke(UriTemplate = "/books?value={value}",
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string CreateBook(string value);



        //end Amer section 

        //Start Adding from Nuqaty



        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserTransferType")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<UserTransferTypeClass> CreateUserTransferType(int LoggedUser, UserTransferTypeClass UserTransferType);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserTransferType")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<UserTransferTypeClass> DeleteUserTransferType(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateUserTransferType")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<UserTransferTypeClass> UpdateUserTransferType(int LoggedUser, UserTransferTypeClass UserTransferType);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUserTransferTypes")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<List<UserTransferTypeClass>> GetUserTransferTypes(int? Id);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUserTypeSendRules")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Type Send Rules", Description = "Get the Selected User Type's Send Rules", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Send Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserTypeSendRuleClass>> GetUserTypeSendRules(int LoggedUser, int UserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUserTypeWithdrawRules")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Type Withdraw Rules", Description = "Get the Selected User Type's Withdrawal Rules", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Withdraw Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserTypeWithdrawRuleClass>> GetUserTypeWithdrawRules(int LoggedUser, int UserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetUserTypeGiftsRules")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Type Gifts Rules", Description = "Get the Selected User Type's Gifts Rules", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Gifts Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserTypeGiftsRuleClass>> GetUserTypeGiftsRules(int LoggedUser, int UserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateUserTypeSendRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Type Send Rule", Description = "Edite the Selected Rule in the Selected User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Send Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserTypeSendRuleClass> UpdateUserTypeSendRule(int LoggedUser, int Id, int UserTypeId, int ToUserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateUserTypeGiftsRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Type Gifts Rule", Description = "Edite the Selected Rule in the Selected User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Gift Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserTypeGiftsRuleClass> UpdateUserTypeGiftsRule(int LoggedUser, int Id, int UserTypeId, int ToUserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateUserTypeWithdrawRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Type Withdraw Rule", Description = "Edite the Selected Rule in the Selected User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Withdraw Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserTypeWithdrawRuleClass> UpdateUserTypeWithdrawRule(int LoggedUser, int Id, int UserTypeId, int FromUserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserTypeSendRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create User Type Send Rule", Description = "Add New Send Rule for the Selected User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Send Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserTypeSendRuleClass> CreateUserTypeSendRule(int LoggedUser, int UserTypeId, int ToUserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserTypeGiftsRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create User Type Gifts Rule", Description = "Add New Gift Rule for the Selected User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Gifts Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserTypeGiftsRuleClass> CreateUserTypeGiftsRule(int LoggedUser, int UserTypeId, int ToUserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserTypeWithdrawRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create User Type Withdraw Rule", Description = "Add New Withdraw Rule for the Selected User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Type Withdraw Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserTypeWithdrawRuleClass> CreateUserTypeWithdrawRule(int LoggedUser, int UserTypeId, int FromUserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserTypeSendRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Type Send Rule", Description = "Delete the selected Rule.. preventing the First User Type from Sending Points for the Second User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Type Send Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserTypeSendRuleClass> DeleteUserTypeSendRule(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserTypeGiftsRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Type Gifts Rule", Description = "Delete the selected Rule.. preventing the First User Type from Gifting Points for the Second User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Type Gifts Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserTypeGiftsRuleClass> DeleteUserTypeGiftsRule(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserTypeWithdrawRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Type Withdraw Rule", Description = "Delete the selected Rule.. preventing the First User Type from Withdrawing Points for the Second User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Type Withdraw Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserTypeWithdrawRuleClass> DeleteUserTypeWithdrawRule(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUserSendRules")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Send Rules", Description = "Get User Types That the Selected User Can Send Points to", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Send Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserSendRuleClass>> GetUserSendRules(int LoggedUser, int UserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUserWithdrawRules")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Withdraw Rules", Description = "Get User Types That the Selected User Can Withdraw Points from", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Withdraw Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserWithdrawRuleClass>> GetUserWithdrawRules(int LoggedUser, int UserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUserGiftsRules")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Gifts Rules", Description = "Get User Types That the Selected User Can Gift Points to", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Gifts Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserGiftsRuleClass>> GetUserGiftsRules(int LoggedUser, int UserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateUserSendRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Send Rule", Description = "Edite the Selected Send Rule for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Send Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserSendRuleClass>> UpdateUserSendRule(int LoggedUser, int Id, int UserId, int UserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateUserWithdrawRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Withdraw Rule", Description = "Edite the Selected Withdraw Rule for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Withdraw Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserWithdrawRuleClass>> UpdateUserWithdrawRule(int LoggedUser, int Id, int UserId, int UserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateUserGiftsRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Gifts Rule", Description = "Edite the Selected Gift Rule for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Gifts Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserGiftsRuleClass>> UpdateUserGiftsRule(int LoggedUser, int Id, int UserId, int UserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserSendRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create User Send Rule", Description = "Add New Send Rule for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Send Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserSendRuleClass>> CreateUserSendRule(int LoggedUser, int UserId, int UserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserWithdrawRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create User Withdraw Rule", Description = "Add New Withdraw Rule for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Withdraw Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserWithdrawRuleClass>> CreateUserWithdrawRule(int LoggedUser, int UserId, int UserTypeId);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserGiftsRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create User Gifts Rule", Description = "Add New Gift Rule for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Gifts Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserGiftsRuleClass>> CreateUserGiftsRule(int LoggedUser, int UserId, int UserTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserSendRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Send Rule", Description = "Delete the selected Send Rule.. preventing the Selected User from Sending Points for the Selected User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Send Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserSendRuleClass>> DeleteUserSendRule(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserWithdrawRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Withdraw Rule", Description = "Delete the selected Withdraw Rule.. preventing the Selected User from Withdrawing Points from the Selected User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Withdraw Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserWithdrawRuleClass>> DeleteUserWithdrawRule(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserGiftsRule")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Gifts Rule", Description = "Delete the selected Withdraw Gift Rule.. preventing the Selected User from Gifting Points for the Selected User Type", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Gifts Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserGiftsRuleClass>> DeleteUserGiftsRule(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUserSendExceptions")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Send Exceptions", Description = "Get Users That the Selected User Can't Send Points to", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Send Exception Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserSendExceptionClass>> GetUserSendExceptions(int LoggedUser, int UserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUserWithdrawExceptions")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Withdraw Exceptions", Description = "Get Users That the Selected User Can't Withdraw Points from", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Withdraw Exception Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserWithdrawExceptionClass>> GetUserWithdrawExceptions(int LoggedUser, int UserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUserGiftsExceptions")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Gifts Exceptions", Description = "Get Users That the Selected User Can't Gift Points to", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Gifts Exception Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserGiftsExceptionClass>> GetUserGiftsExceptions(int LoggedUser, int UserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateUserSendException")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Send Exception", Description = "Edite the Selected Send Exception for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Send Exception Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserSendExceptionClass>> UpdateUserSendException(int LoggedUser, int Id, int UserId, int ForbiddenUserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateUserWithdrawException")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Withdraw Exception", Description = "Edite the Selected Withdraw Exception for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Withdraw Exception Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserWithdrawExceptionClass>> UpdateUserWithdrawException(int LoggedUser, int Id, int UserId, int ForbiddenUserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateUserGiftsException")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Gifts Exception", Description = "Edite the Selected Gift Exception for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Gifts Exception Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserGiftsExceptionClass>> UpdateUserGiftsException(int LoggedUser, int Id, int UserId, int ForbiddenUserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserSendException")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create User Send Exception", Description = "Add New Send Exception for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Send Exception Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserSendExceptionClass>> CreateUserSendException(int LoggedUser, int UserId, int ForbiddenUserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserWithdrawException")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create User Withdraw Exception", Description = "Add New Withdraw Exception for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Withdraw Exception Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserWithdrawExceptionClass>> CreateUserWithdrawException(int LoggedUser, int UserId, int ForbiddenUserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserGiftsException")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create User Gifts Exception", Description = "Add New Gift Exception for the Selected User", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Gifts Exception Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserGiftsExceptionClass>> CreateUserGiftsException(int LoggedUser, int UserId, int ForbiddenUserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserSendException")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Send Exception", Description = "Delete the selected Send Exception Between Tow Users", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Send Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserSendExceptionClass>> DeleteUserSendException(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserWithdrawException")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Withdraw Exception", Description = "Delete the selected Withdraw Exception Between Tow Users", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Withdraw Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserWithdrawExceptionClass>> DeleteUserWithdrawException(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserGiftsException")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Gifts Exception", Description = "Delete the selected Gift Exception Between Tow Users", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Gifts Rule Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserGiftsExceptionClass>> DeleteUserGiftsException(int LoggedUser, int Id);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUserCompanies")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get User Companies", Description = "Get All the Companies Which the Selected User Can Transfer Points for the Users in This Company", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of User Company Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<UserCompanyClass>> GetUserCompanies(int UserId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUserCompany")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create User Company", Description = "Add a New Company for the Selected User So he Can Tranfer Points for the Users in This Company", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Company Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserCompanyClass> CreateUserCompany(int LoggedUser, UserCompanyClass UserCompany);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateUserCompany")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update User Company", Description = "Edite The User's Selected Company", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Company Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserCompanyClass> UpdateUserCompany(int LoggedUser, UserCompanyClass UserCompany);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUserCompany")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete User Company", Description = "Delete The User's Selected Company", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return User Company Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<UserCompanyClass> DeleteUserCompany(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateWithdrawTransfer")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<RequestClass> CreateWithdrawTransfer(int LoggedUser, string MobileNo, TransferClass Transfer);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/VerifyWithdrawTransfer")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<TransferClass> VerifyWithdrawTransfer(int LoggedUser, string RequestId, string PinCode);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SendSMS")]
        [SwaggerWcfPath(Deprecated = true)]
        ResultClass<VerifyMobileNumberClass> SendSMS(string MobileNo, string Body);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateMultipleWithdrawTransfer")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Multiple Withdraw Transfer", Description = "Withdaw the Same Enterd Amount of Points from the Selected Users", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Transfer Result Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<TransferResultClass>> CreateMultipleWithdrawTransfer(int LoggedUser, string Date, List<int> Senders_UserIds,
        double Amount, string Notes, int TransferStatusId, int Receiver_UserId);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetGrantPointTypes")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Grant Point Types", Description = "Get All the Grant Point Types in the System", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Grant Point Type Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<GrantPointTypeClass>> GetGrantPointTypes();





        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CheckOrderNotificationStatus")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Check Order Notification Status", Description = "Chicking if the decision for the Selected Order Notification Was Taken By the User (Manually) or By the System (Automatically)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Boolean true or false",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<bool> CheckOrderNotificationStatus(int LoggedUser, int Type, int NotificationId);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteMultipleItems")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Delete Multiple Items", Description = "Delete the Selected Items (More than one item per process)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return List of Item Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemClass>> DeleteMultipleItems(int LoggedUser, List<int> Ids);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateCategoriesItemsOrderNo")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Categories Items Order Number", Description = "Save the new Items/Categories Order (By Numbers)", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Boolan success or fail",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<bool> UpdateCategoriesItemsOrderNo(int LoggedUser, int Type, List<OrderNoClass> IdsOrders);


        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemTypes")]
        ResultClass<List<ItemTypeClass>> GetItemTypes();

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemType")]
        ResultClass<ItemTypeClass> GetItemType(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemType")]
        ResultClass<ItemTypeClass> CreateItemType(int LoggedUser, ItemTypeClass ItemType);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemType")]
        ResultClass<ItemTypeClass> UpdateItemType(int LoggedUser, ItemTypeClass ItemType);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteItemType")]
        ResultClass<ItemTypeClass> DeleteItemType(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetDashboardData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Dashboard Data", Description = "Get Dashboard (in the main page) Data", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Dashboard Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<DashboardClass> GetDashboardData(int LoggedUser);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateOfferDetailsData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Update Offer Detail Data", Description = "Edit the Data of the Selected item in the selected offer", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Offer Detail Data Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OffersDetailDataClass> UpdateOfferDetailsData(int LoggedUser, OffersDetailDataClass OfferDetailData);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateOfferDetailData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Offer Detail Data", Description = "Add New Item For the Selected Offer With The Item Prices in the Offer", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Offer Detail Data Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OffersDetailDataClass> CreateOfferDetailData(int LoggedUser, OffersDetailDataClass OfferDetailData);

        [WebInvoke(Method = "POST",
    ResponseFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.Wrapped,
    UriTemplate = "JSON/CreatePriceMultiOfferDetails_Percentage")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Create Offer Detail Data for multi items with percentage on price only", Description = "Add New Item For the Selected Offer With The Item Prices in the Offer", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return true if process is done",
    Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
    ResponseTypeOverride = typeof(string))]
         ResultClass<bool> CreatePriceMultiOfferDetails_Percentage(int LoggedUser,
            int OfferId, int PriceTypeId, int CountryId, int CurrencyId, double Percentage, List<int> ItemsIds);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetOfferDetailData")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Offer Detail Data", Description = "Get the Data of the Selected item in the selected offer", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Offer Detail Data Class",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<OffersDetailDataClass> GetOfferDetailData(int LoggedUser, int OfferId, int OfferDetailId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CheckOfferPrices")]
        ResultClass<bool> CheckOfferPrices(int LoggedUser, int ItemId, List<OfferDetailPriceClass> OfferPrices);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/SetUserLanguage")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Set User Language", Description = "Sends the (User ID or Guest FCM token) with the Selected language", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return Integer Number",
            Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
            ResponseTypeOverride = typeof(string))]
        ResultClass<int> SetUserLanguage(int Type, string Id, int Language);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetItemDepartments")]
        ResultClass<List<ItemDepartmentClass>> GetItemDepartments();

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetItemDepartment")]
        ResultClass<ItemDepartmentClass> GetItemDepartment(int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateItemDepartment")]
        ResultClass<ItemDepartmentClass> CreateItemDepartment(int LoggedUser, ItemDepartmentClass ItemDepartment);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateItemDepartment")]
        ResultClass<ItemDepartmentClass> UpdateItemDepartment(int LoggedUser, ItemDepartmentClass ItemDepartment);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteItemDepartment")]
        ResultClass<ItemDepartmentClass> DeleteItemDepartment(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetDays")]
        ResultClass<List<DayClass>> GetDays(int? Id);


        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateItemBooking")]
        ResultClass<ItemBookingClass> CreateItemBooking(int LoggedUser, ItemBookingClass ItemBooking);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetItemBookings")]
        ResultClass<List<ItemBookingClass>> GetItemBookings(int? ItemId, int? UserId);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CanceledItemBookings")]
        ResultClass<ItemBookingClass> CanceledItemBookings(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateOrderDetailSeriesForClient_ForMatjar")]
        ResultClass<OrderDetailSeriesClass> CreateOrderDetailSeriesForClient_ForMatjar(int LoggedUser, int ItemId, int Quantity);


        [WebInvoke(Method = "POST",
    ResponseFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.Wrapped,
    UriTemplate = "JSON/GetItemColorsSizesSeries")]
        [SwaggerWcfHeader(name: "LoggedUser", Required = true, Description = "The User Identifier in System", DefaultValue = "0")]
        [SwaggerWcfPath(Summary = "Get Item Colors and Sizes for Series", Description = "To Generate Colors Sizes List for Series", Deprecated = false)]
        [SwaggerWcfResponse(code: HttpStatusCode.OK, Description = "Return list of item colors and sizes",
    Headers = new string[] { "Access", "TotalSent", "TotalReceived", "PointsBalance", " TotalSent_Waiting", " TotalReceived_Waiting", "Source", "ApplicationToken", "language" },
    ResponseTypeOverride = typeof(string))]
        ResultClass<List<ItemSeriesClass>> GetItemColorsSizesSeries(int LoggedUser, int ItemId);
    


    // Complaints
    [WebInvoke(Method = "POST",
      ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "JSON/GetComplaint")]
    ResultClass<ComplaintDataClass> GetComplaint(int Id);

    [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetComplaints")]
    ResultClass<List<ComplaintClass>> GetComplaints(int? UserId);

    [WebInvoke(Method = "POST",
    ResponseFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.Wrapped,
    UriTemplate = "JSON/CreateComplaint")]

    ResultClass<ComplaintClass> CreateComplaint(int LoggedUser, ComplaintClass Complaint);

    [WebInvoke(Method = "POST",
    ResponseFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.Wrapped,
    UriTemplate = "JSON/UpdateComplaint")]

    ResultClass<ComplaintClass> UpdateComplaint(int LoggedUser, ComplaintClass Complaint);

    [WebInvoke(Method = "POST",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Wrapped,
             UriTemplate = "JSON/DeleteComplaint")]
    ResultClass<ComplaintClass> DeleteComplaint(int LoggedUser, int Id);

    [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "JSON/CloseComplaint")]
    ResultClass<ComplaintClass> CloseComplaint(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/UpdateOrderStatusByDeliveryUser")]
        ResultClass<bool> UpdateOrderStatusByDeliveryUser(int DeliveryUserId, int OrderId, int OrderStatusId, string DeliveryNote);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetDeliveryOrders")]
        ResultClass<List<OrderClass>> GetDeliveryOrders(int LoggedUser);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateRating")]
        ResultClass<RatingClass> CreateRating(int LoggedUser, RatingClass Rating);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetUserAddress")]
        ResultClass<UserAddressClass> GetUserAddress(int Id);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetUserAddresses")]
        ResultClass<List<UserAddressClass>> GetUserAddresses(int? UserId);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateUserAddress")]
        ResultClass<UserAddressClass> CreateUserAddress(int LoggedUser, UserAddressClass UserAddress);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/UpdateUserAddress")]
        ResultClass<UserAddressClass> UpdateUserAddress(int LoggedUser, UserAddressClass UserAddress);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/DeleteUserAddress")]
        ResultClass<UserAddressClass> DeleteUserAddress(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/SetUserCurrentBranch")]
        ResultClass<UserClass> SetUserCurrentBranch(int LoggedUser, int BranchId);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetOrderDetailsSeries")]
        ResultClass<List<OrderDetailSeriesClass>> GetOrderDetailsSeries(int OrderId);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateUsersFromExcel")]
        ResultClass<List<ResultClass<UserClass>>> CreateUsersFromExcel(int LoggedUser, string Url);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateOrUpdateUser")]
        ResultClass<UserClass> CreateOrUpdateUser(int LoggedUser, UserClass User);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/ImportFromFlo")]
        ResultClass<List<FloProductDetailClass>> ImportFromFlo(int CategoryId, int GenderId);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetWooCommerceProducts")]
        ResultClass<ProductList> GetWooCommerceProducts();

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/AddWooCommerceProduct")]
        ResultClass<string> AddWooCommerceProduct(int ItemId);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetItemDepartmentsData")]
        ResultClass<List<ItemDepartmentDataClass>> GetItemDepartmentsData();

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetItemDepartmentImages")]
        ResultClass<List<ItemDepartmentImageClass>> GetItemDepartmentImages(int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetItemDepartmentData")]
        ResultClass<ItemDepartmentDataClass> GetItemDepartmentData(int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/DeleteMultipleOrderDetails")]
        ResultClass<List<OrderDetailClass>> DeleteMultipleOrderDetails(int LoggedUser, List<int> Ids);


        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateItemDepartmentData")]
        ResultClass<ItemDepartmentDataClass> CreateItemDepartmentData(int LoggedUser, ItemDepartmentDataClass ItemDepartmentData);

        [OperationContract]
        [WebInvoke(Method = "POST",
    ResponseFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.Wrapped,
    UriTemplate = "JSON/UpdateItemDepartmentData")]
        ResultClass<ItemDepartmentDataClass> UpdateItemDepartmentData(int LoggedUser, ItemDepartmentDataClass ItemDepartmentData);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/GetItemTypeData")]
        ResultClass<ItemTypeDataClass> GetItemTypeData(int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/CreateItemTypeData")]
        ResultClass<ItemTypeDataClass> CreateItemTypeData(int LoggedUser, ItemTypeDataClass ItemTypeData);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/UpdateItemTypeData")]
        ResultClass<ItemTypeDataClass> UpdateItemTypeData(int LoggedUser, ItemTypeDataClass ItemTypeData);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetItemTypesByDepartment")]
        ResultClass<List<ItemTypeClass>> GetItemTypesByDepartment(int DepartmentId);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateOfferDetailsFromExcel")]
        ResultClass<List<ResultClass<OffersDetailDataClass>>> CreateOfferDetailsFromExcel(int LoggedUser, int OfferId, string Url);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/ScanItemSerial")]
        ResultClass<ItemSerialClass> ScanItemSerial(int LoggedUser, string Serial, string Code);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/AddAllWooCommerceProducts")]
        ResultClass<string> AddAllWooCommerceProducts(int LoggedUser);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetMaintenanceTickets")]
        ResultClass<List<MaintenanceTicketClass>> GetMaintenanceTickets(int LoggedUser, int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/DeleteMaintenanceTicket")]
        ResultClass<MaintenanceTicketClass> DeleteMaintenanceTicket(int LoggedUser, int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/UpdateMaintenanceTicket")]
        ResultClass<MaintenanceTicketClass> UpdateMaintenanceTicket(int LoggedUser, MaintenanceTicketClass MaintenanceTicket);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateMaintenanceTicket")]
        ResultClass<MaintenanceTicketClass> CreateMaintenanceTicket(int LoggedUser, MaintenanceTicketClass MaintenanceTicket);


        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetMaintenanceStatuses")]
        ResultClass<List<MaintenanceStatusClass>> GetMaintenanceStatuses(int LoggedUser);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CheckSerials")]
        ResultClass<List<ItemSerialClass>> CheckSerials(int LoggedUser, List<int> SerialsIds);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetSerials")]
        ResultClass<List<ItemSerialClass>> GetSerials(int LoggedUser, string Serial, List<int> UsersIds, string FromDate, string ToDate, List<int> ItemsIds, int PageId, int RecordsCount, bool FilterByScanned, bool IsScanned, bool FilterByChecked, bool IsChecked);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateStory")]
        ResultClass<StoryClass> CreateStory(int LoggedUser, StoryClass Story);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/UpdateStory")]
        ResultClass<StoryClass> UpdateStory(int LoggedUser, StoryClass Story);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/DeleteStory")]
        ResultClass<StoryClass> DeleteStory(int LoggedUser, int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetStories")]
        ResultClass<List<StoryClass>> GetStories(int LoggedUser, int Id, int DepartmentId);


        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateStoryDetail")]
        ResultClass<StoryDetailClass> CreateStoryDetail(int LoggedUser, StoryDetailClass StoryDetail);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/UpdateStoryDetail")]
        ResultClass<StoryDetailClass> UpdateStoryDetail(int LoggedUser, StoryDetailClass StoryDetail);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/DeleteStoryDetail")]
        ResultClass<StoryDetailClass> DeleteStoryDetail(int LoggedUser, int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetStoryDetails")]
        ResultClass<List<StoryDetailClass>> GetStoryDetails(int LoggedUser, int Id, int StoryId);


        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetBrandData")]
        ResultClass<BrandDataClass> GetBrandData(int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateBrandData")]
        ResultClass<BrandDataClass> CreateBrandData(int LoggedUser, BrandDataClass BrandData);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/UpdateBrandData")]
        ResultClass<BrandDataClass> UpdateBrandData(int LoggedUser, BrandDataClass BrandData);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetBrandsByDepartment")]
        ResultClass<List<BrandClass>> GetBrandsByDepartment(int DepartmentId);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/UpdateStyleDetailData")]
        ResultClass<StyleDetailDataClass> UpdateStyleDetailData(int LoggedUser, StyleDetailDataClass StyleDetailData);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/CreateStyleDetailData")]
        ResultClass<StyleDetailDataClass> CreateStyleDetailData(int LoggedUser, StyleDetailDataClass StyleDetailData);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/DeleteStyleDetail")]
        ResultClass<StyleDetailClass> DeleteStyleDetail(int LoggedUser, int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/DeleteStyle")]
        ResultClass<StyleClass> DeleteStyle(int LoggedUser, int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/UpdateStyle")]
        ResultClass<StyleClass> UpdateStyle(int LoggedUser, StyleClass Style);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/CreateStyle")]
        ResultClass<StyleClass> CreateStyle(int LoggedUser, StyleClass Style);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/GetStyleData")]
        ResultClass<StyleDataClass> GetStyleData(int LoggedUser, int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/GetStyleDetailItems")]
        ResultClass<List<StyleDetailItemClass>> GetStyleDetailItems(int LoggedUser, int Id, int StyleId, int StyleDetailId);


        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/GetStyleDetailImages")]
        ResultClass<List<StyleDetailImageClass>> GetStyleDetailImages(int LoggedUser, int Id, int StyleId, int StyleDetailId);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/GetStyleDetails")]
        ResultClass<List<StyleDetailClass>> GetStyleDetails(int LoggedUser, int Id, int StyleId);

        [OperationContract]
        [WebInvoke(Method = "POST",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "JSON/GetStyles")]
        ResultClass<List<StyleClass>> GetStyles(int LoggedUser, int Id, bool FilterByStyleType, int StyleTypeId, int DepartmentId);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateTag")]
        ResultClass<TagClass> CreateTag(int LoggedUser, TagClass Tag);
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/UpdateTag")]
        ResultClass<TagClass> UpdateTag(int LoggedUser, TagClass Tag);
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/DeleteTag")]
        ResultClass<TagClass> DeleteTag(int LoggedUser, int Id);
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetTags")]
        ResultClass<List<TagClass>> GetTags(int LoggedUser, int Id, int TagTypeId);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateStyleData")]
        ResultClass<StyleDataClass> CreateStyleData(int LoggedUser, StyleDataClass StyleData);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/UpdateStyleData")]
        ResultClass<StyleDataClass> UpdateStyleData(int LoggedUser, StyleDataClass StyleData);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetStyleDetailData")]
        ResultClass<StyleDetailDataClass> GetStyleDetailData(int LoggedUser, int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateTagType")]
        ResultClass<TagTypeClass> CreateTagType(int LoggedUser, TagTypeClass TagType);
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/UpdateTagType")]
        ResultClass<TagTypeClass> UpdateTagType(int LoggedUser, TagTypeClass TagType);
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/DeleteTagType")]
        ResultClass<TagTypeClass> DeleteTagType(int LoggedUser, int Id);
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetTagTypes")]
        ResultClass<List<TagTypeClass>> GetTagTypes(int LoggedUser, int Id);


        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateStoryData")]
        ResultClass<StoryDataClass> CreateStoryData(int LoggedUser, StoryDataClass StoryData);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/UpdateStoryData")]
        ResultClass<StoryDataClass> UpdateStoryData(int LoggedUser, StoryDataClass StoryData);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetStoryData")]
        ResultClass<StoryDataClass> GetStoryData(int LoggedUser, int Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/SearchItems_MultiWithFilters")]
        ResultClass<ItemsListWithSearchFiltersClass> SearchItems_MultiWithFilters(int LoggedUser, ItemSearchClass itemSearch, int PageId,
        int RecordsCount, int? PriceCountryId, int? PriceCurrencyId, int? PriceTypeId, bool CalcItemsForFilter = false, int SourceId = 0, int SourceType = 0);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/SearchItems_MultiWithFiltersForPublic")]
        ResultClass<ItemsListWithSearchFiltersClass> SearchItems_MultiWithFiltersForPublic(int CountryId, ItemSearchClass itemSearch, int PageId,
        int RecordsCount, int? PriceCountryId, int? PriceCurrencyId, int? PriceTypeId, bool CalcItemsForFilter = false);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetPrestigakMainData")]
        ResultClass<PrestigakMainPageDataClass> GetPrestigakMainData(int LoggedUser, int DepartmentId);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetOrderWithDetails")]
        ResultClass<OrderWithDetailsClass> GetOrderWithDetails(int LoggedUser, int Id, bool LastOpenOrder);
        
        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetGovernoratesWithCities")]
        ResultClass<List<GovernorateWithCitiesClass>> GetGovernoratesWithCities(int CountryId, int GovernorateId);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetPrestigakStyleDetailsData")]
        ResultClass<PrestigakStyleDetailsDataClass> GetPrestigakStyleDetailsData(int LoggedUser, int StyleId, int DepartmentId);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetStylesData")]
        ResultClass<List<StyleDataClass>> GetStylesData(int LoggedUser, int DepartmentId);

        // Coupons

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCoupon")]
        ResultClass<CouponClass> GetCoupon(int? Id, string CouponSerial);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetCoupons")]
        ResultClass<List<CouponClass>> GetCoupons(int? CouponTypeId);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateCoupon")]
        ResultClass<CouponClass> CreateCoupon(int LoggedUser, CouponClass Coupon);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/UpdateCoupon")]
        ResultClass<CouponClass> UpdateCoupon(int LoggedUser, CouponClass Coupon);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteCoupon")]
        ResultClass<CouponClass> DeleteCoupon(int LoggedUser, int Id);

        // Users coupon
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/GetUsersCoupon")]
        ResultClass<UsersCouponClass> GetUsersCoupon(int CouponId);
        // Users coupon
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/CreateUsersCoupon")]
        ResultClass<UsersCouponClass> CreateUsersCoupon(int LoggedUser, int CouponId, List<int> UserIds);
        // Users coupon
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSON/DeleteUsersCoupon")]
        ResultClass<UsersCouponClass> DeleteUsersCoupon(int LoggedUser, int CouponId, List<int> UserIds);


        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetCouponTypes")]
        ResultClass<List<CouponTypeClass>> GetCouponTypes(int? Id);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetGovernorateLocations")]
        ResultClass<List<LocationClass>> GetGovernorateLocations(int GovernorateId);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetGovernoratesWithCitiesAndLocations")]
        ResultClass<List<GovernorateWithCitiesAndLocationsClass>> GetGovernoratesWithCitiesAndLocations(int CountryId, int GovernorateId);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateOrderDetailsQtys")]
        ResultClass<List<OrderDetailClass>> UpdateOrderDetailsQtys(int LoggedUser, int OrderId, List<OrderDetailQtyClass> OrderDetailsQtys);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateUsersNotification")]
        ResultClass<List<NotificationClass>> CreateUsersNotification(int LoggedUser, List<int> UsersIds, string Content, string Title, string ImageURL, string ReferenceId, string ReferenceType);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/RecordUsageData")]
        ResultClass<bool> RecordUsageData(int UserId, int ReferenceId, int ReferenceType);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetItemTypesData")]
        ResultClass<List<ItemTypeDataClass>> GetItemTypesData();

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetStylesDataNew")]
        ResultClass<List<StyleDataClass>> GetStylesDataNew(int LoggedUser, int DepartmentId);


        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateMultipleOrderDetails")]
        ResultClass<List<OrderDetailClass>> UpdateMultipleOrderDetails(int LoggedUser, int OrderId, List<OrderDetailForUpdateClass> OrderDetails);
        
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/UpdateItemColorSizeAvailability")]
        ResultClass<ItemColorSizeAvailabilityClass> UpdateItemColorSizeAvailability(int LoggedUser, ItemColorSizeAvailabilityClass ItemColorSizeAvailability);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/CreateItemsColorsSizesAvailabilityFromExcel")]

        ResultClass<List<ResultClass<ItemColorSizeAvailabilityClass>>> CreateItemsColorsSizesAvailabilityFromExcel(int LoggedUser, string Url);

        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "JSON/GetItemDepartmentsForPublic")]
        ResultClass<List<ItemDepartmentClass>> GetItemDepartmentsForPublic(int CountryId);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetItemDepartmentDataForPublic")]
        ResultClass<ItemDepartmentDataClass> GetItemDepartmentDataForPublic(int CountryId, int Id);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetItemDepartmentsDataForPublic")]
        ResultClass<List<ItemDepartmentDataClass>> GetItemDepartmentsDataForPublic(int CountryId);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetItemDepartmentForPublic")]
        ResultClass<ItemDepartmentClass> GetItemDepartmentForPublic(int CountryId, int Id);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/RecordAgentVisit")]
        ResultClass<AgentVisitClass> RecordAgentVisit(int LoggedUser, AgentVisitClass AgentVisit);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/ReorderBrands")]
        ResultClass<List<BrandClass>> ReorderBrands(int LoggedUser, List<BrandClass> BrandsOrder);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetItemDepartmentImagesForPublic")]
        ResultClass<List<ItemDepartmentImageClass>> GetItemDepartmentImagesForPublic(int CountryId, int Id);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/SearchItems_MultiShortWithFiltersForPublic")]
        ResultClass<ItemsListShortWithSearchFiltersClass> SearchItems_MultiShortWithFiltersForPublic(int CountryId, ItemSearchClass itemSearch, int PageId,
int RecordsCount, int? PriceCountryId, int? PriceCurrencyId, int? PriceTypeId, bool CalcItemsForFilter = false);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/SearchItems_MultiShortWithFilters")]
        ResultClass<ItemsListShortWithSearchFiltersClass> SearchItems_MultiShortWithFilters(int LoggedUser, ItemSearchClass itemSearch, int PageId,
        int RecordsCount, int? PriceCountryId, int? PriceCurrencyId, int? PriceTypeId, bool CalcItemsForFilter = false, int SourceId = 0, int SourceType = 0);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetUserSerials")]
        ResultClass<UserSerialsClass> GetUserSerials(int LoggedUser);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetUserItemSerials")]
        ResultClass<List<ItemSerialClass>> GetUserItemSerials(int LoggedUser);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetUserUnknownSerials")]
        ResultClass<List<UnknownSerialClass>> GetUserUnknownSerials(int LoggedUser);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetUnknownSerials")]
        ResultClass<List<UnknownSerialClass>> GetUnknownSerials(int LoggedUser);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/DefineUnknownSerial")]
        ResultClass<ItemSerialClass> DefineUnknownSerial(int LoggedUser, int UnknownSerialId);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetAgentVisits")]
        ResultClass<List<AgentVisitClass>> GetAgentVisits(int LoggedUser);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateAgentClients")]
        ResultClass<List<AgentClientClass>> CreateAgentClients(int LoggedUser, int AgentId, List<int> Clients);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetAgentClients")]
        ResultClass<List<AgentClientClass>> GetAgentClients(int LoggedUser, int AgentId);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetAgents")]
        ResultClass<List<UserClass>> GetAgents(int LoggedUser);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetDeliveryUserOrdersWithDetails")]
        ResultClass<List<OrderWithDetailsClass>> GetDeliveryUserOrdersWithDetails(int LoggedUser, int DeliveryUserId);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/DeliverOrders")]
        ResultClass<List<OrderClass>> DeliverOrders(int LoggedUser, List<OrderClass> DeliveredOrders);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateDeliverOrderDetail")]
        ResultClass<OrderDetailDeliverClass> CreateDeliverOrderDetail(int LoggedUser, int OrderDetailId, int Qty, bool IsDelivered, string Date);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/UpdateDeliverOrderDetail")]
        ResultClass<OrderDetailDeliverClass> UpdateDeliverOrderDetail(int LoggedUser, int Id, int Qty, bool IsDelivered, string Date);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/DeleteDeliverOrderDetail")]
        ResultClass<OrderDetailDeliverClass> DeleteDeliverOrderDetail(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetDeliveriesOrderDetail")]
        ResultClass<List<OrderDetailDeliverClass>> GetDeliveriesOrderDetail(int LoggedUser, int OrderDetailId);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetOrderSerials")]
        ResultClass<List<OrderSerialClass>> GetOrderSerials(int OrderId);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateFatoraPayment")]
        ResultClass<FatoraCreatePaymentResultClass> CreateFatoraPayment(FatoraCreatePaymentClass fatoraCreatePayment);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/FatoraCheckPaymentStatus?PaymentId={PaymentId}")]
        ResultClass<FatoraCheckPaymentStatusResultClass> FatoraCheckPaymentStatus(string PaymentId);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CancelFatoraPayment")]
        ResultClass<FatoraCancelPaymentResultClass> CancelFatoraPayment(FatoraCancelPaymentClass fatoraCancelPayment);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/RemoveUser")]
        ResultClass<UserClass> RemoveUser(int LoggedUser, int Id);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/SubmitFCMForUnknown")]
        ResultClass<FCMRegistrationClass> SubmitFCMForUnknown(FCMRegistrationClass FCMRegistration);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/CreateECashPayment")]
        ResultClass<ECashCreatePaymentResultClass> CreateECashPayment(ECashCreatePaymentClass ecashCreatePayment);

        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/ECashCallBack")]
        ResultClass<ECashCallBackResultClass> ECashCallBack(bool IsSuccess, string Message, string OrderRef, string TransactionNo, string Amount, string Token);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/GetECashCallBackResult?OrderRef={OrderRef}")]
        ResultClass<ECashCallBackResultClass> GetECashCallBackResult(string OrderRef);
    }

}
