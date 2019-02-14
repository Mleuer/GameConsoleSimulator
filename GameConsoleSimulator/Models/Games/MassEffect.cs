using GameConsoleSimulator.Utility;
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
		}

		public override void Play()
		{
			this.Console.DrawToMainDisplay(Normandy, 25000);
		}

		private void resizeGameObjects()
		{
			Normandy.Sprite.Scale = new Vec2<decimal>(0.25M, 0.25M);
			var windowResolution = Console.VideoResolution;
			Normandy.Sprite.Position = new Vec2<uint>(windowResolution.Width / 8, windowResolution.Height / 2);
		}
	}
}