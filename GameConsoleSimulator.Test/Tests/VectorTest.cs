using System.Collections.Generic;
using GameConsoleSimulator.Util;
using NUnit.Framework;
using static GameConsoleSimulator.Test.Util.Assertions;
	
namespace GameConsoleSimulator.Test.Tests
{
	public static class VectorTest
	{
		[Test]
		public static void NormalizeShouldGiveExpectedValue()
		{
			var vector = new Vec2<short>(5, 4);
			
			Vec2<double> normalizedVector = vector.Normalize();
			
			AssertAreEqual(expected: (0.78, 0.62), actual: normalizedVector, 0.02);
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
			
			AssertAreEqual(expected: (0.707, 0.707), actual: normVector, delta: 0.02);
		}

		[Test]

		public static void CalculateMinkowskiSumShouldAddTwoVec2Lists()
		{
			var List1 = new List<Vec2<float>> {(1, 0), (0, 1), (0, -1)};
			var List2 = new List<Vec2<float>> {(0, 0), (1, 1), (1, -1)};
			
			HashSet<Vec2<float>> minkowskiSum = Vec2<float>.CalculateMinkowskiSum(List1, List2);
			var expectedMinkowskiSum = new HashSet<Vec2<float>>{(1, 0), (2, 1), (2, -1), (0, 1), (1, 2), (0, -1), (1, -2)};
			
			Assert.AreEqual(expectedMinkowskiSum, minkowskiSum);
		}
	}
}