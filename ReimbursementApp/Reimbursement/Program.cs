using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Reimbursement.Data;
using Reimbursement.PdfData;

namespace Reimbursement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<FormInfo>();
            builder.Services.AddSingleton<PDF>();
            builder.Services.AddSingleton<UserController>();
            builder.Services.AddSingleton<Mailservice>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }
            ).AddCookie().
            AddGoogle(googleoptions =>
            {
                IConfiguration googleAuthSection = builder.Configuration.GetSection("Authentication:Google");
                googleoptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                googleoptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
                googleoptions.SaveTokens = true;
                var scope = googleoptions.Scope;
                //scope.Add("https://mail.google.com/");
                //scope.Add("https://www.googleapis.com/auth/userinfo.profile");
                //scope.Add("https://www.googleapis.com/auth/userinfo.email");
                scope.Add("https://www.googleapis.com/auth/gmail.send");
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