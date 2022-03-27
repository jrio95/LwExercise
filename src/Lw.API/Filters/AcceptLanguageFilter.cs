using Lw.DTO.Enums;
using Lw.DTO.Exceptions;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lw.API.Filters
{
    /// <summary>
    /// AcceptLanguageFilter
    /// </summary>
    public class AcceptLanguageFilter : IOperationFilter
    {
        /// <summary>
        /// Apply headers open api documentation
        /// </summary>
        /// <param name="operation">The operation</param>
        /// <param name="context">The context</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Description = "Language to translate the sentence if it is null, all available translations will be returned",
                Schema = new OpenApiSchema()
                {
                    Type = "String",
                    Enum = new List<IOpenApiAny>
                    {
                        new OpenApiString("en-US"),
                        new OpenApiString("es-ES"),
                        new OpenApiString("fr-FR"),
                        new OpenApiString("de-DE"),
                        new OpenApiString("pt-PT")
                    }
                }
            });
        }

        /// <summary>
        /// Gets the enum language from the accept language header
        /// </summary>
        /// <param name="headerValue">The header value</param>
        /// <returns></returns>
        /// <exception cref="ApiBadRequestException">Bad request in case the language is not supported</exception>
        public static LanguageEnum? GetEnumFromAcceptLanguage(string headerValue)
        {
            if (string.IsNullOrEmpty(headerValue))
            {
                return null;
            }

            if (!Enum.TryParse(headerValue.Replace("-", "_"), out LanguageEnum lang))
            {
                throw new ApiBadRequestException(String.Format("Specified Accept-Language {0} not supported", headerValue));
            }

            return lang;
        }
    }
}
