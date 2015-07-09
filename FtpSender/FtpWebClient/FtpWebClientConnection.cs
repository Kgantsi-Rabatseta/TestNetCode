using System;
using System.IO;
using System.Net;

namespace FtpWebClient
{
    public class FtpWebClientConnection
    {
        private string _ftpAddress;
        private readonly string _userName;
        private readonly string _password;

        public FtpWebClientConnection(string ftpAddress, string userName, string password)
        {
            _ftpAddress = ftpAddress;
            _userName = userName;
            _password = password;
            CreateCredentials();
            CreateWebRequest();
        }

        public void SetUri(string uri)
        {
            _ftpAddress = uri;
            CreateWebRequest();
        }

        public void ClearProxy()
        {
            Request.Proxy = null;
        }

        public void SetFtpMethod(String ftpWebMethod)
        {
            Request.Method = ftpWebMethod;
        }

        private void CreateCredentials()
        {
            FtpWebCredentials = new NetworkCredential(_userName, _password);
        }

        private void CreateWebRequest()
        {
            Request = null;
            Request = (FtpWebRequest)WebRequest.Create(new Uri(_ftpAddress, UriKind.Absolute));
            Request.Credentials = FtpWebCredentials;
            Request.KeepAlive = true;
            Request.UsePassive = true;
            Request.UseBinary = true;
        }

        public object CopyFileToFtpFolder(string fileName)
        {
            try
            {
                var filePart = FileIO.CreateFilePart(fileName);

                var buffer = CreateBuffer(filePart);
                WriteBytesToFtpFolder(buffer);
                var response = (FtpWebResponse)(Request.GetResponse());
                return response.StatusDescription;
            }
            catch (WebException exception)
            {
                return ((FtpWebResponse)(exception.Response)).StatusDescription;
            }
        }


        private byte[] CreateBuffer(string sourceFileName)
        {
            var fileStream = File.OpenRead(sourceFileName);
            var buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            fileStream.Close();

            return buffer;
        }

        private void WriteBytesToFtpFolder(byte[] buffer)
        {
            var ftpStream = Request.GetRequestStream();
            ftpStream.Write(buffer, 0, buffer.Length);
            ftpStream.Close();
        }

        public object RenameFtpFile(string ftpFileName, string ftpNewFileName)
        {
            try
            {
                SetUri(ftpFileName);
                ClearProxy();
                SetFtpMethod(WebRequestMethods.Ftp.Rename);
                Request.RenameTo = ftpNewFileName;
                var response =(FtpWebResponse) (Request.GetResponse());
                return response.StatusDescription;
            }
            catch (WebException exception)
            {
                return ((FtpWebResponse)(exception.Response)).StatusDescription;
            }
        }

        protected FtpWebRequest Request { get; set; }
        protected NetworkCredential FtpWebCredentials { get; set; }
    }
}
