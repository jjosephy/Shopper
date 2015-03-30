// Copyright (c) Nordstrom 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Nordstrom.Services.Shopper.Context;

namespace Nordstrom.Services.Shopper.Extensions
{
    public static class ApiControllerExtensions
    {
        public static IShopperRequestContext CreateRequestContext(this ApiController controller)
        {
            return new ShopperRequestContext
            {
                Version = controller.Request.Headers.GetVersionRequestHeader(),
                CorrelationId = controller.Request.Headers.GetCorrelationIdRequestHeader()
            };
        }
    }
}