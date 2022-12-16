using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Reimbursement.Data;
using Xunit;
using Bunit;
using Microsoft.AspNetCore.Http;
using AngleSharp.Io;

namespace ReimbursementTests.UnitTest
{
    public class UserControllerTest
    {
        [Fact]
        public void TestForUserControllerLogIn_ShouldAuthinticateUser()
        {
            var controller = new UserController();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();


        }
    }
}
