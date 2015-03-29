using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Nordstrom.Services.Shopper.Contracts;

namespace Nordstom.Services.Shopper.Tests
{
    [TestClass]
    public class AddressV1Tests
    {
        [TestMethod]
        public void Test_SerializeAddress()
        {
            var address = new AddressV1
            {
                Address1 = "1 Address Way",
                Address2 = "2 Address Way",
                City = "City",
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleInitial = "MI",
                Phone = "123456789",
                State = "WA",
                Zip = "98133"
            };

            var json = JsonConvert.SerializeObject(address);
        }
    }
}
