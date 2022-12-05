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
    public class Autheraztion
    {
        [Fact]
        public void TestingIndexMatches()
        {

            //Arange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton(new Program());
            ctx.Services.AddSingleton(new PDF());
            ctx.Services.AddSingleton(new Mailservice());
            ctx.Services.AddSingleton(new FormInfo());

            var authcontext = ctx.AddTestAuthorization();

            //Act
            var cut = ctx.RenderComponent<Reimbursement.Pages.Form>();

            //Assert
            cut.MarkupMatches("<article class=\"content px-4\" b-qepciaaf35=\"\">Not authorized</article>");
        }
    }
}
