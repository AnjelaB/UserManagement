using System.Web.Http;
using WebActivatorEx;
using UserManagement;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace UserManagement
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
              .EnableSwagger(c => c.SingleApiVersion("v1", "UserManagement"))
              .EnableSwaggerUi();
        }
    }
}
