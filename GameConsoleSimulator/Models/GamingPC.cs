using System;
using SFML.Graphics;
using GameConsoleSimulator.Util;

namespace GameConsoleSimulator.Models
{
    public class GamingPC : GameConsole
    {
        public GamingPC()
        {
            DefaultVideoResolution = new Size(width: 320, height: 240);
        }

        public override AVInterface VideoConnectorType
        {
            get
            {
                //hint: you'll want to replace the line below with a "return <something>;" statement
                throw new Exception("GamingPC's get VideoConnectorType isn't implemented yet!");
            }
        }

        public override void DrawToMainDisplay(Sprite sprite, ulong framesToDisplayFor)
        {
            throw new NotImplementedException();
        }

        public override void RunStartupRoutine()
        {
            //don't worry about this yet
            throw new System.NotImplementedException();
        }
    }
}