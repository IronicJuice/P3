using EASendMail;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using Reimbursement.Data;

namespace Reimbursement.Data
{
    public class Mailservice
    {
        public void SendMail(string userEmail, string token)
        {
            try
            {
                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // enable SSL connection
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                // Using 587 port, you can also use 465 port
                oServer.Port = 587;

                // use Gmail SMTP OAUTH 2.0 authentication
                oServer.AuthType = SmtpAuthType.XOAUTH2;
                // set user authentication
                oServer.User = userEmail;
                // use access token as password
                oServer.Password = token;

                SmtpMail oMail = new SmtpMail("TryIt");
                // Your gmail email address
                oMail.From = userEmail;
                oMail.To = "bredfort1234@gmail.com";

                oMail.Subject = "Test email sent from with microsoft asp";
                oMail.TextBody = "this is a test email sent from c# project with gmail.";

                Console.WriteLine("start to send email using OAUTH 2.0 ...");
                Console.WriteLine(token);

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("The email has been submitted to server successfully!");

            }
            catch (Exception ep)
            {
                Console.WriteLine("Exception: {0}", ep.Message);
            }
        }
}
}
