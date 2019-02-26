using System;
using SFML.Graphics;
using GameConsoleSimulator.Util;

namespace GameConsoleSimulator.Models
{
    public class GamingPC : GameConsole
    {
        public GamingPC()
        {
            VideoResolution = new Size(width: 3840, height: 2160);
        }

        public override AVInterface VideoConnectorType
        {
            get
            {
                return AVInterface.DisplayPort;
            }
        }

        public override void DrawToMainDisplay(Drawable drawable, TimeSpan RefreshInterval)
        {
            throw new NotImplementedException();
        }
        
        public override void DrawToMainDisplay(TimeSpan refreshInterval, params Drawable[] drawables)
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