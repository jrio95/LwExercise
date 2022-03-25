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
        /// Gets the translations
        /// </summary>
        /// <param name="language">Language to filter, if its null it will return all available languages</param>
        /// <param name="sentenceId">Sentence identifier</param>
        /// <returns>The translations</returns>
        IEnumerable<TranslationDTO> GetTranslation(LanguageEnum? language, int sentenceId);
    }
}
