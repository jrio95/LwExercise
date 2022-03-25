using Lw.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.DTO.DTOs
{
    /// <summary>
    /// Translation DTO
    /// </summary>
    public class TranslationDTO
    {
        /// <summary>
        /// Translation identifier
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Language ISO
        /// </summary>
        public LanguageEnum LanguageISO { get; set; }

        /// <summary>
        /// Translated sentence
        /// </summary>
        public string TranslatedSentence { get; set; }
    }
}
