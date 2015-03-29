// Copyright (c) Nordstrom 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Nordstrom.Services.Shopper.Contracts
{
    public class WalletV1
    {
        [JsonProperty(PropertyName = "creditCards")]
        public CreditCardV1[] CreditCards
        {
            get;
            set;
        }
    }
}