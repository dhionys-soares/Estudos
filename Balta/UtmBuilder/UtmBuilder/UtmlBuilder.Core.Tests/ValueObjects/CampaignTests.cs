using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtmBuider.ValueObjects;
using UtmBuider.ValueObjects.Exceptions;

namespace UtmBuilder.UtmlBuilder.Core.Tests.ValueObject
{
    [TestClass]
    public class CampaignTests
    {
        [TestMethod]
        [DataRow("", "", "", true)]
        [DataRow("src", "", "", true)]
        [DataRow("src", "med", "", true)]
        [DataRow("src", "med", "nme", false)]

        public void TestCampaign(string source, string medium, string name, bool expectedException)
        {
            if (expectedException)
            {
                try
                {
                    new Campaign(source, medium, name);
                    Assert.Fail();
                }
                catch (InvalidCampaignException)
                {
                    Assert.IsTrue(true);
                }
            }

            else
            {
                new Campaign(source, medium, name);
                Assert.IsTrue(true);
            }
        }
    }
}