using System;
using SFML.Graphics;

namespace GameConsoleSimulator.Models
{
    public class GenericGameConsole : GameConsole
    {   
        public override AVInterface VideoConnectorType
        {
            get
            {
                return AVInterface.Other;
            }
        }

        public override void DrawToMainDisplay(Drawable drawable, TimeSpan RefreshInterval)
        {
            throw new System.NotImplementedException();
        }

        public override void RunStartupRoutine()
        {
            throw new System.NotImplementedException();
        }
    }
}