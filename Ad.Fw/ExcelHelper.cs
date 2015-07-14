using Ad.Model.BModel;
using Ad.Model.VModel;
using Ad.Model.DbModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Ad.Fw
{
    public class ExcelHelper
    {
        public static string ICell_String(IList<ICell> cells, int i)
        {
            if (cells.Count < i)
            {
                return null;
            }
            try
            {
                var cell = cells[i];
                return cell.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static int? ICell_Int(IList<ICell> cells, int i)
        {
            string s = ICell_String(cells, i);
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            int r;
            if (int.TryParse(s, out r))
            {
                return r;
            }
            return null;
        }

        public static decimal? ICell_Decimal(IList<ICell> cells, int i)
        {
            string s = ICell_String(cells, i);
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            decimal r;
            if (decimal.TryParse(s, out r))
            {
                return r;
            }
            return null;
        }

        public static DateTime? ICell_Date(IList<ICell> cells, int i)
        {
            if (cells.Count < i)
            {
                return null;
            }
            try
            {
                var cell = cells[i];
                return DateTime.Parse(cell.ToString());
            }
            catch
            {
                return null;
            }
        }

        public static bool? ICell_Bool(IList<ICell> cells, int i)
        {
            string s = ICell_String(cells, i);
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            return s == "是";
        }

        // 列A,..Z,AA,..ZZ
        public static IList<string> ExcelTitleList()
        {
            IList<string> returnList = new List<string>();
            string[] alphabet = new string[26];
            int ascii_A = (int)'A';
            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = Convert.ToChar(ascii_A + i).ToString();
                returnList.Add(alphabet[i]);
            }

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    returnList.Add(alphabet[i] + alphabet[j]);
                }
            }
            return returnList;

        }


        public static MemoryStream Export_DoctorIncomeStatistics(IList<Income> items)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("医师诊疗创收统计");
            var row = sheet.CreateRow(0);
            row.CreateCell(0, CellType.String).SetCellValue("医师编号");
            row.CreateCell(1, CellType.String).SetCellValue("医师姓名");
            row.CreateCell(2, CellType.String).SetCellValue("金额");

            int i = 1;
            foreach (var item in items)
            {
                row = sheet.CreateRow(i);
                row.CreateCell(0, CellType.String).SetCellValue(item.ItemId.Value.ToString());
                row.CreateCell(1, CellType.String).SetCellValue(item.ItemName);
                row.CreateCell(2, CellType.String).SetCellValue(item.ItemNum.Value.ToString("C2"));
                i++;
            }

            row = sheet.CreateRow(i);
            string s = string.Format(@"总金额：{0}", items.Sum(f=>f.ItemNum.Value).ToString("C2"));
            row.CreateCell(2, CellType.String).SetCellValue(s);

            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }

        public static string ExcelToHtml(string excelFileName)
        {
            //实例化Excel  
            Microsoft.Office.Interop.Excel.Application repExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            //打开文件，n.FullPath是文件路径  
            workbook = repExcel.Application.Workbooks.Open(excelFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            string filesavefilename = excelFileName.ToString();
            string strsavefilename = filesavefilename.Substring(0, filesavefilename.Length - 3) + "html";
            object savefilename = (object)strsavefilename;
            object ofmt = Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml;
            //进行另存为操作    
            workbook.SaveAs(savefilename, ofmt, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            object osave = false;
            //逐步关闭所有使用的对象  
            workbook.Close(osave, Type.Missing, Type.Missing);
            repExcel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            worksheet = null;
            //垃圾回收  
            GC.Collect();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            workbook = null;
            GC.Collect();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(repExcel.Application.Workbooks);
            GC.Collect();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(repExcel);
            repExcel = null;
            GC.Collect();
            //依据时间杀灭进程  
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (System.Diagnostics.Process p in process)
            {
                if (DateTime.Now.Second - p.StartTime.Second > 0 && DateTime.Now.Second - p.StartTime.Second < 5)
                {
                    p.Kill();
                }
            }

            return savefilename.ToString();
        }  
    }
}
