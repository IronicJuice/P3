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
using System.Transactions;

namespace ReimbursementTests
{
    public class TestingIndexPage
        {
        [Fact]
        public void TestingIndexMatches()
        {

            //Arange
            using var ctx = new TestContext();
            var authcontext = ctx.AddTestAuthorization();

            //Act
            var cut = ctx.RenderComponent<Reimbursement.Pages.Index>();

            //Assert
            cut.MarkupMatches("<head>\r\n    <link rel=\"stylesheet\" href=\"/css/homepage.css\">\r\n</head>\r\n<centering>\r\n<body>\r\n    <img src=\"/css/StudentersamfundetLogo.png\" alt=\"stlogo\" class=\"img\" />\r\n    <h1>Velkommen</h1>\r\n        <div>\r\n            <center>\r\n                Denne sider er til at søge udlæg\r\n            </center>\r\n        </div>\r\n        <button type=\"button\" class=\"button-Login\" @onclick=\"GoogleSignIn\">Login</button>\r\n    </body>\r\n</centering>");
        }

        }
}
