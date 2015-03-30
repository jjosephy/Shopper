// Copyright (c) Nordstrom 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Nordstrom.Services.OwinSelfHostServer
{
    public class Server<T>
    {
        // TODO: find and use standard Nord Header
        const string RequestVersionHeader = "x-api-version";
        const string CorrelationIdHeader = "x-correlation-id";

        readonly Uri baseUri;
        readonly int timeOut;

        private Server(
            Uri baseUri, 
            int timeOut)
        {
            this.baseUri = baseUri;
            this.timeOut = timeOut;
        }

        public static Server<T> Create(
            Uri baseUri,
            int clientTimeout = 60000)
            
        {
            WebApp.Start<T>(url: baseUri.AbsoluteUri);
            return new Server<T>(
                baseUri: baseUri,
                timeOut: clientTimeout);
        }

        public async Task<HttpResponseMessage> CreateRequestAsync<TBody>(
            HttpMethod method,
            string uri,
            TBody value = default(TBody),
            double version = 1.0,
            string contentType = "application/json",
            string versionHeaderName = RequestVersionHeader,
            Guid? correlationId = null)
        {
            var handler = new WebRequestHandler();
            using (var client = new HttpClient(handler)
            {
                BaseAddress = baseUri,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add(versionHeaderName, version.ToString());
                client.DefaultRequestHeaders.Add(CorrelationIdHeader,
                    correlationId == null ? Guid.Empty.ToString() : correlationId.Value.ToString());

                if (method == HttpMethod.Get)
                {
                    return await client.GetAsync(uri);
                }
                else if (method == HttpMethod.Post)
                {
                    return await client.PostAsJsonAsync<TBody>(uri, value);
                }
                else if (method == HttpMethod.Delete)
                {
                    return await client.DeleteAsync(uri);
                }
            }

            throw new NotSupportedException("Method not supported");
        }
    }
}
