using System;
using System.IO;
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
        public override void DrawToMainDisplay(Drawable drawable, ulong framesToDisplayFor)
        {
            ulong framesShown = 0;
            
            while (framesShown < framesToDisplayFor)
            {
                Window.Draw(drawable);
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
            /* TODO: This method needs to somehow turn our startup screen image into something that can be drawn, then call DrawToMainDisplay()
            to have the startup image drawn to the screen for some number of frames  */
            
            //First, turn our chosen startup screen image into some sort of object that can be drawn (DrawToMainDisplay()'s parameters should give you
            //some hint as to what you'll need 
            
            
            //Next, uncomment the line below, then fix it
            //DrawToMainDisplay(??, ??);
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