// Copyright (c) Nordstrom 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Dispatcher;
using Nordstrom.Services.Shopper.Controllers;

namespace Nordstrom.Services.Shopper.Resolvers
{
    public class AssemblyResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            return new Assembly[1]
            {
                // Add more handlers here
                typeof(WalletController).Assembly
            };
        }
    }
}