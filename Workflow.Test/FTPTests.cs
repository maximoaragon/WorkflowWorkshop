using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exchange.ServerLib;
using System.Net;
using System.IO;

namespace Workflow.Test
{
    [TestClass]
    public class FTPTests
    {
        private string _userName = "**";
        private string _password = "***";    

        [TestMethod]
        [DeploymentItem(@"TestData\", @"TestData\")] //Files in this dir must be set to Copy To Output
        public void SFTPCallsTests()
        {

            string tiffFile = @"TestData\testfile.txt";
            string tiffFile2 = @"TestData\testfile2.txt";

            Assert.IsTrue(File.Exists(tiffFile), "tiffFile.txt File not found");
            Assert.IsTrue(File.Exists(tiffFile2), "tiffFile2.txt File not found");

            var ftpClient = new FTPWrapper();
            ftpClient.Credentials = new NetworkCredential(_userName, _password);

            string localFileDest = @"TestData\in";
            string sftpHost = "showcase.equivant.com";


            Console.Write("Calling PutFile()... ");
            ftpClient.PutFile(tiffFile, sftpHost + "/testdir/", FileTransferMode.SFTP, true);
            Console.WriteLine("**SUCCESS!***");

            Console.Write("Calling PutFiles()... ");
            ftpClient.PutFiles("TestData", sftpHost + "/testdir/", FileTransferMode.SFTP, true);
            Console.WriteLine("**SUCCESS!***");

            Directory.CreateDirectory(localFileDest);

            Console.Write("Calling GetFile()... ");
            ftpClient.GetFile(sftpHost + "/testdir/testfile2.txt", localFileDest, FileTransferMode.SFTP, true);
            Assert.IsTrue(File.Exists(localFileDest + "\\testfile2.txt"));
            File.Delete(localFileDest + "\\testfile2.txt");
            Console.WriteLine("**SUCCESS!***");

            Console.Write("Calling GetFiles()... ");
            ftpClient.GetFiles(sftpHost + "/testdir/", localFileDest, FileTransferMode.SFTP, true, new string[] { ".txt" }, false, null);
            Assert.IsTrue(File.Exists(localFileDest + "\\testfile.txt"));
            Assert.IsTrue(File.Exists(localFileDest + "\\testfile2.txt"));
            Console.WriteLine("**SUCCESS!***");

            Console.Write("Calling MoveFiles()... ");
            ftpClient.MoveFiles(sftpHost + "/", sftpHost.TrimEnd('/') + "/processed/", FileTransferMode.SFTP, true, new string[] { ".txt" });
            Console.WriteLine("**SUCCESS!***");
        }

        [TestMethod]
        public void FTPCallsTests()
        {

            string tiffFile = @"TestData\testfile.txt";
            string tiffFile2 = @"TestData\testfile2.txt";

            Assert.IsTrue(File.Exists(tiffFile), "tiffFile.txt File not found");
            Assert.IsTrue(File.Exists(tiffFile2), "tiffFile2.txt File not found");

            var ftpClient = new FTPWrapper();
            ftpClient.Credentials = new NetworkCredential(_userName, _password);

            string localFileDest = @"TestData\in";
            string ftpURL = "ftp://showcase.equivant.com/";

            Console.Write("Calling PutFile()... ");
            ftpClient.PutFile(tiffFile, ftpURL + Path.GetFileName(tiffFile), FileTransferMode.FTP, true);
            Console.WriteLine("**SUCCESS!***");

            Console.Write("Calling PutFiles()... ");
            ftpClient.PutFiles("TestData", ftpURL + "/", FileTransferMode.FTP, true);
            Console.WriteLine("**SUCCESS!***");

            Directory.CreateDirectory(localFileDest);

            Console.Write("Calling GetFile()... ");
            ftpClient.GetFile(ftpURL + "/testfile2.txt", localFileDest, FileTransferMode.FTP, true);
            Assert.IsTrue(File.Exists(localFileDest + "\\testfile2.txt"));
            File.Delete(localFileDest + "\\testfile2.txt");
            Console.WriteLine("**SUCCESS!***");

            Console.Write("Calling GetFiles()... ");
            ftpClient.GetFiles(ftpURL + "/", localFileDest, FileTransferMode.FTP, true, new string[] { ".txt" }, false, null);
            Assert.IsTrue(File.Exists(localFileDest + "\\testfile.txt"));
            Assert.IsTrue(File.Exists(localFileDest + "\\testfile2.txt"));
            Console.WriteLine("**SUCCESS!***");

            Console.Write("Calling MoveFiles()... ");
            ftpClient.MoveFiles(ftpURL + "/", ftpURL.TrimEnd('/') + "/processed/", FileTransferMode.FTP, true, new string[] { ".txt" });
            Console.WriteLine("**SUCCESS!***");

            Console.Write("Calling DeleteFiles()... ");

            //Must put the file before testing the delete
            ftpClient.PutFile(tiffFile, ftpURL + Path.GetFileName(tiffFile), FileTransferMode.FTP, true);

            //DeleteFiles also test DeleteFile which is called internally.
            ftpClient.DeleteFiles(ftpURL, FileTransferMode.FTP, new string[] { ".txt" });
            //Delete local file so we can check for its existence after downloading.
            File.Delete(localFileDest + "\\" + Path.GetFileName(tiffFile));
            ftpClient.GetFile(ftpURL + Path.GetFileName(tiffFile), localFileDest, FileTransferMode.FTP, true);

            //It should not exists... right?
            Assert.IsFalse(File.Exists(localFileDest + "\\" + Path.GetFileName(tiffFile)), "Unable to delete from FTP");

            Console.WriteLine("**SUCCESS!***");
        }
    }
}
