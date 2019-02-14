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

        public override void DrawToMainDisplay(Sprite sprite, ulong framesToDisplayFor)
        {
            throw new System.NotImplementedException();
        }

        public override void RunStartupRoutine()
        {
            throw new System.NotImplementedException();
        }
    }
}