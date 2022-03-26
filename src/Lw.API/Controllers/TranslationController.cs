using Lw.API.Filters;
using Lw.DTO.DTOs;
using Lw.DTO.Enums;
using Lw.DTO.Exceptions;
using Lw.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lw.API.Controllers
{
    /// <summary>
    /// Translate controller
    /// </summary>
    [ApiController]  
    [Route("lw")]
    public class TranslationController : ControllerBase
    {
        /// <summary>
        /// Translation service
        /// </summary>
        private readonly ITranslationService _translationService;

        /// <summary>
        /// Translate controller ctor
        /// </summary>
        public TranslationController(ITranslationService translationService)
        {
            this._translationService = translationService;
         }

        /// <summary>
        /// Get translation endpoint. If the language is specified it will return the translation in that language. 
        /// If the Accept-Language header is not specified it will return all available languages
        /// </summary>
        /// <returns>List of translations</returns>
        [HttpGet("translate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TranslationDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ErrorDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<ErrorDTO>))]
        public ActionResult GetTranslation()
        {
            List<TranslationDTO> result = new List<TranslationDTO>();
            int helloSentenceId = 1;
            var a = HttpContext.Request.GetTypedHeaders().AcceptLanguage;

            LanguageEnum? lang = AcceptLanguageFilter.GetEnumFromAcceptLanguage(HttpContext.Request.GetTypedHeaders().AcceptLanguage.Select(x => x.Value).FirstOrDefault().ToString());
            result = _translationService.GetTranslation(lang, helloSentenceId).ToList();
            if(!result.Any())
                throw new ApiNotFoundException("No translations were found");

            return Ok(result);
        }
    }
}