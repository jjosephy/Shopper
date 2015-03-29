using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Nordstrom.Services.Shopper.Contracts;
using Nordstrom.Services.Shopper.Enum;
using Nordstrom.Services.Shopper.Tests.Extensions;

namespace Nordstom.Services.Shopper.Tests
{
    [TestClass]
    public class AddressV1Tests
    {
        [TestMethod]
        public void Test_SerializeBillingAddressV1()
        {
            var address = AddressExtensions.CreateAddressV1();
            var json = JsonConvert.SerializeObject(address, new StringEnumConverter());
            var deserialized = JsonConvert.DeserializeObject<AddressV1>(json);
            Assert.IsTrue(deserialized.AddressType.Equals(AddressType.Billing), "AddressType is not Billing");
        }
    }
}
