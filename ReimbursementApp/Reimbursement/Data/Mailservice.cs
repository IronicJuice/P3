using EASendMail;
using System.IO;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using Reimbursement.Data;
using Reimbursement.PdfData;
using System.Drawing.Text;
using Microsoft.Win32.SafeHandles;
using Spire.Pdf;
using System.Security.Cryptography.X509Certificates;

namespace Reimbursement.Data
{
    public class Mailservice
    {
        public void SendMail(string Name, string Email, string userIdentifier, string pdfName, string recipientEmail, int port)
        {
            try
            {
                //Console.WriteLine(UserController.token);
                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // enable SSL connection
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                // Using 587 port, you can also use 465 port
                oServer.Port = port;
                // use Gmail SMTP OAUTH 2.0 authentication
                oServer.AuthType = SmtpAuthType.XOAUTH2;
                // set user authentication
                oServer.User = Email;
                // use access token as password
                oServer.Password = UserController.token;

                SmtpMail oMail = new SmtpMail("TryIt");
                // Your gmail email address
                oMail.From = Email;
                oMail.To = recipientEmail;

                oMail.Subject = "Udlæg"; //The subject field of the sent email
                oMail.TextBody = "Hej,\n\nVedhæftet er en udfyldt udlæg formular, samt billeddokumentation\n\nHilsen,\n" + Name; //The text body of the sent email

                string path = Directory.GetCurrentDirectory();
                oMail.AddAttachment(@path + "/PdfData/GeneratedPdf/" + pdfName + ".pdf"); //Attach the relevant pdf to the email

                string imageFolderDir = $"{path}/Pages/Images/{userIdentifier}";
                string[] imageDirectoryList = Directory.GetFiles(imageFolderDir);
                for (int i = 0; i < imageDirectoryList.Length; i++) {
                    oMail.AddAttachment(imageDirectoryList[i]); //Attach photos
                }

                Console.WriteLine("Port: " + port);
                Console.WriteLine("start to send email using OAUTH 2.0 ...");
                //Console.WriteLine(UserController.token);

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail); //The email is sent

                Console.WriteLine("The email has been submitted to server successfully!");

            }
            catch (Exception ep) //If sending the email fails, the program will try using a different port
            {
                Console.WriteLine("Exception: {0}", ep.Message);
                if (port == 587) {
                    SendMail(Name, Email, userIdentifier, pdfName, recipientEmail, 465);
                }
            }
        }
    }
}
