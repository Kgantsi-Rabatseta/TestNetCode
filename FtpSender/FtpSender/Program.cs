

using System;
using System.IO;
using System.Net;
using FtpWebClient;

namespace FtpSender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            File.WriteAllLines(TestData.FileName1,new[]{"time","and","Time","Again"});
            Console.WriteLine("Contents of file :"+File.ReadAllLines(TestData.FileName1));
            Console.WriteLine("Sending to Ftp");
            var client = new FtpWebClientConnection(TestData.FtpSite,TestData.FtpUsername,TestData.FtpPassword);
            client.SetFtpMethod(WebRequestMethods.Ftp.UploadFile);
            client.CopyFileToFtpFolder(TestData.FileName1);
            Console.WriteLine("Sending to Ftp Complete");
            Console.ReadLine();
            Console.ReadLine();

        }
    }
}
