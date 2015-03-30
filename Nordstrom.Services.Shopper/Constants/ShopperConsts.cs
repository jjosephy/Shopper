using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nordstrom.Services.Shopper.Constants
{
    public static class ShopperConstants
    {
        // TODO: reconcile this with common Nordstrom Version Header and Correlation Id Header
        public const string VersionHeader = "x-api-version";
        public const string CorrelationIdHeader = "x-correlation-id";
    }
}