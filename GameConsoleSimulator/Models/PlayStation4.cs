using System;
using System.IO;
using System.Threading;
using GameConsoleSimulator.Util;
using SFML.Audio; 

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
            Stream soundFile =
                new FileStream("/Users/matthewleuer/Developer/GameConsoleSimulator/GameConsoleSimulator/Assets/Sounds/PlayStation Startup Tone.flac",
                    FileMode.Open);
            
            var music = new SoundBuffer(soundFile);
            var startUpSound = new SFML.Audio.Sound(music);
            startUpSound.Play();
            
            Thread.Sleep(TimeSpan.FromSeconds(20));
       
        }
    }
}