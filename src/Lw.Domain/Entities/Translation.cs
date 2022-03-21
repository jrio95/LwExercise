using System;
using System.Collections.Generic;
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
        /// Sentence identifier
        /// </summary>
        public string Sentence { get; set; }
    }
}
