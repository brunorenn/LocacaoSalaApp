﻿using LocacaoSala.Infra.CrossCutting.IoC;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LocacaoSala.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ContainerManager.Load(config);

            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
