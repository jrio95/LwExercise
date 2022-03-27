using Lw.API.Controllers;
using Lw.DTO.DTOs;
using Lw.DTO.Enums;
using Lw.DTO.Exceptions;
using Lw.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private ITranslationService _translationServiceMock;
        private TranslationController _translationController;

        #region set up mock and methods

        public ITranslationService SetUpTranslationService()
        {
            var translationServiceMock = new Mock<ITranslationService>();
            translationServiceMock.Setup(x => x.GetTranslation(It.IsAny<LanguageEnum?>(), It.IsAny<int>())).Returns(ListTranslationDTOMock());
            translationServiceMock.Setup(x => x.GetTranslation(LanguageEnum.pt_PT, It.IsAny<int>())).Returns(new List<TranslationDTO>());

            return translationServiceMock.Object;
        }

        public ITranslationService SetUpTranslationServiceNotFound()
        {
            var translationServiceMock = new Mock<ITranslationService>();
            translationServiceMock.Setup(x => x.GetTranslation(It.IsAny<LanguageEnum?>(), It.IsAny<int>())).Returns(new List<TranslationDTO>());

            return translationServiceMock.Object;
        }

        public IEnumerable<TranslationDTO> ListTranslationDTOMock()
        {
            var spanishSentence = new TranslationDTO()
            {
                TranslationId = 1,
                LanguageISO = DTO.Enums.LanguageEnum.es_ES,
                TranslatedSentence = "Hola"
            };

            var englishSentence = new TranslationDTO()
            {
                TranslationId = 2,
                LanguageISO = DTO.Enums.LanguageEnum.en_US,
                TranslatedSentence = "Hi"
            };

            return new List<TranslationDTO>() { englishSentence, spanishSentence};
        }

        #endregion

        [TestInitialize]
        public void Initialize()
        {
            var httpContext = new DefaultHttpContext();
            this._translationServiceMock = SetUpTranslationService();
            _translationController = new TranslationController(_translationServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };
        }

        [TestMethod]
        public void GetTranslation_ThenSuccess()
        {
            var translationListMock = ListTranslationDTOMock().ToList();

            var actionResult = (OkObjectResult)_translationController.GetTranslation();

            var translationListResult = (List<TranslationDTO>)actionResult.Value;
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            Assert.AreEqual(translationListResult[0].TranslationId, translationListMock[0].TranslationId);
            Assert.AreEqual(translationListResult[0].LanguageISO, translationListMock[0].LanguageISO);
            Assert.AreEqual(translationListResult[0].TranslatedSentence, translationListMock[0].TranslatedSentence);

            Assert.AreEqual(translationListResult[1].TranslationId, translationListMock[1].TranslationId);
            Assert.AreEqual(translationListResult[1].LanguageISO, translationListMock[1].LanguageISO);
            Assert.AreEqual(translationListResult[1].TranslatedSentence, translationListMock[1].TranslatedSentence);
        }

        [TestMethod]
        [ExpectedException(typeof(ApiNotFoundException),
            "No translations were found")]
        public void GetTranslation_ReturnNull_ThenNotFound()
        {
            _translationController.ControllerContext.HttpContext.Request.Headers.AcceptLanguage = "pt-PT";

            _translationController.GetTranslation();

        }
    }
}
