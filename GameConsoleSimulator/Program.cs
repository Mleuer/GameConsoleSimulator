using System;
using System.Threading;
using GameConsoleSimulator.Models;

namespace GameConsoleSimulator
{
    
    internal static class Program
    {
        public static void Main()
        {
            var ps4 = new PlayStation4();  
            ps4.RunStartupRoutine();
            Thread.Sleep(TimeSpan.FromSeconds(20));
        }
    } 
    
}
