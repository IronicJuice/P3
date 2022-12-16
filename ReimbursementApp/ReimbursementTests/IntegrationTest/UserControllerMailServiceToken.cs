using Reimbursement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementTests.IntegrationTest
{
    public class UserControllerMailServiceToken
    {
        [Fact]
        public void SetsTokenInControllerReadTokenInMailService()
        {
            Assert.Equal(UserController.token = "testForToken", Mailservice.token);
        }
    }
}
