using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ad.DA;
using Ad.Model;
using Ad.Model.DbModel;
using Ad.Model.VModel;
using Ad.Util;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace Ad.Fw
{
    public class CustomerExcelHelper
    {
        #region
        // 遍历插入(包括空行)行数
        private int insertNo = 0;

        private string[] titleArray = ExcelTempBuild.custTitleArr;
        // 数据开始行号
        private int firstRowNo = 1;

        // 数据结束行号
        private int lastRowNo;

        // 数据开始列号
        private int firstCellNo = 0;

        // 数据结束列号
        private int lastCellNo;

        // Excel完全路径
        private string excelName;

        // 工作簿
        private IWorkbook workbook = null;

        // Sheet
        private ISheet sheet = null;

        // Row
        private IRow row = null;
        
        // Cell
        private ICell cell = null;

        // 导入成功标记字符串
        private string Ok = "导入成功";

        // 一次最多导入数量
        private int maxRowNum = 10000;
        #endregion

        public CustomerExcelHelper(string excelName)
        {
            this.excelName = excelName;
        }

        // 检查Excel
        public string CheckImportCustomerExcel(out int totalNum)
        {
            string errorString = "";
            totalNum = 0;
            // 配置文件 App.config 部门名称设置错误
            if (SysLoadDataHelper.ImportCustDeptList == null)
            {
                return "App.config 部门名称设置错误,无部门可录入";
            }

            if (SysLoadDataHelper.ImportCustomerList == null)
            {
                return "所有人员都不能录入（可能原因：数据库变动）";
            }

            if (SysLoadDataHelper.ImportEnumList == null)
            {
                return "客户来源都不能录入（可能设置错误）";
            }

            #region  检查Excel文件是否存在
            if (string.IsNullOrWhiteSpace(this.excelName))
            {
                errorString = "1.未读取到指定的Excel";
                return errorString;
            }
            if (!System.IO.File.Exists(this.excelName))
            {
                errorString = "2.未读取到指定的Excel";
                return errorString;
            }
            #endregion

            #region 根据扩展名(.xls|.xlsx)初始化Workbook,Sheet
            this.workbook = null;
            this.sheet = null;
            try
            {
                using (System.IO.FileStream fileStream = new System.IO.FileStream(this.excelName, System.IO.FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    if (System.IO.Path.GetExtension(this.excelName) == ".xls")
                    {
                        workbook = new HSSFWorkbook(fileStream);
                        sheet = (HSSFSheet)workbook.GetSheetAt(0);
                    }
                    else if (System.IO.Path.GetExtension(this.excelName) == ".xlsx")
                    {
                        workbook = new XSSFWorkbook(fileStream);
                        sheet = (XSSFSheet)workbook.GetSheetAt(0);
                    }
                    else
                    {
                        fileStream.Close();
                        errorString = "文件类型错误，请选择(.xls|.xlsx)";
                        return errorString;
                    }
                    fileStream.Close();
                }
                if (sheet.SheetName.Contains(this.Ok))
                {
                    errorString = "此文件已经被导入过数据库，不允许导入第二遍";
                    return errorString;
                }
            }
            catch (Exception e)
            {
                errorString = e.Message;
                return errorString;
            }
            #endregion

            #region 检查是否有客户资料
            int firstRowNum = sheet.FirstRowNum;
            int lastRowNum = sheet.LastRowNum;
            if (lastRowNum == firstRowNum)
            {
                errorString = "数据为空(无客户资料)";
                return errorString;
            }
            #endregion

            #region 确定行号，列号

            this.firstRowNo = firstRowNum + 1;
            this.lastRowNo = lastRowNum;
            this.firstCellNo = 0;
            this.lastCellNo = this.firstCellNo + this.titleArray.Length - 1;

            totalNum = this.lastRowNo - this.firstRowNo + 1;
            #endregion

            #region 检查表头
            for (int i = firstCellNo; i <= lastCellNo; i++)
            {
                ICell pCell = sheet.GetRow(firstRowNo-1).GetCell(i);
                if (pCell == null)
                {
                    errorString = "标题第 " + (i - firstCellNo + 1).ToString() + " 列为空，应该为（" + this.titleArray[i-firstCellNo]+")";
                    return errorString;
                }
                if (pCell.StringCellValue.Trim() != this.titleArray[i - firstCellNo])
                {
                    errorString = "标题第 " + (i - firstCellNo + 1).ToString() + " 列不为（" + this.titleArray[i-firstCellNo]+"）";
                    return errorString;
                }
            }
            #endregion

            #region  检查每一行
            try
            {
                int dataRowNum = 0;
                var excelTitleList = ExcelHelper.ExcelTitleList();
                for (int i = this.firstRowNo; i <= this.lastRowNo; i++)
                {
                    string departmentId = null;
                    string areaId = null;
                    row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (dataRowNum++ > this.maxRowNum)
                    {
                        errorString += "数据量过大超过10000条，请拆分多个文件导入" + Environment.NewLine;
                        return errorString;
                    }
                    #region 部门
                    cell = row.GetCell(this.firstCellNo);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        errorString += excelTitleList[this.firstCellNo] + (i + 1).ToString() + " (部门)为空" + Environment.NewLine;
                    }
                    var departmentIEnum = SysLoadDataHelper.ImportCustDeptList.Where(m => m.NAME == cell.ToString().Trim());
                    if (departmentIEnum == null || departmentIEnum.Count() < 1)
                    {
                        errorString += excelTitleList[this.firstCellNo] + (i + 1).ToString() +"("+ cell.ToString()+") 该部门不允许插入" + Environment.NewLine;
                    }
                    else
                    {
                        departmentId = departmentIEnum.First().ID.Value.ToString();
                        cell.SetCellValue(departmentId+","+cell.ToString().Trim());
                    }
                    #endregion

                    #region 录入时间
                    cell = row.GetCell(this.firstCellNo + 1);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        errorString += excelTitleList[this.firstCellNo + 1] + (i + 1).ToString() + " (录入时间)为空" + Environment.NewLine;
                    }
                    else if (cell.CellType != CellType.Numeric)
                    {
                        errorString += excelTitleList[this.firstCellNo + 1] + (i + 1).ToString() + " (录入时间)格式错误" + Environment.NewLine;
                    }
                    else
                    {
                        if (!DateUtil.IsCellDateFormatted(cell))
                        {
                            errorString += excelTitleList[this.firstCellNo + 1] + (i + 1).ToString() + " (录入时间)格式错误" + Environment.NewLine;
                        }
                    }
                    #endregion

                    #region 所在区域
                    cell = row.GetCell(this.firstCellNo + 2);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        errorString += excelTitleList[this.firstCellNo + 2] + (i + 1).ToString() + " (所在区域)为空" + Environment.NewLine;
                    }
                    var areaIEnum = SysLoadDataHelper.ImportEnumList.Where(m => m.SHOWVALUE == cell.ToString().Trim() && m.REF_ENUMID == StaticConst.PositionEnumId);
                    if (areaIEnum == null || areaIEnum.Count() < 1)
                    {
                        errorString += excelTitleList[this.firstCellNo+2] + (i + 1).ToString() + "(" + cell.ToString() + ") 不是允许的区域" + Environment.NewLine;
                    }
                    else
                    {
                        areaId = areaIEnum.First().ID.Value.ToString();
                        cell.SetCellValue(areaId + "," + cell.ToString().Trim());
                    }

                    #endregion

                    #region 地区
                    cell = row.GetCell(this.firstCellNo + 3);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        errorString += excelTitleList[this.firstCellNo + 3] + (i + 1).ToString() + "  (地区)为空" + Environment.NewLine;
                    }
                    if(!string.IsNullOrEmpty(areaId))
                    {
                        var provinceIEnum = SysLoadDataHelper.ImportEnumList.Where(m => m.PARENT_ID.Value.ToString() == areaId
                            && m.SHOWVALUE == cell.ToString().Trim());
                        if (provinceIEnum == null || provinceIEnum.Count() < 1)
                        {
                            errorString += excelTitleList[this.firstCellNo+3] + (i + 1).ToString() + "(" + cell.ToString() + ") 不是允许的地区" + Environment.NewLine;
                        }
                        else
                        {
                            string provinceId = areaIEnum.First().ID.Value.ToString();
                            cell.SetCellValue(provinceId + "," + cell.ToString().Trim());
                        }
                    }
                    #endregion

                    #region 客户姓名
                    cell = row.GetCell(this.firstCellNo + 4);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        errorString += excelTitleList[this.firstCellNo + 4] + (i + 1).ToString() + "  (客户姓名)为空" + Environment.NewLine;
                    }
                    else if (cell.ToString().Trim().Length > 25)
                    {
                        errorString += excelTitleList[this.firstCellNo + 4] + (i + 1).ToString() + "  (客户姓名)的长度超过了25个字符" + Environment.NewLine;
                    }
                    #endregion

                    #region  性别
                    cell = row.GetCell(this.firstCellNo + 5);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        errorString += excelTitleList[this.firstCellNo + 5] + (i + 1).ToString() + "  (性别)为空" + Environment.NewLine;
                    }
                    else if (cell.ToString().Trim() != "男" && cell.ToString().Trim() != "女")
                    {
                        errorString += excelTitleList[this.firstCellNo + 5] + (i + 1).ToString() + "  (性别)内容只允许(男，女)" + Environment.NewLine;
                    }
                    #endregion

                    #region 客户来源
                    cell = row.GetCell(this.firstCellNo + 6);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        errorString += excelTitleList[this.firstCellNo + 6] + (i + 1).ToString() + "  (客户来源)为空" + Environment.NewLine;
                    }
                    var custSourceIEnum = SysLoadDataHelper.ImportEnumList.Where(m => m.SHOWVALUE == cell.ToString().Trim() &&
                        m.REF_ENUMID == StaticConst.CustomerSourceEnumId);
                    if (custSourceIEnum == null || custSourceIEnum.Count() < 1)
                    {
                        errorString += excelTitleList[this.firstCellNo+6] + (i + 1).ToString() + "(" + cell.ToString() + ") 不是允许的客户来源" + Environment.NewLine;
                    }
                    else
                    {
                        string custSourceId = custSourceIEnum.First().ID.Value.ToString();
                        cell.SetCellValue(custSourceId + "," + cell.ToString().Trim());
                    }
                    #endregion

                    #region 联系方式和电话同时验证
                    /*手机*/
                    bool isPhoneNull = false;
                    cell = row.GetCell(this.firstCellNo + 7);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        isPhoneNull = true;
                    }
                    else if (!System.Text.RegularExpressions.Regex.IsMatch(cell.ToString().Trim(), Ad.Util.RegexHelper.reg_Mobile_str2))
                    {
                        errorString += excelTitleList[this.firstCellNo + 7] + (i + 1).ToString() + "  (手机)格式错误" + Environment.NewLine;
                    }
                    /*电话*/
                    cell = row.GetCell(this.firstCellNo + 8);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        if (isPhoneNull)
                        {
                            errorString += excelTitleList[this.firstCellNo + 7] + (i + 1).ToString() + " -- " + excelTitleList[this.firstCellNo + 8] + (i + 1).ToString() + "  (手机,电话)都为空" + Environment.NewLine;
                        }
                    }
                    else if (!System.Text.RegularExpressions.Regex.IsMatch(cell.ToString().Trim(), Ad.Util.RegexHelper.reg_Tel_str2))
                    {
                        errorString += excelTitleList[this.firstCellNo + 8] + (i + 1).ToString() + "  (电话)格式错误" + Environment.NewLine;
                    }
                    #endregion

                    #region Email
                    cell = row.GetCell(this.firstCellNo + 9);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {

                    }
                    else if (!System.Text.RegularExpressions.Regex.IsMatch(cell.ToString().Trim(), Ad.Util.RegexHelper.reg_Email_str))
                    {
                        errorString += excelTitleList[this.firstCellNo + 9] + (i + 1).ToString() + "  (Email)格式错误" + Environment.NewLine;
                    }
                    #endregion

                    #region 职位
                    cell = row.GetCell(this.firstCellNo + 10);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                    }
                    else if (cell.ToString().Trim().Length > 25)
                    {
                        errorString += excelTitleList[this.firstCellNo + 10] + (i + 1).ToString() + "  (职位)长度不能大于25个字符" + Environment.NewLine;
                    }
                    #endregion

                    #region 咨询产品
                    cell = row.GetCell(this.firstCellNo + 11);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        errorString += excelTitleList[this.firstCellNo + 11] + (i + 1).ToString() + "  (咨询产品)为空" + Environment.NewLine;

                    }
                    #endregion

                    #region 咨询内容
                    cell = row.GetCell(this.firstCellNo + 12);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        errorString += excelTitleList[this.firstCellNo + 12] + (i + 1).ToString() + "  (咨询内容)为空" + Environment.NewLine;
                    }
                    else if (cell.ToString().Trim().Length > 100)
                    {
                        errorString += excelTitleList[this.firstCellNo + 12] + (i + 1).ToString() + "  (咨询内容)长度不能超过100个字符" + Environment.NewLine;
                    }
                    #endregion

                    #region 录入人员
                    cell = row.GetCell(this.firstCellNo + 13);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    {
                        errorString += excelTitleList[this.firstCellNo + 13] + (i + 1).ToString() + "  (录入人员)为空" + Environment.NewLine;
                    }
                    if (!string.IsNullOrEmpty(departmentId))
                    {
                        var custIEnum = SysLoadDataHelper.ImportCustomerList.Where(m => m.ORG_DEPARTMENT_ID.Value.ToString() == departmentId 
                            && m.NAME == cell.ToString().Trim());
                        if (custIEnum == null || custIEnum.Count() < 1)
                        {
                            errorString += excelTitleList[this.firstCellNo+13] + (i + 1).ToString() + "(" + cell.ToString() + ") 非法员工姓名" + Environment.NewLine;
                        }
                        else
                        {
                            string custId = custIEnum.First().ID.Value.ToString();
                            cell.SetCellValue(custId + "," + cell.ToString().Trim());
                        }
                    }
                    #endregion


                }
            }
            catch (Exception e)
            {
                errorString += e.Message + Environment.NewLine;
            }
        #endregion
            return errorString;
        }

        // 插入到Excel
        public string InsertToDataBaseOneByOne()
        {
            var map = SingletonHelper<ModelDAL<Y_Call_Cust>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var ts = conn.BeginTransaction())
                {
                    try
                    {
                        int? serialNum = BllGenerateKey.GetKeyNumForBatch(KeyTypeEnum.CustKey_Ins);
                        if (serialNum == null)
                        {
                            conn.Close();
                            return "取得序列号错误";
                        }
                        string dateStr = DateTime.Now.ToString(Const.YYMMDD);
                        Y_Call_Cust entity = new Y_Call_Cust();
                        #region 一行行插入
                        for (int rowNo = this.firstRowNo; rowNo <= this.lastRowNo; rowNo++)
                        {
                            if (sheet.GetRow(rowNo) == null) continue;
                            // 客户编号
                            entity.CustCode = StringHelper.GenerateString(PreValueType.CustPre_Ins, dateStr, serialNum.Value + this.insertNo, 5, '0'); 

                            // 部门
                            string[] deptMes = sheet.GetRow(rowNo).GetCell(this.firstCellNo).ToString().Split(new char[] { ',' });
                            entity.DeptId = Convert.ToInt64(deptMes[0]);
                            entity.DeptName = deptMes[1];
                            // 录入时间
                            entity.EntryDate = sheet.GetRow(rowNo).GetCell(this.firstCellNo+1).DateCellValue;
                            // 所在区域
                            string[] AreaMes = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 2).ToString().Split(new char[] { ',' });
                            entity.AreaId = Convert.ToInt64(AreaMes[0]);
                            entity.Area = AreaMes[1];
                            // 地区
                            string[] provinceMes = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 3).ToString().Split(new char[] { ',' });
                            entity.ProvinceId = Convert.ToInt64(provinceMes[0]);
                            entity.Province = provinceMes[1];

                            // 客户姓名
                            entity.CustName = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 4).ToString().Trim();
                            // 性别(0:男，1：女）
                            entity.Sex = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 5).ToString().Trim() == "男" ? false : true;
                            // 客户来源
                            string[] csourceMes = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 6).ToString().Split(new char[] { ',' });
                            entity.CustSourceId = Convert.ToInt64(csourceMes[0]);
                            entity.CustSource = csourceMes[1];
                            // 手机
                            ICell phoneCell = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 7);
                            if (phoneCell != null)
                            {
                                entity.Phone = phoneCell.ToString().Trim();
                            }
                            else
                            {
                                entity.Phone = null;
                            }
                            // 电话
                            ICell telCell = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 8);
                            if (telCell != null)
                            {
                                entity.Tel = telCell.ToString().Trim();
                            }
                            else
                            {
                                entity.Tel = null;
                            }
                            // Email
                            ICell emailCell = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 9);
                            if (emailCell != null)
                            {
                                entity.Email = emailCell.StringCellValue.Trim();
                            }
                            else
                            {
                                entity.Email = null;
                            }
                            // 职位
                            ICell jobCell = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 10);
                            if (jobCell != null)
                            {
                                entity.Job = jobCell.ToString().Trim();
                            }
                            else
                            {
                                entity.Job = null;
                            }
                            // 咨询产品
                            entity.Product = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 11).ToString().Trim();
                            // 咨询内容
                            entity.Question = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 12).ToString().Trim();
                            // 录入人员
                            string[] stuffMes = sheet.GetRow(rowNo).GetCell(this.firstCellNo + 13).ToString().Split(new char[] { ',' });
                            entity.StuffId = Convert.ToInt64(stuffMes[0]);
                            entity.StuffName = stuffMes[1];

                            if (map.Insert(entity, conn, ts) < 1)
                            {
                                ts.Rollback();
                                return "第"+(rowNo+1).ToString()+"行未插入到数据库，请检查";
                            }
                            this.insertNo++;
                        }
                        #endregion

                        string updateKeyStr = BllGenerateKey.UpdateGenerateTable(KeyTypeEnum.CustKey_Ins, serialNum.Value + this.insertNo, PreValueType.CustPre_Ins);
                        if (null == updateKeyStr)
                        {
                            ts.Commit();
                            //using (FileStream fileStream = File.Open(this.excelName, FileMode.Open, FileAccess.ReadWrite))
                            //{
                            //    // 标记 为成功导入
                            //    workbook.SetSheetName(0, sheet.SheetName + this.Ok);
                            //    // 保存修改
                            //    workbook.Write(fileStream);
                            //    fileStream.Close();
                            //}  
                            return null;
                        }
                        ts.Rollback();
                        return updateKeyStr;
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        return e.Message + Environment.NewLine + e.StackTrace;
                    }
                }
            }
        }

        // 导入到数据库
        public string ImportDataBase()
        {
            int totalRowNum;
            string errorString = CheckImportCustomerExcel(out totalRowNum);
            if (string.IsNullOrWhiteSpace(errorString))
            {
                return InsertToDataBaseOneByOne();
            }
            else
            {
                return errorString;
            }
        }

        // 返回目前已插入的行数
        public int GetInsertedRowNum()
        {
            return this.insertNo;
        }
    }
}
