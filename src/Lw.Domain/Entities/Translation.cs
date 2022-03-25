using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.Domain.Entities
{
    /// <summary>
    /// Translation
    /// </summary>
    public class Translation
    {
        /// <summary>
        /// Translation identifier
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Sentence identifier
        /// </summary>
        public int SentenceId { get; set; }

        /// <summary>
        /// Language identifier
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Translated sentence
        /// </summary>
        public string TranslatedSentence { get; set; }
    }
}
