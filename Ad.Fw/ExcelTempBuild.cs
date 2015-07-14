using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace Ad.Fw
{
    public class ExcelTempBuild
    {
        // 客户资料导入表
        public static readonly string[] custTitleArr = new string[]{ "部门", "录入时间", "所在区域", "地区", "客户姓名", "性别", "客户来源", "手机", "电话", "Email", "职位", "咨询产品", "咨询内容", "录入人员" };
        public static MemoryStream CustTemplateCreat()
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            string sheetName = DateTime.Now.ToString("yyyy-MM-dd");
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(sheetName);
            var row = sheet.CreateRow(0);
            for (int i = 0; i < custTitleArr.Length; i++)
            {
                row.CreateCell(i, CellType.String).SetCellValue(custTitleArr[i]);
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            return ms;
        }
    }
}
