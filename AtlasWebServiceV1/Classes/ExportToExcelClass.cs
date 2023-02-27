using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OfficeOpenXml;
using System.Runtime.Serialization.Json;
using System.IO;

namespace PointsSystemWebService.Classes
{
    public class ExportToExcelClass
    {
        public static Stream Export()
        {
            try
            {
                //DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(type);

                Stream ms = new MemoryStream();

                //jsonSerializer.WriteObject(ms, Result);

                ExcelPackage pck = new ExcelPackage(ms);

                ExcelWorksheet worksheet = pck.Workbook.Worksheets.Add("Test");

                // Create 4 columns of samples data
                for (int col = 1; col < 10; col++)
                {
                    // Add the headers
                    worksheet.Cells[1, col].Value = "Test " + col;

                    for (int row = 2; row < 21; row++)
                    {
                        // Add some items...
                        worksheet.Cells[row, col].Value = row;
                    }

                }
                pck.Save();
                ms.Position = 0L;
                return ms;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}