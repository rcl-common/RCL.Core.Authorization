using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace RCL.Core.Authorization.Test
{
    [TestClass]
    public class AzureAuthorizationTest
    {
        private readonly IAuthTokenService _authTokenService;

        public AzureAuthorizationTest()
        {
            _authTokenService = (IAuthTokenService)DependencyResolver
                .ServiceProvider().GetService(typeof(IAuthTokenService));
        }

        [TestMethod]
        public async Task GetAuthTokenTest()
        {
            try
            {
                string resource = "6a8b4b39-c021-437c-b060-5a14a3fd65f3";
                AuthToken authToken = await _authTokenService.GetAuthTokenAsync(resource);
                Assert.AreNotEqual(string.Empty, authToken.access_token);
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }
    }
}
