// Copyright (c) Nordstrom 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Nordstrom.Services.Shopper.Enum;

namespace Nordstrom.Services.Shopper.Contracts
{
    public class AddressV1
    {
        [JsonProperty(PropertyName = "address1", Required = Required.Always)]
        public string Address1
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "address2", Required = Required.Default)]
        public string Address2
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "addressType", Required = Required.Default)]
        public AddressType AddressType
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "city", Required = Required.Always)]
        public string City
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "firstName", Required = Required.Always)]
        public string FirstName
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "lastName", Required = Required.Always)]
        public string LastName
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "middleInitial", Required = Required.Default)]
        public string MiddleInitial
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "phone", Required = Required.Always)]
        public string Phone
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "state", Required = Required.Always)]
        public string State
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "zip", Required = Required.Always)]
        public string Zip
        {
            get;
            set;
        }
    }
}