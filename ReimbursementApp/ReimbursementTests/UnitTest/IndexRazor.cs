using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Globalization;
using Reimbursement.Pages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Transactions;


namespace ReimbursementTests.UnitTest
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
            cut.Find("h1").MarkupMatches("<h1>Velkommen</h1>");
        }
        [Fact]
        public void TestingLogInButtonOnIndexPage()
        {
            //Arange
            using var ctx = new TestContext();
            var navMan = ctx.Services.GetRequiredService<FakeNavigationManager>();
            var cut = ctx.RenderComponent<Reimbursement.Pages.Index>();

            //Act
            string oldUrl = navMan.Uri;
            cut.Find("button").Click();

            //Assert
            Assert.Equal("http://localhost/", oldUrl); //The previos uri befor button clickd
            Assert.Equal("http://localhost/user/GoogleSignIn", navMan.Uri); // new uri after button click
        }

    }
}
