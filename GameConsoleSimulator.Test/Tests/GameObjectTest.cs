using NUnit.Framework;

using GameConsoleSimulator.Models;
using SFML.Graphics;
using Position = GameConsoleSimulator.Utility.Vec2<short>;

namespace GameConsoleSimulator.Test.Tests
{
	public static class GameObjectTest
	{
		[Test]
		public static void ShouldChangeBrightness()
		{
			var npc = new GameObject();
			npc.Texture = new Texture(1600, 1600);
			npc.Color = new Color(Color.Cyan);
				
			npc.AdjustBrightness(-16);
			
			Assert.AreEqual(0, npc.Color.R);
			Assert.AreEqual(239, npc.Color.G);
			Assert.AreEqual(239, npc.Color.B);
		}

		[Test]
		public static void WhenInvisibleColorShouldBeTransparent()
		{
			var npc = new GameObject();
			npc.Texture = new Texture(1600, 1600);
			npc.Color = new Color(Color.Magenta);

			npc.Visible = false;
			
			Assert.AreEqual(0x00, npc.Color.A);
		}
		
		[Test]
		public static void MoveShouldChangeTheGameObjectsPosition()
		{
			var npc = new GameObject();
			npc.Texture = new Texture(2880, 2880);
			npc.Position = (48, 48);
			npc.MovementDistance = (+8, -8);
			
			npc.Move();
			
			Assert.AreEqual(56, npc.Position.X);
			Assert.AreEqual(expected: 40, npc.Position.Y);
		}

		[Test]
		public static void ChangeTrajectoryShouldRotateTheMovementDistanceVectorByTheGivenAngle()
		{
			var npc = new GameObject();
			npc.Texture          = new Texture(3000, 2500);
			npc.Position         = (4, 4);
			npc.MovementDistance = (-2, +6);
			
			npc.ChangeTrajectory(+60);
			
			Assert.AreEqual(-6.20, npc.MovementDistance.X, 0.1);
			Assert.AreEqual(1.27, npc.MovementDistance.Y, 0.1);
		}

		[Test]
		public static void ChangeSpeedShouldAlterSpeed()
		{
			var npc = new GameObject();
			npc.Texture          = new Texture(3000, 2500);
			npc.MovementDistance = (4, 0);
			
			npc.ChangeSpeed(30);
			
			Assert.AreEqual(120, npc.MovementDistance.X);
			Assert.AreEqual(0, npc.MovementDistance.Y);
		}
		
		[Test]
		public static void ShouldReturnFalseWhenThereIsNoCollision()
		{
			var ship0 = new GameObject();
			var ship1 = new GameObject();
			ship0.Texture = new Texture(8, 8); //a GameObject gets its size from its texture
			ship1.Texture = new Texture(6, 6);
			ship0.Position = (4, 4);
			ship1.Position = (50, 50);

			bool collisionDetected = GameObject.CheckForCollision(ship0, ship1);
			
			Assert.False(collisionDetected);
		}
		
		[Test]
		public static void ShouldReturnTrueWhenTwoGameObjectsAreColliding()
		{
			var ship = new GameObject();
			var missile = new GameObject();
			ship.Texture = new Texture(8, 8);
			missile.Texture = new Texture(8, 8);
			ship.Position = (4, 4);
			missile.Position = (6, 6);

			bool collisionDetected = GameObject.CheckForCollision(ship, missile);
			
			Assert.True(collisionDetected);
		}
	}
}