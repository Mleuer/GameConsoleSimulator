using GameConsoleSimulator.Models;
using GameConsoleSimulator.View;

namespace GameConsoleSimulator
{
    
    internal static class Program
    {
        public static void Main()
        {
            var ps4 = new PlayStation4();
            ps4.ShowWelcomeScreen();
        }
    } 
    
}
