using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using SearchOption = System.IO.SearchOption;

namespace FtpSender
{
    public class FileMover
    {
        public void MoveDeploymentFiles()
        {
            string directory = @"C:\Shared\Deployment\COPS\V4.0.5.7\";
            var filenames = Directory.GetFiles(directory, "*.zip", SearchOption.TopDirectoryOnly).ToList<String>();
            foreach (var file in filenames)
            {
                var indexOfDot = file.IndexOf(".zip", StringComparison.Ordinal);
                string ipAddress = String.Concat("192.168.", file.Substring(indexOfDot - 5, 5));
                string reportsFolder = String.Concat("\\\\", ipAddress, "\\", "COPSReports");
                if (CopyFile(file, reportsFolder))
                {
                    var writer = File.AppendText(directory + "DeployLog.txt");
                    writer.WriteLine(file + " has been Copied");
                    writer.Close();
                }
                else
                {
                    var writer = File.AppendText(directory + "DeployLog.txt");
                    writer.WriteLine(file + " Failed");
                    writer.Close();
                }
            }
        }



        public bool CopyFile(string longfilename, string destination)
        {
            try
            {
                var shortFileName = Path.GetFileName(longfilename);
                var destinationFile = destination +"\\"+ shortFileName;
                FileSystem.CopyFile(longfilename,destinationFile,UIOption.AllDialogs);
                return true;
            }
            catch(Exception exception)
            {
                return false;
            }
        }
    }
}
