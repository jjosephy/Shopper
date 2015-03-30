﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Nordstrom.Services.Shopper.HttpContentFormatters
{
    public class JsonContent<T> : HttpContent
    {
        const string ContentType = "application/json";
        readonly MemoryStream stream = new MemoryStream();

        public JsonContent(T value)
        {
            this.Headers.ContentType = new MediaTypeHeaderValue(ContentType);
            InitializeContent(value);
        }

        protected override Task SerializeToStreamAsync(
            Stream stream,
            TransportContext context)
        {
            return this.stream.CopyToAsync(stream);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.stream != null)
                {
                    this.stream.Dispose();
                }
            }

            base.Dispose(disposing);
        }
        protected override bool TryComputeLength(out long length)
        {
            length = 0;
            if ( this.stream == null )
            {
                return false;
            }

            length = this.stream.Length;
            return true;
        }

        private void InitializeContent(T value)
        {
            var serializer = new JsonSerializer();
            var writer = new JsonTextWriter(new StreamWriter(this.stream));

            serializer.Serialize(writer, value);
            writer.Flush();
            this.stream.Position = 0;
        }
    }
}