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

namespace Nordstrom.Services.Shopper.Controllers
{
    public class WalletController : ApiController
    {
        public Task<HttpResponseMessage> Get(Guid id)
        {
            var context = this.CreateRequestContext();
            var wallet = new WalletV1
            {
                CreditCards = new List<CreditCardV1>(1) 
                { 
                    new CreditCardV1
                    {
                        BillingAddress = new AddressV1
                        {

                        },
                        CardType = "VISA"
                    }
                }
            };

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new JsonContent<WalletV1>(wallet as WalletV1)
            });
        }
    }
}
