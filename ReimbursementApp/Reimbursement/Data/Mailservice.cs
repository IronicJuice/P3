using EASendMail;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using Reimbursement.Data;
using System.Drawing.Text;
using Microsoft.Win32.SafeHandles;

namespace Reimbursement.Data
{
    public class Mailservice : UserController
    {
        //public async void GetToken()
        //{
        //    var token = await HttpContext.GetTokenAsync(GoogleDefaults.AuthenticationScheme, "access_token");
        //    Console.WriteLine(token);
        //}
        public void SendMail()
        {
            try
            {
                Console.WriteLine(UserController.token);
                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // enable SSL connection
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                // Using 587 port, you can also use 465 port
                oServer.Port = 587;

                // use Gmail SMTP OAUTH 2.0 authentication
                oServer.AuthType = SmtpAuthType.XOAUTH2;
                // set user authentication
                oServer.User = "bredfort1234@gmail.com";
                // use access token as password
                oServer.Password = UserController.token;

                SmtpMail oMail = new SmtpMail("TryIt");
                // Your gmail email address
                oMail.From = "bredfort1234@gmail.com";
                oMail.To = "bredfort1234@gmail.com";

                oMail.Subject = "Test email sent from with microsoft asp";
                oMail.TextBody = "this is a test email sent from c# project with gmail.";

                Console.WriteLine("start to send email using OAUTH 2.0 ...");
                Console.WriteLine(UserController.token);

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
