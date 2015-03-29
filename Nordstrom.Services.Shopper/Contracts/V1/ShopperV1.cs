// Copyright (c) Nordstrom 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Nordstrom.Services.Shopper.Contracts
{
    public class ShopperV1
    {
        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "billingAddress")]
        public AddressV1 BillingAddress
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "shippingAddress")]
        public AddressV1 ShippingAddress
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "shopperId")]
        public Guid? ShopperId
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "wallet")]
        public WalletV1 Wallet
        {
            get;
            set;
        }
    }
}