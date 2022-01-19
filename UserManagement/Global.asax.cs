using System.Web.Http;

namespace UserManagement
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configure(SwaggerConfig.Register);
        }
    }
}
