using System;
using GameConsoleSimulator.Util;

namespace GameConsoleSimulator.Models
{
    public class PlayStation4 : GameConsole
    {
        public PlayStation4()
        {
            DefaultVideoResolution = new Size(width: 1920, height: 1080);
        }
        
        public override AVInterface VideoConnectorType
        {
            get { return AVInterface.HDMI; }
        }
        
        public override void ShowWelcomeScreen()
        {
            //don't worry about this yet
            throw new System.NotImplementedException();
        }
    }
}