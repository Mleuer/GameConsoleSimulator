using System;
using GameConsoleSimulator.Util;

namespace GameConsoleSimulator.Test.Util
{
    public static class Assertions
    {
        public static void AssertAreEqual<N>(Vec2<N> expected, Vec2<N> actual, double delta) where N : struct, IComparable, IComparable<N>, IConvertible, IEquatable<N>, IFormattable
        {
            NUnit.Framework.Assert.AreEqual((dynamic)expected.X, (dynamic)actual.X, delta);
            NUnit.Framework.Assert.AreEqual((dynamic)expected.Y, (dynamic)actual.Y, delta);
        }
    }
}