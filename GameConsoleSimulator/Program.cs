using System;
using System.Threading;
using GameConsoleSimulator.Models;
using GameConsoleSimulator.Models.Games;

namespace GameConsoleSimulator
{
    
    internal static class Program
    {
        public static void Main()
        {
            var ps4 = new PlayStation4();  
            ps4.RunStartupRoutine();
            
            Game massEffect = new MassEffect();
            ps4.InstallGame(massEffect);
            
            ps4.Play(massEffect);
            
            Thread.Sleep(TimeSpan.FromSeconds(20));
        }
    } 
    
}
