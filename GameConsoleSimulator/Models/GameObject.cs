using System;
using GameConsoleSimulator.Util;
using SFML.Graphics;
using GameConsoleSimulator.Utility;
using Position = GameConsoleSimulator.Utility.Vec2<float>;
using Direction = GameConsoleSimulator.Utility.NormalizedVec2<float>;
using static System.Math;

namespace GameConsoleSimulator.Models
{
	/// <summary>
	/// A basic object within a game
	/// </summary>
	public class GameObject : Drawable
	{
		public Color Color { get { return Sprite.Color; } set { Sprite.Color = value; } }
		
		/// <summary>
		/// When true, the GameObject is at least somewhat translucent. When false, it is fully transparent.
		/// </summary>
		/// <returns>true if the GameObject should be visible, false otherwise</returns>
		public bool Visible 
		{
			get
			{
				if (this.Color.A == 0x00)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			set
			{
				if (value == true)
				{
					Color color = new Color(this.Color);
					color.A = 0xFF;
					this.Color = color;
				}
				else
				{
					Color color = new Color(this.Color);
					color.A = 0x00;
					this.Color = color;
				}
			}
		}
		
		/// <summary>
		/// How far this GameObject should move each time Move() is called, in (±x, ±y) pixels
		/// </summary>
		public Vec2<float> MovementDistance { get; set; } = (0, 0);
		
		/// <summary>
		/// The current position of this GameObject in the world
		/// </summary>
		public Position Position 
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

		public GameObject(Texture texture) 
		{
			this.Texture = texture;
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			this.Sprite.Draw(target, states);
		}
		
		/// <summary>
		/// Moves this GameObject by the number of pixels given by its property MovementDistance
		/// </summary>
		public void Move()
		{
			Move(this.MovementDistance);
		}
		
		/// <summary>
		/// Moves this GameObject by the number of pixels given by the argument distance
		/// </summary>
		public void Move(Vec2<float> distance)
		{
			var newPosition = new Position(x: 0, y: 0);
			newPosition.X = (this.Position.X + distance.X);
			newPosition.Y = (this.Position.Y + distance.Y);
			Position = newPosition;
		}
		
		/// <summary>
		/// Adjusts the angle of the GameObject's MovementDistance (a 2-vector value)
		/// by rotating it the number of degrees given by the parameter change
		/// </summary>
		/// <param name="change">How much to rotate MovementDirection, in degrees</param>
		public void ChangeTrajectory(Angle change)
		{
			this.MovementDistance.Rotate(change);
		}

		public void ChangeSpeed(float multiplier)
		{
			float xVelocity = this.MovementDistance.X * multiplier;
			float yVelocity = this.MovementDistance.Y * multiplier;
			this.MovementDistance.X = (short)xVelocity;
			this.MovementDistance.Y = (short)yVelocity;
		}
		
		/// <summary>
		/// Increases or decreases the overall brightness of the Color of this GameObject by the amount given by change
		/// </summary>
		/// <param name="change"></param>
		public void AdjustBrightness(short change)
		{
			Color color = new Color(this.Color);
			int b = color.B + change;
			int g = color.G + change;
			int r = color.R + change;

			if (b > 255)
			{
				Math.DivRem(b, 255, out b);
			}
			if (g > 255)
			{
				Math.DivRem(g, 255, out g);
			}
			if (r > 255)
			{
				Math.DivRem(r, 255, out r);
			}
			if (r < 0)
			{
				r = 0;
			}
			if (g < 0)
			{
				g = 0;
			}
			if (b < 0)
			{
				b = 0;
			}

			color.B = (byte)b;
			color.G = (byte)g;
			color.R = (byte)r;
			this.Color = color;
		}

		public void CenterOrigin()
		{
			Sprite.Origin = ((Vec2<uint>) Texture.Size) / 2;
		}
	}
}