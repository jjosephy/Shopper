
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nordstrom.Services.Shopper.Contracts;
using Nordstrom.Services.Shopper.Tests.Extensions;

namespace Nordstrom.Services.Shopper.Tests
{
    [TestClass]
    public class ShopperV1Tests
    {
        [TestMethod]
        public void Test_SerializeShopperV1()
        {
            var shopper = new ShopperV1
            {
                BillingAddress = AddressExtensions.CreateAddressV1(),
                ShippingAddress = AddressExtensions.CreateAddressV1(addressType: Enum.AddressType.Shipping)
            };

            var t = shopper.Wallet;
        }
    }
}
