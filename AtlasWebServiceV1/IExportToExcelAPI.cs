using PointsSystemWebService.Classes;
using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PointsSystemWebService
{
   //NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IExportToExcelAPI" in both code and config file together.
   [ServiceContract]
   public interface IExportToExcelAPI
   {
      [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/CreateUserExcelReports")]
      ResultClass<ExcelReportClass> CreateUserExcelReports(int LoggedUser, string ReportName, string ReportURL);


      [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/NewSearchUsersReportToExcel")]
      ResultClass<bool> NewSearchUsersReportToExcel(int LoggedUser, bool FilterByUsername, string Username, bool FilterByFullName, string FullName,
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
           bool FilterByExceptUsersIds, List<int> ExceptUsersIds,
           int PageId = 1, int RecordsCount = 10000,
           bool ForReports = false,
           bool FilterByVisibleOnMap = false, bool VisibleOnMap = false,
           bool FilterByLocationValidated = false, bool LocationValidated = false,
          ReportType reportType = ReportType.Excel, bool ForAllColumns = false);


      [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/PointsReportToExcel")]
      ResultClass<bool> PointsReportToExcel(int LoggedUser,
         bool FilterByDate, string FromDate, string ToDate,
         List<int> UserIds, bool FilterBySendersIds, List<int> SendersIds, bool FilterByReceiversIds, List<int> ReceiversIds,
         bool FilterByOperations, List<int> OperationsIds, ReportType reportType = ReportType.Excel, bool ForAllColumns = false);


      [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/TotalPointsReportToExcel")]
      ResultClass<bool> TotalPointsReportToExcel(int LoggedUser,
         bool FilterByDate, string FromDate, string ToDate,
         List<int> UserIds, bool FilterBySendersIds, List<int> SendersIds, bool FilterByReceiversIds, List<int> ReceiversIds,
         bool FilterByOperations, List<int> OperationsIds, int RecordsCount = 99999999, int PageId = 1, ReportType reportType = ReportType.Excel, bool ForAllColumns = false);


      [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "JSON/GetTotalUserBalanceReportToExcel")]
      ResultClass<bool> GetTotalUserBalanceReportToExcel(int LoggedUser,
         bool FilterByDate, string FromDate, string ToDate,
         List<int> UserIds, List<int> Sender_UserIds, List<int> Receiver_UserIds,
         bool ShowUsersWhoHaveResultsOnly, int RecordsCount = 99999999, int PageId = 1, ReportType reportType = ReportType.Excel, bool ForAllColumns = false);

      [WebInvoke(Method = "POST",
      ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "JSON/UserSessionsReportToExcel")]
      ResultClass<bool> UserSessionsReportToExcel(int LoggedUser,
      bool FilterByUserId, List<int> UserIds,
      bool FilterByDates, string FromDate, string ToDate,
      bool FilterByTimes, string FromTime, string ToTime,
      bool FilterByUserType, bool ShowGuest, bool ShowRegisteredUser,
      bool GroupByDay, bool GroupByHour,
      int RecordsCount = 99999999, int PageId = 1,
       ReportType reportType = ReportType.Excel, bool ForAllColumns = true);


      [WebInvoke(Method = "POST",
    ResponseFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.Wrapped,
    UriTemplate = "JSON/MultipleTransferFromExcelReport")]
      ResultClass<bool> MultipleTransferFromExcelReport(int LoggedUser,
      string TransferExcelGuid,
      ReportType reportType = ReportType.Excel, bool ForAllColumns = true);


        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "JSON/ExportToWordpress")]
        ResultClass<bool> ExportToWordpress(int LoggedUser);

   }
}
