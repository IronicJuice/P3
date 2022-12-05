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
using Reimbursement.PdfData;
using Microsoft.Extensions.DependencyInjection;
using Reimbursement.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Reimbursement;

namespace ReimbursementTests
{
    public class TestForAutheraztion
    {
        [Fact]
        public void NotAuthAccesForm()
        {
            //Arange
            using var ctx = new TestContext();
            var authcontext = ctx.AddTestAuthorization();

            ctx.Services.AddSingleton(new PDF());
            ctx.Services.AddSingleton(new Mailservice());
            ctx.Services.AddSingleton(new FormInfo());

            //Act
            var cut = ctx.RenderComponent<Form>();


            //Assert
            cut.MarkupMatches(@"<h3>Log in før du kan udfylder formen</h3>
                                <button type=""button"" class=""button-Preview"" >Til Forsiden</button>");
        }

        [Fact]
        public void AutheAccesForm()
        {
            //Arange
            var ctx = new TestContext();
            var authcontext = ctx.AddTestAuthorization();
            authcontext.SetAuthorized("Test User");

            ctx.Services.AddSingleton(new PDF());
            ctx.Services.AddSingleton(new Mailservice());
            ctx.Services.AddSingleton(new FormInfo());

            //Act
            var cut = ctx.RenderComponent<Form>();

            //Assert
            cut.Find("h3").MarkupMatches("<h3><nobr>Personlige oplysninger</nobr></h3>");
        }

        [Fact]
        public void AuthAccesFormAndClaims()
        {
            //Arange
            var ctx = new TestContext();
            var authcontext = ctx.AddTestAuthorization();

            ctx.Services.AddSingleton(new PDF());
            ctx.Services.AddSingleton(new Mailservice());
            ctx.Services.AddSingleton(new FormInfo());

            authcontext.SetAuthorized("TEST USER");
            authcontext.SetClaims(new Claim(ClaimTypes.Email, "Test@test.com"));

            //act
            var cut = ctx.RenderComponent<Form>();

            //Assert
            var inputList = cut.FindAll("input");
            inputList[0].MarkupMatches("<input class=\"valid\" value=\"TEST USER\"  >");
            inputList[1].MarkupMatches("<input class=\"valid\"  >");
            inputList[2].MarkupMatches("<input class=\"valid\" value=\"Test@test.com\"  >");
        }
    }
}
