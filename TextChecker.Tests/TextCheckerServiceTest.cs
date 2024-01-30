using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextChecker.Services;

namespace TextChecker.Tests
{
    [TestClass]
    public class TextCheckerServiceTest
    {
        TextCheckerService _sut;

        public TextCheckerServiceTest()
        {
            _sut = new TextCheckerService();
        }

        [DataRow(false, true)]
        [DataRow(true, false)]
        [TestMethod]
        public void CaseSensitiveShouldWork(bool caseSensitive, bool expectedResult)
        {
            // Arange

            // Act
            var result = _sut.CheckText("The quick red fox jump over the lazy dog", "the", caseSensitive, Core.ConditionEnum.StartsWith);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
