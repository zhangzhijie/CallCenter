using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ad.Fw
{
    public class ZipHelper
    {
        public static bool FastZip(string zipFileName, string sourceDir)
        {
            try
            {
                sourceDir = sourceDir.Replace("/", "\\");
                if (!sourceDir.EndsWith("\\"))
                {
                    sourceDir += "\\";
                }
                if (!Directory.Exists(sourceDir))
                {
                    Directory.CreateDirectory(sourceDir);
                }
                if (File.Exists(zipFileName))
                {
                    File.Delete(zipFileName);
                }
                ICSharpCode.SharpZipLib.Zip.FastZip fz = new ICSharpCode.SharpZipLib.Zip.FastZip();
                fz.CreateEmptyDirectories = true;
                fz.CreateZip(zipFileName, sourceDir, true, "");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CreatTarArchive(string strBasePath, string strSourceFolderName)
        {
            if (string.IsNullOrEmpty(strBasePath)
                || string.IsNullOrEmpty(strSourceFolderName)
                || !System.IO.Directory.Exists(strBasePath)
                || !System.IO.Directory.Exists(Path.Combine(strBasePath, strSourceFolderName)))
            {
                return false;
            }

            Environment.CurrentDirectory = strBasePath;
            string strSourceFolderAllPath = Path.Combine(strBasePath, strSourceFolderName);
            string strOupFileAllPath = Path.Combine(strBasePath, strSourceFolderName + ".tar");

            Stream outStream = new FileStream(strOupFileAllPath, FileMode.OpenOrCreate);

            ICSharpCode.SharpZipLib.Tar.TarArchive archive = ICSharpCode.SharpZipLib.Tar.TarArchive.CreateOutputTarArchive(outStream, ICSharpCode.SharpZipLib.Tar.TarBuffer.DefaultBlockFactor);
            ICSharpCode.SharpZipLib.Tar.TarEntry entry = ICSharpCode.SharpZipLib.Tar.TarEntry.CreateEntryFromFile(strSourceFolderAllPath);
            archive.WriteEntry(entry, true);

            if (archive != null)
            {
                archive.Close();
            }

            outStream.Close();

            return true;
        }  
    }
}
