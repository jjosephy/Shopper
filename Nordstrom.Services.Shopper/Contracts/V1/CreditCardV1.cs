// Copyright (c) Nordstrom 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Nordstrom.Services.Shopper.Contracts
{
    public class CreditCardV1
    {
        [JsonProperty(PropertyName = "billingAddress")]
        public AddressV1 BillingAddress
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "bin")]
        public AddressV1 Bin
        {
            get;
            set;
        }

        // TODO: find all card types and make this an enum
        [JsonProperty(PropertyName = "cardType")]
        public string CardType
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "cvv")]
        public string Cvv
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "expirationId")]
        public DateTime ExpirationDate
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "lastFour")]
        public string LastFour
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "lowValueToken")]
        public string LowValueToken
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "highValueToken")]
        public string HighValueToken
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "pan")]
        public string Pan
        {
            get;
            set;
        }
    }
}