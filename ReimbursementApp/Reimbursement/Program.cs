using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;
using Reimbursement.Data;
using Reimbursement.PdfData;

/******** MAYBE DELETE UNUSED ********/
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Reimbursement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            //Coment here
            builder.Services.AddSingleton<FormInfo>();
            builder.Services.AddSingleton<PDF>();
            builder.Services.AddSingleton<UserController>();
            builder.Services.AddSingleton<Mailservice>();

            builder.Services.AddControllersWithViews();

            //Adds the authentication that will be used in the system
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }
            //The system uses cookie to authinticate then it is added here
            ).AddCookie(o =>
            {
                o.LoginPath = "/user/GoogleSignIn";
                o.LogoutPath = "/user/logoutuser";
            }
            /*The sysem has external authitication, that is provided by Google. The client 
             Id and Secret is stored in the file "appsettings" and can be change to match
            a new google workspace. The scopes are added aswell here to get access to the necessary stuff.*/
            ).
            AddGoogle(googleoptions =>
            {
                IConfiguration googleAuthSection = builder.Configuration.GetSection("Authentication:Google");
                googleoptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                googleoptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
                googleoptions.SaveTokens = true;
                var scope = googleoptions.Scope;
                scope.Add("https://www.googleapis.com/auth/userinfo.profile");
                scope.Add("https://www.googleapis.com/auth/gmail.send");
                scope.Add("https://mail.google.com");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "Pages/Images")),
                RequestPath = "/Pages/Images"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                  Path.Combine(Directory.GetCurrentDirectory(), "PdfData/GeneratedPdf")),
                RequestPath = "/PdfData/GeneratedPdf"
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}