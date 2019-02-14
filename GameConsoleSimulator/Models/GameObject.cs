using GameConsoleSimulator.Util;
using GameConsoleSimulator.Utility;
using SFML.Graphics;

namespace GameConsoleSimulator.Models
{
	public class GameObject
	{
		public Angle Heading;
		public Vec2<uint> Position
		{
			get { return this.Sprite.Position; }
			set { Sprite.Position = value; }
		}

		public Sprite Sprite { get; private set; }

		public Texture Texture
		{
			get { return Sprite.Texture; }
			set { Sprite = new Sprite(value); }
		}

		public GameObject()
		{
		}
	}
}