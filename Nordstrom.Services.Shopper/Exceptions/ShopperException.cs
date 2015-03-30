// Copyright (c) Nordstrom 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Nordstrom.Services.Shopper.Contracts;
using Nordstrom.Services.Shopper.HttpContentFormatters;

namespace Nordstrom.Services.Shopper.Exceptions
{
    public class ShopperException : HttpResponseException
    {
        public ShopperException(
            string message, 
            uint errorCode = 0x0,
            HttpStatusCode statusCode = HttpStatusCode.OK) :
                base(CreateMessage(message, errorCode, statusCode))
        {
        }

        public static HttpResponseException InvalidVersionHeader()
        {
            const string message = "Invalid Version Header provided";
            return new ShopperException(message, ErrorCodes.InvalidVersionHeader, HttpStatusCode.BadRequest);
        }

        public static HttpResponseException InvalidShopperId()
        {
            const string message = "Provided Shopper Id is Invalid";
            return new ShopperException(message, ErrorCodes.InvalidShopperId, HttpStatusCode.BadRequest);
        }

        static HttpResponseMessage CreateMessage(
            string message,
            uint errorCode,
            HttpStatusCode statusCode)
        {
            return new HttpResponseMessage
            {
                Content = new JsonContent<ErrorDetailsV1>(
                    new ErrorDetailsV1
                    {
                        Details = message,
                        ErrorCode = errorCode,
                        StatusCode = statusCode
                    }),
                StatusCode = statusCode
            };
        }
    }
}