using Lw.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.Repository.Repositories
{
    /// <summary>
    /// ITranslationRepository
    /// </summary>
    public interface ITranslationRepository
    {
        /// <summary>
        /// Returns de translation by lenguage and sentence
        /// </summary>
        /// <param name="languageId">Lenguage identifier</param>
        /// <param name="sentenceId">Sentence identifier</param>
        Translation GetTranslationByLanguageIdAndSentenceId(int languageId, int sentenceId);

        /// <summary>
        /// Returns the translation list by lenguage and sentence
        /// </summary>
        /// <param name="sentenceId">Sentence identifier</param>
        IEnumerable<Translation> GetTranslationListBySentenceId(int sentenceId);
    }
}
