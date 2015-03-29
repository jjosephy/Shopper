
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nordstrom.Services.Shopper.Contracts;
using Nordstrom.Services.Shopper.Enum;

namespace Nordstrom.Services.Shopper.Tests.Extensions
{
    public static class AddressExtensions
    {
        public static AddressV1 CreateAddressV1(
            string address1 = "1 Address Way",
            string address2 = "2 Address Way",
            AddressType addressType = AddressType.Billing,
            string city = "City",
            string firstName = "FirstName",
            string lastName = "LastName",
            string middleInitial = "MI",
            string phone = "Phone",
            string state = "State",
            string zip = "Zip")
        {
            return new AddressV1
            {
                Address1 = address1,
                Address2 = address2,
                AddressType = addressType,
                City = city,
                FirstName = firstName,
                LastName = lastName,
                MiddleInitial = middleInitial,
                Phone = phone,
                State = state,
                Zip = zip
            };
        }
    }
}
