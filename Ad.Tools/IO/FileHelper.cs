using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ad.Util;

namespace Ad.IO
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// 读入文件到字节数组
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>字节数组</returns>
        public static byte[] ReadToByte(string filePath)
        {
            List<byte> ls = new List<byte>();
            byte[] block = new byte[1024];
            using (Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                int length = 1;
                while (length > 0)
                {
                    length = stream.Read(block, 0, 1024);
                    if (length > 0)
                    {
                        ls.AddRange(block.SubBuffer(0, length));
                    }
                }
                return ls.ToArray();
            }
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件内容</returns>
        public static string ReadToString(string filePath)
        {
            using (System.IO.StreamReader sr = new StreamReader(filePath))
            {
               return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">文件内容</param>
        public static void WriteFile(string filePath, string content)
        {
            using (Stream stream = File.Open(filePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    sw.Write(content);
                    sw.Close();
                }
            }
        }
    }
}
