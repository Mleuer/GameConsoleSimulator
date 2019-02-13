
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

        public override void StartVideoDisplay()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowWelcomeScreen()
        {
            throw new System.NotImplementedException();
        }
    }
}