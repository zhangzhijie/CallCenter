using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using Ad.Util;

namespace Ad.Fw
{
    public class FileUpLoad
    {
        public static string GetZipFileFullPath()
        {
            string dir = Path.Combine(Environment.CurrentDirectory, Const.KnowledgeBaseDir);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return Path.Combine(dir, Guid.NewGuid().ToString("N") + ".zip");
        }

        public static string UpLoadFile(string sourceFile, string targetFile)
        {
            return SaveFile(GetBinaryArray(sourceFile), targetFile);
        }

        public static byte[] GetBinaryArray(string fileName)
        {
            if (File.Exists(fileName))
            {
                int bi;
                MemoryStream ms = new MemoryStream();
                try
                {
                    FileStream fs = File.OpenRead(fileName);
                    //FileStream fs = new FileStream(fileName, FileMode.Open);
                    while ((bi = fs.ReadByte()) != -1)
                    {
                        ms.WriteByte((byte)bi);
                    }
                    return ms.ToArray();
                }
                catch (Exception e)
                {
                    return new byte[0];
                }
                finally
                {
                    ms.Close();
                }
               
            }
            else
            {
                return new byte[0];
            }
        }
        public static string SaveFile(byte[] data, string targetFile)
        {
            if (data == null || data.Length == 0)
            {
                return "数据为空";
            }
            FileStream fileStream = null;
            MemoryStream m = new MemoryStream(data);
            try
            {
                string dir = targetFile.Substring(0, targetFile.LastIndexOf('\\'));
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                fileStream = new FileStream(targetFile, FileMode.Create);
                m.WriteTo(fileStream);
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                m.Close();
                fileStream.Close();
            }
        }


        public static bool ZipFile(string fileToZip, string zipedFile, string password)
        {
            bool result = true;
            ZipOutputStream zipStream = null;
            FileStream fs = null;
            ZipEntry ent = null;

            if (!File.Exists(fileToZip))
                return false;

            try
            {
                fs = File.OpenRead(fileToZip);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                fs = File.Create(zipedFile);
                zipStream = new ZipOutputStream(fs);
                if (!string.IsNullOrEmpty(password)) zipStream.Password = password;
                ent = new ZipEntry(Path.GetFileName(fileToZip));
                zipStream.PutNextEntry(ent);
                zipStream.SetLevel(6);

                zipStream.Write(buffer, 0, buffer.Length);

            }
            catch
            {
                result = false;
            }
            finally
            {
                if (zipStream != null)
                {
                    zipStream.Finish();
                    zipStream.Close();
                }
                if (ent != null)
                {
                    ent = null;
                }
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
            GC.Collect();
            GC.Collect(1);

            return result;
        }


        public static bool UnZipFile(string fileToUnZip, string zipedFolder,string saveFileName, string password)
        {
            bool result = true;
            FileStream fs = null;
            ZipInputStream zipStream = null;
            ZipEntry ent = null;

            if (!File.Exists(fileToUnZip))
                return false;

            if (!Directory.Exists(zipedFolder))
                Directory.CreateDirectory(zipedFolder);

            try
            {
                zipStream = new ZipInputStream(File.OpenRead(fileToUnZip));
                if (!string.IsNullOrEmpty(password)) zipStream.Password = password;
                ent = zipStream.GetNextEntry();
                if (!string.IsNullOrEmpty(ent.Name))
                {
                    fs = File.Create(Path.Combine(zipedFolder, saveFileName));
                    int size = 2048;
                    byte[] data = new byte[size];
                    while (true)
                    {
                        size = zipStream.Read(data, 0, data.Length);
                        if (size > 0)
                            fs.Write(data, 0, data.Length);
                        else
                            break;
                    }
                }
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                if (zipStream != null)
                {
                    zipStream.Close();
                    zipStream.Dispose();
                }
                if (ent != null)
                {
                    ent = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
            return result;
        }

        public static bool WordToHtml(object wordfilename)
        {
            try
            {
                //在此处放置用户代码以初始化页面   
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Type wordtype = wordApp.GetType();
                Microsoft.Office.Interop.Word.Documents docs = wordApp.Documents;
                //打开文件   
                Type docstype = docs.GetType();
                Microsoft.Office.Interop.Word.Document doc = (Microsoft.Office.Interop.Word.Document)docstype.InvokeMember("open",
                    System.Reflection.BindingFlags.InvokeMethod, null, docs, new object[] { wordfilename, true, true });
                //转换格式，另存为   
                Type doctype = doc.GetType();
                string wordsavefilename = wordfilename.ToString();
                string strsavefilename = wordsavefilename.Substring(0, wordsavefilename.Length - 3) + "html";
                object savefilename = (object)strsavefilename;
                doctype.InvokeMember("saveas", System.Reflection.BindingFlags.InvokeMethod, null, doc, new object[] { savefilename, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatFilteredHTML });
                doctype.InvokeMember("close", System.Reflection.BindingFlags.InvokeMethod, null, doc, null);
                // 退出 word   
                wordtype.InvokeMember("quit", System.Reflection.BindingFlags.InvokeMethod, null, wordApp, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ExcelToHtml(string excelFileName)
        {
            try
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool isExcelInstalled()
        {
            Type type = Type.GetTypeFromProgID("Excel.Application");
            return type != null;
        }

        public static bool isWordInstalled()
        {
            Type type = Type.GetTypeFromProgID("Word.Application");
            return type != null;
        }

        public static bool isOfficInstalled()
        {
             Microsoft.Win32.RegistryKey reg_key = Microsoft.Win32.Registry.LocalMachine;
             Microsoft.Win32.RegistryKey offic_key = reg_key.OpenSubKey(@"SOFTWARE\Microsoft\Office");
             return offic_key != null;
        }

    //    public static bool UnZip(string fileToUnZip, string zipedFolder, string password)
    //    {
    //        bool result = true;
    //        FileStream fs = null;
    //        ZipInputStream zipStream = null;
    //        ZipEntry ent = null;
    //        string fileName;

    //        if (!File.Exists(fileToUnZip))
    //            return false;

    //        if (!Directory.Exists(zipedFolder))
    //            Directory.CreateDirectory(zipedFolder);

    //        try
    //        {
    //            zipStream = new ZipInputStream(File.OpenRead(fileToUnZip));
    //            if (!string.IsNullOrEmpty(password)) zipStream.Password = password;
    //            while ((ent = zipStream.GetNextEntry()) != null)
    //            {
    //                if (!string.IsNullOrEmpty(ent.Name))
    //                {
    //                    fileName = Path.Combine(zipedFolder, ent.Name);
    //                    fileName = fileName.Replace('/', '\\');//change by Mr.HopeGi 

    //                    if (fileName.EndsWith("\\"))
    //                    {
    //                        Directory.CreateDirectory(fileName);
    //                        continue;
    //                    }

    //                    fs = File.Create(fileName);
    //                    int size = 2048;
    //                    byte[] data = new byte[size];
    //                    while (true)
    //                    {
    //                        size = zipStream.Read(data, 0, data.Length);
    //                        if (size > 0)
    //                            fs.Write(data, 0, data.Length);
    //                        else
    //                            break;
    //                    }
    //                }
    //            }
    //        }
    //        catch
    //        {
    //            result = false;
    //        }
    //        finally
    //        {
    //            if (fs != null)
    //            {
    //                fs.Close();
    //                fs.Dispose();
    //            }
    //            if (zipStream != null)
    //            {
    //                zipStream.Close();
    //                zipStream.Dispose();
    //            }
    //            if (ent != null)
    //            {
    //                ent = null;
    //            }
    //            GC.Collect();
    //            GC.Collect(1);
    //        }
    //        return result;
    //    } 
    }
}
