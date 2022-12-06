using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Globalization;
using Bunit;
using Bunit.TestDoubles;
using Reimbursement.Pages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ReimbursementTests
{
    internal class Autheraitzion
    {
        public class AutheratzionTest
        {
            [Fact]
            public void TestingNonAuthWorks()
            {

                //Arange
                using var ctx = new TestContext();
                var authcontext = ctx.AddTestAuthorization();
                authcontext.SetAuthorized("TEST USER", AuthorizationState.Unauthorized);

                //Act
                var cut = ctx.Render<Form>();

                //Assert
            }

        }
    }
}
