using System;
using GameConsoleSimulator.Util;

namespace GameConsoleSimulator.Models
{
    public class GamingPC : GameConsole
    {
        public GamingPC()
        {
            DefaultVideoResolution = new Size(width: 3840, height: 2160);
        }

        public override AVInterface VideoConnectorType
        {
            get { return AVInterface.DisplayPort; }
        }
        
        public override void ShowWelcomeScreen()
        {
            //don't worry about this yet
            throw new System.NotImplementedException();
        }
    }
}