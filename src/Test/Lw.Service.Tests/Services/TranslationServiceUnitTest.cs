using AutoMapper;
using Lw.Domain.Entities;
using Lw.DTO.DTOs;
using Lw.DTO.Mappings;
using Lw.Repository.Repositories;
using Lw.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.API.Tests.Controllers
{
    [TestClass]
    public class TranslationRepositoryUnitTest
    {
        private ITranslationService _translationService;
        private ITranslationRepository _translationRepositoryMock;
        private static IMapper _mapper;

        #region set up mock and methods

        public ITranslationRepository SetUpTranslationRepository()
        {
            var translationRepositoryMock = new Mock<ITranslationRepository>();
            translationRepositoryMock.Setup(x => x.GetTranslationListBySentenceId(It.IsAny<int>())).Returns(ListTranslationMock());
            translationRepositoryMock.Setup(x => x.GetTranslationByLanguageIdAndSentenceId(It.IsAny<int>(), It.IsAny<int>())).Returns(TranslationMock());

            return translationRepositoryMock.Object;
        }

        public IMapper SetUpAutoMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });
            return mappingConfig.CreateMapper();
        }

        public TranslationDTO TranslationDTOMock()
        {
            return new TranslationDTO()
            {
                TranslationId = 1,
                LanguageISO = DTO.Enums.LanguageEnum.es_ES,
                TranslatedSentence = "Hola"
            };
        }

        public IEnumerable<TranslationDTO> ListTranslationDTOMock()
        {
            var englishSentence = new TranslationDTO()
            {
                TranslationId = 1,
                LanguageISO = DTO.Enums.LanguageEnum.es_ES,
                TranslatedSentence = "Hola"
            };

            var spanishSentence = new TranslationDTO()
            {
                TranslationId = 2,
                LanguageISO = DTO.Enums.LanguageEnum.en_US,
                TranslatedSentence = "Hi"
            };

            return new List<TranslationDTO>() { englishSentence, spanishSentence };
        }

        public Translation TranslationMock()
        {
            return new Translation()
            {
                TranslationId = 1,
                LanguageId = 2,
                TranslatedSentence = "Hola"
            };
        }

        public IEnumerable<Translation> ListTranslationMock()
        {
            var spanishSentence = new Translation()
            {
                TranslationId = 1,
                LanguageId = 2,
                TranslatedSentence = "Hola"
            };

            var englishSentence = new Translation()
            {
                TranslationId = 2,
                LanguageId = 1,
                TranslatedSentence = "Hi"
            };

            return new List<Translation>() { englishSentence, spanishSentence };
        }

        #endregion

        [TestInitialize]
        public void Initialize()
        {
            this._translationRepositoryMock = SetUpTranslationRepository();
            _mapper = SetUpAutoMapper();
            _translationService = new TranslationService(_translationRepositoryMock, _mapper);
        }
    }
}
