using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PointsSystemWebService.Classes.Core;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class TotalPointsReportClass
   {
      public static List<string[]> headerRow = new List<string[]>()
       {
          new string[] { "رقم السطر",
             "التاريخ",
             "العملية",
             "رقم العملية",
             "القيمة",
             "الرصيد",
             "الطرف الثاني",
             "المستخدم المدروس"}
       };

      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int UserId { get; set; }
      [DataMember(Order = 3)]
      public int OperationUserId { get; set; }
      [DataMember(Order = 4)]
      public double Amount { get; set; }
      [DataMember(Order = 5)]
      public string Operation { get; set; }
      [DataMember(Order = 6)]
      public int Order { get; set; }
      [DataMember(Order = 7)]
      public UserClass Users { get; set; }
      [DataMember(Order = 8)]
      public UserClass OperationUsers { get; set; }


      public TotalPointsReportClass PopulateTotalPointsReport(string[] fieldNames, SqlDataReader reader)
      {
         var reportClass = new TotalPointsReportClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               reportClass.Id = (int)reader["Id"];

         if (fieldNames.Contains("UserId"))
            if (!Convert.IsDBNull(reader["UserId"]))
               reportClass.UserId = (int)reader["UserId"];

         if (fieldNames.Contains("OperationUserId"))
            if (!Convert.IsDBNull(reader["OperationUserId"]))
               reportClass.OperationUserId = (int)reader["OperationUserId"];

         if (fieldNames.Contains("Operation"))
            if (!Convert.IsDBNull(reader["Operation"]))
               reportClass.Operation = reader["Operation"].ToString();

         if (fieldNames.Contains("Amount"))
            if (!Convert.IsDBNull(reader["Amount"]))
               reportClass.Amount = Convert.ToDouble(reader["Amount"]);

         reportClass.Users = new UserClass().PopulateUser(fieldNames, reader, "Users_");

         reportClass.OperationUsers = new UserClass().PopulateUser(fieldNames, reader, "OperationUsers_");

         return reportClass;

      }


      public static void PopulateTotalPointsReportForExcelHeaders(int LoggedUser, ExcelWorksheet worksheet, int offset, List<string> columnNameList)
      {
         //Clean Column Name
         var cleanColumnList = new List<string>();
         //foreach (var item in columnNameList)
         //{
         //   int lastDotIndex = item.LastIndexOf(@".", StringComparison.Ordinal);

         //   if (lastDotIndex > 0) cleanColumnList.Add(item.Substring(lastDotIndex + 1));
         //   else cleanColumnList.Add(item);
         //}
         cleanColumnList = columnNameList;
         #region EnglishHeaderTemp

         headerRow[0] = cleanColumnList.ToArray();

         var lastAlpha = ServiceMethod.GetExcelColumnName(headerRow[0].Length);
         var englishheaderRange = "A" + offset + ":" + lastAlpha + offset;
         //worksheet.Cells[englishheaderRange].LoadFromArrays(headerRow);

         #endregion

         //Get Column Name in Arabic
         var resourceResult = ServiceMethod.GetTranslatedResource(cleanColumnList).Result;
         //Sort based on User Column Order
         var orderedList = resourceResult.OrderBy(b => cleanColumnList.FindIndex(a => a.ToLower() == b.Keyword.ToLower()));
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

      public Dictionary<string, string> PopulateTotalPointsReportForExcel(string[] fieldNames, SqlDataReader reader, ExcelWorksheet worksheet, List<string> columnList, int lineInWorksheet)
      {
         //Fix ColumnList Naming  --> replace "." with "_" 
         var newColumnList = columnList.Select(s => s.Replace(".", "_")).ToList();

         if (!newColumnList.Contains("Users_FullName")) //add only if its not already in list
            newColumnList.Add("Users_FullName");


         var data = new Dictionary<string, string>();
         var TotalPointboolPropList = ServiceMethod.GetClassBooleanProp(new UserClass());

         foreach (var column in newColumnList)
         {
            if (fieldNames.Contains(column))
            {
               if (!Convert.IsDBNull(reader[column]))
               {
                  if (TotalPointboolPropList.Contains(column.Substring(column.LastIndexOf('_') + 1)))
                  {
                     string boolText = String.Empty;

                     if (Convert.ToInt32(reader[column]) == 0)
                        boolText = "لا";
                     else if (Convert.ToInt32(reader[column]) == 1)
                        boolText = "نعم";

                     data.Add(column, boolText);
                  }
                  else //other column
                  {
                     data.Add(column, reader[column].ToString());
                  }
               }
               else
               { data.Add(column, ""); }
            }
         }

         return data;
      }

   }
}