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
		
		
	}
}