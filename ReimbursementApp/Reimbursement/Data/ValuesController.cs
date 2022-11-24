using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reimbursement.Data
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        //Logs out the user, and deletes the CookieAuthentication, so that the user needsd to log bac in to get access
        [HttpGet("logoutuser")]
        [Authorize]
        public async Task LogOutUser()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = "/" });
        }

        //Signs the user in throug google login
        // GET api/<ValuesController>/5

        // GET api/<ValuesController>/

        [HttpGet("GoogleSignIn")]
        public async Task GoogleSignin()
        {
            AuthenticationProperties auth = new AuthenticationProperties()
            {
                RedirectUri = "/form",
                ExpiresUtc = DateTime.Now.AddHours(1),
            };
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, auth);
            GetToken();
        }
        public static string token { get; set; }

        [HttpGet]
        public async void GetToken()
        {
            token = await HttpContext.GetTokenAsync(GoogleDefaults.AuthenticationScheme, "access_token");
            Console.WriteLine(token);

    }
}


