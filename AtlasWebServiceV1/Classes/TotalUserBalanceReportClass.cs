using OfficeOpenXml;
using OfficeOpenXml.Style;
using PointsSystemWebService.Classes.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class TotalUserBalanceReportClass
   {
      public static List<string[]> headerRow = new List<string[]>()
      {
         new string[] { "رقم السطر"}
      };

      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int UserId { get; set; }

      [DataMember(Order = 3)]
      public double PointsBefore { get; set; }
      [DataMember(Order = 4)]
      public double PointsAfter { get; set; }
      [DataMember(Order = 5)]
      public double TotalSentToUsers { get; set; }
      [DataMember(Order = 6)]
      public double TotalReceivedFromUsers { get; set; }
      [DataMember(Order = 7)]
      public double TotalSentToDate { get; set; }

      [DataMember(Order = 8)]
      public double TotalReceivedToDate { get; set; }
      [DataMember(Order = 9)]
      public double OrderPointBalanceToDate { get; set; }
      [DataMember(Order = 10)]
      public double TotalSent { get; set; }
      [DataMember(Order = 11)]
      public double TotalReceived { get; set; }
      [DataMember(Order = 12)]
      public double OrdersPoints { get; set; }
      [DataMember(Order = 13)]
      public double CurrentPointsBalance { get; set; }
      [DataMember(Order = 14)]
      public UserClass TargetUsers { get; set; }
      [DataMember(Order = 15)]
      public int Order { get; set; }


      public TotalUserBalanceReportClass PopulateUserReport(string[] fieldNames, SqlDataReader reader)
      {
         var reportClass = new TotalUserBalanceReportClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               reportClass.Id = (int)reader["Id"];

         if (fieldNames.Contains("UserId"))
            if (!Convert.IsDBNull(reader["UserId"]))
               reportClass.UserId = (int)reader["UserId"];

         if (fieldNames.Contains("PointsBefore"))
            if (!Convert.IsDBNull(reader["PointsBefore"]))
               reportClass.PointsBefore = Convert.ToDouble(reader["PointsBefore"]);

         if (fieldNames.Contains("PointsAfter"))
            if (!Convert.IsDBNull(reader["PointsAfter"]))
               reportClass.PointsAfter = Convert.ToDouble(reader["PointsAfter"]);

         if (fieldNames.Contains("TotalSentToUsers"))
            if (!Convert.IsDBNull(reader["TotalSentToUsers"]))
               reportClass.TotalSentToUsers = Convert.ToDouble(reader["TotalSentToUsers"]);

         if (fieldNames.Contains("TotalReceivedFromUsers"))
            if (!Convert.IsDBNull(reader["TotalReceivedFromUsers"]))
               reportClass.TotalReceivedFromUsers = Convert.ToDouble(reader["TotalReceivedFromUsers"]);

         if (fieldNames.Contains("TotalSentToDate"))
            if (!Convert.IsDBNull(reader["TotalSentToDate"]))
               reportClass.TotalSentToDate = Convert.ToDouble(reader["TotalSentToDate"]);

         if (fieldNames.Contains("TotalReceivedToDate"))
            if (!Convert.IsDBNull(reader["TotalReceivedToDate"]))
               reportClass.TotalReceivedToDate = Convert.ToDouble(reader["TotalReceivedToDate"]);

         if (fieldNames.Contains("OrderPointBalanceToDate"))
            if (!Convert.IsDBNull(reader["OrderPointBalanceToDate"]))
               reportClass.OrderPointBalanceToDate = Convert.ToDouble(reader["OrderPointBalanceToDate"]);

         if (fieldNames.Contains("TotalSent"))
            if (!Convert.IsDBNull(reader["TotalSent"]))
               reportClass.TotalSent = Convert.ToDouble(reader["TotalSent"]);

         if (fieldNames.Contains("TotalReceived"))
            if (!Convert.IsDBNull(reader["TotalReceived"]))
               reportClass.TotalReceived = Convert.ToDouble(reader["TotalReceived"]);

         if (fieldNames.Contains("OrdersPoints"))
            if (!Convert.IsDBNull(reader["OrdersPoints"]))
               reportClass.OrdersPoints = Convert.ToDouble(reader["OrdersPoints"]);

         if (fieldNames.Contains("CurrentPointsBalance"))
            if (!Convert.IsDBNull(reader["CurrentPointsBalance"]))
               reportClass.CurrentPointsBalance = Convert.ToDouble(reader["CurrentPointsBalance"]);

         reportClass.TargetUsers = new UserClass().PopulateUser(fieldNames, reader, "TargetUsers_");

         return reportClass;

      }


      public static void PopulateTotalUserReportForExcelHeaders(int LoggedUser, ExcelWorksheet worksheet, int offset, List<string> columnNameList)
      {
         //Clean Column Name
         var cleanColumnList = new List<string>();

         cleanColumnList = columnNameList;
         #region EnglishHeaderTemp

         string c = "";
         foreach (var item in cleanColumnList)
         {
            c += item + "\n";
         }
         headerRow[0] = cleanColumnList.ToArray();

         var lastAlpha = ServiceMethod.GetExcelColumnName(headerRow[0].Length);
         var englishheaderRange = "A" + (offset - 1) + ":" + lastAlpha + (offset - 1);
         worksheet.Cells[englishheaderRange].LoadFromArrays(headerRow);

         #endregion

         //Get Column Name in Arabic
         var resourceResult = ServiceMethod.GetTranslatedResource(cleanColumnList).Result;

         string cx = "";
         string cz = "";
         foreach (var item in resourceResult)
         {
            cx += item.Keyword + "\n";
            cz += item.ArabicName + "\n";
         }

         //Sort based on User Column Order
         //var orderedList = resourceResult.OrderBy(b => cleanColumnList.FindIndex(a => a == b.Keyword));

         var orderedList = from i in cleanColumnList
                           join o in resourceResult
                           on i.ToLower() equals o.Keyword.ToLower()
                           select o;

         var ColumnList = orderedList.Select(x => x.ArabicName);

         // return the result back to "headerRow"
         headerRow[0] = ColumnList.ToArray();

         // Determine the header range (e.g. A1:D1)
         // Popular header row data
         lastAlpha = ServiceMethod.GetExcelColumnName(headerRow[0].Length);
         string headerRange = "A" + offset + ":" + lastAlpha + offset;

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

      public Dictionary<string, string> PopulateTotalUserReportForExcel(string[] fieldNames, SqlDataReader reader, ExcelWorksheet worksheet, List<string> columnList, int lineInWorksheet)
      {
         //Fix ColumnList Naming  --> replace "." with "_" 
         var newColumnList = columnList.Select(s => s.Replace(".", "_")).ToList();

         var data = new Dictionary<string, string>();

         var UserboolPropList = ServiceMethod.GetClassBooleanProp(new UserClass());
         foreach (var column in newColumnList)
         {
            if (fieldNames.Contains(column))
            {
               if (!Convert.IsDBNull(reader[column]))
               {
                  //add check for gender and true false value and replace them 
                  if (column == "Gender")
                  {
                     string gender = String.Empty;
                     if (Convert.ToInt32(reader[column]) == 1)
                        gender = "ذكر";
                     else if (Convert.ToInt32(reader[column]) == 2)
                        gender = "انثى";

                     data.Add(column, gender);
                  }
                  else if (UserboolPropList.Contains(column.Substring(column.LastIndexOf('_') + 1)))
                  {
                     string boolText = String.Empty;

                     if (Convert.ToInt32(reader[column]) == 0)
                        boolText = "لا";
                     else if (Convert.ToInt32(reader[column]) == 1)
                        boolText = "نعم";

                     data.Add(column, boolText);
                  }
                  else //other column
                  { data.Add(column, reader[column].ToString()); }
               }
               else //the column value is null
               { data.Add(column, ""); }
            }
         }

         return data;
      }


   }
}