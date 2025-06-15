using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtmBuider.ValueObjects;
using UtmBuider.ValueObjects.Exceptions;

namespace UtmBuilder.UtmlBuilder.Core.Tests.ValueObject
{
    [TestClass]
    public class UrlTests
    {
        [TestMethod(displayName: "Deve retornar um exceção quando a URL for inválida")]
        [TestCategory("Teste de URL")]
        [ExpectedException(typeof(InvalidUrlException))]
        public void ShouldReturnExceptionWhenUrlIsInvalid()
        {
            new Url("banana");
        }

        [TestMethod]
        public void ShouldNotReturnExceptionWhenUrlIsValid()
        {
            new Url("https://balta.io");
            Assert.IsTrue(true);
        }

        [TestMethod]
        [DataRow("", true)]
        [DataRow("banana", true)]
        [DataRow("http", true)]
        [DataRow("https://balta.io", false)]
        public void TestUrl(string link, bool expectedExeception)
        {
            if (expectedExeception)
            {
                try
                {
                    new Url(link);
                    Assert.Fail();
                }
                catch (InvalidUrlException)
                {
                    Assert.IsTrue(true);
                }
            }

            else
            {
                new Url(link);
                Assert.IsTrue(true);
            }
        }
    }
}