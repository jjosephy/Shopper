// Copyright (c) Nordstrom 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Nordstrom.Services.Shopper.Contracts;
using Nordstrom.Services.Shopper.Extensions;
using Nordstrom.Services.Shopper.HttpContentFormatters;
using Nordstrom.Services.Shopper.Exceptions;

namespace Nordstrom.Services.Shopper.Controllers
{
    public class WalletController : ApiController
    {
        public Task<HttpResponseMessage> Get(string id)
        {
            Guid shopperGuid = Guid.Empty;
            if ( !Guid.TryParse(id, out shopperGuid) )
            {
                throw ShopperException.InvalidShopperId();
            }

            var context = this.CreateRequestContext();
            var wallet = new WalletV1
            {
                CreditCards = new List<CreditCardV1>(1) 
                { 
                    new CreditCardV1
                    {
                        BillingAddress = new AddressV1
                        {
                            Address1 = "1 Address Way",
                            City = "City",
                            FirstName = "first Name",
                            LastName = "last name",
                            Phone = "1234444444",
                            State = "ST",
                            Zip = "98122"
                        },
                        CardType = "VISA"
                    }
                }
            };

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new JsonContent<WalletV1>(wallet as WalletV1),
                
            });
        }
    }
}
