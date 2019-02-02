using System;
using GameConsoleSimulator.Util;

namespace GameConsoleSimulator.Models
{
    public class PlayStation4 : GameConsole
    {
        public PlayStation4()
        {
            DefaultVideoResolution = new Size(width: 640, height: 480);
        }
        
        public override AVInterface VideoConnectorType
        {
            get
            {
                //hint: you'll want to replace the line below with a "return <something>;" statement
                throw new Exception("PS4's get VideoConnectorType isn't implemented yet!");
            }
        }
        
        public override void ShowWelcomeScreen()
        {
            //don't worry about this yet
            throw new System.NotImplementedException();
        }
    }
}