using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Gestao_Clientes.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Listar",
                routeTemplate: "api/{controller}",
                defaults: new { action = "Listar" }
            );

            config.Routes.MapHttpRoute(
                name: "BuscaPorCpf",
                routeTemplate: "api/{controller}/{cpf}",
                defaults: new { action = "BuscaPorCpf", cpf = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Remover",
                routeTemplate: "api/{controller}/{cpf}",
                defaults: new { action = "Remover", cpf = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }
    }
}
