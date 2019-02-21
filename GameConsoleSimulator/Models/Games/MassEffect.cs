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

		public override void Play()
		{
			bool headingAdjusted = false;
			bool dimmed = false;
			bool brightened = false;
			bool madeInvisible = false;
			bool madeVisibleAgain = false;
			bool spedUp = false;
			
			var timer = new CountdownTimer();
			timer.Start(Duration.FromSeconds(30));
			
			while (timer.Complete == false)
			{
				Normandy.Move();
				Console.DrawToMainDisplay(Normandy, TimeSpan.FromMilliseconds(32), 1);
				

				if ((timer.TimeElapsed >= Duration.FromSeconds(2.5)) && (headingAdjusted == false))
				{
					Normandy.ChangeTrajectory(30);
					headingAdjusted = true;
				}
				
				if ((timer.TimeElapsed >= Duration.FromSeconds(5)) && (dimmed == false))
				{
					Normandy.AdjustBrightness(-75);
					dimmed = true;
				}
				
				if ((timer.TimeElapsed >= Duration.FromSeconds(6.5)) && (brightened == false))
				{
					Normandy.AdjustBrightness(+200);
					brightened = true;
				}
				
				if ((timer.TimeElapsed >= Duration.FromSeconds(9)) && (madeInvisible == false))
				{
					Normandy.Visible = false;
					madeInvisible = true;
				}
				
				if ((timer.TimeElapsed >= Duration.FromSeconds(11.5)) && madeInvisible && (madeVisibleAgain == false))
				{
					Normandy.Visible = true;
					madeVisibleAgain = true;
				}
				if ((timer.TimeElapsed >= Duration.FromSeconds(0)) )
				{
					Normandy.ChangeSpeed(1.8f);
					spedUp = true;
				}
				
			}
		}

		private void resizeGameObjects()
		{
			Normandy.Sprite.Scale = new Vec2<decimal>(0.25M, 0.25M);
			var windowResolution = Console.VideoResolution;
			Normandy.Sprite.Position = new Vec2<uint>(windowResolution.Width / 8, windowResolution.Height / 2);
		}
	}
}