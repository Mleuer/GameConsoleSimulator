using System;
using Chess.Utility;
using GameConsoleSimulator.Utility;
using NodaTime;
using SFML.Graphics;

using static GameConsoleSimulator.Config.Configuration;
using static GameConsoleSimulator.Util.Util;

namespace GameConsoleSimulator.Models.Games
{
	public class MassEffect : Game
	{
		public override GameConsole Console
		{
			get { return base.Console; }
			set
			{
				base.Console = value;
				resizeGameObjects();
			}
			
		}

		public GameObject Normandy { get; private set; }
		
		public MassEffect() 
		{
			Title = "Mass Effect";
			var normandyTexture = new Texture(ImageFileDirectoryPath + Slash + "Normandy.png");
			Normandy = new GameObject(normandyTexture);
			Normandy.CenterOrigin();
			Normandy.MovementDistance = (1, 0);
		}
		
		public void ProcessKeyboardInput()
		{
			if (SFML.Window.Keyboard.IsKeyPressed (SFML.Window.Keyboard.Key.W))
			{
				// left key is pressed: move our character
				Normandy.Move(new Vec2<float>(0f, -1f));
			}
			if (SFML.Window.Keyboard.IsKeyPressed (SFML.Window.Keyboard.Key.A))
			{
				// left key is pressed: move our character
				Normandy.Move(new Vec2<float>(-1f, 0f));
			}
			if (SFML.Window.Keyboard.IsKeyPressed (SFML.Window.Keyboard.Key.S))
			{
				// left key is pressed: move our character
				Normandy.Move(new Vec2<float>(0f, 1f));
			}
			if (SFML.Window.Keyboard.IsKeyPressed (SFML.Window.Keyboard.Key.D))
			{
				// left key is pressed: move our character
				Normandy.Move(new Vec2<float>(1f, 0f));
			}
			
		}
		
		public override void Play()
		{
			var timer = new CountdownTimer();
			timer.Start(Duration.FromHours(30));
			
			while (timer.Complete == false)
			{
				ProcessKeyboardInput();
				Console.DrawToMainDisplay(Normandy, TimeSpan.FromMilliseconds(8));
			}
		}

		private void resizeGameObjects()
		{
			Normandy.Sprite.Scale = new Vec2<decimal>(0.25M, 0.25M);
			Normandy.Sprite.Position = new Vec2<float>(Console.VideoResolution.Width / 2, Console.VideoResolution.Height / 1.5f);
		}
	}
}