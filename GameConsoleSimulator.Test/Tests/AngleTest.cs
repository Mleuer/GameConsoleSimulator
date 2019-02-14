using System;
using GameConsoleSimulator.Util;
using NUnit.Framework;

namespace GameConsoleSimulator.Test.Tests
{
	public static class AngleTest
	{
		[Test]
		public static void ShouldConvertFromRadians()
		{
			var angle = new Angle((float) Math.PI / 4, AngleUnitType.Radians);
			
			Assert.AreEqual(45, angle.Value);
		}
		
		[Test]
		public static void TestAddition()
		{
			var angle = 45;
			var angleToAdd = new Angle((float) Math.PI / 2, AngleUnitType.Radians);

			Angle sum = angle + angleToAdd;
			
			Assert.AreEqual(135, sum.Value);
		}
		
		[Test]
		public static void TestSubtraction()
		{
			var angle = new Angle((float) Math.PI, AngleUnitType.Radians);
			var angleToSubtract = 30;

			Angle difference = angle - angleToSubtract;
			
			Assert.AreEqual(150, difference.Value);
		}
	}
}