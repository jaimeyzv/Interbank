using Intercorp.Api;
using Swashbuckle.Application;
using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Intercorp.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                 .EnableSwagger(c =>
                 {
                     var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\bin\";
                     var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                     var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                     c.SingleApiVersion("v1", "Chatroom Api")
                       .Description("This API is about chatroom where many people can send and receive messages from others.")
                       .TermsOfService("")
                       .Contact(cc => cc
                       .Name("Jaime Yampiere Zamora Vasquez")
                       .Url("https://www.linkedin.com/in/jaimeyzv/")
                       .Email("jyzamorav@gmail.com"));

                     c.IncludeXmlComments(commentsFile);

                 })
                 .EnableSwaggerUi();            
        }
    }
}
