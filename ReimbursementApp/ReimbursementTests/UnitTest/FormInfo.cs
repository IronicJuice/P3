using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Reimbursement;
using Reimbursement.PdfData;
using Reimbursement.Data;
using Spire.Pdf.Graphics;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Bunit.TestDoubles;

namespace ReimbursementTests.UnitTest
{
    public class FormInfoClass
    {
        [Fact]
        public void PopulateAccountsTests()
        {
            FormInfo formInfo = new FormInfo();

            Assert.Empty(formInfo.accountList);

            formInfo.GroupStr = "TestGroup";
            formInfo.PopulateAccounts();
            Assert.Equal("Test1: 6163 - 6422854624", formInfo.accountList[0]);
            Assert.Equal("Test2: 4594 - 1416146756", formInfo.accountList[1]);
        }

        [Fact]
        public void PopulateTextFieldsTests()
        {
            FormInfo formInfo = new FormInfo();

            Assert.Null(formInfo.Name);
            Assert.Null(formInfo.Phone);
            Assert.Null(formInfo.Email);

            string userName = "John Doe";
            string email = "JohnDoe@gmail.com";
            formInfo.PopulateTextFields(formInfo, userName, email);

            Assert.Equal("John Doe", formInfo.Name);
            Assert.Equal(null, formInfo.Phone);
            Assert.Equal("JohnDoe@gmail.com", formInfo.Email);
        }

        [Fact]
        public void PopulateGroupsTests()
        {
            FormInfo formInfo = new FormInfo();

            Assert.Empty(formInfo.GroupList);

            formInfo.PopulateGroups();
            Assert.Equal("Aalbar", formInfo.GroupList[0]);
            Assert.Equal("AAU LGBT+", formInfo.GroupList[1]);
            Assert.Equal("AAULAN", formInfo.GroupList[2]);
        }
    }
}