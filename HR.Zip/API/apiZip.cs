using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.IO.Compression;

namespace HR.Zip.API
{
    class apiZip
    {
        public void CompressFilesWithZip(string sourcefile, string zipFile, string passWord,string zipFlodername)
        {
            if (Directory.Exists(zipFile))
            {
                File.Delete(zipFile);
            }
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(zipFile, Encoding.UTF8))
            {
                zip.Password = passWord == string.Empty ? string.Empty : passWord;
                try
                {
                    zip.TempFileFolder = Path.GetTempPath();                    
                    zip.AddFile(sourcefile,zipFlodername);
                }
                catch { zip.Dispose(); }
                zip.Save();
                zip.Dispose();

            }
        }
        public void CompressFilesWithZip(string directory, List<string> sourceFiles, string zipFile, string passWord)
        {
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(zipFile, Encoding.UTF8))
            {
                zip.Password = passWord == string.Empty ? string.Empty : passWord;
                try
                {
                    foreach (string detail in sourceFiles)
                    {
                        zip.AddFile(detail);
                        zip.AddDirectory(directory);
                    }
                }
                catch { }
                finally
                {
                    zip.Save();
                    zip.Dispose();
                }
            }
            //sample
            //using (ZipFile zip = new ZipFile("Backup.zip"))
            //{
            //    zip.AddFile("ReadMe.txt"); // no password for this entry

            //    zip.Password = "123456!";
            //    ZipEntry e = zip.AddFile("7440-N49th.png");
            //    e.Comment = "Map of the company headquarters.";

            //    zip.Password = "!Secret1";
            //    zip.AddFile("2Q2008_Operations_Report.pdf");

            //    zip.Save();
            //}
        }
    }
}
