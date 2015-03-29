// Copyright (c) Nordstrom 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nordstrom.Services.Shopper.Contracts;

namespace Nordstrom.Services.Shopper.Controllers
{
    public class WalletController : ApiController
    {
        public IHttpActionResult GetWallet(int id)
        {
            var wallet = new WalletV1
            {
                
            };

            return Ok(wallet);
        }
    }
}
