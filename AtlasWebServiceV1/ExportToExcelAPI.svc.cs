using OfficeOpenXml;
using OfficeOpenXml.Style;
using PointsSystemWebService.Classes;
using PointsSystemWebService.Classes.Core;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Windows;
//
using System.ComponentModel;
//using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ios = System.Runtime.InteropServices;
using System.Threading;
using SwaggerWcf.Attributes;
using System.Web;

namespace PointsSystemWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ExportToExcelAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ExportToExcelAPI.svc or ExportToExcelAPI.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    public class ExportToExcelAPI : IExportToExcelAPI
    {
        public ExportToExcelAPI()
        {
            //CheckLicense
            //ServiceMethod.CheckLicense();
        }


        public ResultClass<ExcelReportClass> CreateUserExcelReports(int LoggedUser, string ReportName, string ReportURL)
        {
            ResultClass<ExcelReportClass> result = new ResultClass<ExcelReportClass>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_InsertUserExcelReport";
                    cmd.Parameters.Add(new SqlParameter("LoggedUser", LoggedUser));
                    cmd.Parameters.Add(new SqlParameter("ReportName", ReportName));
                    cmd.Parameters.Add(new SqlParameter("ReportURL", ReportURL));

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                        ExcelReportClass excelReport;
                        int order = 0;
                        reader.Read();
                        {
                            order += 1;
                            excelReport = new ExcelReportClass().PopulateExcelReportClass(fieldNames, reader);

                            excelReport.ProcessExcelReportNotification();

                            excelReport.Order = order;

                        }

                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = excelReport;
                        return result;
                    }
                    else
                    {
                        result.Message = "";
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
                    result.Message = e.Message;
                    Errors.LogError(LoggedUser, e.Message, e.StackTrace, "1.0.3", "API", "CreateUserExcelReports", e.Source, "");
                }
                result.Result = null;
                return result;
            }

        }

        /***************************************************/
        // REPORT APIs
        /***************************************************/

        public ResultClass<bool> NewSearchUsersReportToExcel(int LoggedUser, bool FilterByUsername, string Username, bool FilterByFullName, string FullName,
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
          ReportType reportType = ReportType.Excel, bool ForAllColumns = false)  //0 = Excel  -  1 = Pdf
        {
            ResultClass<bool> result = new ResultClass<bool>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_SearchUsers_New";

                    List<SqlParameter> Params = new List<SqlParameter>()
             {
                new SqlParameter("LoggedUser", HttpContext.Current.Request.Headers["LoggedUser"]),


                  new SqlParameter("FilterByUsername", FilterByUsername),
                  new SqlParameter("Username", Username),

                  new SqlParameter("FilterByFullname", FilterByFullName),
                  new SqlParameter("Fullname", FullName),

                  new SqlParameter("FilterByEmail", FilterByEmail),
                  new SqlParameter("Email", Email),

                  new SqlParameter("FilterByMobileNumber", FilterByMobileNumber),

                  //new SqlParameter("MobileNumber", MobileNumber?.TrimStart('0')),
                  new SqlParameter("MobileCountryCode", MobileCountryCode),

                  new SqlParameter("FilterByText", FilterByText),
                  new SqlParameter("Text", Text),

                  new SqlParameter("FilterByDisabled", FilterByDisabled),
                  new SqlParameter("Disabled", Disabled),

                  new SqlParameter("FilterByHasVocationalCertificate", FilterByHasVocationalCertificate),
                  new SqlParameter("HasVocationalCertificate", HasVocationalCertificate),

                  new SqlParameter("FilterByIsActive", FilterByIsActive),
                  new SqlParameter("IsActive", IsActive),

                  new SqlParameter("FilterByAddress1", FilterByAddress1),
                  new SqlParameter("Address1", Address1),

                  new SqlParameter("FilterByAddress2", FilterByAddress2),
                  new SqlParameter("Address2", Address2),

                  new SqlParameter("FilterByNickname", FilterByNickname),
                  new SqlParameter("Nickname", Nickname),

                  new SqlParameter("FilterByYearsOfExperience", FilterByYearsOfExperience),
                  new SqlParameter("FromYearsOfExperience", FromFilterByYearsOfExperience),
                  new SqlParameter("ToYearsOfExperience", ToFilterByYearsOfExperience),

                  new SqlParameter("FilterByStaffCount", FilterByStaffCount),
                  new SqlParameter("FromStaffCount", FromStaffCount),
                  new SqlParameter("ToStaffCount", ToStaffCount),

                  new SqlParameter("FilterByNotes", FilterByNotes),
                  new SqlParameter("Notes", Notes),

                  new SqlParameter("FilterByCommercialName", FilterByCommercialName),
                  new SqlParameter("CommercialName", CommercialName),

                  new SqlParameter("FilterByGender", FilterByGender),
                  new SqlParameter("Gender", Gender),

                  new SqlParameter("SearchForSenders", SearchForSenders),
                  new SqlParameter("SearchForReceivers", SearchForReceivers),

                  new SqlParameter("PageId", PageId),
                  new SqlParameter("RecordsCount", RecordsCount),
                  new SqlParameter("ForReports", ForReports),

                  new SqlParameter("FilterByVisibleOnMap", FilterByVisibleOnMap),
                  new SqlParameter("VisibleOnMap", VisibleOnMap),
                  new SqlParameter("FilterByLocationValidated", FilterByLocationValidated),
                  new SqlParameter("LocationValidated", LocationValidated),

                  new SqlParameter("FilterByLunchCount", FilterByLunchCount),
                  new SqlParameter("FromLunchCount", FromLunchCount),
                  new SqlParameter("ToLunchCount", ToLunchCount),
               };

                    if (MobileNumber != null)
                        cmd.Parameters.Add(new SqlParameter("MobileNumber", MobileNumber));

                    if (FilterByCreateDate)
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByCreateDate", FilterByCreateDate));
                        cmd.Parameters.Add(new SqlParameter("FromCreateDate", FromCreateDate));
                        cmd.Parameters.Add(new SqlParameter("ToCreateDate", ToCreateDate));
                    }

                    if (FilterByBirthdate)
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByBirthdate", FilterByBirthdate));
                        cmd.Parameters.Add(new SqlParameter("FromBirthdate", FromBirthdate));
                        cmd.Parameters.Add(new SqlParameter("ToBirthdate", ToBirthdate));
                    }

                    if ((FilterByUserTypeIds) && (UserTypeIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByUserTypeIds", FilterByUserTypeIds));

                        //UserTypeIds
                        DataTable userTypeTable;
                        using (userTypeTable = new DataTable())
                        {
                            userTypeTable.Columns.Add("Id", typeof(string));
                            foreach (int x in UserTypeIds)
                                userTypeTable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@UserTypeIds", SqlDbType.Structured);
                        pList.Value = userTypeTable;
                        Params.Add(pList);
                    }

                    if ((FilterByCompanyIds) && (CompanyIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByCompanyIds", FilterByCompanyIds));

                        //CompanyIds
                        DataTable companytable;
                        using (companytable = new DataTable())
                        {
                            companytable.Columns.Add("Id", typeof(string));
                            foreach (int x in CompanyIds)
                                companytable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@CompanyIds", SqlDbType.Structured);
                        pList.Value = companytable;
                        Params.Add(pList);
                    }

                    if ((FilterByCountryIds) && (CountryIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByCountryIds", FilterByCountryIds));

                        //CountryIds
                        DataTable countrytable;
                        using (countrytable = new DataTable())
                        {
                            countrytable.Columns.Add("Id", typeof(string));
                            foreach (int x in CountryIds)
                                countrytable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@CountryIds", SqlDbType.Structured);
                        pList.Value = countrytable;
                        Params.Add(pList);
                    }


                    if ((FilterByGovernorateIds) && (GovernorateIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByGovernorateIds", FilterByGovernorateIds));

                        //GovernorateIds
                        DataTable governoratetable;
                        using (governoratetable = new DataTable())
                        {
                            governoratetable.Columns.Add("Id", typeof(string));
                            foreach (int x in GovernorateIds)
                                governoratetable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@GovernorateIds", SqlDbType.Structured);
                        pList.Value = governoratetable;
                        Params.Add(pList);
                    }

                    if ((FilterByCityIds) && (CityIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByCityIds", FilterByCityIds));

                        //CityIds
                        DataTable citytable;
                        using (citytable = new DataTable())
                        {
                            citytable.Columns.Add("Id", typeof(string));
                            foreach (int x in CityIds)
                                citytable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@CityIds", SqlDbType.Structured);
                        pList.Value = citytable;
                        Params.Add(pList);
                    }

                    if ((FilterByLocationIds) && (LocationIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByLocationIds", FilterByLocationIds));

                        //LocationIds
                        DataTable locationtable;
                        using (locationtable = new DataTable())
                        {
                            locationtable.Columns.Add("Id", typeof(string));
                            foreach (int x in LocationIds)
                                locationtable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@LocationIds", SqlDbType.Structured);
                        pList.Value = locationtable;
                        Params.Add(pList);
                    }

                    if ((FilterByPositionIds) && (PositionIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByPositionIds", FilterByPositionIds));

                        //PositionIds
                        DataTable positiontable;
                        using (positiontable = new DataTable())
                        {
                            positiontable.Columns.Add("Id", typeof(string));
                            foreach (int x in PositionIds)
                                positiontable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@PositionIds", SqlDbType.Structured);
                        pList.Value = positiontable;
                        Params.Add(pList);
                    }

                    if ((FilterByJobIds) && (JobIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByJobIds", FilterByJobIds));

                        //JobIds
                        DataTable jobtable;
                        using (jobtable = new DataTable())
                        {
                            jobtable.Columns.Add("Id", typeof(string));
                            foreach (int x in JobIds)
                                jobtable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@JobIds", SqlDbType.Structured);
                        pList.Value = jobtable;
                        Params.Add(pList);
                    }

                    if ((FilterByWorkDomainIds) && (WorkDomainIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByWorkDomainIds", FilterByWorkDomainIds));

                        //WorkDomainIds
                        DataTable workdomaintable;
                        using (workdomaintable = new DataTable())
                        {
                            workdomaintable.Columns.Add("Id", typeof(string));
                            foreach (int x in WorkDomainIds)
                                workdomaintable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@WorkDomainIds", SqlDbType.Structured);
                        pList.Value = workdomaintable;
                        Params.Add(pList);
                    }

                    if ((FilterByEducationLevelIds) && (EducationLevelIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByEducationLevelIds", FilterByEducationLevelIds));

                        //EducationLevelIds
                        DataTable educationleveltable;
                        using (educationleveltable = new DataTable())
                        {
                            educationleveltable.Columns.Add("Id", typeof(string));
                            foreach (int x in EducationLevelIds)
                                educationleveltable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@EducationLevelIds", SqlDbType.Structured);
                        pList.Value = educationleveltable;
                        Params.Add(pList);
                    }

                    if ((FilterByExceptUsersIds) && (ExceptUsersIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByExceptUsersIds", FilterByExceptUsersIds));

                        //ExceptUsersIds 
                        DataTable exceptUsersTable;
                        using (exceptUsersTable = new DataTable())
                        {
                            exceptUsersTable.Columns.Add("Id", typeof(string));
                            foreach (int x in ExceptUsersIds)
                                exceptUsersTable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@ExceptUsersIds", SqlDbType.Structured);
                        pList.Value = exceptUsersTable;
                        Params.Add(pList);
                    }

                    cmd.Parameters.AddRange(Params.ToArray());

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MemoryStream stream = new MemoryStream();

                        ExcelPackage pck = new ExcelPackage(stream);

                        ExcelWorksheet worksheet = pck.Workbook.Worksheets.Add("تقرير بيانات المستخدمين");

                        //RTL Direction
                        worksheet.View.RightToLeft = true;
                        //Apply Center to all Cells
                        worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        //Worksheet Name in first cell
                        worksheet.Cells["A1:I1"].Merge = true;
                        worksheet.Cells["A1:I1"].Style.Font.Bold = true;
                        worksheet.Cells["A1:I1"].Style.Font.Size = 14;
                        worksheet.Cells["A1:I1"].Value = "تقرير بيانات المستخدمين";

                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        #region GetUserColumn
                        List<ColumnClass> columnNameList = new List<ColumnClass>();

                        if (ForAllColumns)
                        {
                            columnNameList = ServiceMethod.GetAllUserColumns("UserReport.bs.table.columns");

                            //Sort columnNameList based on order
                            //var sorted = columnNameList.OrderBy(o => o.Name).ToList();
                            //columnNameList = sorted;
                        }
                        else
                        {
                            var GetUserColumnsResult = ServiceMethod.GetUserColumns(LoggedUser, LoggedUser);

                            var tableResult = GetUserColumnsResult.Result[0].Tables.Find(x => x.TableName.Equals("UserReport.bs.table.columns"));
                            columnNameList = tableResult.StandardColumns;

                            //Check if its empty or have one (item == Order)
                            if ((columnNameList == null) || (columnNameList?.Count == 0) ||
                               ((columnNameList?.Count == 1) && (columnNameList?[0].Name == "Order")))
                            {
                                result.Code = Errors.NoColumnSelected;
                                result.Message = Errors.GetErrorMessage(result.Code);
                                result.Result = false;
                                return result;
                            }
                            //Sort columnNameList based on order
                            var sorted = columnNameList.OrderBy(o => o.Order).ToList();
                            columnNameList = sorted;


                            //Re-order list based on sup lists
                            List<ColumnClass> reportList = new List<ColumnClass>();
                            List<ColumnClass> FirstUserList = new List<ColumnClass>();
                            List<ColumnClass> SecUserList = new List<ColumnClass>();

                            FirstUserList = columnNameList.FindAll(x => x.Name.StartsWith("Users."));
                            SecUserList = columnNameList.FindAll(x => x.Name.StartsWith("OperationUsers."));
                            reportList = columnNameList.FindAll(x => !x.Name.StartsWith("Users.") && !x.Name.StartsWith("OperationUsers."));

                            List<ColumnClass> TempList = new List<ColumnClass>();
                            TempList.AddRange(reportList);
                            TempList.AddRange(FirstUserList);
                            TempList.AddRange(SecUserList);

                            columnNameList = TempList;
                        }

                        #endregion

                        int offset = 5;
                        //Write Headers
                        ServiceMethod.PopulateExcelReportHeaders(LoggedUser, worksheet, offset, columnNameList);

                        //Start filling data
                        var data = new List<Dictionary<string, object>>();

                        while (reader.Read())
                        {
                            var rowData = ServiceMethod.PopulateExcelReportData(fieldNames, reader, worksheet, columnNameList, new UserClass());

                            data.Add(rowData);
                        }

                        //Write Data To Excel
                        //columnNameList = columnNameList.Select(s => s.Name.Replace(".", "_")).ToList();
                        var tempList = new List<ColumnClass>();
                        foreach (var item in columnNameList)
                            tempList.Add(new ColumnClass { Order = item.Order, Name = item.Name.Replace(".", "_"), Width = item.Width });

                        columnNameList = tempList;

                        int counter = 0;
                        int order = 0;

                        foreach (var dic in data)
                        {
                            counter = 0; order++;

                            foreach (var column in columnNameList)
                            { //Write data 
                                if (dic.ContainsKey(column.Name))
                                {
                                    counter++;
                                    try //to avoid error in style when decimal  like: 51e2 which should be 5100
                                    { worksheet.Cells[offset + order, counter].Value = decimal.Parse(dic[column.Name].ToString()); }
                                    catch (Exception)
                                    { worksheet.Cells[offset + order, counter].Value = dic[column.Name].ToString(); }
                                }
                            }
                        }

                        //Style Data With Border
                        var lastAlpha = ServiceMethod.GetExcelColumnName(ServiceMethod.headerRow[0].Length);

                        ExcelRange Rng = worksheet.Cells["A" + (offset + 1) + ":" + lastAlpha + (offset + order)];

                        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Top.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Left.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Right.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Bottom.Color.SetColor(Color.SlateGray);

                        worksheet.Cells.AutoFitColumns();

                        pck.Save();
                        var outputDir = Config.ServerPhysicalExcelPath;
                        var fileName = "UserDataReport-" + LoggedUser + "-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";

                        if (reportType == ReportType.Excel) //Excel
                        {
                            //Export Stream To Excel 
                            FileInfo file = new FileInfo(outputDir + fileName);
                            pck.SaveAs(file);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileName;
                            CreateUserExcelReports(LoggedUser, "تقرير بيانات المستخدمين", url);
                        }
                        else if (reportType == ReportType.Pdf) //Pdf
                        {
                            Workbook workbook = new Workbook();
                            workbook.LoadFromStream(stream);

                            //convert Excel to HTML 
                            var fileNameWithNoExtention = fileName.Split('.')[0];

                            Worksheet sheet = workbook.Worksheets[0];
                            var imageFileName = outputDir + fileNameWithNoExtention + ".png";
                            sheet.SaveToImage(imageFileName);

                            // Convert to PDF and delete image
                            PdfHelper.Instance.SaveImageAsPdf(imageFileName, $"{outputDir + fileNameWithNoExtention}.pdf", 1000, deleteImage: true);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileNameWithNoExtention + ".pdf";
                            CreateUserExcelReports(LoggedUser, "تقرير بيانات المستخدمين", url);
                        }

                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = true;

                        return result;

                    }
                    else
                    {
                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = false;
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
                    Errors.LogError(LoggedUser, e.Message, e.StackTrace, "1.0.3", "API", "NewSearchUsersToExcel", e.Source, "");
                }
                result.Result = false;
                return result;
            }
        }


        public ResultClass<bool> TotalPointsReportToExcel(int LoggedUser,
           bool FilterByDate, string FromDate, string ToDate,
           List<int> UserIds, bool FilterBySendersIds, List<int> SendersIds, bool FilterByReceiversIds, List<int> ReceiversIds,
           bool FilterByOperations, List<int> OperationsIds, int RecordsCount = 99999999, int PageId = 1, ReportType reportType = ReportType.Excel, bool ForAllColumns = false)
        {
            ResultClass<bool> result = new ResultClass<bool>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 1500000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Report_TotalPoints";
                    cmd.Parameters.Add(new SqlParameter("LoggedUser", LoggedUser));
                    cmd.Parameters.Add(new SqlParameter("RecordsCount", RecordsCount));
                    cmd.Parameters.Add(new SqlParameter("PageId", PageId));

                    if ((FilterByDate) && (!String.IsNullOrWhiteSpace(FromDate.Trim())) && (!String.IsNullOrWhiteSpace(ToDate.Trim())))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByDate", FilterByDate));
                        cmd.Parameters.Add(new SqlParameter("FromDate", FromDate));
                        cmd.Parameters.Add(new SqlParameter("ToDate", ToDate));
                    }

                    //UsersIds
                    if (UserIds != null)
                    {
                        DataTable userIdTable;
                        using (userIdTable = new DataTable())
                        {
                            userIdTable.Columns.Add("Id", typeof(string));
                            foreach (int x in UserIds)
                                userIdTable.Rows.Add(x);
                        }
                        var uIdList = new SqlParameter("@UsersIds", SqlDbType.Structured);
                        uIdList.Value = userIdTable;
                        cmd.Parameters.Add(uIdList);
                    }

                    //SendersIds
                    if ((FilterBySendersIds) && (SendersIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterBySendersIds", FilterBySendersIds));
                        DataTable userSenderTable;
                        using (userSenderTable = new DataTable())
                        {
                            userSenderTable.Columns.Add("Id", typeof(string));
                            foreach (int x in SendersIds)
                                userSenderTable.Rows.Add(x);
                        }
                        var uSenderList = new SqlParameter("@SendersIds", SqlDbType.Structured);
                        uSenderList.Value = userSenderTable;
                        cmd.Parameters.Add(uSenderList);
                    }

                    //ReceiversIds
                    if ((FilterByReceiversIds) && (ReceiversIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByRecieversIds", FilterByReceiversIds));
                        DataTable userReceiverTable;
                        using (userReceiverTable = new DataTable())
                        {
                            userReceiverTable.Columns.Add("Id", typeof(string));
                            foreach (int x in ReceiversIds)
                                userReceiverTable.Rows.Add(x);
                        }
                        var uReceiverList = new SqlParameter("@ReceiversIds", SqlDbType.Structured);
                        uReceiverList.Value = userReceiverTable;
                        cmd.Parameters.Add(uReceiverList);
                    }

                    //OperationsIds
                    if ((FilterByOperations) && (OperationsIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByOperations", FilterByOperations));
                        DataTable userOperationTable;
                        using (userOperationTable = new DataTable())
                        {
                            userOperationTable.Columns.Add("Id", typeof(string));
                            foreach (int x in OperationsIds)
                                userOperationTable.Rows.Add(x);
                        }
                        var uOperationList = new SqlParameter("@OperationsIds", SqlDbType.Structured);
                        uOperationList.Value = userOperationTable;
                        cmd.Parameters.Add(uOperationList);
                    }

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MemoryStream stream = new MemoryStream();

                        ExcelPackage pck = new ExcelPackage(stream);

                        ExcelWorksheet worksheet = pck.Workbook.Worksheets.Add("تقرير حركة النقاط الإجمالية");

                        //RTL Direction
                        worksheet.View.RightToLeft = true;
                        //Apply Center to all Cells
                        worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        //Worksheet Name in first cell
                        worksheet.Cells["A1:I1"].Merge = true;
                        worksheet.Cells["A1:I1"].Style.Font.Bold = true;
                        worksheet.Cells["A1:I1"].Style.Font.Size = 14;
                        worksheet.Cells["A1:I1"].Value = "تقرير حركة النقاط الإجمالية";

                        #region Report Filter Header

                        var userResult = ServiceMethod.GetUsers(UserIds).Result;
                        var userList = userResult?.Select(x => x.FullName);
                        int userListCount = (userList != null) ? userList.ToList().Count : 0;
                        string userListResult = String.Empty;
                        switch (userListCount)
                        {
                            case 0:
                                userListResult = "كل المستخدمين"; break;
                            case 1:
                                userListResult = userList.ToList()[0]; break;
                            default:
                                userListResult = "عدة مستخدمين"; break;
                        }

                        var sendersResult = ServiceMethod.GetUsers(SendersIds).Result;
                        var SendersList = sendersResult?.Select(x => x.FullName);
                        int senderListCount = (SendersList != null) ? SendersList.ToList().Count : 0;
                        string senderListResult = String.Empty;
                        switch (senderListCount)
                        {
                            case 0:
                                senderListResult = "كل المستخدمين"; break;
                            case 1:
                                senderListResult = SendersList.ToList()[0]; break;
                            default:
                                senderListResult = "عدة مستخدمين"; break;
                        }

                        var receiversResult = ServiceMethod.GetUsers(ReceiversIds).Result;
                        var ReceiversList = receiversResult?.Select(x => x.FullName);
                        int receiverListCount = (ReceiversList != null) ? ReceiversList.ToList().Count : 0;
                        string receiverListResult = String.Empty;
                        switch (receiverListCount)
                        {
                            case 0:
                                receiverListResult = "كل المستخدمين"; break;
                            case 1:
                                receiverListResult = ReceiversList.ToList()[0]; break;
                            default:
                                receiverListResult = "عدة مستخدمين"; break;
                        }


                        string operationName = String.Empty;
                        if (OperationsIds != null)
                        {
                            foreach (var id in OperationsIds)
                            {
                                if (id == 1)
                                    operationName += " استقبال ";
                                else if (id == 2)
                                    operationName += " ارسال ";
                                else if (id == 3)
                                    operationName += " طلبية ";
                            }
                        }

                        worksheet.Cells["A2:A8"].Value = "خيارات التقرير";
                        worksheet.Cells["A2:A8"].Merge = true;
                        worksheet.Cells["A2:A8"].Style.Font.Bold = true;


                        worksheet.Cells["B2"].Value = "تصفية حسب التاريخ";
                        worksheet.Cells["B2"].Style.Font.Bold = true;

                        worksheet.Cells["B3"].Value = "من تاريخ";
                        worksheet.Cells["B3"].Style.Font.Bold = true;

                        worksheet.Cells["C3"].Value = FromDate;

                        worksheet.Cells["D3"].Value = "الى تاريخ";
                        worksheet.Cells["D3"].Style.Font.Bold = true;

                        worksheet.Cells["E3"].Value = ToDate;

                        worksheet.Cells["B4"].Value = "المستخدمين المدروسين";
                        worksheet.Cells["B4"].Style.Font.Bold = true;

                        //worksheet.Cells["C4"].Value = (userList != null) ? string.Join("-", userList.ToArray()) : "";
                        worksheet.Cells["C4"].Value = userListResult;

                        worksheet.Cells["B5"].Value = "فلترة حسب المرسلين";
                        worksheet.Cells["B5"].Style.Font.Bold = true;

                        worksheet.Cells["B6"].Value = "المستخدمين المرسلين";
                        worksheet.Cells["B6"].Style.Font.Bold = true;

                        //worksheet.Cells["C6"].Value = (SendersList != null) ? string.Join("-", SendersList.ToArray()) : "";
                        worksheet.Cells["C6"].Value = senderListResult;

                        worksheet.Cells["D6"].Value = "المستخدمين المستقبلين ";
                        worksheet.Cells["D6"].Style.Font.Bold = true;

                        //worksheet.Cells["E6"].Value = (ReceiversList != null) ? string.Join("-", ReceiversList.ToArray()) : "";
                        worksheet.Cells["E6"].Value = receiverListResult;

                        worksheet.Cells["B7"].Value = "فلترة حسب العملية";
                        worksheet.Cells["B7"].Style.Font.Bold = true;

                        worksheet.Cells["B8"].Value = "العملية";
                        worksheet.Cells["B8"].Style.Font.Bold = true;

                        //worksheet.Cells["C8"].Value = operationName;
                        worksheet.Cells["C8"].Value = "ارسال – استقبال – طلبيات";

                        worksheet.Cells["A2:E8"].Style.Border.BorderAround(ExcelBorderStyle.MediumDashDot, Color.DarkBlue);

                        #endregion


                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        #region GetUserColumn
                        List<ColumnClass> columnNameList = new List<ColumnClass>();

                        if (ForAllColumns)
                        {
                            columnNameList = ServiceMethod.GetAllUserColumns("TotalPointsReport.bs.table.columns");

                            //Sort columnNameList based on order
                            //var sorted = columnNameList.OrderBy(o => o.Name).ToList();
                            //columnNameList = sorted;
                        }
                        else
                        {
                            var GetUserColumnsResult = ServiceMethod.GetUserColumns(LoggedUser, LoggedUser);

                            var tableResult = GetUserColumnsResult.Result[0].Tables.Find(x => x.TableName.Equals("TotalPointsReport.bs.table.columns"));
                            columnNameList = tableResult.StandardColumns;

                            //Check if its empty or have one (item == Order)
                            if ((columnNameList == null) || (columnNameList?.Count == 0) ||
                                ((columnNameList?.Count == 1) && (columnNameList?[0].Name == "Order")))
                            {
                                result.Code = Errors.NoColumnSelected;
                                result.Message = Errors.GetErrorMessage(result.Code);
                                result.Result = false;
                                return result;
                            }
                            //Sort columnNameList based on order
                            var sorted = columnNameList.OrderBy(o => o.Order).ToList();
                            columnNameList = sorted;

                            //Re-order list based on sup lists
                            List<ColumnClass> reportList = new List<ColumnClass>();
                            List<ColumnClass> FirstUserList = new List<ColumnClass>();
                            List<ColumnClass> SecUserList = new List<ColumnClass>();

                            FirstUserList = columnNameList.FindAll(x => x.Name.StartsWith("Users."));
                            SecUserList = columnNameList.FindAll(x => x.Name.StartsWith("OperationUsers."));
                            reportList = columnNameList.FindAll(x => !x.Name.StartsWith("Users.") && !x.Name.StartsWith("OperationUsers."));

                            List<ColumnClass> TempList = new List<ColumnClass>();
                            TempList.AddRange(reportList);
                            TempList.AddRange(FirstUserList);
                            TempList.AddRange(SecUserList);

                            columnNameList = TempList;
                        }
                        #endregion

                        int offset = 11; //one more line for seperating header taq by type 
                                         //Write Headers
                        ServiceMethod.PopulateExcelReportHeaders(LoggedUser, worksheet, offset, columnNameList, ForAllColumns);

                        //Start filling data
                        var data = new List<Dictionary<string, object>>();

                        while (reader.Read())
                        {
                            var rowData = ServiceMethod.PopulateExcelReportData(fieldNames, reader, worksheet, columnNameList, new UserClass(), new string[] { "Users_FullName" });
                            data.Add(rowData);
                        }

                        //Sort Result data on UserName
                        var sortedData = data.OrderBy(x => x.ContainsKey("Users_FullName") ? x["Users_FullName"] : string.Empty);
                        //Write Data To Excel
                        //columnNameList = columnNameList.Select(s => s.Replace(".", "_")).ToList();
                        var tempList = new List<ColumnClass>();
                        foreach (var item in columnNameList)
                            tempList.Add(new ColumnClass { Order = item.Order, Name = item.Name.Replace(".", "_"), Width = item.Width });

                        columnNameList = tempList;

                        int counter = 0;
                        int totalPoint = 0;
                        int order = 0;
                        var groupByName = String.Empty;
                        var subgroupByOperation = String.Empty;

                        string tempLastAlpha = ServiceMethod.GetExcelColumnName(ServiceMethod.headerRow[0].Length);

                        foreach (var dic in sortedData)
                        {
                            counter = 0; order++;

                            #region groupByFullNameRegion

                            if (groupByName != (string)dic["Users_FullName"]) //if new value for grouping field
                            {
                                if (!string.IsNullOrWhiteSpace(groupByName))
                                {
                                    //Add totalRegion before changing user
                                    #region HandleTotalRegion

                                    //Write data (Total Point) for past group before adding new header
                                    if (!string.IsNullOrWhiteSpace(subgroupByOperation) && subgroupByOperation != "طلبية")
                                    {
                                        //Add Total Line
                                        string cellPos_Total = "A" + (offset + order) + ":" +
                                                               tempLastAlpha + (offset + order);

                                        worksheet.Cells[cellPos_Total].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                        worksheet.Cells[cellPos_Total].Style.Font.Bold = false;
                                        worksheet.Cells[cellPos_Total].Merge = true;
                                        worksheet.Cells[cellPos_Total].Style.Fill.PatternType = ExcelFillStyle.LightGray;
                                        worksheet.Cells[cellPos_Total].Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);

                                        //Fix naming for group
                                        if (subgroupByOperation == "إرسال") subgroupByOperation = "ارسالات";
                                        else if (subgroupByOperation == "إستقبال") subgroupByOperation = "استقبالات";


                                        string content = @"مجموع " + subgroupByOperation + "     " + groupByName
                                                         + "     " + totalPoint;

                                        worksheet.Cells[cellPos_Total].Value = content;

                                        totalPoint = 0;
                                        order++;
                                    }

                                    #endregion
                                }

                                //Write data grouping header
                                groupByName = dic["Users_FullName"].ToString();
                                totalPoint = 0;

                                string cellPos_FullName = "A" + (offset + order) + ":" +
                                                 tempLastAlpha + (offset + order);

                                worksheet.Cells[cellPos_FullName].Style.Font.Bold = true;
                                worksheet.Cells[cellPos_FullName].Merge = true;
                                worksheet.Cells[cellPos_FullName].Style.Fill.PatternType = ExcelFillStyle.LightGray;
                                worksheet.Cells[cellPos_FullName].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                                worksheet.Cells[cellPos_FullName].Value = dic["Users_FullName"].ToString();

                                subgroupByOperation = String.Empty;
                                order++;
                            }

                            #endregion

                            #region groupByOperationAndTotalRegion

                            if (subgroupByOperation != (string)dic["Operation"]) //if new value for grouping field
                            {
                                #region HandleTotalRegion
                                //Write data (Total Point) for past group before adding new header
                                if (!string.IsNullOrWhiteSpace(subgroupByOperation) && subgroupByOperation != "طلبية")
                                {
                                    //Add Total Line
                                    string cellPos_Total = "A" + (offset + order) + ":" +
                                                           tempLastAlpha + (offset + order);

                                    worksheet.Cells[cellPos_Total].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    worksheet.Cells[cellPos_Total].Style.Font.Bold = false;
                                    worksheet.Cells[cellPos_Total].Merge = true;
                                    worksheet.Cells[cellPos_Total].Style.Fill.PatternType = ExcelFillStyle.LightGray;
                                    worksheet.Cells[cellPos_Total].Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);

                                    //Fix naming for group
                                    if (subgroupByOperation == "إرسال") subgroupByOperation = "ارسالات";
                                    else if (subgroupByOperation == "إستقبال") subgroupByOperation = "استقبالات";


                                    string content = @"مجموع " + subgroupByOperation + "     " + dic["Users_FullName"]
                                                     + "     " + totalPoint;

                                    worksheet.Cells[cellPos_Total].Value = content;

                                    totalPoint = 0;
                                    order++;
                                }

                                #endregion

                                #region groupByOperationRegion

                                //Write data grouping header
                                subgroupByOperation = dic["Operation"].ToString();

                                string cellPos_operation = "A" + (offset + order) + ":" +
                                                           tempLastAlpha + (offset + order);

                                worksheet.Cells[cellPos_operation].Style.Font.Bold = true;
                                worksheet.Cells[cellPos_operation].Merge = true;
                                worksheet.Cells[cellPos_operation].Style.Fill.PatternType = ExcelFillStyle.LightGray;
                                worksheet.Cells[cellPos_operation].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                                worksheet.Cells[cellPos_operation].Value = dic["Operation"].ToString();

                                order++;

                                #endregion
                            }

                            totalPoint += Convert.ToInt32(dic["Amount"]);

                            #endregion

                            foreach (var column in columnNameList)
                            { //Write data 
                                if (dic.ContainsKey(column.Name))
                                {
                                    counter++;
                                    try
                                    { worksheet.Cells[offset + order, counter].Value = decimal.Parse(dic[column.Name].ToString()); }
                                    catch (Exception)
                                    { worksheet.Cells[offset + order, counter].Value = dic[column.Name].ToString(); }
                                }

                            }
                        }

                        //Add Total For Last Result
                        #region HandleTotalRegion

                        if (!string.IsNullOrWhiteSpace(subgroupByOperation) && subgroupByOperation != "طلبية")
                        {
                            order++;
                            //Add Total Line
                            string cellPos_Total = "A" + (offset + order) + ":" +
                                                   tempLastAlpha + (offset + order);

                            worksheet.Cells[cellPos_Total].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            worksheet.Cells[cellPos_Total].Style.Font.Bold = false;
                            worksheet.Cells[cellPos_Total].Merge = true;
                            worksheet.Cells[cellPos_Total].Style.Fill.PatternType = ExcelFillStyle.LightGray;
                            worksheet.Cells[cellPos_Total].Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);

                            string content = @"مجموع " + subgroupByOperation + "     " + groupByName
                                             + "     " + totalPoint;

                            worksheet.Cells[cellPos_Total].Value = content;

                            totalPoint = 0;
                        }

                        #endregion



                        //Style Data With Border
                        var lastAlpha = ServiceMethod.GetExcelColumnName(ServiceMethod.headerRow[0].Length);

                        ExcelRange Rng = worksheet.Cells["A" + (offset + 1) + ":" + lastAlpha + (offset + order)];

                        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Top.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Left.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Right.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Bottom.Color.SetColor(Color.SlateGray);

                        worksheet.Cells.AutoFitColumns();


                        pck.Save();

                        var outputDir = Config.ServerPhysicalExcelPath;
                        //var outputDir = "G:\\";
                        var fileName = "TotalPointsReport-" + LoggedUser + "-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";

                        if (reportType == ReportType.Excel) //Excel
                        {
                            //Export Stream To Excel 
                            FileInfo file = new FileInfo(outputDir + fileName);
                            pck.SaveAs(file);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileName;
                            CreateUserExcelReports(LoggedUser, "تقرير حركة النقاط الإجمالية", url);

                        }
                        else if (reportType == ReportType.Pdf) //Pdf
                        {
                            Workbook workbook = new Workbook();
                            workbook.LoadFromStream(stream);

                            //convert Excel to HTML 
                            var fileNameWithNoExtention = fileName.Split('.')[0];

                            Worksheet sheet = workbook.Worksheets[0];
                            var imageFileName = outputDir + fileNameWithNoExtention + ".png";
                            sheet.SaveToImage(imageFileName);

                            // Convert to PDF and delete image
                            PdfHelper.Instance.SaveImageAsPdf(imageFileName, $"{outputDir + fileNameWithNoExtention}.pdf", 1000, deleteImage: true);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileNameWithNoExtention + ".pdf";
                            CreateUserExcelReports(LoggedUser, "تقرير حركة النقاط الإجمالية", url);
                        }


                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = true;
                        return result;
                    }
                    else
                    {
                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = false;
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
                    result.Message = e.Message;
                    Errors.LogError(LoggedUser, e.Message, e.StackTrace, "1.0.3", "API", "TotalPointsReportToExcel", e.Source, "");
                }
                result.Result = false;
                return result;
            }

        }


        public ResultClass<bool> PointsReportToExcel(int LoggedUser,
           bool FilterByDate, string FromDate, string ToDate,
           List<int> UserIds, bool FilterBySendersIds, List<int> SendersIds, bool FilterByReceiversIds, List<int> ReceiversIds,
           bool FilterByOperations, List<int> OperationsIds,
            ReportType reportType = ReportType.Excel, bool ForAllColumns = false)
        {
            ResultClass<bool> result = new ResultClass<bool>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 1500000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Report_Points";
                    cmd.Parameters.Add(new SqlParameter("LoggedUser", LoggedUser));

                    if ((FilterByDate) && (!String.IsNullOrWhiteSpace(FromDate.Trim())) && (!String.IsNullOrWhiteSpace(ToDate.Trim())))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByDate", FilterByDate));
                        cmd.Parameters.Add(new SqlParameter("FromDate", FromDate));
                        cmd.Parameters.Add(new SqlParameter("ToDate", ToDate));
                    }

                    //UsersIds
                    if (UserIds != null)
                    {
                        DataTable userIdTable;
                        using (userIdTable = new DataTable())
                        {
                            userIdTable.Columns.Add("Id", typeof(string));
                            foreach (int x in UserIds)
                                userIdTable.Rows.Add(x);
                        }
                        var uIdList = new SqlParameter("@UsersIds", SqlDbType.Structured);
                        uIdList.Value = userIdTable;
                        cmd.Parameters.Add(uIdList);
                    }

                    //SendersIds
                    if ((FilterBySendersIds) && (SendersIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterBySendersIds", FilterBySendersIds));
                        DataTable userSenderTable;
                        using (userSenderTable = new DataTable())
                        {
                            userSenderTable.Columns.Add("Id", typeof(string));
                            foreach (int x in SendersIds)
                                userSenderTable.Rows.Add(x);
                        }
                        var uSenderList = new SqlParameter("@SendersIds", SqlDbType.Structured);
                        uSenderList.Value = userSenderTable;
                        cmd.Parameters.Add(uSenderList);
                    }

                    //ReceiversIds
                    if ((FilterByReceiversIds) && (ReceiversIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByRecieversIds", FilterByReceiversIds));
                        DataTable userReceiverTable;
                        using (userReceiverTable = new DataTable())
                        {
                            userReceiverTable.Columns.Add("Id", typeof(string));
                            foreach (int x in ReceiversIds)
                                userReceiverTable.Rows.Add(x);
                        }
                        var uReceiverList = new SqlParameter("@ReceiversIds", SqlDbType.Structured);
                        uReceiverList.Value = userReceiverTable;
                        cmd.Parameters.Add(uReceiverList);
                    }

                    //OperationsIds
                    if ((FilterByOperations) && (OperationsIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByOperations", FilterByOperations));
                        DataTable userOperationTable;
                        using (userOperationTable = new DataTable())
                        {
                            userOperationTable.Columns.Add("Id", typeof(string));
                            foreach (int x in OperationsIds)
                                userOperationTable.Rows.Add(x);
                        }
                        var uOperationList = new SqlParameter("@OperationsIds", SqlDbType.Structured);
                        uOperationList.Value = userOperationTable;
                        cmd.Parameters.Add(uOperationList);
                    }

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MemoryStream stream = new MemoryStream();

                        ExcelPackage pck = new ExcelPackage(stream);

                        ExcelWorksheet worksheet = pck.Workbook.Worksheets.Add("تقرير حركة النقاط");

                        //RTL Direction
                        worksheet.View.RightToLeft = true;
                        //Apply Center to all Cells
                        worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        //Worksheet Name in first cell
                        worksheet.Cells["A1:I1"].Merge = true;
                        worksheet.Cells["A1:I1"].Style.Font.Bold = true;
                        worksheet.Cells["A1:I1"].Style.Font.Size = 14;
                        worksheet.Cells["A1:I1"].Value = "تقرير حركة النقاط";

                        #region Report Filter Header




                        var userResult = ServiceMethod.GetUsers(UserIds).Result;
                        var userList = userResult?.Select(x => x.FullName);
                        int userListCount = (userList != null) ? userList.ToList().Count : 0;
                        string userListResult = String.Empty;
                        switch (userListCount)
                        {
                            case 0:
                                userListResult = "كل المستخدمين"; break;
                            case 1:
                                userListResult = userList.ToList()[0]; break;
                            default:
                                userListResult = "عدة مستخدمين"; break;
                        }

                        var sendersResult = ServiceMethod.GetUsers(SendersIds).Result;
                        var SendersList = sendersResult?.Select(x => x.FullName);
                        int senderListCount = (SendersList != null) ? SendersList.ToList().Count : 0;
                        string senderListResult = String.Empty;
                        switch (senderListCount)
                        {
                            case 0:
                                senderListResult = "كل المستخدمين"; break;
                            case 1:
                                senderListResult = SendersList.ToList()[0]; break;
                            default:
                                senderListResult = "عدة مستخدمين"; break;
                        }

                        var receiversResult = ServiceMethod.GetUsers(ReceiversIds).Result;
                        var ReceiversList = receiversResult?.Select(x => x.FullName);
                        int receiverListCount = (ReceiversList != null) ? ReceiversList.ToList().Count : 0;
                        string receiverListResult = String.Empty;
                        switch (receiverListCount)
                        {
                            case 0:
                                receiverListResult = "كل المستخدمين"; break;
                            case 1:
                                receiverListResult = ReceiversList.ToList()[0]; break;
                            default:
                                receiverListResult = "عدة مستخدمين"; break;
                        }


                        string operationName = String.Empty;
                        if (OperationsIds != null)
                        {
                            foreach (var id in OperationsIds)
                            {
                                if (id == 1)
                                    operationName += " استقبال ";
                                else if (id == 2)
                                    operationName += " ارسال ";
                                else if (id == 3)
                                    operationName += " طلبية ";
                            }
                        }

                        worksheet.Cells["A2:A8"].Value = "خيارات التقرير";
                        worksheet.Cells["A2:A8"].Merge = true;
                        worksheet.Cells["A2:A8"].Style.Font.Bold = true;


                        worksheet.Cells["B2"].Value = "تصفية حسب التاريخ";
                        worksheet.Cells["B2"].Style.Font.Bold = true;

                        worksheet.Cells["B3"].Value = "من تاريخ";
                        worksheet.Cells["B3"].Style.Font.Bold = true;

                        worksheet.Cells["C3"].Value = FromDate;

                        worksheet.Cells["D3"].Value = "الى تاريخ";
                        worksheet.Cells["D3"].Style.Font.Bold = true;

                        worksheet.Cells["E3"].Value = ToDate;

                        worksheet.Cells["B4"].Value = "المستخدمين المدروسين";
                        worksheet.Cells["B4"].Style.Font.Bold = true;

                        //worksheet.Cells["C4"].Value = (userList != null) ? string.Join("-", userList.ToArray()) : "";
                        worksheet.Cells["C4"].Value = userListResult;

                        worksheet.Cells["B5"].Value = "فلترة حسب المرسلين ";
                        worksheet.Cells["B5"].Style.Font.Bold = true;

                        worksheet.Cells["B6"].Value = "المستخدمين المرسلين";
                        worksheet.Cells["B6"].Style.Font.Bold = true;

                        //worksheet.Cells["C6"].Value = (SendersList != null) ? string.Join("-", SendersList.ToArray()) : "";
                        worksheet.Cells["C6"].Value = senderListResult;

                        worksheet.Cells["D6"].Value = "المستخدمين المستقبلين";
                        worksheet.Cells["D6"].Style.Font.Bold = true;

                        //worksheet.Cells["E6"].Value = (ReceiversList != null) ? string.Join("-", ReceiversList.ToArray()) : "";
                        worksheet.Cells["E6"].Value = receiverListResult;

                        worksheet.Cells["B7"].Value = "فلترة حسب العملية";
                        worksheet.Cells["B7"].Style.Font.Bold = true;

                        worksheet.Cells["B8"].Value = "العملية";
                        worksheet.Cells["B8"].Style.Font.Bold = true;

                        worksheet.Cells["C8"].Value = operationName;

                        worksheet.Cells["A2:E8"].Style.Border.BorderAround(ExcelBorderStyle.MediumDashDot, Color.DarkBlue);

                        #endregion


                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        #region GetUserColumn
                        List<ColumnClass> columnNameList = new List<ColumnClass>();

                        if (ForAllColumns)
                        {
                            columnNameList = ServiceMethod.GetAllUserColumns("PointReport.bs.table.columns");

                            //Sort columnNameList based on order
                            //var sorted = columnNameList.OrderBy(o => o.Name).ToList();
                            //columnNameList = sorted;
                        }
                        else
                        {
                            var GetUserColumnsResult = ServiceMethod.GetUserColumns(LoggedUser, LoggedUser);

                            var tableResult = GetUserColumnsResult.Result[0].Tables.Find(x => x.TableName.Equals("PointReport.bs.table.columns"));
                            columnNameList = tableResult.StandardColumns;
                            //Check if its empty or have one (item == Order)
                            if ((columnNameList == null) || (columnNameList?.Count == 0) ||
                                ((columnNameList?.Count == 1) && (columnNameList?[0].Name == "Order")))
                            {
                                result.Code = Errors.NoColumnSelected;
                                result.Message = Errors.GetErrorMessage(result.Code);
                                result.Result = false;
                                return result;
                            }
                            //Sort columnNameList based on order
                            var sorted = columnNameList.OrderBy(o => o.Order).ToList();
                            columnNameList = sorted;

                            //Re-order list based on sup lists
                            List<ColumnClass> reportList = new List<ColumnClass>();
                            List<ColumnClass> FirstUserList = new List<ColumnClass>();
                            List<ColumnClass> SecUserList = new List<ColumnClass>();

                            FirstUserList = columnNameList.FindAll(x => x.Name.StartsWith("Users."));
                            SecUserList = columnNameList.FindAll(x => x.Name.StartsWith("OperationUsers."));
                            reportList = columnNameList.FindAll(x => !x.Name.StartsWith("Users.") && !x.Name.StartsWith("OperationUsers."));

                            List<ColumnClass> TempList = new List<ColumnClass>();
                            TempList.AddRange(reportList);
                            TempList.AddRange(FirstUserList);
                            TempList.AddRange(SecUserList);

                            columnNameList = TempList;
                        }
                        #endregion

                        int offset = 11;
                        //Write Headers
                        ServiceMethod.PopulateExcelReportHeaders(LoggedUser, worksheet, offset, columnNameList, ForAllColumns);

                        //Start filling data
                        var data = new List<Dictionary<string, object>>();

                        while (reader.Read())
                        {
                            var rowData = ServiceMethod.PopulateExcelReportData(fieldNames, reader, worksheet, columnNameList, new UserClass(), new string[] { "Users_FullName" });
                            data.Add(rowData);
                        }

                        //Sort Result data on UserName
                        var sortedData = data.OrderBy(x => x.ContainsKey("Users_FullName") ? x["Users_FullName"] : string.Empty);
                        //Write Data To Excel
                        //columnNameList = columnNameList.Select(s => s.Replace(".", "_")).ToList();
                        var tempList = new List<ColumnClass>();
                        foreach (var item in columnNameList)
                            tempList.Add(new ColumnClass { Order = item.Order, Name = item.Name.Replace(".", "_"), Width = item.Width });

                        columnNameList = tempList;

                        int counter = 0;
                        int order = 0;
                        var groupByName = String.Empty;
                        foreach (var dic in sortedData)
                        {
                            counter = 0; order++;
                            if (groupByName != (string)dic["Users_FullName"]) //if new value for grouping field
                            { //Write data grouping header
                                groupByName = dic["Users_FullName"].ToString();

                                var tempLastAlpha = ServiceMethod.GetExcelColumnName(ServiceMethod.headerRow[0].Length);
                                string cellPos = "A" + (offset + order) + ":" +
                                                 tempLastAlpha + (offset + order);

                                worksheet.Cells[cellPos].Style.Font.Bold = true;
                                worksheet.Cells[cellPos].Merge = true;
                                worksheet.Cells[cellPos].Style.Fill.PatternType = ExcelFillStyle.LightGray;
                                worksheet.Cells[cellPos].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                                worksheet.Cells[cellPos].Value = dic["Users_FullName"].ToString();

                                order++;
                            }
                            foreach (var column in columnNameList)
                            { //Write data 
                                counter++;
                                try
                                { worksheet.Cells[offset + order, counter].Value = decimal.Parse(dic[column.Name].ToString()); }
                                catch (Exception)
                                { worksheet.Cells[offset + order, counter].Value = dic[column.Name].ToString(); }
                            }
                        }

                        //Style Data With Border
                        var lastAlpha = ServiceMethod.GetExcelColumnName(ServiceMethod.headerRow[0].Length);

                        ExcelRange Rng = worksheet.Cells["A" + (offset + 1) + ":" + lastAlpha + (offset + order)];

                        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Top.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Left.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Right.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Bottom.Color.SetColor(Color.SlateGray);

                        worksheet.Cells.AutoFitColumns();

                        pck.Save();

                        var outputDir = Config.ServerPhysicalExcelPath;
                        var fileName = "PointsReport-" + LoggedUser + "-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";

                        if (reportType == ReportType.Excel) //Excel
                        {
                            //Export Stream To Excel 
                            FileInfo file = new FileInfo(outputDir + fileName);
                            pck.SaveAs(file);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileName;
                            CreateUserExcelReports(LoggedUser, "تقرير حركة النقاط", url);
                        }
                        else if (reportType == ReportType.Pdf) //Pdf
                        {
                            Workbook workbook = new Workbook();
                            workbook.LoadFromStream(stream);

                            //convert Excel to HTML 
                            var fileNameWithNoExtention = fileName.Split('.')[0];

                            Worksheet sheet = workbook.Worksheets[0];
                            var imageFileName = outputDir + fileNameWithNoExtention + ".png";
                            sheet.SaveToImage(imageFileName);

                            // Convert to PDF and delete image
                            PdfHelper.Instance.SaveImageAsPdf(imageFileName, $"{outputDir + fileNameWithNoExtention}.pdf", 1000, deleteImage: true);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileNameWithNoExtention + ".pdf";
                            CreateUserExcelReports(LoggedUser, "تقرير حركة النقاط", url);
                        }

                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = true;
                        return result;
                    }
                    else
                    {
                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = false;
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
                    result.Message = e.Message;
                    Errors.LogError(LoggedUser, e.Message, e.StackTrace, "1.0.3", "API", "PointsReportToExcel", e.Source, "");
                }
                result.Result = false;
                return result;
            }

        }


        public ResultClass<bool> GetTotalUserBalanceReportToExcel(int LoggedUser,
           bool FilterByDate, string FromDate, string ToDate,
           List<int> UserIds, List<int> Sender_UserIds, List<int> Receiver_UserIds,
           bool ShowUsersWhoHaveResultsOnly, int RecordsCount = 99999999, int PageId = 1,
           ReportType reportType = ReportType.Excel, bool ForAllColumns = false)
        {
            ResultClass<bool> result = new ResultClass<bool>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 1500000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "TotalUserBalanceReport";
                    cmd.Parameters.Add(new SqlParameter("LoggedUser", LoggedUser));
                    cmd.Parameters.Add(new SqlParameter("ShowUsersWhoHaveResultsOnly", ShowUsersWhoHaveResultsOnly));
                    cmd.Parameters.Add(new SqlParameter("RecordsCount", RecordsCount));
                    cmd.Parameters.Add(new SqlParameter("PageId", PageId));

                    if ((FilterByDate) && (!String.IsNullOrWhiteSpace(FromDate.Trim())) && (!String.IsNullOrWhiteSpace(ToDate.Trim())))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterDates", FilterByDate));
                        cmd.Parameters.Add(new SqlParameter("FromDate", FromDate));
                        cmd.Parameters.Add(new SqlParameter("ToDate", ToDate));
                    }

                    //UserIds
                    DataTable userIdTable;
                    using (userIdTable = new DataTable())
                    {
                        userIdTable.Columns.Add("Id", typeof(string));
                        foreach (int x in UserIds)
                            userIdTable.Rows.Add(x);
                    }
                    var uIdList = new SqlParameter("@UserIds", SqlDbType.Structured);
                    uIdList.Value = userIdTable;
                    cmd.Parameters.Add(uIdList);

                    //Sender_UserIds
                    DataTable userSenderTable;
                    using (userSenderTable = new DataTable())
                    {
                        userSenderTable.Columns.Add("Id", typeof(string));
                        foreach (int x in Sender_UserIds)
                            userSenderTable.Rows.Add(x);
                    }
                    var uSenderList = new SqlParameter("@Sender_UserIds", SqlDbType.Structured);
                    uSenderList.Value = userSenderTable;
                    cmd.Parameters.Add(uSenderList);

                    //Receiver_UserIds
                    DataTable userReceiverTable;
                    using (userReceiverTable = new DataTable())
                    {
                        userReceiverTable.Columns.Add("Id", typeof(string));
                        foreach (int x in Receiver_UserIds)
                            userReceiverTable.Rows.Add(x);
                    }
                    var uReceiverList = new SqlParameter("@Receiver_UserIds", SqlDbType.Structured);
                    uReceiverList.Value = userReceiverTable;
                    cmd.Parameters.Add(uReceiverList);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MemoryStream stream = new MemoryStream();

                        ExcelPackage pck = new ExcelPackage(stream);

                        ExcelWorksheet worksheet = pck.Workbook.Worksheets.Add("تقرير اجمالي أرصدة المستخدمين");

                        //RTL Direction
                        worksheet.View.RightToLeft = true;
                        //Apply Center to all Cells
                        worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        //Worksheet Name in first cell
                        worksheet.Cells["A1:I1"].Merge = true;
                        worksheet.Cells["A1:I1"].Style.Font.Bold = true;
                        worksheet.Cells["A1:I1"].Style.Font.Size = 14;
                        worksheet.Cells["A1:I1"].Value = "تقرير اجمالي أرصدة المستخدمين";


                        #region Report Filter Header

                        var userResult = ServiceMethod.GetUsers(UserIds).Result;
                        var userList = userResult?.Select(x => x.FullName);
                        int userListCount = (userList != null) ? userList.ToList().Count : 0;
                        string userListResult = String.Empty;
                        switch (userListCount)
                        {
                            case 0:
                                userListResult = "كل المستخدمين"; break;
                            case 1:
                                userListResult = userList.ToList()[0]; break;
                            default:
                                userListResult = "عدة مستخدمين"; break;
                        }

                        var sendersResult = ServiceMethod.GetUsers(Sender_UserIds).Result;
                        var SendersList = sendersResult?.Select(x => x.FullName);
                        int senderListCount = (SendersList != null) ? SendersList.ToList().Count : 0;
                        string senderListResult = String.Empty;
                        switch (senderListCount)
                        {
                            case 0:
                                senderListResult = "كل المستخدمين"; break;
                            case 1:
                                senderListResult = SendersList.ToList()[0]; break;
                            default:
                                senderListResult = "عدة مستخدمين"; break;
                        }

                        var receiversResult = ServiceMethod.GetUsers(Receiver_UserIds).Result;
                        var ReceiversList = receiversResult?.Select(x => x.FullName);
                        int receiverListCount = (ReceiversList != null) ? ReceiversList.ToList().Count : 0;
                        string receiverListResult = String.Empty;
                        switch (receiverListCount)
                        {
                            case 0:
                                receiverListResult = "كل المستخدمين"; break;
                            case 1:
                                receiverListResult = ReceiversList.ToList()[0]; break;
                            default:
                                receiverListResult = "عدة مستخدمين"; break;
                        }


                        string operationName = String.Empty;
                        if (ShowUsersWhoHaveResultsOnly)
                            operationName = "نعم";
                        else
                            operationName = "لا";

                        worksheet.Cells["A2:A8"].Value = "خيارات التقرير";
                        worksheet.Cells["A2:A8"].Merge = true;
                        worksheet.Cells["A2:A8"].Style.Font.Bold = true;


                        worksheet.Cells["B2"].Value = "تصفية حسب التاريخ";
                        worksheet.Cells["B2"].Style.Font.Bold = true;

                        worksheet.Cells["B3"].Value = "من تاريخ";
                        worksheet.Cells["B3"].Style.Font.Bold = true;

                        worksheet.Cells["C3"].Value = FromDate;

                        worksheet.Cells["D3"].Value = "الى تاريخ";
                        worksheet.Cells["D3"].Style.Font.Bold = true;

                        worksheet.Cells["E3"].Value = ToDate;

                        worksheet.Cells["B4"].Value = "المستخدمين المدروسين";
                        worksheet.Cells["B4"].Style.Font.Bold = true;

                        //worksheet.Cells["C4"].Value = (userList != null) ? string.Join("-", userList.ToArray()) : "";
                        worksheet.Cells["C4"].Value = userListResult;

                        worksheet.Cells["B5"].Value = "فلترة حسب المرسلين ";
                        worksheet.Cells["B5"].Style.Font.Bold = true;

                        worksheet.Cells["B6"].Value = "المستخدمين المرسلين";
                        worksheet.Cells["B6"].Style.Font.Bold = true;

                        //worksheet.Cells["C6"].Value = (SendersList != null) ? string.Join("-", SendersList.ToArray()) : "";
                        worksheet.Cells["C6"].Value = senderListResult;

                        worksheet.Cells["D6"].Value = "المستخدمين المستقبلين";
                        worksheet.Cells["D6"].Style.Font.Bold = true;

                        //worksheet.Cells["E6"].Value = (ReceiversList != null) ? string.Join("-", ReceiversList.ToArray()) : "";
                        worksheet.Cells["E6"].Value = receiverListResult;

                        worksheet.Cells["B8"].Value = "إظهار المتحركة فقط";
                        worksheet.Cells["B8"].Style.Font.Bold = true;

                        worksheet.Cells["C8"].Value = operationName;

                        worksheet.Cells["A2:E8"].Style.Border.BorderAround(ExcelBorderStyle.MediumDashDot, Color.DarkBlue);

                        #endregion



                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        #region GetUserColumn
                        List<ColumnClass> columnNameList = new List<ColumnClass>();

                        if (ForAllColumns)
                        {
                            columnNameList = ServiceMethod.GetAllUserColumns("TotalUserBalance.bs.table.columns");

                            //Sort columnNameList based on order
                            //var sorted = columnNameList.OrderBy(o => o.Name).ToList();
                            //columnNameList = sorted;
                        }
                        else
                        {
                            var GetUserColumnsResult = ServiceMethod.GetUserColumns(LoggedUser, LoggedUser);

                            var tableResult = GetUserColumnsResult.Result[0].Tables.Find(x => x.TableName.Equals("TotalUserBalance.bs.table.columns"));
                            columnNameList = tableResult.StandardColumns;
                            //Check if its empty or have one (item == Order)
                            if ((columnNameList == null) || (columnNameList?.Count == 0) ||
                                ((columnNameList?.Count == 1) && (columnNameList?[0].Name == "Order")))
                            {
                                result.Code = Errors.NoColumnSelected;
                                result.Message = Errors.GetErrorMessage(result.Code);
                                result.Result = false;
                                return result;
                            }

                            //Sort columnNameList based on order
                            var sorted = columnNameList.OrderBy(o => o.Order).ToList();
                            columnNameList = sorted;

                            //Re-order list based on sup lists
                            List<ColumnClass> reportList = new List<ColumnClass>();
                            List<ColumnClass> FirstUserList = new List<ColumnClass>();
                            List<ColumnClass> SecUserList = new List<ColumnClass>();

                            FirstUserList = columnNameList.FindAll(x => x.Name.StartsWith("Users."));
                            SecUserList = columnNameList.FindAll(x => x.Name.StartsWith("OperationUsers."));
                            reportList = columnNameList.FindAll(x => !x.Name.StartsWith("Users.") && !x.Name.StartsWith("OperationUsers."));

                            List<ColumnClass> TempList = new List<ColumnClass>();
                            TempList.AddRange(reportList);
                            TempList.AddRange(FirstUserList);
                            TempList.AddRange(SecUserList);

                            columnNameList = TempList;
                        }
                        #endregion

                        int offset = 11;
                        //Write Headers
                        ServiceMethod.PopulateExcelReportHeaders(LoggedUser, worksheet, offset, columnNameList);

                        //Start filling data
                        var data = new List<Dictionary<string, object>>();

                        while (reader.Read())
                        {
                            var rowData = ServiceMethod.PopulateExcelReportData(fieldNames, reader, worksheet, columnNameList, new UserClass());
                            data.Add(rowData);
                        }

                        //Write Data To Excel
                        //columnNameList = columnNameList.Select(s => s.Replace(".", "_")).ToList();
                        var tempList = new List<ColumnClass>();
                        foreach (var item in columnNameList)
                            tempList.Add(new ColumnClass { Order = item.Order, Name = item.Name.Replace(".", "_"), Width = item.Width });

                        columnNameList = tempList;

                        int counter = 0;
                        int order = 0;

                        foreach (var dic in data)
                        {
                            counter = 0; order++;

                            foreach (var column in columnNameList)
                            { //Write data 
                                if (dic.ContainsKey(column.Name))
                                {
                                    counter++;
                                    try
                                    { worksheet.Cells[offset + order, counter].Value = decimal.Parse(dic[column.Name].ToString()); }
                                    catch (Exception)
                                    { worksheet.Cells[offset + order, counter].Value = dic[column.Name].ToString(); }
                                }
                            }
                        }

                        //Style Data With Border
                        var lastAlpha = ServiceMethod.GetExcelColumnName(ServiceMethod.headerRow[0].Length);

                        ExcelRange Rng = worksheet.Cells["A" + (offset + 1) + ":" + lastAlpha + (offset + order)];

                        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Top.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Left.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Right.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Bottom.Color.SetColor(Color.SlateGray);
                        worksheet.Cells.AutoFitColumns();

                        pck.Save();

                        //Export Stream To Excel 
                        var outputDir = Config.ServerPhysicalExcelPath;
                        var fileName = "TotalUserBalanceReport-" + LoggedUser + "-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
                        if (reportType == ReportType.Excel) //Excel
                        {
                            //Export Stream To Excel 
                            FileInfo file = new FileInfo(outputDir + fileName);
                            pck.SaveAs(file);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileName;
                            CreateUserExcelReports(LoggedUser, "تقرير اجمالي أرصدة المستخدمين", url);
                        }
                        else if (reportType == ReportType.Pdf) //Pdf
                        {
                            Workbook workbook = new Workbook();
                            workbook.LoadFromStream(stream);

                            //convert Excel to HTML 
                            var fileNameWithNoExtention = fileName.Split('.')[0];

                            Worksheet sheet = workbook.Worksheets[0];
                            var imageFileName = outputDir + fileNameWithNoExtention + ".png";
                            sheet.SaveToImage(imageFileName);

                            // Convert to PDF and delete image
                            PdfHelper.Instance.SaveImageAsPdf(imageFileName, $"{outputDir + fileNameWithNoExtention}.pdf", 1000, deleteImage: true);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileNameWithNoExtention + ".pdf";
                            CreateUserExcelReports(LoggedUser, "تقرير اجمالي أرصدة المستخدمين", url);
                        }

                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = true;
                        return result;
                    }
                    else
                    {
                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = false;
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
                    result.Message = e.Message;
                    Errors.LogError(LoggedUser, e.Message, e.StackTrace, "1.0.3", "API", "GetTotalUserBalanceReportClassToExcel", e.Source, "");
                }
                result.Result = false;
                return result;
            }

        }


        public ResultClass<bool> UserSessionsReportToExcel(int LoggedUser,
        bool FilterByUserId, List<int> UserIds,
        bool FilterByDates, string FromDate, string ToDate,
        bool FilterByTimes, string FromTime, string ToTime,
        bool FilterByUserType, bool ShowGuest, bool ShowRegisteredUser,
        bool GroupByDay, bool GroupByHour,
        int RecordsCount = 99999999, int PageId = 1,
        ReportType reportType = ReportType.Excel, bool ForAllColumns = true)
        {
            ResultClass<bool> result = new ResultClass<bool>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 1500000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_SearchUserSessions";
                    List<SqlParameter> Params = new List<SqlParameter>()
               {
                  new SqlParameter("LoggedUser", HttpContext.Current.Request.Headers["LoggedUser"]),

                  new SqlParameter("FilterByUserType", FilterByUserType),
                  new SqlParameter("ShowGuest", ShowGuest),
                  new SqlParameter("ShowRegisteredUser", ShowRegisteredUser),

                  new SqlParameter("GroupByDay", GroupByDay),
                  new SqlParameter("GroupByHour", GroupByHour),

                  new SqlParameter("PageId", PageId),
                  new SqlParameter("RecordsCount", RecordsCount)
               };

                    if ((FilterByDates) && (!String.IsNullOrWhiteSpace(FromDate.Trim())) &&
                        (!String.IsNullOrWhiteSpace(ToDate.Trim())))
                    {
                        Params.Add(new SqlParameter("FilterByDates", FilterByDates));
                        Params.Add(new SqlParameter("FromDate", FromDate));
                        Params.Add(new SqlParameter("ToDate", ToDate));
                    }

                    if ((FilterByTimes) && (!String.IsNullOrWhiteSpace(FromTime.Trim())) &&
                        (!String.IsNullOrWhiteSpace(ToTime.Trim())))
                    {
                        Params.Add(new SqlParameter("FilterByTimes", FilterByTimes));
                        Params.Add(new SqlParameter("FromTime", FromTime));
                        Params.Add(new SqlParameter("ToTime", ToTime));
                    }
                    cmd.Parameters.AddRange(Params.ToArray());

                    if ((FilterByUserId) && (UserIds != null))
                    {
                        cmd.Parameters.Add(new SqlParameter("FilterByUserId", FilterByUserId));

                        //UserTypeIds
                        DataTable userIdsTable;
                        using (userIdsTable = new DataTable())
                        {
                            userIdsTable.Columns.Add("Item", typeof(int));
                            foreach (int x in UserIds)
                                userIdsTable.Rows.Add(x);
                        }
                        SqlParameter pList = new SqlParameter("@UserIds", SqlDbType.Structured);
                        pList.ParameterName = "@UserIds";
                        pList.TypeName = "dbo.IntList";
                        pList.Value = userIdsTable.DefaultView.ToTable();
                        cmd.Parameters.Add(pList);
                    }

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MemoryStream stream = new MemoryStream();

                        ExcelPackage pck = new ExcelPackage(stream);

                        ExcelWorksheet worksheet = pck.Workbook.Worksheets.Add("تقرير دخول الزوار و المستخدمين");

                        //RTL Direction
                        worksheet.View.RightToLeft = true;
                        //Apply Center to all Cells
                        worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        //Worksheet Name in first cell
                        worksheet.Cells["A1:I1"].Merge = true;
                        worksheet.Cells["A1:I1"].Style.Font.Bold = true;
                        worksheet.Cells["A1:I1"].Style.Font.Size = 14;
                        worksheet.Cells["A1:I1"].Value = "تقرير دخول الزوار و المستخدمين";


                        #region Report Filter Header

                        string userListResult = String.Empty;

                        if ((!FilterByUserType) ||
                           ((FilterByUserType) && (ShowGuest && ShowRegisteredUser)))
                            userListResult = "كل المستخدمين";

                        else if ((FilterByUserType) && (ShowGuest && !ShowRegisteredUser))
                            userListResult = "الزوار فقط";

                        else if ((FilterByUserType) && (!ShowGuest && ShowRegisteredUser))
                            userListResult = "المستخدمين المسجلين فقط";


                        string operationName = String.Empty;
                        if (GroupByDay)
                            operationName = "يومي";
                        else
                            operationName = "ساعي";

                        worksheet.Cells["A2:A8"].Value = "خيارات التقرير";
                        worksheet.Cells["A2:A8"].Merge = true;
                        worksheet.Cells["A2:A8"].Style.Font.Bold = true;


                        worksheet.Cells["B2"].Value = "تصفية حسب التاريخ";
                        worksheet.Cells["B2"].Style.Font.Bold = true;

                        worksheet.Cells["B3"].Value = "من تاريخ";
                        worksheet.Cells["B3"].Style.Font.Bold = true;

                        worksheet.Cells["C3"].Value = FromDate;

                        worksheet.Cells["D3"].Value = "الى تاريخ";
                        worksheet.Cells["D3"].Style.Font.Bold = true;

                        worksheet.Cells["E3"].Value = ToDate;

                        if (GroupByHour)
                        {
                            worksheet.Cells["B4"].Value = "تصفية حسب الوقت";
                            worksheet.Cells["B4"].Style.Font.Bold = true;

                            worksheet.Cells["B5"].Value = "من توقيت";
                            worksheet.Cells["B5"].Style.Font.Bold = true;

                            worksheet.Cells["C5"].Value = Convert.ToDateTime(FromTime).ToString("hh:mm tt");

                            worksheet.Cells["D5"].Value = "الى توقيت";
                            worksheet.Cells["D5"].Style.Font.Bold = true;

                            worksheet.Cells["E5"].Value = Convert.ToDateTime(ToTime).ToString("hh:mm tt");
                        }

                        worksheet.Cells["B6"].Value = "المستخدمين المدروسين";
                        worksheet.Cells["B6"].Style.Font.Bold = true;

                        worksheet.Cells["C6"].Value = userListResult;


                        worksheet.Cells["B7"].Value = "نوع الفلترة";
                        worksheet.Cells["B7"].Style.Font.Bold = true;

                        worksheet.Cells["C7"].Value = operationName;

                        worksheet.Cells["A2:E8"].Style.Border.BorderAround(ExcelBorderStyle.MediumDashDot, Color.DarkBlue);

                        #endregion



                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        #region GetUserColumn
                        List<ColumnClass> columnNameList = new List<ColumnClass>();

                        //Force to filter by all Columns !!
                        //if (ForAllColumns)
                        {
                            columnNameList = ServiceMethod.GetAllUserColumns("UserSessionsReport.bs.table.columns");
                            if (GroupByHour)
                            {
                                columnNameList.Insert(2, new ColumnClass { Name = "Hour" });
                            }
                            //Sort columnNameList based on order
                            //var sorted = columnNameList.OrderBy(o => o.Name).ToList();
                            //columnNameList = sorted;
                        }
                        //else
                        //{
                        //   var GetUserColumnsResult = ServiceMethod.GetUserColumns(LoggedUser, LoggedUser);

                        //   var tableResult = GetUserColumnsResult.Result[0].Tables.Find(x => x.TableName.Equals("UserSessionsReport.bs.table.columns"));
                        //   columnNameList = tableResult.StandardColumns;
                        //   //Check if its empty or have one (item == Order)
                        //   if ((columnNameList == null) || (columnNameList?.Count == 0) ||
                        //       ((columnNameList?.Count == 1) && (columnNameList?[0].Name == "Order")))
                        //   {
                        //      result.Code = Errors.NoColumnSelected;
                        //      result.Message = Errors.GetErrorMessage(result.Code);
                        //      result.Result = false;
                        //      return result;
                        //   }

                        //   //Sort columnNameList based on order
                        //   var sorted = columnNameList.OrderBy(o => o.Order).ToList();
                        //   columnNameList = sorted;

                        //   //Re-order list based on sup lists
                        //   List<ColumnClass> reportList = new List<ColumnClass>();
                        //   List<ColumnClass> FirstUserList = new List<ColumnClass>();
                        //   List<ColumnClass> SecUserList = new List<ColumnClass>();

                        //   FirstUserList = columnNameList.FindAll(x => x.Name.StartsWith("Users."));
                        //   SecUserList = columnNameList.FindAll(x => x.Name.StartsWith("OperationUsers."));
                        //   reportList = columnNameList.FindAll(x => !x.Name.StartsWith("Users.") && !x.Name.StartsWith("OperationUsers."));

                        //   List<ColumnClass> TempList = new List<ColumnClass>();
                        //   TempList.AddRange(reportList);
                        //   TempList.AddRange(FirstUserList);
                        //   TempList.AddRange(SecUserList);

                        //   columnNameList = TempList;
                        //}
                        #endregion

                        int offset = 11;
                        //Write Headers
                        ServiceMethod.PopulateExcelReportHeaders(LoggedUser, worksheet, offset, columnNameList);

                        //Start filling data
                        var data = new List<Dictionary<string, object>>();

                        while (reader.Read())
                        {
                            var rowData = ServiceMethod.PopulateExcelReportData(fieldNames, reader, worksheet, columnNameList, new UserClass());
                            data.Add(rowData);
                        }

                        //Write Data To Excel
                        //columnNameList = columnNameList.Select(s => s.Replace(".", "_")).ToList();
                        var tempList = new List<ColumnClass>();
                        foreach (var item in columnNameList)
                            tempList.Add(new ColumnClass { Order = item.Order, Name = item.Name.Replace(".", "_"), Width = item.Width });

                        columnNameList = tempList;

                        int counter = 0;
                        int order = 0;

                        foreach (var dic in data)
                        {
                            counter = 0; order++;

                            foreach (var column in columnNameList)
                            { //Write data 
                                if (dic.ContainsKey(column.Name))
                                {
                                    counter++;
                                    try
                                    { worksheet.Cells[offset + order, counter].Value = decimal.Parse(dic[column.Name].ToString()); }
                                    catch (Exception)
                                    { worksheet.Cells[offset + order, counter].Value = dic[column.Name].ToString(); }
                                }
                            }
                        }

                        //Style Data With Border
                        var lastAlpha = ServiceMethod.GetExcelColumnName(ServiceMethod.headerRow[0].Length);

                        ExcelRange Rng = worksheet.Cells["A" + (offset + 1) + ":" + lastAlpha + (offset + order)];

                        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Top.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Left.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Right.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Bottom.Color.SetColor(Color.SlateGray);
                        worksheet.Cells.AutoFitColumns();

                        //added to style Date Column
                        ExcelRange Rng1 = worksheet.Cells["A" + (offset + 1) + ":" + "A" + (offset + order)];
                        string DateCellFormat = "mm/dd/yyyy";
                        Rng1.Style.Numberformat.Format = DateCellFormat;



                        pck.Save();

                        //Export Stream To Excel 
                        var outputDir = Config.ServerPhysicalExcelPath;
                        var fileName = "UserSessionsReport-" + LoggedUser + "-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
                        if (reportType == ReportType.Excel) //Excel
                        {
                            //Export Stream To Excel 
                            FileInfo file = new FileInfo(outputDir + fileName);
                            pck.SaveAs(file);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileName;
                            CreateUserExcelReports(LoggedUser, "تقرير دخول الزوار و المستخدمين", url);
                        }
                        else if (reportType == ReportType.Pdf) //Pdf
                        {
                            Workbook workbook = new Workbook();
                            workbook.LoadFromStream(stream);

                            //convert Excel to HTML 
                            var fileNameWithNoExtention = fileName.Split('.')[0];

                            Worksheet sheet = workbook.Worksheets[0];
                            var imageFileName = outputDir + fileNameWithNoExtention + ".png";
                            sheet.SaveToImage(imageFileName);

                            // Convert to PDF and delete image
                            PdfHelper.Instance.SaveImageAsPdf(imageFileName, $"{outputDir + fileNameWithNoExtention}.pdf", 1000, deleteImage: true);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileNameWithNoExtention + ".pdf";
                            CreateUserExcelReports(LoggedUser, "تقرير دخول الزوار و المستخدمين", url);
                        }

                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = true;
                        return result;
                    }
                    else
                    {
                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = false;
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
                    result.Message = e.Message;
                    Errors.LogError(LoggedUser, e.Message, e.StackTrace, "1.0.3", "API", "UserSessionsReportToExcel", e.Source, "");
                }
                result.Result = false;
                return result;
            }

        }

        public ResultClass<bool> MultipleTransferFromExcelReport(int LoggedUser,
     string TransferExcelGuid,
     ReportType reportType = ReportType.Excel, bool ForAllColumns = true)
        {
            ResultClass<bool> result = new ResultClass<bool>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 1500000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetTransfersResult";
                    cmd.Parameters.Add(new SqlParameter("LoggedUser", LoggedUser));
                    cmd.Parameters.Add(new SqlParameter("TransferExcelGuid", TransferExcelGuid));

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string reportName = "تقرير نتائج تحويل من ملف إكسل";

                        MemoryStream stream = new MemoryStream();

                        ExcelPackage pck = new ExcelPackage(stream);

                        ExcelWorksheet worksheet = pck.Workbook.Worksheets.Add(reportName);

                        //RTL Direction
                        worksheet.View.RightToLeft = true;
                        //Apply Center to all Cells
                        worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        //Worksheet Name in first cell
                        worksheet.Cells["A1:I1"].Merge = true;
                        worksheet.Cells["A1:I1"].Style.Font.Bold = true;
                        worksheet.Cells["A1:I1"].Style.Font.Size = 14;
                        worksheet.Cells["A1:I1"].Value = reportName;


                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();


                        #region GetUserColumn
                        List<ColumnClass> columnNameList = new List<ColumnClass>();

                        columnNameList = ServiceMethod.GetAllUserColumns("MultipleTransferFromExcelReport.bs.table.columns");

                        #endregion

                        int offset = 4;
                        //Write Headers
                        ServiceMethod.PopulateExcelReportHeaders(LoggedUser, worksheet, offset, columnNameList);

                        //Start filling data
                        var data = new List<Dictionary<string, object>>();

                        while (reader.Read())
                        {
                            var rowData = ServiceMethod.PopulateExcelReportData(fieldNames, reader, worksheet, columnNameList, new UserClass());
                            data.Add(rowData);
                        }

                        //Write Data To Excel
                        //columnNameList = columnNameList.Select(s => s.Replace(".", "_")).ToList();
                        var tempList = new List<ColumnClass>();
                        foreach (var item in columnNameList)
                            tempList.Add(new ColumnClass { Order = item.Order, Name = item.Name.Replace(".", "_"), Width = item.Width });

                        columnNameList = tempList;

                        int counter = 0;
                        int order = 0;

                        foreach (var dic in data)
                        {
                            counter = 0; order++;

                            foreach (var column in columnNameList)
                            { //Write data 
                                if (dic.ContainsKey(column.Name))
                                {
                                    counter++;
                                    try
                                    { worksheet.Cells[offset + order, counter].Value = decimal.Parse(dic[column.Name].ToString()); }
                                    catch (Exception)
                                    { worksheet.Cells[offset + order, counter].Value = dic[column.Name].ToString(); }
                                }
                            }
                        }

                        //Style Data With Border
                        var lastAlpha = ServiceMethod.GetExcelColumnName(ServiceMethod.headerRow[0].Length);

                        ExcelRange Rng = worksheet.Cells["A" + (offset + 1) + ":" + lastAlpha + (offset + order)];

                        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Top.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Left.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Right.Color.SetColor(Color.SlateGray);

                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Rng.Style.Border.Bottom.Color.SetColor(Color.SlateGray);
                        worksheet.Cells.AutoFitColumns();

                        pck.Save();

                        //Export Stream To Excel 
                        var outputDir = Config.ServerPhysicalExcelPath;
                        var fileName = "MultipleTransferFromExcelReport-" + LoggedUser + "-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
                        if (reportType == ReportType.Excel) //Excel
                        {
                            //Export Stream To Excel 
                            FileInfo file = new FileInfo(outputDir + fileName);
                            pck.SaveAs(file);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileName;
                            CreateUserExcelReports(LoggedUser, reportName, url);
                        }
                        else if (reportType == ReportType.Pdf) //Pdf
                        {
                            Workbook workbook = new Workbook();
                            workbook.LoadFromStream(stream);

                            //convert Excel to HTML 
                            var fileNameWithNoExtention = fileName.Split('.')[0];

                            Worksheet sheet = workbook.Worksheets[0];
                            var imageFileName = outputDir + fileNameWithNoExtention + ".png";
                            sheet.SaveToImage(imageFileName);

                            // Convert to PDF and delete image
                            PdfHelper.Instance.SaveImageAsPdf(imageFileName, $"{outputDir + fileNameWithNoExtention}.pdf", 1000, deleteImage: true);

                            string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileNameWithNoExtention + ".pdf";
                            CreateUserExcelReports(LoggedUser, reportName, url);
                        }

                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = true;
                        return result;
                    }
                    else
                    {
                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = false;
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
                    result.Message = e.Message;
                    Errors.LogError(LoggedUser, e.Message, e.StackTrace, "1.0.3", "API", "GetTotalUserBalanceReportClassToExcel", e.Source, "");
                }
                result.Result = false;
                return result;
            }

        }


        public ResultClass<bool> ExportToWordpress(int LoggedUser)
        {
            ResultClass<bool> result = new ResultClass<bool>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();

                    SqlCommand cmd0 = new SqlCommand();
                    cmd0.Connection = conn;
                    cmd0.CommandTimeout = 1500000;
                    cmd0.CommandType = System.Data.CommandType.Text;
                    cmd0.CommandText = "SELECT * FROM ConfigTbl";
                    Errors.LogError(LoggedUser, "ConfigTbl", "ConfigTbl", "1.0.3", "API", "ExportToWordpress", "ConfigTbl", "");
                    SqlDataReader reader0 = cmd0.ExecuteReader();

                    string currencyId = "";
                    string pricetypeId = "";
                    string countryId = "";
                    string countryCurrencyId = "";

                    if (reader0.HasRows)
                    {
                        reader0.Read();
                        currencyId = reader0["CurrencyId"].ToString();
                        countryId = reader0["CountryId"].ToString();
                        pricetypeId = reader0["PriceTypeId"].ToString();
                    }
                    

                    SqlCommand cmd000 = new SqlCommand();
                    cmd000.Connection = conn;
                    cmd000.CommandTimeout = 1500000;
                    cmd000.CommandType = System.Data.CommandType.Text;
                    cmd000.CommandText = "SELECT TOP 1 * FROM CountryCurrenciesTbl WHERE CountryId = " + countryId + " AND CurrencyId = " + currencyId;
                    Errors.LogError(LoggedUser, "CountryCurrenciesTbl", "CountryCurrenciesTbl", "1.0.3", "API", "ExportToWordpress", "CountryCurrenciesTbl", "");
                    SqlDataReader reader000 = cmd000.ExecuteReader();

                    if (reader000.HasRows)
                    {
                        reader000.Read();
                        countryCurrencyId = reader000["Id"].ToString();
                    }
                    



                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 1500000;
                    cmd.CommandType = System.Data.CommandType.Text;
                    Errors.LogError(LoggedUser, "ItemsVw", "ItemsVw", "1.0.3", "API", "ExportToWordpress", "ItemsVw", "");
                    cmd.CommandText = "SELECT * FROM ItemsVw WHERE [Disabled] = 0";
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string reportName = "Wordpress";

                        MemoryStream stream = new MemoryStream();
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        ExcelPackage pck = new ExcelPackage(stream);
                        

                        ExcelWorksheet worksheet = pck.Workbook.Worksheets.Add(reportName);

                        worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        
                        worksheet.Cells[1, 1].Value = "Type";
                        worksheet.Cells[1, 2].Value = "SKU";
                        worksheet.Cells[1, 3].Value = "Name";
                        worksheet.Cells[1, 4].Value = "Published";
                        worksheet.Cells[1, 5].Value = "Is featured?";
                        worksheet.Cells[1, 6].Value = "Visibility in catalog";
                        worksheet.Cells[1, 7].Value = "In stock?";
                        worksheet.Cells[1, 8].Value = "Stock";
                        worksheet.Cells[1, 9].Value = "Low stock amount";
                        worksheet.Cells[1, 10].Value = "Backorders allowed?";
                        worksheet.Cells[1, 11].Value = "Sold individually?";
                        worksheet.Cells[1, 12].Value = "Allow customer reviews?";
                        worksheet.Cells[1, 13].Value = "Sale price";
                        worksheet.Cells[1, 14].Value = "Regular price";
                        worksheet.Cells[1, 15].Value = "Categories";
                        worksheet.Cells[1, 16].Value = "Images";
                        worksheet.Cells[1, 17].Value = "Parent";
                        worksheet.Cells[1, 18].Value = "Attribute 1 name";
                        worksheet.Cells[1, 19].Value = "Attribute 1 value(s)";
                        worksheet.Cells[1, 20].Value = "Attribute 1 visible";
                        worksheet.Cells[1, 21].Value = "Attribute 1 global";
                        worksheet.Cells[1, 22].Value = "Attribute 2 name";
                        worksheet.Cells[1, 23].Value = "Attribute 2 value(s)";
                        worksheet.Cells[1, 24].Value = "Attribute 2 visible";
                        worksheet.Cells[1, 25].Value = "Attribute 2 global";


                        int r = 1;
                        int x = 0;
                        while (reader.Read())
                        {
                            x = 0;
                            r = r + 1;
                            SqlCommand cmd00 = new SqlCommand();
                            cmd00.Connection = conn;
                            cmd00.CommandTimeout = 1500000;
                            cmd00.CommandType = System.Data.CommandType.Text;
                            cmd00.CommandText = "SELECT TOP 1 * FROM ItemPricesTbl WHERE ItemId = " + reader["Id"].ToString() + " AND CountryCurrencyId = " + countryCurrencyId + " AND TypeId = " + pricetypeId;
                            Errors.LogError(LoggedUser, "ItemPricesTbl", "ItemPricesTbl", "1.0.3", "API", "ExportToWordpress", "ItemPricesTbl", "");
                            SqlDataReader reader00 = cmd00.ExecuteReader();

                            if (reader00.HasRows)
                                reader00.Read();

                            worksheet.Cells[r, 1].Value = "variable";
                            worksheet.Cells[r, 2].Value = reader["Code"].ToString();
                            worksheet.Cells[r, 3].Value = reader["EnglishName"].ToString();
                            worksheet.Cells[r, 4].Value = 1;
                            worksheet.Cells[r, 5].Value = 0;
                            worksheet.Cells[r, 6].Value = "visible";
                            worksheet.Cells[r, 7].Value = "1";
                            worksheet.Cells[r, 8].Value = "100";
                            worksheet.Cells[r, 9].Value = "2";
                            worksheet.Cells[r, 10].Value = "0";
                            worksheet.Cells[r, 11].Value = "0";
                            worksheet.Cells[r, 12].Value = "1";
                            worksheet.Cells[r, 13].Value = "";
                            if (reader00.HasRows)
                                worksheet.Cells[r, 14].Value = reader00["Price"].ToString();
                            else
                                worksheet.Cells[r, 14].Value = "0";
                            worksheet.Cells[r, 15].Value = reader["CategoryEnglishName"].ToString();
                            worksheet.Cells[r, 16].Value = reader["ImageUrl"];
                            worksheet.Cells[r, 17].Value = "";
                            worksheet.Cells[r, 18].Value = "Color";
                            worksheet.Cells[r, 19].Value = "";
                            worksheet.Cells[r, 20].Value = "1";
                            worksheet.Cells[r, 21].Value = "1";
                            worksheet.Cells[r, 22].Value = "Size";
                            worksheet.Cells[r, 23].Value = "";
                            worksheet.Cells[r, 24].Value = "1";
                            worksheet.Cells[r, 25].Value = "1";

                            SqlCommand cmd2 = new SqlCommand();
                            cmd2.Connection = conn;
                            cmd2.CommandTimeout = 1500000;
                            cmd2.CommandType = System.Data.CommandType.Text;
                            cmd2.CommandText = "SELECT ICV.*, C.Code FROM ItemColorsVw AS ICV INNER JOIN ColorsTbl AS C ON C.Id = ICV.ColorId WHERE ItemId = " + reader["Id"];
                            Errors.LogError(LoggedUser, "ItemColorsVw", "ItemColorsVw", "1.0.3", "API", "ExportToWordpress", "ItemColorsVw", "");
                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            

                            SqlCommand cmd3 = new SqlCommand();
                            cmd3.Connection = conn;
                            cmd3.CommandTimeout = 1500000;
                            cmd3.CommandType = System.Data.CommandType.Text;
                            cmd3.CommandText = "SELECT * FROM ItemSizesVw WHERE ItemId = " + reader["Id"];
                            Errors.LogError(LoggedUser, "ItemSizesVw", "ItemSizesVw", "1.0.3", "API", "ExportToWordpress", "ItemSizesVw", "");
                            SqlDataReader reader3 = cmd3.ExecuteReader();
                            

                            SqlCommand cmd4 = new SqlCommand();
                            cmd4.Connection = conn;
                            cmd4.CommandTimeout = 1500000;
                            cmd4.CommandType = System.Data.CommandType.Text;
                            cmd4.CommandText = "SELECT * FROM ItemImagesTbl WHERE ItemId = " + reader["Id"];
                            Errors.LogError(LoggedUser, "ItemImagesTbl", "ItemImagesTbl", "1.0.3", "API", "ExportToWordpress", "ItemImagesTbl", "");
                            SqlDataReader reader4 = cmd4.ExecuteReader();
                            

                            string Colors = "";
                            string Sizes = "";
                            string Images = "";

                            if (reader4.HasRows)
                            {
                                Images = "";
                                while (reader4.Read())
                                { 
                                    Images = Images + reader4["ImageUrl"].ToString() + ",";
                                }
                            }
                            if (reader2.HasRows)
                            {

                                while (reader2.Read())
                                {
                                    Colors = Colors + reader2["ColorEnglishName"].ToString() + ",";
                                    Sizes = "";
                                    if (reader3.HasRows)
                                    {
                                        while (reader3.Read())
                                        {
                                            x = x + 1;
                                            Sizes = Sizes + reader3["SizeEnglishName"].ToString() + ",";


                                            worksheet.Cells[r + x, 1].Value = "variation";
                                            worksheet.Cells[r + x, 2].Value = reader["Code"].ToString() + reader2["Code"].ToString() + reader3["SizeEnglishName"].ToString();
                                            worksheet.Cells[r + x, 3].Value = reader["EnglishName"].ToString();
                                            worksheet.Cells[r + x, 4].Value = 1;
                                            worksheet.Cells[r + x, 5].Value = 0;
                                            worksheet.Cells[r + x, 6].Value = "visible";
                                            worksheet.Cells[r + x, 7].Value = "1";
                                            worksheet.Cells[r + x, 8].Value = "100";
                                            worksheet.Cells[r + x, 9].Value = "2";
                                            worksheet.Cells[r + x, 10].Value = "0";
                                            worksheet.Cells[r + x, 11].Value = "0";
                                            worksheet.Cells[r + x, 12].Value = "1";
                                            worksheet.Cells[r + x, 13].Value = "";
                                            if (reader00.HasRows)
                                                worksheet.Cells[r + x, 14].Value = reader00["Price"].ToString();
                                            else
                                                worksheet.Cells[r + x, 14].Value = "0";
                                            worksheet.Cells[r + x, 15].Value = reader["CategoryEnglishName"].ToString();
                                            worksheet.Cells[r + x, 16].Value = "";
                                            worksheet.Cells[r + x, 17].Value = reader["Code"].ToString();
                                            worksheet.Cells[r + x, 18].Value = "Color";
                                            worksheet.Cells[r + x, 19].Value = reader2["ColorEnglishName"].ToString();
                                            worksheet.Cells[r + x, 20].Value = "1";
                                            worksheet.Cells[r + x, 21].Value = "1";
                                            worksheet.Cells[r + x, 22].Value = "Size";
                                            worksheet.Cells[r + x, 23].Value = reader3["SizeEnglishName"].ToString();
                                            worksheet.Cells[r + x, 24].Value = "1";
                                            worksheet.Cells[r + x, 25].Value = "1";
                                        }
                                    }
                                    else
                                    {

                                        x = x + 1;
                                        worksheet.Cells[r + x, 1].Value = "variation";
                                        worksheet.Cells[r + x, 2].Value = reader["Code"].ToString() + reader2["Code"].ToString();
                                        worksheet.Cells[r + x, 3].Value = reader["EnglishName"].ToString();
                                        worksheet.Cells[r + x, 4].Value = 1;
                                        worksheet.Cells[r + x, 5].Value = 0;
                                        worksheet.Cells[r + x, 6].Value = "visible";
                                        worksheet.Cells[r + x, 7].Value = "1";
                                        worksheet.Cells[r + x, 8].Value = "100";
                                        worksheet.Cells[r + x, 9].Value = "2";
                                        worksheet.Cells[r + x, 10].Value = "0";
                                        worksheet.Cells[r + x, 11].Value = "0";
                                        worksheet.Cells[r + x, 12].Value = "1";
                                        worksheet.Cells[r + x, 13].Value = "";
                                        if (reader00.HasRows)
                                            worksheet.Cells[r + x, 14].Value = reader00["Price"].ToString();
                                        else
                                            worksheet.Cells[r + x, 14].Value = "0";
                                        worksheet.Cells[r + x, 15].Value = reader["CategoryEnglishName"].ToString();
                                        worksheet.Cells[r + x, 16].Value = "";
                                        worksheet.Cells[r + x, 17].Value = reader["Code"].ToString();
                                        worksheet.Cells[r + x, 18].Value = "Color";
                                        worksheet.Cells[r + x, 19].Value = reader2["ColorEnglishName"].ToString();
                                        worksheet.Cells[r + x, 20].Value = "1";
                                        worksheet.Cells[r + x, 21].Value = "1";
                                        worksheet.Cells[r + x, 22].Value = "Size";
                                        worksheet.Cells[r + x, 23].Value = "ONE SIZE";
                                        worksheet.Cells[r + x, 24].Value = "1";
                                        worksheet.Cells[r + x, 25].Value = "1";
                                    }
                                }
                            }
                            else
                            {
                                if (reader3.HasRows)
                                {
                                    while (reader3.Read())
                                    {
                                        x = x + 1;
                                        Sizes = Sizes + reader3["SizeEnglishName"].ToString() + ",";

                                        worksheet.Cells[r + x, 1].Value = "variation";
                                        worksheet.Cells[r + x, 2].Value = reader["Code"].ToString() + reader3["SizeArabicName"].ToString();
                                        worksheet.Cells[r + x, 3].Value = reader["EnglishName"].ToString();
                                        worksheet.Cells[r + x, 4].Value = 1;
                                        worksheet.Cells[r + x, 5].Value = 0;
                                        worksheet.Cells[r + x, 6].Value = "visible";
                                        worksheet.Cells[r + x, 7].Value = "1";
                                        worksheet.Cells[r + x, 8].Value = "100";
                                        worksheet.Cells[r + x, 9].Value = "2";
                                        worksheet.Cells[r + x, 10].Value = "0";
                                        worksheet.Cells[r + x, 11].Value = "0";
                                        worksheet.Cells[r + x, 12].Value = "1";
                                        worksheet.Cells[r + x, 13].Value = "";
                                        if (reader00.HasRows)
                                            worksheet.Cells[r + x, 14].Value = reader00["Price"].ToString();
                                        else
                                            worksheet.Cells[r + x, 14].Value = "0";
                                        worksheet.Cells[r + x, 15].Value = reader["CategoryEnglishName"].ToString();
                                        worksheet.Cells[r + x, 16].Value = "";
                                        worksheet.Cells[r + x, 17].Value = reader["Code"].ToString();
                                        worksheet.Cells[r + x, 18].Value = "Color";
                                        worksheet.Cells[r + x, 19].Value = "ONE COLOR";
                                        worksheet.Cells[r + x, 20].Value = "1";
                                        worksheet.Cells[r + x, 21].Value = "1";
                                        worksheet.Cells[r + x, 22].Value = "Size";
                                        worksheet.Cells[r + x, 23].Value = reader3["SizeEnglishName"].ToString();
                                        worksheet.Cells[r + x, 24].Value = "1";
                                        worksheet.Cells[r + x, 25].Value = "1";
                                    }
                                }
                            }

                            worksheet.Cells[r, 19].Value = Colors;
                            worksheet.Cells[r, 23].Value = Sizes;
                            worksheet.Cells[r, 16].Value = Images;

                            r = r + x;

                            reader00.Close();
                            reader2.Close();
                            reader3.Close();
                            reader4.Close();
                        }
                        var outputDir = Config.ServerPhysicalExcelPath;
                        var fileName = "WooCommerce-" + LoggedUser + "-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";

                        //Export Stream To Excel 
                        FileInfo file = new FileInfo(outputDir + fileName);
                        pck.SaveAs(file);

                        string url = Config.StaticURL + @Config.ServerPhysicalExcelPath.Remove(0, Config.ServerRoot.Length).Replace(@"\", "/") + fileName;
                        CreateUserExcelReports(LoggedUser, "بيانات الأصناف لل WooCommerce", url);

                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = true;
                        return result;
                    }
                    else
                    {
                        
                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = false;
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
                    result.Message = e.Message;
                    Errors.LogError(LoggedUser, e.Message, e.StackTrace, "1.0.3", "API", "ExportToWordpress", e.Source, "");
                }
                result.Result = false;
                return result;
            }

        }

    }
}
