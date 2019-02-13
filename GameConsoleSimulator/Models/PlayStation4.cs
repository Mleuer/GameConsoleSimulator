using System;
using System.IO;
using System.Threading;
using GameConsoleSimulator.Util;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace GameConsoleSimulator.Models
{
    public class PlayStation4 : GameConsole
    {
        private uint storagSpaceGigaBytes;
        

        public uint StorageSpaceGigaBytes
        {
            get { return storagSpaceGigaBytes; }
            set { storagSpaceGigaBytes = value; }       
        }
        
        public PlayStation4()
        {
            DefaultVideoResolution = new Size(width: 640, height: 480);
            var mode = new VideoMode(DefaultVideoResolution.Width, DefaultVideoResolution.Height);
            Window = new RenderWindow(mode, "PS4");
            Window.Display();
            Running = true;
        }
        
        public override AVInterface VideoConnectorType
        {
            get
            {
                //hint: you'll want to replace the line below with a "return <something>;" statement
                throw new Exception("PS4's get VideoConnectorType isn't implemented yet!");
            }
        }

        
        public override void StartVideoDisplay()
        {
            while (Running)
            {
                Window.DispatchEvents();
                Window.Display();
                Thread.Sleep(8);
            }
        }

       

        public override void ShowWelcomeScreen()
        {
            PlayStartupTone();
            ShowStartupImage();
        }

        private void ShowStartupImage()
        {
            throw new NotImplementedException();
        }

        private void PlayStartupTone()
        {
            Stream soundFile =
                new FileStream(
                    "/Users/matthewleuer/Developer/GameConsoleSimulator/GameConsoleSimulator/Assets/Sounds/PlayStation Startup Tone.flac",
                    FileMode.Open);

            var music = new SoundBuffer(soundFile);
            var startUpSound = new SFML.Audio.Sound(music);
            startUpSound.Play();

            Thread.Sleep(TimeSpan.FromSeconds(20));
        }
        
        
    }
}