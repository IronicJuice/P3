using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reimbursement.Data
{



    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("getcurrentuser")]
        //public async Task<ActionResult<User>> GetCurrentUser()
        //{
        //    User currentUser = new User();

        //    if (User.Identity.IsAuthenticated)
        //    {
        //        currentUser.EmailAddress = User.FindFirstValue(ClaimTypes.Email);

        //        if (currentUser == null)
        //        {
        //            currentUser = new User();
        //            currentUser.EmailAddress = User.FindFirstValue(ClaimTypes.Email);
        //            currentUser.Source = "EXTL";
        //        }
        //    }
        //}

        // GET api/<ValuesController>/5
        [HttpGet("GoogleSignIn")]
        public async Task GoogleSignin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = "/form" });
        }
    }
}


