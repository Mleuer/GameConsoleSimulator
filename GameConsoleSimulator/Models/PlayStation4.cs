using System;
using System.IO;
using System.Net.Mime;
using System.Threading;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

using GameConsoleSimulator.Util;
using static GameConsoleSimulator.Config.Configuration;


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
            DefaultVideoResolution = new Size(width: 1280, height: 720);
            var mode = new VideoMode(DefaultVideoResolution.Width, DefaultVideoResolution.Height);
            Window = new RenderWindow(mode, "PS4");
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

        /// Draws the Drawable to the display for the number of frames given by framesToDisplayFor.
        /// For example, if the program refreshes 30 times per second, and DrawToMainDisplay()
        /// is requested to draw a Sprite for 30 frames, the sprite will remain on screen for
        /// 1 second.
        public override void DrawToMainDisplay(Sprite sprite, ulong framesToDisplayFor)
        {
            ulong framesShown = 0;
            
            while (framesShown < framesToDisplayFor)
            {
                Window.Draw(sprite);
                Window.Display();
                Window.DispatchEvents();
                Thread.Sleep(RefreshTime);
                framesShown++;
            }
        }

        public override void RunStartupRoutine()
        {
            PlayStartupTone();
            ShowStartupImage();
        }

        private void ShowStartupImage()
        {
            Texture texture = new Texture("/Users/matthewleuer/Developer/GameConsoleSimulator/GameConsoleSimulator/Assets/Bitmaps/PlayStationStartupScreen.png");
            Sprite sprite = new Sprite(texture);
            
            DrawToMainDisplay(sprite, 1000 );
        }

        private void PlayStartupTone()
        {
            string applicationDirectory   = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            char slash = Path.DirectorySeparatorChar;
            String startupToneSoundFile = applicationDirectory + $"{slash}Assets{slash}Sounds{slash}PlayStation Startup Tone.flac";
            var startupToneSoundBuffer = new SoundBuffer(filename: startupToneSoundFile);
            SFML.Audio.Sound startupTone = new Sound(startupToneSoundBuffer);
            
            startupTone.Play();
        }
        
        
    }
}