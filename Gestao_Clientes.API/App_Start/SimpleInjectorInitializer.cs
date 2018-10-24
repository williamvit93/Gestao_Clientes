using Gestao_Clientes.Infra;
using Gestao_Clientes.WebApi.App_Start;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace Gestao_Clientes.WebApi.App_Start
{

    public class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            var httpConfig = new HttpConfiguration();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            ConfigureDependencyInjection(container);
            ConfigureWebApi(httpConfig);

            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

        }

        private static void ConfigureDependencyInjection(Container container)
        {
            BootStrapperGestaoClientes.Register(container);
        }

        private static void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}

