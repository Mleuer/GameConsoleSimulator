using GameConsoleSimulator.Utility;
using NUnit.Framework;

namespace GameConsoleSimulator.Test.Tests
{
	public static class VectorTest
	{
		[Test]
		public static void NormalizeShouldGiveExpectedValue()
		{
			var vector = new Vec2<short>(5, 4);
			
			Vec2<double> normalizedVector = vector.Normalize();
			
			Assert.AreEqual(expected: 0.78, actual: normalizedVector.X, delta: 0.02);
			Assert.AreEqual(expected: 0.62, actual: normalizedVector.Y, delta: 0.02);
		}
		
		[Test]
		public static void MagnitudeShouldGiveExpectedValue()
		{
			var vector = new Vec2<float>(1.1f, 7.4f);
			
			double magnitude = vector.Magnitude;
			
			Assert.AreEqual(expected: 7.48, actual: magnitude, delta: 0.1);
		}

		[Test]
		public static void NormalizedVectorShouldAlwaysNormalize()
		{
			var normVector = new NormalizedVec2<double>(0.5, 0.5);
			
			Assert.AreEqual(expected: 0.707, actual: normVector.X, delta: 0.02);
			Assert.AreEqual(expected: 0.707, actual: normVector.Y, delta: 0.02);
		}
	}
}