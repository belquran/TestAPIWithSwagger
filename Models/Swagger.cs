using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection.Metadata;

namespace SwaggerVersion
{
    /// <summary>
    /// روژن بندی سواگر
    /// </summary>
    public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerNamespace = controller.ControllerType.Namespace; // e.g. "Controllers.V1"
            var apiVersion = controllerNamespace.Split('.').Last().ToLower();

            controller.ApiExplorer.GroupName = apiVersion;
        }
    }

    /// <summary>
    ///توضیحات اضافه از HTML
    /// </summary>
    public class TestDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
           
            swaggerDoc.Info.Description = "Custom HTML" +
                                          "<ul>" +
                                          "<li>1</li>" +
                                          "<li><b>2</b></li>" +
                                          "</ul>";
        }
    }


}
