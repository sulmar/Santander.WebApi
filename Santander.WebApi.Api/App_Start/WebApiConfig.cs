using FluentValidation.WebApi;
using Microsoft.Practices.Unity;
using Santander.WebApi.Api.Constraints;
using Santander.WebApi.Api.Filters;
using Santander.WebApi.Api.Handlers;
using Santander.WebApi.FakeRepositories;
using Santander.WebApi.Fakers;
using Santander.WebApi.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Routing;

namespace Santander.WebApi.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services


            config.MessageHandlers.Add(new LoggerMessageHandler());
            config.MessageHandlers.Add(new FormatMessageHandler());

        

            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICustomerRepository, FakeCustomerRepository>();
            container.RegisterType<IProductRepository, FakeProductRepository>();

            container.RegisterType<IAuthenticationFilter, BasicAuthenticationFilter>();


            container.RegisterInstance(new CustomerFaker());
            container.RegisterInstance(new ProductFaker());


            config.DependencyResolver = new UnityDependencyResolver(container);

            config.Filters.Add(container.Resolve<IAuthenticationFilter>());


            // Install-Package FluentValidation.WebApi
            FluentValidationModelValidatorProvider.Configure(config);

            //var constraintResolver = new DefaultInlineConstraintResolver();
            //constraintResolver.ConstraintMap.Add("color", typeof(ColorConstraint));
            //config.MapHttpAttributeRoutes(constraintResolver);

            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

         
        }
    }
}
