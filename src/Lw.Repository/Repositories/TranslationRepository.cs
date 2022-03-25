using Lw.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.Repository.Repositories
{
    /// <summary>
    /// TranslationRepository
    /// </summary>
    public class TranslationRepository : ITranslationRepository
    {
        private readonly ApiDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public TranslationRepository(ApiDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Returns the translation by lenguage and sentence
        /// </summary>
        /// <param name="languageId">Lenguage identifier</param>
        /// <param name="sentenceId">Sentence identifier</param>
        public Translation GetTranslationByLanguageIdAndSentenceId(int languageId, int sentenceId)
        {
            return _context.Translations.SingleOrDefault(x => x.LanguageId == languageId && x.SentenceId == sentenceId);
        }

        /// <summary>
        /// Returns the translation list by lenguage and sentence
        /// </summary>
        /// <param name="sentenceId">Sentence identifier</param>
        public IEnumerable<Translation> GetTranslationListBySentenceId(int sentenceId)
        {
            return _context.Translations.Where(x => x.SentenceId == sentenceId);
        }
    }
}
