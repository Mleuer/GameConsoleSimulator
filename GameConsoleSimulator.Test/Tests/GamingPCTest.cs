using GameConsoleSimulator.Models;
using NUnit.Framework;

namespace GameConsoleSimulator.Test.Tests
{
    public class GamingPCTest
    {
        [Test]
        public void AGamingPCsDefaultResolutionShouldBe4K()
        {
            GameConsole gamingPC = new GamingPC();

            Assert.AreEqual(expected: 3840, actual: gamingPC.VideoResolution.Width);
            Assert.AreEqual(expected: 2160, actual: gamingPC.VideoResolution.Height);
        }
        
        [Test]
        public void AGamingPCShouldHaveADisplayPortConnectionByDefault()
        {
            GamingPC gamingPC = new GamingPC();
            
            Assert.AreEqual(expected: AVInterface.DisplayPort, actual: gamingPC.VideoConnectorType);
        }
    }
}