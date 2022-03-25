using Lw.DTO.DTOs;
using Lw.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.Service.Services
{
    /// <summary>
    /// ITranslateService
    /// </summary>
    public interface ITranslationService
    {
        /// <summary>
        /// Gets the translation
        /// </summary>
        /// <param name="language">Language to filter</param>
        /// <param name="sentenceId">Sentence identifier</param>
        /// <returns>The translation</returns>
        IEnumerable<TranslationDTO> GetTranslation(LanguageEnum? language, int sentenceId);
    }
}
