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
        /// <param name="logger"></param>
        public TranslationController(ITranslationService translationService)
        {
            this._translationService = translationService;
        }

        /// <summary>
        /// Get translate endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet("translate")]
        public IEnumerable<ActionResult> Get()
        {
            return null;
        }
    }
}