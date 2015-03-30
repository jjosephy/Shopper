using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nordstrom.Services.Shopper.Context
{
    public class ShopperRequestContext : IShopperRequestContext
    {
        public double Version
        {
            get;
            set;
        }

        public Guid CorrelationId
        {
            get;
            set;
        }
    }
}