using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Reimbursement;
using Reimbursement.PdfData;
using Reimbursement.Data;
using Spire.Pdf.Graphics;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace ReimbursementTests
{
    public class FormInfoTests
    {
        [Fact]
        public void Test()
        {
            using var ctx = new TestContext();
            ctx.Services.AddSingleton(new PDF());
            ctx.Services.AddSingleton(new FormInfo());
            ctx.Services.AddSingleton(new UserController());
            ctx.Services.AddSingleton(new Mailservice());
            var cut = ctx.RenderComponent<Reimbursement.Pages.Form>();

            


        }
        [Fact]
        public void GroupSelectTest() {
            using var ctx = new TestContext();
            ctx.Services.AddSingleton(new PDF());
            ctx.Services.AddSingleton<FormInfo>(new FormInfo());
            ctx.Services.AddSingleton(new UserController());
            ctx.Services.AddSingleton(new Mailservice());
            var cut = ctx.RenderComponent<Reimbursement.Pages.Form>();

            //Find out how to read elements of the datalist

            //cut.Find("div").MarkupMatches("no");
            //cut.Find("select").SetAttribute("value", "EDB");
            //cut.Find("div").MarkupMatches("no");
            //cut.Find("datalist").MarkupMatches("No");
        }
        [Fact]
        public void PopulateAccountsTests() {
            FormInfo formInfo = new FormInfo();

            Assert.Empty(formInfo.accountList);

            formInfo.GroupStr = "TestGroup";
            formInfo.PopulateAccounts();
            Assert.Equal("Test1: 6163 - 6422854624", formInfo.accountList[0]);
            Assert.Equal("Test2: 4594 - 1416146756", formInfo.accountList[1]);

        }
        [Fact]
        public void PopulateTextFieldsTests() {
            FormInfo formInfo = new FormInfo();

            Assert.Null(formInfo.Name);
            Assert.Null(formInfo.Email);

            formInfo.PopulateTextFields(formInfo, "John Doe", "JohnDoe@gmail.com");
            Assert.Equal("John Doe", formInfo.Name);
            Assert.Equal("JohnDoe@gmail.com", formInfo.Email);
        }
        [Fact]
        public void PopulateGroupsTests() {
            FormInfo formInfo = new FormInfo();

            Assert.Empty(formInfo.GroupList);

            formInfo.PopulateGroups();

            Assert.NotEmpty(formInfo.GroupList);

        }
    }
}