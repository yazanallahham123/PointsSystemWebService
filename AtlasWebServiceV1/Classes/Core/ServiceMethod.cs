using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Web;
using System.Reflection;
using System.Threading;
using System.Windows;
using OfficeOpenXml;
using OfficeOpenXml.Style;
//using static System.Net.Mime.MediaTypeNames;
//using Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using CipherLibrary.Cipher;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Firebase.Database;
using Firebase.Database.Query;

namespace PointsSystemWebService.Classes.Core
{
    public static class ServiceMethod
    {
        public static void ActivateSystem()
        {
            Config.IsSystemUp = true;
        }

        public static void DeactivateSystem()
        {
            Config.IsSystemUp = false;
        }


        public static List<string[]> headerRow = new List<string[]>() { new string[] { "رقم السطر" } };


        public static List<string> GetUserColumns(string Perfix)
        {
            string modifiedPerfix = Perfix;
            if (modifiedPerfix.Trim() != "")
                modifiedPerfix = modifiedPerfix + ".";
            List<string> UserColumns = new List<string> {
        modifiedPerfix+"Id",
        modifiedPerfix+"FullName",
        modifiedPerfix+"NickName",
        modifiedPerfix+"Username",
        modifiedPerfix+"CommercialName",
        modifiedPerfix+"MobileNumber",
        modifiedPerfix+"CompanyArabicName",
        modifiedPerfix+"GovernorateArabicName",
        modifiedPerfix+"CityArabicName",
        modifiedPerfix+"LocationArabicName",
        modifiedPerfix+"Address1",
        modifiedPerfix+"Address2",
        modifiedPerfix+"Birthdate",
        modifiedPerfix+"CreateDate",
        modifiedPerfix+"Disabled",
        modifiedPerfix+"Email",
        modifiedPerfix+"Gender",
        modifiedPerfix+"HasVocationalCertificate",
        modifiedPerfix+"IsActive",
        modifiedPerfix+"JobArabicName",
        modifiedPerfix+"WorkDomainArabicName",
        modifiedPerfix+"PositionArabicName",
        modifiedPerfix+"EducationLevelArabicName",
        modifiedPerfix+"Notes",
        modifiedPerfix+"OrdersPoints",
        modifiedPerfix+"PointsBalance",
        modifiedPerfix+"StaffCount",
        modifiedPerfix+"YearsOfExperience",
        modifiedPerfix+"TotalReceived",
        modifiedPerfix+"TotalReceived_Waiting",
        modifiedPerfix+"TotalSent",
        modifiedPerfix+"TotalSent_Waiting",
        modifiedPerfix+"UserTypeName",
        modifiedPerfix+"LunchCount",
        modifiedPerfix+"CountryCode",
        modifiedPerfix+"MobileNumber2",
        modifiedPerfix+"CardNumber",
        modifiedPerfix+"CardType",
        modifiedPerfix+"AccountNumber",
        modifiedPerfix+"Nationality",
        modifiedPerfix+"ChildCount",
        modifiedPerfix+"MaritalStatus"
         };

            return UserColumns;
        }

        public static ResultClass<List<UserTypeColumnsClass>> GetUserColumns(int LoggedUser, int UserId)
        {
            ResultClass<List<UserTypeColumnsClass>> result = new ResultClass<List<UserTypeColumnsClass>>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetUserColumns";

                    List<SqlParameter> Params = new List<SqlParameter>()
               {
                  new SqlParameter("LoggedUser", LoggedUser),
                  new SqlParameter("UserId", UserId),
               };


                    cmd.Parameters.AddRange(Params.ToArray());

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<UserTypeColumnsClass> UserTypeColumnsList = new List<UserTypeColumnsClass>();
                        UserTypeColumnsClass userTypeColumns;
                        int order = 0;
                        while (reader.Read())
                        {
                            userTypeColumns = new UserTypeColumnsClass();


                            order += 1;
                            var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                            userTypeColumns = new UserTypeColumnsClass().PopulateUserTypeColumns(fieldNames, reader);

                            userTypeColumns.Order = order;
                            UserTypeColumnsList.Add(userTypeColumns);
                        }

                        //Table
                        if (reader.NextResult())
                        {
                            List<TableColumnsClass> TableColumnsList = new List<TableColumnsClass>();
                            TableColumnsClass tableColumns = new TableColumnsClass();

                            order = 0;
                            while (reader.Read())
                            {
                                order += 1;
                                var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                                tableColumns = new TableColumnsClass().PopulateTableColumns(fieldNames, reader);
                                var userTypeCol = UserTypeColumnsList.Find(X => X.UserId.Equals(tableColumns.UserId));

                                if (userTypeCol != null)
                                    userTypeCol.Tables.Add(tableColumns);


                            }
                            TableColumnsList.Add(tableColumns);
                        }

                        //Mobile Columns
                        if (reader.NextResult())
                        {

                            order = 0;
                            while (reader.Read())
                            {
                                order += 1;
                                var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                                int userId = 0;
                                string tableName = "";
                                ColumnClass columnClass = new ColumnClass();

                                if (fieldNames.Contains("UserId"))
                                    if (!Convert.IsDBNull(reader["UserId"]))
                                        userId = (int)reader["UserId"];

                                if (fieldNames.Contains("TableName"))
                                    if (!Convert.IsDBNull(reader["TableName"]))
                                        tableName = reader["TableName"].ToString();

                                if (fieldNames.Contains("ColumnName"))
                                    if (!Convert.IsDBNull(reader["ColumnName"]))
                                        columnClass.Name = reader["ColumnName"].ToString();

                                if (fieldNames.Contains("ColumnOrder"))
                                    if (!Convert.IsDBNull(reader["ColumnOrder"]))
                                        columnClass.Order = Convert.ToInt32(reader["ColumnOrder"]);

                                if (fieldNames.Contains("ColumnWidth"))
                                    if (!Convert.IsDBNull(reader["ColumnWidth"]))
                                        columnClass.Width = Convert.ToInt32(reader["ColumnWidth"]);

                                var userTypeCol = UserTypeColumnsList.Find(X => X.UserId.Equals(userId));
                                if (userTypeCol != null)
                                {
                                    var Tbl = userTypeCol.Tables.Find(T => T.TableName.Equals(tableName));
                                    if (Tbl != null)
                                        Tbl.MobileColumns.Add(columnClass);
                                }
                            }
                        }


                        //Standard Columns
                        if (reader.NextResult())
                        {
                            order = 0;
                            while (reader.Read())
                            {
                                order += 1;
                                var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                                int userId = 0;
                                string tableName = "";
                                ColumnClass columnClass = new ColumnClass();

                                if (fieldNames.Contains("UserId"))
                                    if (!Convert.IsDBNull(reader["UserId"]))
                                        userId = (int)reader["UserId"];

                                if (fieldNames.Contains("TableName"))
                                    if (!Convert.IsDBNull(reader["TableName"]))
                                        tableName = reader["TableName"].ToString();

                                if (fieldNames.Contains("ColumnName"))
                                    if (!Convert.IsDBNull(reader["ColumnName"]))
                                        columnClass.Name = reader["ColumnName"].ToString();

                                if (fieldNames.Contains("ColumnOrder"))
                                    if (!Convert.IsDBNull(reader["ColumnOrder"]))
                                        columnClass.Order = Convert.ToInt32(reader["ColumnOrder"]);

                                if (fieldNames.Contains("ColumnWidth"))
                                    if (!Convert.IsDBNull(reader["ColumnWidth"]))
                                        columnClass.Width = Convert.ToInt32(reader["ColumnWidth"]);

                                var userTypeCol = UserTypeColumnsList.Find(X => X.UserId.Equals(userId));
                                if (userTypeCol != null)
                                {
                                    var Tbl = userTypeCol.Tables.Find(T => T.TableName.Equals(tableName));
                                    if (Tbl != null)
                                        Tbl.StandardColumns.Add(columnClass);
                                }
                            }
                        }

                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = UserTypeColumnsList;
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
                    Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "GetUserColumns", e.Source, "");
                }
                result.Result = null;
                return result;
            }
        }

        public static List<ColumnClass> GetAllUserColumns(string ReportName)
        {
            List<ColumnClass> result = new List<ColumnClass>();

            /*List<string> TotalUserBalanceList = new List<string> {"Order",
            "PointsBefore","PointsAfter","CurrentPointsBalance","OrdersPoints","TotalSent","TotalReceived",
            "TotalReceivedFromUsers","TotalSentToUsers","TotalReceivedToDate","TotalSentToDate",
            "OrderPointBalanceToDate","TargetUsers.FullName","TargetUsers.Id","TargetUsers.Address1",
            "TargetUsers.Address2","TargetUsers.Birthdate",
            "TargetUsers.CityArabicName","TargetUsers.CommercialName","TargetUsers.CompanyArabicName",
            "TargetUsers.CreateDate","TargetUsers.Disabled","TargetUsers.EducationLevelArabicName",
            "TargetUsers.Email","TargetUsers.Gender","TargetUsers.GovernorateArabicName",
            "TargetUsers.HasVocationalCertificate","TargetUsers.IsActive","TargetUsers.JobArabicName",
            "TargetUsers.LocationArabicName","TargetUsers.MobileNumber","TargetUsers.NickName",
            "TargetUsers.Notes","TargetUsers.OrdersPoints","TargetUsers.PointsBalance",
            "TargetUsers.PositionArabicName","TargetUsers.StaffCount","TargetUsers.TotalReceived",
            "TargetUsers.TotalReceived_Waiting","TargetUsers.TotalSent","TargetUsers.TotalSent_Waiting",
            "TargetUsers.UserTypeName","TargetUsers.Username","TargetUsers.WorkDomainArabicName",
            "TargetUsers.YearsOfExperience" };*/

            List<string> TotalUserBalanceList = new List<string> {"Order",
         "PointsBefore","PointsAfter","CurrentPointsBalance","OrdersPoints","TotalSent","TotalReceived",
         "TotalReceivedFromUsers","TotalSentToUsers","TotalReceivedToDate","TotalSentToDate",
         "OrderPointBalanceToDate"};
            TotalUserBalanceList.AddRange(GetUserColumns("TargetUsers"));

            /*List <string> PointReportList = new List<string> {"Order",
            "TransactionId","Operation","Balance","Amount","Date","Users.FullName","Users.Id","Users.Address1",
            "Users.Address2","Users.Birthdate","Users.CityArabicName","Users.CommercialName",
            "Users.CompanyArabicName","Users.CreateDate","Users.Disabled","Users.EducationLevelArabicName",
            "Users.Email","Users.Gender","Users.GovernorateArabicName","Users.HasVocationalCertificate",
            "Users.IsActive","Users.JobArabicName","Users.LocationArabicName","Users.MobileNumber",
            "Users.NickName","Users.Notes","Users.OrdersPoints","Users.PointsBalance","Users.PositionArabicName",
            "Users.StaffCount","Users.TotalReceived","Users.TotalReceived_Waiting","Users.TotalSent",
            "Users.TotalSent_Waiting","Users.UserTypeName","Users.Username","Users.WorkDomainArabicName",
            "Users.YearsOfExperience","OperationUsers.FullName","OperationUsers.Id","OperationUsers.Address1",
            "OperationUsers.Address2","OperationUsers.Birthdate",
            "OperationUsers.CityArabicName","OperationUsers.CommercialName","OperationUsers.CompanyArabicName",
            "OperationUsers.CreateDate","OperationUsers.Disabled","OperationUsers.EducationLevelArabicName",
            "OperationUsers.Email","OperationUsers.Gender","OperationUsers.GovernorateArabicName",
            "OperationUsers.HasVocationalCertificate","OperationUsers.IsActive","OperationUsers.JobArabicName",
            "OperationUsers.LocationArabicName","OperationUsers.MobileNumber","OperationUsers.NickName",
            "OperationUsers.Notes","OperationUsers.OrdersPoints","OperationUsers.PointsBalance",
            "OperationUsers.PositionArabicName","OperationUsers.StaffCount","OperationUsers.TotalReceived",
            "OperationUsers.TotalReceived_Waiting","OperationUsers.TotalSent","OperationUsers.TotalSent_Waiting",
            "OperationUsers.UserTypeName","OperationUsers.Username","OperationUsers.WorkDomainArabicName",
            "OperationUsers.YearsOfExperience"};*/


            List<string> PointReportList = new List<string> {"Order",
         "TransactionId","Operation","Balance","Amount","Date"};
            PointReportList.AddRange(GetUserColumns("Users"));
            PointReportList.AddRange(GetUserColumns("OperationUsers"));

            /*List<string> TotalPointsReportList = new List<string> {"Order",
         "Amount","Operation","Users.FullName","Users.Id","Users.Address1","Users.Address2","Users.Birthdate",
         "Users.CityArabicName","Users.CommercialName","Users.CompanyArabicName",
         "Users.CreateDate","Users.Disabled","Users.EducationLevelArabicName","Users.Email","Users.Gender",
         "Users.GovernorateArabicName","Users.HasVocationalCertificate","Users.IsActive","Users.JobArabicName",
         "Users.LocationArabicName","Users.MobileNumber","Users.NickName","Users.Notes","Users.OrdersPoints",
         "Users.PointsBalance","Users.PositionArabicName","Users.StaffCount","Users.TotalReceived",
         "Users.TotalReceived_Waiting","Users.TotalSent","Users.TotalSent_Waiting","Users.UserTypeName",
         "Users.Username","Users.WorkDomainArabicName","Users.YearsOfExperience","OperationUsers.Id",
         "OperationUsers.FullName","OperationUsers.Address1","OperationUsers.Address2","OperationUsers.Birthdate",
         "OperationUsers.CityArabicName","OperationUsers.CommercialName",
         "OperationUsers.CompanyArabicName","OperationUsers.CreateDate","OperationUsers.Disabled",
         "OperationUsers.EducationLevelArabicName","OperationUsers.Email","OperationUsers.Gender",
         "OperationUsers.GovernorateArabicName","OperationUsers.HasVocationalCertificate",
         "OperationUsers.IsActive","OperationUsers.JobArabicName","OperationUsers.LocationArabicName",
         "OperationUsers.MobileNumber","OperationUsers.NickName","OperationUsers.Notes",
         "OperationUsers.OrdersPoints","OperationUsers.PointsBalance","OperationUsers.PositionArabicName",
         "OperationUsers.StaffCount","OperationUsers.TotalReceived","OperationUsers.TotalReceived_Waiting",
         "OperationUsers.TotalSent","OperationUsers.TotalSent_Waiting","OperationUsers.UserTypeName",
         "OperationUsers.Username","OperationUsers.WorkDomainArabicName","OperationUsers.YearsOfExperience"};*/

            List<string> TotalPointsReportList = new List<string> {"Order",
         "Amount","Operation"};
            TotalPointsReportList.AddRange(GetUserColumns("Users"));
            TotalPointsReportList.AddRange(GetUserColumns("OperationUsers"));


            /*List<string> UserReportList = new List<string> {"Order",
         "FullName","Id","Address1","Address2","Birthdate","CityArabicName",
         "CommercialName","CompanyArabicName","CreateDate","Disabled","EducationLevelArabicName","Email",
         "Gender","GovernorateArabicName","HasVocationalCertificate","IsActive","JobArabicName","LocationArabicName",
         "MobileNumber","NickName","Notes","OrdersPoints","PointsBalance","PositionArabicName","StaffCount",
         "TotalReceived","TotalReceived_Waiting","TotalSent","TotalSent_Waiting","UserTypeName",
         "Username","WorkDomainArabicName","YearsOfExperience","LunchCount"};*/

            List<string> UserReportList = new List<string> { "Order"/*, "LunchCount"*/ };
            UserReportList.AddRange(GetUserColumns(""));


            List<string> UserSessionsReportList = new List<string> {"Order",
         "Date","UserCount","TotalCount","PrecentageCount"};

            List<string> MultipleTransferFromExcelReportList = new List<string> {"Order",
         "Receiver_UserId","Receiver_UserFullName","Sender_UserId","Sender_UserFullName",
         "Amount","Note","TransferResultStatus", "TransferErrorCode"};




            List<string> SelectedList = new List<string>();
            switch (ReportName)
            {
                case "UserReport.bs.table.columns":
                    SelectedList = UserReportList;
                    break;
                case "TotalPointsReport.bs.table.columns":
                    SelectedList = TotalPointsReportList;
                    break;
                case "PointReport.bs.table.columns":
                    SelectedList = PointReportList;
                    break;
                case "TotalUserBalance.bs.table.columns":
                    SelectedList = TotalUserBalanceList;
                    break;
                case "UserSessionsReport.bs.table.columns":
                    SelectedList = UserSessionsReportList;
                    break;
                case "MultipleTransferFromExcelReport.bs.table.columns":
                    SelectedList = MultipleTransferFromExcelReportList;
                    break;
                default:
                    break;
            }

            foreach (var item in SelectedList)
                result.Add(new ColumnClass { Name = item });


            return result;
        }

        public static ResultClass<List<ResourceClass>> GetTranslatedResource(List<string> columnsNameList)
        {
            ResultClass<List<ResourceClass>> result = new ResultClass<List<ResourceClass>>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetTranslatedResource";

                    if (columnsNameList.Count > 0)
                    {
                        //columnsNameList
                        DataTable columnNameTable;
                        using (columnNameTable = new DataTable())
                        {
                            columnNameTable.Columns.Add("Id", typeof(string));
                            foreach (var x in columnsNameList)
                                columnNameTable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@columnsNameList", SqlDbType.Structured);
                        pList.Value = columnNameTable;
                        cmd.Parameters.Add(pList);
                    }

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<ResourceClass> resourceList = new List<ResourceClass>();
                        ResourceClass resource;

                        while (reader.Read())
                        {
                            var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                            resource = new ResourceClass().PopulateResource(fieldNames, reader);

                            resourceList.Add(resource);
                        }
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = resourceList;
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
                    Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "GetTranslatedResource", e.Source, "");
                }
                result.Result = null;
                return result;
            }
        }

        public static ResultClass<List<UserClass>> GetUsers(List<int> UserIds)
        {
            ResultClass<List<UserClass>> result = new ResultClass<List<UserClass>>();
            try
            {
                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetUsersFullName";
                    cmd.CommandTimeout = 1500000;
                    if (UserIds.Count > 0)
                    {
                        //UserIds
                        DataTable userTable;
                        using (userTable = new DataTable())
                        {
                            userTable.Columns.Add("Id", typeof(string));
                            foreach (int x in UserIds)
                                userTable.Rows.Add(x);
                        }
                        var pList = new SqlParameter("@UserIds", SqlDbType.Structured);
                        pList.Value = userTable;
                        cmd.Parameters.Add(pList);
                    }

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
                        List<UserClass> Users = new List<UserClass>();
                        UserClass user;

                        while (reader.Read())
                        {
                            user = new UserClass().PopulateUser(fieldNames, reader);

                            Users.Add(user);
                        }

                        result.Message = "";
                        result.Code = Errors.Success;
                        result.Result = Users;
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
                    Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "GetUsersFullName", e.Source, "");
                }
                result.Result = null;
                return result;
            }
        }


        public static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        public static List<string> GetClassBooleanProp<T>(T Object)
        {
            var propertyList = Object.GetType().GetProperties().Where(p => p.PropertyType == typeof(bool));
            return propertyList.Select(p => p.Name).ToList();
        }

        public static string GetExcelCellByValue(ExcelWorksheet WorkSheet, string cellValue)
        {
            try
            {
                var cellAddress = (from cell in WorkSheet.Cells[WorkSheet.Dimension.Address]//"A1:" + WorkSheet.Dimension.End.Column + "1"]
                                   where cell.Value?.ToString() == cellValue
                                   select cell).First().Address;

                return new String(cellAddress.Where(Char.IsLetter).ToArray());
            }
            catch (Exception e)
            {
                string ee = e.Message;
                return "";
            }
        }

        public static void PopulateExcelReportHeaders(int LoggedUser, ExcelWorksheet worksheet, int offset, List<ColumnClass> columnNameList, bool ForAllColumns = true)
        {
            #region EnglishHeaderTemp
            //remove "Order" from columnNameList
            //var item = columnNameList.First(kvp => kvp.Name == "Order");
            columnNameList.RemoveAll(p => p.Name.Equals("Order"));

            headerRow[0] = columnNameList.Select(x => x.Name).ToArray();

            if (headerRow[0].Length > 0)
            {
                var lastAlpha = ServiceMethod.GetExcelColumnName(headerRow[0].Length);
                var englishheaderRange = "A" + (offset) + ":" + lastAlpha + (offset);
                worksheet.Cells[englishheaderRange].LoadFromArrays(headerRow);

                //new added To Add Header Type
                //if (ForAllColumns == false)
                {
                    //int count = 0;
                    int startUser = 0;
                    int startSecUser = 0;

                    //Re-order list based on sup lists
                    List<ColumnClass> reportList = new List<ColumnClass>();
                    List<ColumnClass> FirstUserList = new List<ColumnClass>();
                    List<ColumnClass> SecUserList = new List<ColumnClass>();

                    FirstUserList = columnNameList.FindAll(x => x.Name.StartsWith("Users.") || x.Name.StartsWith("TargetUsers."));
                    SecUserList = columnNameList.FindAll(x => x.Name.StartsWith("OperationUsers."));
                    reportList = columnNameList.FindAll(x => !x.Name.StartsWith("Users.") && !x.Name.StartsWith("OperationUsers.") && !x.Name.StartsWith("TargetUsers."));

                    startUser = reportList.Count + 1;

                    if (reportList.Count > 0) //TODO: Check on error maybe we should replace it with  //  if (startUser.Count > 0)
                        startSecUser = reportList.Count + FirstUserList.Count + 1;


                    //foreach (var item in headerRow[0])
                    //{
                    //   count++;

                    //   if (item.StartsWith("Users.") && startUser == 0)
                    //      startUser = count;

                    //   else if (item.StartsWith("OperationUsers.") && startSecUser == 0)
                    //      startSecUser = count;
                    //}

                    if (reportList.Count > 0)
                    {
                        var lastAlphaReport = ServiceMethod.GetExcelColumnName(startUser - 1);
                        var englishheaderRange1 = "A" + (offset - 1) + ":" + lastAlphaReport + (offset - 1);
                        worksheet.Cells[englishheaderRange1].Value = "معلومات التقرير";
                        worksheet.Cells[englishheaderRange1].Merge = true;
                    }

                    if (FirstUserList.Count > 0)
                    {

                        var firstAlphaUser = ServiceMethod.GetExcelColumnName(startUser);
                        var lastAlphaUser = ServiceMethod.GetExcelColumnName(startSecUser - 1);
                        var englishheaderRange2 = firstAlphaUser + (offset - 1) + ":" + lastAlphaUser + (offset - 1);
                        worksheet.Cells[englishheaderRange2].Value = "معلومات المستخدم";
                        worksheet.Cells[englishheaderRange2].Merge = true;
                    }

                    if (SecUserList.Count > 0)
                    {
                        var lastAlphaSecUser = ServiceMethod.GetExcelColumnName(startSecUser);
                        var englishheaderRange3 = lastAlphaSecUser + (offset - 1) + ":" + lastAlpha + (offset - 1);
                        worksheet.Cells[englishheaderRange3].Value = "معلومات المستخدم الثاني";
                        worksheet.Cells[englishheaderRange3].Merge = true;
                    }


                    //Style for Header
                    string headerRange1 = "A" + (offset - 1) + ":" + lastAlpha + (offset - 1);
                    ExcelRange Rng1 = worksheet.Cells[headerRange1];
                    Rng1.Style.Font.Bold = true;
                    Rng1.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng1.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
                    Rng1.Style.Font.Color.SetColor(Color.Black);
                    Rng1.Style.ShrinkToFit = true;

                    Rng1.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng1.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng1.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng1.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                }




                #endregion

                //Get Column Name in Arabic
                var resourceResult = ServiceMethod.GetTranslatedResource(columnNameList.Select(x => x.Name).ToList()).Result;
                if (resourceResult != null)
                {
                    //Sort based on User Column Order
                    //var orderedList = resourceResult.OrderBy(b => cleanColumnList.FindIndex(a => a == b.Keyword));

                    var orderedList = from i in columnNameList
                                      join o in resourceResult
                                      on i.Name.ToLower() equals o.Keyword.ToLower()
                                      select o;

                    var ColumnList = orderedList.Select(x => x.ArabicName);

                    // return the result back to "headerRow"
                    headerRow[0] = ColumnList.ToArray();

                    // Determine the header range (e.g. A1:D1)
                    lastAlpha = ServiceMethod.GetExcelColumnName(headerRow[0].Length);
                    string headerRange = "A" + offset + ":" + lastAlpha + offset;

                    // Popular header row data 
                    worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                    ExcelRange Rng = worksheet.Cells[headerRange];
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
                    Rng.Style.Font.Color.SetColor(Color.Black);
                    Rng.Style.ShrinkToFit = true;

                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

                }
            }
        }


        public static Dictionary<string, object> PopulateExcelReportData<T>(string[] fieldNames, SqlDataReader reader, ExcelWorksheet worksheet, List<ColumnClass> columnList, T dataObjectType, string[] requiredColumns = null)
        {
            //Fix ColumnList Naming  --> replace "." with "_" 
            var newColumnList = columnList.Select(s => s.Name.Replace(".", "_")).ToList();

            //Add RequiredColumns
            if (requiredColumns != null)
            {
                if (requiredColumns.Length > 0)
                { //"Users_FullName"
                    foreach (var item in requiredColumns)
                    {
                        if (!newColumnList.Contains(item)) //add only if its not already in list
                            newColumnList.Add(item);
                    }
                }
            }

            var data = new Dictionary<string, object>();
            var Object_boolPropList = ServiceMethod.GetClassBooleanProp(dataObjectType);

            //Populate Data
            foreach (var column in newColumnList)
            {
                if (fieldNames.Contains(column))
                {
                    if (!Convert.IsDBNull(reader[column]))
                    {
                        //add check for gender and true false value and replace them 
                        var indexofUnderscore = (column.LastIndexOf('_') + 1);

                        if (column.Substring(column.LastIndexOf('_') + 1) == "Gender" || column == "Gender")
                        {
                            string gender = String.Empty;
                            if (Convert.ToInt32(reader[column]) == 1)
                                gender = "ذكر";
                            else if (Convert.ToInt32(reader[column]) == 2)
                                gender = "انثى";

                            data.Add(column, gender);
                        }
                        else if (Object_boolPropList.Contains(column.Substring(column.LastIndexOf('_') + 1)))
                        {
                            string boolText = String.Empty;

                            if (Convert.ToInt32(reader[column]) == 0)
                                boolText = "لا";
                            else if (Convert.ToInt32(reader[column]) == 1)
                                boolText = "نعم";

                            data.Add(column, boolText);
                        }
                        else if (column == "TransferResultStatus")
                        {
                            string result = String.Empty;
                            if (Convert.ToInt32(reader[column]) == 1)
                                result = "تم التحويل";
                            else if ((Convert.ToInt32(reader[column]) == 0) || (Convert.ToInt32(reader[column]) == -1))
                                result = "لم يتم التحويل";

                            data.Add(column, result);

                            //Add TransferResultStatus when -1
                            if (Convert.ToInt32(reader["TransferResultStatus"]) == -1)
                                data.Add("TransferErrorCode", "المستخدم غير موجود");
                        }
                        else if (column == "TransferErrorCode")
                        {
                            string result = String.Empty;
                            if (Convert.ToInt32(reader["TransferResultStatus"]) == -1)
                            {
                                result = "المستخدم غير موجود";

                                data.Add(column, result);
                            }
                            else if (Convert.ToInt32(reader["TransferErrorCode"]) > 0)
                            {
                                result = Errors.GetErrorMessage(Convert.ToInt32(reader["TransferErrorCode"]));

                                data.Add(column, result);
                            }

                        }
                        else if (((object[,])(worksheet.Cells["A1:I1"].Value))[0, 0].ToString() == "تقرير دخول الزوار و المستخدمين" && column == "Date") //other column
                        {
                            data.Add(column, Convert.ToDateTime(reader[column]).ToString("d"));
                        }
                        else //other column
                        {
                            data.Add(column, reader[column].ToString());
                        }

                    }
                    else //Column Value == Null
                    {
                        if (!data.ContainsKey(column)) // Add column if it's not exist before
                            data.Add(column, "");
                    }
                }
            }

            return data;
        }

        public static Bitmap Crop(Image myImage)
        {
            Bitmap croppedBitmap = new Bitmap(myImage);
            croppedBitmap = croppedBitmap.Clone(
               new Rectangle(100, 100, myImage.Width, myImage.Height - 200),
               System.Drawing.Imaging.PixelFormat.DontCare);
            return croppedBitmap;
        }

        public static string RemoveSpecialChars(this string input)
        {
            return Regex.Replace(input, @"[^0-9a-zA-Z\._]", string.Empty);
        }

        public static string Between(this string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }

        /// <summary>
        /// Get string value before [first] a.
        /// </summary>
        public static string Before(this string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }

        /// <summary>
        /// Get string value after [last] a.
        /// </summary>
        public static string After(this string value, string a)
        {
            int posA = value.LastIndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }


        public static void CheckLicense()
        {
            if (Config.NextLicenseCheck.HasValue)
            {
                if (Config.NextLicenseCheck.Value > DateTime.Now)
                    return;
            }

            //if we don't hit the return line we will check here !!
            int resultCode = Errors.Success;//ServiceMethod.CheckLicenseValidity();

            if (resultCode != Errors.Success)
            {
                Errors.LogError(0, resultCode.ToString(), "Error in License", "1.0.3", "API", "CheckLicense", "", "");
                Config.IsSystemUp = false;
            }
            else
            {
                Config.IsSystemUp = true;
                Config.NextLicenseCheck = ServiceMethod.GetRandomDateInRange(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));
            }

        }

        public static int CheckItemLicenseLimit()
        {
            try
            {
                //Read License File
                string licenseContent = ServiceMethod.GetLicenseContent();

                //Get Active Items
                var itemCountResult = ServiceMethod.GetActiveItemsCount();
                if ((itemCountResult.Code != Errors.Success) || (itemCountResult?.Result < 0))
                    throw new Exception(Errors.InvalidItemsCount.ToString());

                //Check If valid License with Server
                string url = "https://yallaasouq.com:9999/api/CheckItemLimit";
                //string url = "http://localhost:9595/api/CheckItemLimit";

                // Encrypte the password
                var currentActiveItemEncrypted = StringCipher.Encrypt(itemCountResult.Result.ToString(), Config.LicenseSaltsToken);

                string jsonData = new JavaScriptSerializer().Serialize(new
                {
                    LicenseFileContent = licenseContent,
                    currentActiveItem = currentActiveItemEncrypted
                });

                string encryptedResult = ServiceMethod.CreateWebRequest(url, jsonData, "CheckItemLimit").Result;

                //Decrypt Result
                string result = StringCipher.Decrypt(encryptedResult, Config.LicenseSaltsToken);

                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                int code;
                if (!Int32.TryParse(e.Message, out code))
                {
                    code = Errors.UnknownError;
                }

                return code;
            }
        }

        public static int CheckUserLicenseLimit()
        {
            try
            {
                //Read License File
                string licenseContent = ServiceMethod.GetLicenseContent();

                //Get Active Users
                var userCountResult = ServiceMethod.GetActiveUsersCount();
                if ((userCountResult.Code != 0) || (userCountResult?.Result < 0))
                    throw new Exception(Errors.InvalidUsersCount.ToString());

                //Check If valid License with Server
                string url = "https://yallaasouq.com:9999/api/CheckUserLimit";
                //string url = "http://localhost:9595/api/CheckUserLimit";

                // Encrypte the password
                var currentActiveUserEncrypted = StringCipher.Encrypt(userCountResult.Result.ToString(), Config.LicenseSaltsToken);

                string jsonData = new JavaScriptSerializer().Serialize(new
                {
                    LicenseFileContent = licenseContent,
                    currentActiveUser = currentActiveUserEncrypted
                });

                string encryptedResult = ServiceMethod.CreateWebRequest(url, jsonData, "CheckUserLimit").Result;

                //Decrypt Result
                string result = StringCipher.Decrypt(encryptedResult, Config.LicenseSaltsToken);

                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                int code;
                if (!Int32.TryParse(e.Message, out code))
                {
                    code = Errors.UnknownError;
                }

                return code;
            }
        }



        /************************************* Internal Use *************************************/

        private static int CheckLicenseValidity()
        {
            try
            {
                //Read License File
                string licenseContent = ServiceMethod.GetLicenseContent();

                //Check If valid License with Server
                string url = "https://yallaasouq.com:9999/api/CheckValidLicense";
                //string url = "http://localhost:9595/api/CheckValidLicense";


                string jsonData = new JavaScriptSerializer().Serialize(new
                {
                    LicenseFileContent = licenseContent
                });

                string encryptedResult = ServiceMethod.CreateWebRequest(url, jsonData, "CheckValidLicense").Result;
                //Errors.LogError(7, encryptedResult, "", "9999", "API", "CheckLicenseValidity", url, "");

                //Decrypt Result
                string result = StringCipher.Decrypt(encryptedResult, Config.LicenseSaltsToken);

                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                Errors.LogError(7, e.Message, e.StackTrace, "9999", "API", "CheckLicenseValidity", e.Source, "");
                Errors.LogError(7, e.InnerException.Message, e.StackTrace, "910", "API", "CheckLicenseValidity", e.Source, "");
                int code;
                if (!Int32.TryParse(e.Message, out code))
                {
                    code = Errors.UnknownError;
                }

                return code;
            }
        }

        private static string GetLicenseContent()
        {
            string serverPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            string licensePath = serverPath + "Resources\\License.lic";

            //Check if the XML license file exists
            if (!File.Exists(licensePath))
                throw new Exception(Errors.InvalidLicenseFile.ToString());

            string licenseContent = File.ReadAllText(licensePath);

            return licenseContent;
        }

        private static DateTime GetRandomDateInRange(DateTime rangeStart, DateTime rangeEnd)
        {
            Random generator = new Random();
            TimeSpan span = rangeEnd - rangeStart;

            int randomMinutes = generator.Next(0, (int)span.TotalMinutes);
            return rangeStart + TimeSpan.FromMinutes(randomMinutes);
        }

        private static ResultClass<int> GetActiveItemsCount()
        {
            ResultClass<int> result = new ResultClass<int>();
            int ItemsCount = -1;
            try
            {
                bool SystemWasDown = false;
                if (!Config.IsSystemUp)
                { ActivateSystem(); SystemWasDown = true; }

                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    if (SystemWasDown)
                        DeactivateSystem();


                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetActiveItemsCount";

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        ConfigClass config = new ConfigClass().PopulateConfig(fieldNames, reader);

                        if (fieldNames.Contains("ItemsCount"))
                            if (!Convert.IsDBNull(reader["ItemsCount"]))
                                ItemsCount = Convert.ToInt32(reader["ItemsCount"]);

                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = ItemsCount;
                        return result;
                    }
                    else
                    {
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = -1;
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
                    Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "GetActiveItemsCount", e.Source, "");
                }
                result.Result = -1;
                return result;
            }
        }

        private static ResultClass<int> GetActiveUsersCount()
        {
            ResultClass<int> result = new ResultClass<int>();
            int usersCount = -1;
            try
            {
                bool SystemWasDown = false;
                if (!Config.IsSystemUp)
                { ActivateSystem(); SystemWasDown = true; }

                using (SqlConnection conn = ConnectionClass.GetDataConnection())
                {
                    if (SystemWasDown)
                        DeactivateSystem();


                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Admin_GetActiveUsersCount";

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        var fieldNames = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                        ConfigClass config = new ConfigClass().PopulateConfig(fieldNames, reader);

                        if (fieldNames.Contains("UsersCount"))
                            if (!Convert.IsDBNull(reader["UsersCount"]))
                                usersCount = Convert.ToInt32(reader["UsersCount"]);

                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = usersCount;
                        return result;
                    }
                    else
                    {
                        result.Code = Errors.Success;
                        result.Message = "";
                        result.Result = -1;
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
                    Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "GetActiveUsersCount", e.Source, "");
                }
                result.Result = -1;
                return result;
            }
        }

        private static async Task<string> CreateWebRequest(string url, string jsonData, string responseKey)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(200);
                var response = await client.PostAsync(url, new StringContent(jsonData, Encoding.UTF8, "application/json"));
                var responseString = await response.Content.ReadAsStringAsync();
                //string data = JObject.Parse(responseString).ToString();
                string data = responseString.Replace("\"", ""); // to skip "" around json response

                return data;
            }
            catch (Exception e)
            {
                Errors.LogError(7, e.Message, e.StackTrace, "1.0.3", "API", "CreateWebRequest", e.Source, "");

                throw new Exception(Errors.InvalidInternetConnection.ToString());
            }
        }

        /************************************* End Internal Use *************************************/

        private static FirebaseClient GetFirebaseClient()
        {
            return new FirebaseClient(Config.FirebaseClient);// "https://machlah.firebaseio.com/");
        }

        public static void UpdateFirebaseDeliveryUser(UserClass DeliveryUser)
        {
            try
            {
                var firebase = GetFirebaseClient();

                var newUser = new FirebaseDeliveryUser
                {
                    Id = DeliveryUser.Id,
                    FullName = DeliveryUser.FullName,
                    EmployeeCode = DeliveryUser.FullName,
                    Username = DeliveryUser.Username,
                    MobileNumber = DeliveryUser.MobileNumber,
                    Address = DeliveryUser.Address1,
                    Nationality = DeliveryUser.Address1,
                    ResidenceType = DeliveryUser.Address1,
                    ImageURL = DeliveryUser.FullName,
                };

                var dino = firebase.Child("CurrentLocation").Child(newUser.Id.ToString()).PutAsync(newUser);

            }
            catch (Exception e)
            {
                Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "UpdateFirebaseDeliveryUser", e.Source, "");
            }
        }

        public static void DeleteFirebaseDeliveryUser(int DeliveryUserId)
        {
            try
            {
                var firebase = GetFirebaseClient();

                var dino = firebase.Child("CurrentLocation").Child(DeliveryUserId.ToString()).DeleteAsync();
            }
            catch (Exception e)
            {
                Errors.LogError(0, e.Message, e.StackTrace, "1.0.3", "API", "DeleteFirebaseDeliveryUser", e.Source, "");
            }
        }
    }



    public static class Extensions
    {
        public static StringContent AsJson(this object o)
         => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
    }

    public enum ReportType
    {
        Excel,
        Pdf
    }

}