using Lw.DTO.DTOs;
using Lw.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.Service.Services
{
    /// <summary>
    /// Translation service
    /// </summary>
    public class TranslationService : ITranslationService
    {
        /// <summary>
        /// Translation repository
        /// </summary>
        private readonly ITranslationRepository _translationRepository;

        /// <summary>
        /// Translate service ctor
        /// </summary>
        public TranslationService(ITranslationRepository translationRepository)
        {
            this._translationRepository = translationRepository;
        }

        /// <summary>
        /// Gets the translation
        /// </summary>
        /// <returns></returns>
        public TranslationDTO GetTranslation()
        {
            return new TranslationDTO();
        }
    }
}
