﻿using AutoMapper;
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
        /// Configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Translate service ctor
        /// </summary>
        public TranslationService(ITranslationRepository translationRepository, IConfiguration configuration, IMapper mapper)
        {
            this._translationRepository = translationRepository;
            this._configuration = configuration;
            this._mapper = mapper;
         }

        /// <summary>
        /// Gets the translation
        /// </summary>
        /// <param name="language">Language to filter</param>
        /// <param name="sentenceId">Sentence identifier</param>
        /// <returns>The translation</returns>
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
