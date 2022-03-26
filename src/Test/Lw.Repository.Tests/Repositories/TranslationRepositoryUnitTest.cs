using Lw.Domain.Entities;
using Lw.Repository;
using Lw.Repository.Repositories;
using Lw.Repository.Tests;
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
    public class TranslationControllerUnitTest
    {
        private ITranslationRepository _translationRepositoryMock;
        private Mock<ApiDbContext> _mockApiDbContext;
     

        #region set up mock and methods

        public Mock<ApiDbContext> SetUpDbContext()
        {
            var _mockApiDbContext = new Mock<ApiDbContext>();
            _mockApiDbContext.Setup(x => x.Translations).Returns(ApiDbContextMock.GetMockDbSet<Translation>(ListTranslationMock().ToList()).Object);

            return _mockApiDbContext;
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
            var _mockApiDbContext = SetUpDbContext();
            _translationRepositoryMock = new TranslationRepository(_mockApiDbContext.Object);
        }

        [TestMethod]
        public void GetTranslation_BySentenceId_ThenReturnTranslationList()
        {
            var helloSentenceId = 1;

            var translations = _translationRepositoryMock.GetTranslationListBySentenceId(helloSentenceId);
            var translationList = translations.ToList();

            Assert.IsTrue(translationList.Count() == 2);
        }

        [TestMethod]
        public void GetTranslation_ByWrongSentenceId_ThenReturnsEmpty()
        {
            var wrongSentenceId = 2;

            var translations = _translationRepositoryMock.GetTranslationListBySentenceId(wrongSentenceId);
            var translationList = translations.ToList();

            Assert.IsFalse(translationList.Any());
        }

        [TestMethod]
        public void GetTranslation_BySentenceIdAndLanguageId_ThenReturnsSpecifiedTranslation()
        {
            var translationMock = TranslationMock();

            var translations = _translationRepositoryMock.GetTranslationByLanguageIdAndSentenceId(translationMock.LanguageId, translationMock.SentenceId);

            Assert.AreEqual(translations.TranslationId, translationMock.TranslationId);
            Assert.AreEqual(translations.SentenceId, translationMock.SentenceId);
            Assert.AreEqual(translations.LanguageId, translationMock.LanguageId);
            Assert.AreEqual(translations.TranslatedSentence, translationMock.TranslatedSentence);
        }

        [TestMethod]
        public void GetTranslation_ByWrongSentenceIdAndLanguageId_ThenReturnsNull()
        {
            var wrongSentenceId = 2;
            var wrongLanguageId = 80;

            var translations = _translationRepositoryMock.GetTranslationByLanguageIdAndSentenceId(wrongLanguageId, wrongSentenceId);

            Assert.IsNull(translations);
        }
    }
}
