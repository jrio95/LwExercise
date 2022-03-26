using AutoMapper;
using Lw.Domain.Entities;
using Lw.DTO.DTOs;
using Lw.DTO.Enums;
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
    public class TranslationServiceUnitTest
    {
        private ITranslationService _translationService;
        private ITranslationRepository _translationRepositoryMock;
        private static IMapper _mapper;

        #region set up mock and methods

        public ITranslationRepository SetUpTranslationRepository()
        {
            var translationRepositoryMock = new Mock<ITranslationRepository>();
            translationRepositoryMock.Setup(x => x.GetTranslationListBySentenceId(It.IsAny<int>())).Returns(ListTranslationMock());
            translationRepositoryMock.Setup(x => x.GetTranslationByLanguageIdAndSentenceId((int)LanguageEnum.es_ES, It.IsAny<int>())).Returns(TranslationMock());

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
                LanguageISO = LanguageEnum.es_ES,
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
                SentenceId = 1,
                TranslatedSentence = "Hola"
            };
        }

        public IEnumerable<Translation> ListTranslationMock()
        {
            var spanishSentence = new Translation()
            {
                TranslationId = 1,
                LanguageId = 2,
                SentenceId = 1,
                TranslatedSentence = "Hola"
            };

            var englishSentence = new Translation()
            {
                TranslationId = 2,
                LanguageId = 1,
                SentenceId = 1,
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

        [TestMethod]
        public void GetTranslation_WithNoLanguage_ThenReturnTranslationList()
        {
            var translationListMock = ListTranslationMock().ToList();
            var helloSentenceId = 1;

            var translations = _translationService.GetTranslation(null, helloSentenceId);
            var translationList = translations.ToList();

            Assert.AreEqual(translationList[0].TranslationId, translationListMock[0].TranslationId);
            Assert.AreEqual((int)translationList[0].LanguageISO, translationListMock[0].LanguageId);
            Assert.AreEqual(translationList[0].TranslatedSentence, translationListMock[0].TranslatedSentence);

            Assert.AreEqual(translationList[1].TranslationId, translationListMock[1].TranslationId);
            Assert.AreEqual((int)translationList[1].LanguageISO, translationListMock[1].LanguageId);
            Assert.AreEqual(translationList[1].TranslatedSentence, translationListMock[1].TranslatedSentence);
        }

        [TestMethod]
        public void GetTranslation_WithSpecifiedLanguage_ThenReturnSpecifiedTranslation()
        {
            var translationMock = TranslationMock();
            var helloSentenceId = 1;

            var translationsResult = _translationService.GetTranslation(DTO.Enums.LanguageEnum.es_ES, helloSentenceId);
            var translationResultList = translationsResult.ToList();

            Assert.IsTrue(translationResultList.Any());
            Assert.IsTrue(translationResultList.Count == 1);
            Assert.AreEqual(translationResultList[0].TranslationId, translationMock.TranslationId);
            Assert.AreEqual((int)translationResultList[0].LanguageISO, translationMock.LanguageId);
            Assert.AreEqual(translationResultList[0].TranslatedSentence, translationMock.TranslatedSentence);
        }
    }
}
