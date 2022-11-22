using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reimbursement.Data
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        // GET api/<ValuesController>/5
        [HttpGet("GoogleSignIn")]
        public async Task GoogleSignin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = "/form" });
            GetToken();
        }
        public static string token { get; set; }

        public async void GetToken()
        {
            token = await HttpContext.GetTokenAsync(GoogleDefaults.AuthenticationScheme, "access_token");
            Console.WriteLine(token);
        }
        
    }
}


