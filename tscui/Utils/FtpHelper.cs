﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace tscui.Utils
{
    class FtpHelper
    {
        /// <summary>
        /// ftp方式上传 
        /// </summary>
        public static int UploadFtp(string filePath, string filename, string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            FileInfo fileInf = new FileInfo(filePath + "\\" + filename);
            string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
            FtpWebRequest reqFTP;
            // Create FtpWebRequest object from the Uri provided 
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileInf.Name));
            try
            {
                // Provide the WebPermission Credintials 
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

                // By default KeepAlive is true, where the control connection is not closed 
                // after a command is executed. 
                reqFTP.KeepAlive = false;

                // Specify the command to be executed. 
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

                // Specify the data transfer type. 
                reqFTP.UseBinary = true;

                // Notify the server about the size of the uploaded file 
                reqFTP.ContentLength = fileInf.Length;

                // The buffer size is set to 2kb 
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;

                // Opens a file stream (System.IO.FileStream) to read the file to be uploaded 
                //FileStream fs = fileInf.OpenRead(); 
                FileStream fs = fileInf.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                // Stream to which the file to be upload is written 
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time 
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends 
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream 
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream 
                strm.Close();
                fs.Close();
                return 0;
            }
            catch (Exception ex)
            {
                reqFTP.Abort();
                Console.WriteLine(ex.Message + ex.StackTrace);
                return -2;
            }
        }
        /// <summary>
        /// ftp方式上传 
        /// </summary>
        public static int UploadFtp(string filename, string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
            FtpWebRequest reqFTP;
            // Create FtpWebRequest object from the Uri provided 
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileInf.Name));
            try
            {
                // Provide the WebPermission Credintials 
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

                // By default KeepAlive is true, where the control connection is not closed 
                // after a command is executed. 
                reqFTP.KeepAlive = false;

                // Specify the command to be executed. 
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

                // Specify the data transfer type. 
                reqFTP.UseBinary = true;

                // Notify the server about the size of the uploaded file 
                reqFTP.ContentLength = fileInf.Length;

                // The buffer size is set to 2kb 
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;

                // Opens a file stream (System.IO.FileStream) to read the file to be uploaded 
                //FileStream fs = fileInf.OpenRead(); 
                FileStream fs = fileInf.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                // Stream to which the file to be upload is written 
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time 
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends 
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream 
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream 
                strm.Close();
                fs.Close();
                return 0;
            }
            catch (Exception ex)
            {
                reqFTP.Abort();
                Console.WriteLine(ex.ToString());
                return -2;
            }
        }
        /// <summary>   
        /// 获取FTP文件列表   
        /// </summary>   
        /// <returns></returns>   
        public static List<String> GetFileList(string FtpAddress, string FtpRemotePath, string FtpUid, string FtpPwd)
        {
            List<string> list = new List<string>();
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + FtpAddress + FtpRemotePath));
            req.Credentials = new NetworkCredential(FtpUid, FtpPwd);
            req.Method = WebRequestMethods.Ftp.ListDirectory;
            req.UseBinary = true;
            req.UsePassive = true;
            //req.KeepAlive = false;
            try
            {
                using (FtpWebResponse res = (FtpWebResponse)req.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {

                            list.Add(s);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //Log("下载文件列表失败:");
              //  Log(ex.ToString());
            }
            return list;

        }  
        /// <summary>
        /// ftp方式下载 
        /// </summary>
        public static int DownloadFtp(string filePath, string fileName, string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            FtpWebRequest reqFTP;
            try
            {
                //filePath = < <The full path where the file is to be created.>>, 
                //fileName = < <Name of the file to be created(Need not be the name of the file on FTP server).>> 
                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -2;
            }
        }
    }
}
