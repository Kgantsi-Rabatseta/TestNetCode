

using System;
using System.IO;
using System.Linq;
using System.Net;
using FtpWebClient;

namespace FtpSender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //InitialiseTest();
            Console.WriteLine("copying files");
            CopySharedFiles();
            //SentToFtp();
            //AddAndRemoveFilePart();
            Console.ReadLine();
        }

        private static void CopySharedFiles()
        {
            var mv =  new FileMover();
            
            mv.MoveDeploymentFiles();
        }


        private static void InitialiseTest()
        {
            CreateTestFile();
            Console.WriteLine("File 1 Created");
            WriteContentsOfFile(TestData.FileName1);
        }

        private static void AddAndRemoveFilePart()
        {
            Console.WriteLine("Create FilePart * ");
            var filepart = FileIO.CreateFilePart(TestData.FileName1);
            WriteContentsOfFile(filepart);
            Console.ReadLine();
            Console.WriteLine("Remove FilePart ****");
            if (FileIO.RemoveFile(filepart))
                Console.Write("File Exists: " + File.Exists(filepart));
        }

        private static void WriteContentsOfFile(string fileName1)
        {
            var contents = File.ReadAllLines(fileName1)
                               .Aggregate("", (current, readAllLine) => current +
                                                                        (" " + readAllLine));

            Console.WriteLine("Contents of file :" + contents);
        }

        private static void SentToFtp()
        {
            Console.WriteLine("Sending to Ftp");
            var filePart = FileIO.CreateFilePart(TestData.FileName1);
            var fullFileName = TestData.FtpSite + "/" + filePart;
            var client = new FtpWebClientConnection(fullFileName, TestData.FtpUsername, TestData.FtpPassword);
            client.SetFtpMethod(WebRequestMethods.Ftp.UploadFile);
            var response = client.CopyFileToFtpFolder(TestData.FileName1).ToString();
            if (response.Contains("complete"))
            {
                Console.WriteLine("Sending to Ftp :"+response);
                Console.WriteLine("Remove File: "+ FileIO.RemoveFile(filePart));
                Console.WriteLine("RenamingFile");
                var response2 = client.RenameFtpFile(fullFileName, TestData.FileName1);
                Console.WriteLine("RenamingFile : "+response2);
            }
            else Console.WriteLine("Sending to Ftp Error: \n" + (response));
            Console.ReadLine();
        
            Console.ReadLine();
        }

        private static void CreateTestFile()
        {
            File.WriteAllLines(TestData.FileName1, new[] {"time", "and", "Time", "Again"});
        }
    }
}
