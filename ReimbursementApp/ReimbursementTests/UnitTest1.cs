using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Reimbursement;
using Reimbursement.PdfData;
using Reimbursement.Data;
using Spire.Pdf.Graphics;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace ReimbursementTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestButanTest()
        {
            using var ctx = new TestContext();
            ctx.Services.AddSingleton(new PDF());
            ctx.Services.AddSingleton(new FormInfo());
            var cut = ctx.RenderComponent<Reimbursement.Pages.Form>();

            var inputList = cut.FindAll("input");
            inputList[0].MarkupMatches("<input class=\"valid\"  >");
            inputList[1].MarkupMatches("<input class=\"valid\"  >");
            inputList[2].MarkupMatches("<input class=\"valid\"  >");

            cut.Find("select").MarkupMatches("<select  style=\"width: 200px;\" class=\"valid\"  >" +
                "<option>Vælg en gruppe</option");

            cut.Find("button").Click();

            inputList = cut.FindAll("input");
            inputList[0].MarkupMatches("<input class=\"valid\" value=\"John Doe\"  >");
            inputList[1].MarkupMatches("<input class=\"valid\" value=\"112\"  >");
            inputList[2].MarkupMatches("<input class=\"valid\" value=\"JohnDoe@gmail.com\"  >");

            cut.Find("select").MarkupMatches("<select  style=\"width: 200px;\" class=\"valid\"  >" +
                "<option>Vælg en gruppe</option>" +
                "<option>EDB</option>" +
                "<option>Silly</option>" +
                "<option>Test3</option>" +
                "</select>");
        }
        [Fact]
        public void GroupSelectTest() {
            using var ctx = new TestContext();
            ctx.Services.AddSingleton(new PDF());
            ctx.Services.AddSingleton(new FormInfo());
            var cut = ctx.RenderComponent<Reimbursement.Pages.Form>();

            cut.Find("button").Click();

            //Find out how to read elements of the datalist

            //cut.Find("div").MarkupMatches("no");
            //cut.Find("select").SetAttribute("value", "EDB");
            //cut.Find("div").MarkupMatches("no");
            //cut.Find("datalist").MarkupMatches("No");
        }
        [Fact]
        public void IdkTest() {
            using var ctx = new TestContext();
            ctx.Services.AddSingleton(new PDF());
            ctx.Services.AddSingleton(new FormInfo());
            var cut = ctx.RenderComponent<Reimbursement.Pages.Form>();

            //Find out how to read from the same instance of the class that the razor page interacts with (if even possible)

            //FormInfo formInfo = new FormInfo();
            //cut.Find("input").SetAttribute("value", "heyo");
            //Assert.Equal("Heyo", formInfo.Name);
        }
    }
}