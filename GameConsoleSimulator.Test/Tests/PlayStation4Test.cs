using GameConsoleSimulator.Models;
using NUnit.Framework;

namespace GameConsoleSimulator.Test.Tests
{
    public class PlayStation4Test
    {
        [Test]
        public void APS4sDefaultResolutionShouldBe1080p()
        {
            var ps4 = new PlayStation4();
            
            Assert.AreEqual(1920, ps4.VideoResolution.Width);
            Assert.AreEqual(1080, ps4.VideoResolution.Height);
        }
        
        [Test]
        public void APS4ShouldHaveAnHDMIConnectionByDefault()
        {
            var ps4 = new PlayStation4();
            
            Assert.AreEqual(expected: AVInterface.HDMI, actual: ps4.VideoConnectorType);
        }
    }
}