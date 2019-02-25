using System;
using System.Threading;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

using GameConsoleSimulator.Util;
using GameConsoleSimulator.Utility;
using static GameConsoleSimulator.Config.Configuration;
using static GameConsoleSimulator.Util.Util;


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
            VideoResolution = new Size(width: 1280, height: 720);
            var mode = new VideoMode(VideoResolution.Width, VideoResolution.Height);
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
        public override void DrawToMainDisplay(Drawable drawable, TimeSpan refreshInterval)
        {
            Window.Clear();
            Window.Draw(drawable);
            Window.Display();
            Window.DispatchEvents();
            Thread.Sleep(refreshInterval);
        }
        public override void DrawToMainDisplay(TimeSpan refreshInterval, params Drawable[] drawables)
        {
            Window.Clear();
            
            foreach (var drawable in drawables)
            {
                Window.Draw(drawable);
            }
            Window.Display();
            Window.DispatchEvents();
            Thread.Sleep(refreshInterval);
        }

        public override void RunStartupRoutine()
        {
            PlayStartupTone();
            ShowStartupScreen();
        }

        private void ShowStartupScreen()
        {
            string startupImageFilePath = $"{ImageFileDirectoryPath}{Slash}PlayStationSymbols.png";
            var startupScreenTexture = new Texture(startupImageFilePath);
            var startupScreen = new GameObject(startupScreenTexture);
            startupScreen.CenterOrigin();
            startupScreen.Position = new Vec2<float>
            {
                X = VideoResolution.Width / 2,
                Y = VideoResolution.Height / 2
            };
            
            DrawToMainDisplay(startupScreen,400 );
        }

        private void PlayStartupTone()
        {
            String startupToneSoundFilePath = $"{SoundFileDirectoryPath}{Slash}PlayStation Startup Tone.flac";
            var startupToneSoundBuffer = new SoundBuffer(filename: startupToneSoundFilePath);
            SFML.Audio.Sound startupTone = new Sound(startupToneSoundBuffer);
            
            startupTone.Play();
        }
    }
}