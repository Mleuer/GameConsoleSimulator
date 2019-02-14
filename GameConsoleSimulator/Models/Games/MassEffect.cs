using SFML.Graphics;

using static GameConsoleSimulator.Config.Configuration;
using static GameConsoleSimulator.Util.Util;

namespace GameConsoleSimulator.Models.Games
{
	public class MassEffect : Game
	{
		public GameObject Normandy { get; private set; }
		
		public MassEffect()
		{
			var normandyTexture = new Texture($"{ImageFileDirectoryPath}{Slash}Normandy.png");
			Normandy = new GameObject(normandyTexture);
		}

		public override void Play()
		{
			base.Play();
		}
	}
}