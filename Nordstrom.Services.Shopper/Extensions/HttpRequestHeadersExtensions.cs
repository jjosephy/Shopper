// Copyright (c) Nordstrom 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Nordstrom.Services.Shopper.Constants;
using Nordstrom.Services.Shopper.Exceptions;

namespace Nordstrom.Services.Shopper.Extensions
{
    public static class HttpRequestHeadersExtensions
    {
        public static double GetVersionRequestHeader(this HttpRequestHeaders headers)
        {
            var version = headers.Where(header =>
                   header.Key.Equals(ShopperConstants.VersionHeader, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (version.Key == null || version.Value == null || !version.Value.Any())
            {
                // If version header is not provided then throw
                throw ShopperException.InvalidVersionHeader();
            }

            double parsed = 0;
            if (double.TryParse(version.Value.FirstOrDefault(), out parsed))
            {
                return parsed;
            }

            throw new ArgumentException("could not parse version header");
        }

        public static Guid GetCorrelationIdRequestHeader(this HttpRequestHeaders headers)
        {
            var version = headers.Where(header =>
                   header.Key.Equals(ShopperConstants.CorrelationIdHeader, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            Guid correlationId = Guid.Empty;
            if (version.Key == null || version.Value == null || !version.Value.Any())
            {
                // If correlation header is not provided then throw
                correlationId = Guid.NewGuid();
            }
            else
            {
                if ( Guid.TryParse(version.Value.FirstOrDefault(), out correlationId) )
                {
                    return correlationId;
                }
            }

            throw new ArgumentException("could not parse correlation Id header");
        }
    }
}