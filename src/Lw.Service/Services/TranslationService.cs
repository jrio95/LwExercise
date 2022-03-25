using AutoMapper;
using Lw.Domain.Entities;
using Lw.DTO.DTOs;
using Lw.DTO.Enums;
using Lw.Repository.Repositories;
using Microsoft.Extensions.Configuration;
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
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Translate service ctor
        /// </summary>
        public TranslationService(ITranslationRepository translationRepository, IMapper mapper)
        {
            this._translationRepository = translationRepository;
            this._mapper = mapper;
         }

        /// <summary>
        /// Gets the translations
        /// </summary>
        /// <param name="language">Language to filter, if its null it will return all available languages</param>
        /// <param name="sentenceId">Sentence identifier</param>
        /// <returns>The translations</returns>
        public IEnumerable<TranslationDTO> GetTranslation(LanguageEnum? language, int sentenceId)
        {
            List<TranslationDTO> translationList = new List<TranslationDTO>();

            if (language == null)
            {
                translationList = _mapper.Map<List<TranslationDTO>>(_translationRepository.GetTranslationListBySentenceId(sentenceId).ToList());
            }
            else 
            { 
                Translation translation = _translationRepository.GetTranslationByLanguageIdAndSentenceId((int)language, sentenceId);
                translationList.Add(_mapper.Map<TranslationDTO>(translation));
            }

            return translationList;
        }
    }
}
