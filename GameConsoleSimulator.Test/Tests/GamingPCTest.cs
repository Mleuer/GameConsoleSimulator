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
            
            Assert.AreEqual(expected: gamingPC.DefaultVideoResolution.Width, 3840);
            Assert.AreEqual(expected: gamingPC.DefaultVideoResolution.Width, 2160);
        }
        
        [Test]
        public void AGamingPCShouldHaveADisplayPortConnectionByDefault()
        {
            GamingPC gamingPC = new GamingPC();
            
            Assert.AreEqual(expected: AVInterface.DisplayPort, actual: gamingPC.VideoConnectorType);
        }
    }
}