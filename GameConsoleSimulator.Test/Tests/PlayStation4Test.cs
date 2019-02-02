using GameConsoleSimulator.Models;
using NUnit.Framework;

namespace GameConsoleSimulator.Test.Tests
{
    public class PlayStation4Test
    {
        [Test]
        public void AGamingPCsDefaultResolutionShouldBe1080p()
        {
            var ps4 = new PlayStation4();
            
            Assert.AreEqual(expected: ps4.DefaultVideoResolution.Width, 1920);
            Assert.AreEqual(expected: ps4.DefaultVideoResolution.Width, 1080);
        }
        
        [Test]
        public void APS4ShouldHaveAnHDMIConnectionByDefault()
        {
            PlayStation4 ps4 = new PlayStation4();
            
            Assert.AreEqual(expected: AVInterface.HDMI, actual: ps4.VideoConnectorType);
        }
    }
}