using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FtpWebClient
{
    public class FileIO
    {
        public const string PartExtention = ".part";
        public static void CopyFile(string sourceFileName, string destinationFileName)
        {
            File.Copy(sourceFileName,destinationFileName,true);
        }

        public static string CreateFilePart(string fileName)
        {
            var filepart = fileName + PartExtention;
            CopyFile(fileName,filepart);
            return filepart;
        }

        public static bool RemoveFile(string filepart)
        {
            try
            {
                File.Delete(filepart);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
