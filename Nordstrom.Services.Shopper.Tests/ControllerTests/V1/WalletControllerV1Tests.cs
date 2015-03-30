
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Nordstrom.Services.OwinSelfHostServer;
using Nordstrom.Services.Shopper.Contracts;
using Nordstrom.Services.Shopper;

namespace Nordstrom.Services.Shopper.Tests.ControllerTests.V1
{
    [TestClass]
    public class WalletControllerV1Tests
    {
        /// <summary>
        /// OWIN Host for Testing Requests
        /// </summary>
        static Server<OwinStartUp> server;

        /// <summary>
        /// Base address for test host. 
        /// </summary>
        static Uri baseUri = new Uri("http://localhost:8085");

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            server = Server<OwinStartUp>.Create(baseUri: baseUri);
        }

        [TestMethod]
        public async Task WalletControllerV1_TestGetWallet_Success()
        {
            Guid correlationId = Guid.NewGuid();
            var response = await server.CreateRequestAsync<string>(
                HttpMethod.Get,
                "/wallet/" + Guid.NewGuid().ToString(),
                version: 0.1,
                correlationId: correlationId);
            var json = await response.Content.ReadAsStringAsync();
            var wallet = JsonConvert.DeserializeObject<WalletV1>(json);
            Assert.IsTrue(wallet != null, "Wallet is null");
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Status Code is not correct");

        }

        [TestMethod]
        public async Task WalletControllerV1_TestGetWallet_InvalidShopperId()
        {
            Guid correlationId = Guid.NewGuid();
            var response = await server.CreateRequestAsync<string>(
                HttpMethod.Get,
                "/wallet/invalid",
                version: 0.1,
                correlationId: correlationId);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest, "Status Code is not correct");
        }
    }
}
