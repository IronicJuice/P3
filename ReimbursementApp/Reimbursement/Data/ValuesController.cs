using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/*********** NOT USED. DELETE LATER **********/
//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.AspNetCore.CookiePolicy;
//using Microsoft.AspNetCore.Server.HttpSys;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Primitives;
//using Microsoft.IdentityModel.Tokens;
//using System.Reflection;
//using System.Security.Claims;


/*
 * This controller class waits and listens for incoming request. If the infomcing request matches the 
 * incoming requst, it then executes the method attachd the the request. The requst possible are [HttpGet("requstName")]
 * When the requst has been handels the respons is then to redirecd to a new site.
 */

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

        //Signs the user in with use of google login, and navigates to get the token after.
        [HttpGet("GoogleSignIn")]
        public async Task GoogleSignin()
        {
            AuthenticationProperties auth = new AuthenticationProperties()
            {
                RedirectUri = "user/gettoken",
                IsPersistent = true,
                IssuedUtc = DateTimeOffset.UtcNow,
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.AddHours(1),
            };
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, auth);
        }
        public static string token { get; set; }

        //Gets the token for the current use, stors it and then redirect to "form" site.
        [HttpGet("gettoken")]
        public async Task<ActionResult> GetToken()
        {
            token = await HttpContext.GetTokenAsync(GoogleDefaults.AuthenticationScheme, "access_token");
            Console.WriteLine(token);
            return Redirect("/form");
        }
    }
}
