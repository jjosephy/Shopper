// Copyright (c) Nordstrom 2015

using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Microsoft.Owin;
using Nordstrom.Services.Shopper.Resolvers;

[assembly: OwinStartupAttribute(typeof(Nordstrom.Services.Shopper.OwinStartUp))]
namespace Nordstrom.Services.Shopper
{
    public class OwinStartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            bool loadAssemblies = false;
            if ( bool.TryParse(ConfigurationManager.AppSettings["LoadAssemblyForTest"], out loadAssemblies) )
            {
                config.Services.Replace(typeof(IAssembliesResolver), new AssemblyResolver());
            }

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            app.UseWebApi(config);
        }
    }
}