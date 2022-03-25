using Lw.API.Filters;
using Lw.DTO.DTOs;
using Lw.DTO.Enums;
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
        /// Get translation endpoint
        /// </summary>
        /// <returns>List of translations</returns>
        [HttpGet("translate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TranslationDTO>))]
        public ActionResult Get()
        {
            List<TranslationDTO> result = new List<TranslationDTO>();

            LanguageEnum? lang = AcceptLanguageFilter.GetEnumFromAcceptLanguage(Request.Headers["Accept-Language"]);
            result = _translationService.GetTranslation(lang, 1).ToList();

            return StatusCode(200, result);
        }
    }
}