using System.Security.Claims;
using Bunit;
using Bunit.TestDoubles;
using Reimbursement.Pages;
using Reimbursement.PdfData;
using Microsoft.Extensions.DependencyInjection;
using Reimbursement.Data;

//**********************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Transactions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Reimbursement;
using Microsoft.AspNetCore.Components.Web;
using AngleSharp.Dom;

namespace ReimbursementTests.IntegrationTest
{
    public class FormIntegration
    {
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
        [Fact]
        public void ReadAccountInformationOnForm()
        {
            //Arange
            var ctx = new TestContext();
            var authcontext = ctx.AddTestAuthorization();

            ctx.Services.AddSingleton(new PDF());
            ctx.Services.AddSingleton(new Mailservice());
            ctx.Services.AddSingleton(new FormInfo());

            authcontext.SetAuthorized("TEST USER");

            //Act
            var cut = ctx.RenderComponent<Form>();
            cut.Find("select").Change("TestGroup");
            cut.Find("select").Click();

            //Assert
            var datalist = cut.FindAll("datalist option");
            datalist[0].MarkupMatches("<option>Test1: 6163 - 6422854624</option>");
            datalist[1].MarkupMatches("<option>Test2: 4594 - 1416146756</option>");
        }
    }
}
