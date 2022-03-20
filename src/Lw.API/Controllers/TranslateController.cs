using Microsoft.AspNetCore.Mvc;

namespace Lw.API.Controllers
{
    /// <summary>
    /// Translate controller
    /// </summary>
    [ApiController]  
    [Route("lw")]
    public class TranslateController : ControllerBase
    {
        private readonly ILogger<TranslateController> _logger;

        /// <summary>
        /// Translate controller ctor
        /// </summary>
        /// <param name="logger"></param>
        public TranslateController(ILogger<TranslateController> logger)
        {
            _logger = logger;
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