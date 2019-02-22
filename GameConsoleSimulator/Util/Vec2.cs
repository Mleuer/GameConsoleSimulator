﻿using System;
using GameConsoleSimulator.Util;
using SFML.System;

namespace System
{
    public interface IIndexable<N>
    {
        N this[uint index] {get; set;}
    }
}

namespace GameConsoleSimulator.Utility
{
    public class Vec2<N> : IEquatable<Vec2<N>>, IEquatable<(N,N)>, IIndexable<N> where N:
        struct,
        IComparable, 
        IComparable<N>, 
        IConvertible, 
        IEquatable<N>, 
        IFormattable 
    {

        public N X { get; set; }
        public N Y { get; set; }
        
        public Vec2() {}
        
        public Vec2(Vec2<N> other) :
            this(other.X, other.Y)
        {
            
        }

        public Vec2(N x, N y)
        {
            this.X = x;
            this.Y = y;
        }

        public static implicit operator Vec2<N> ((N, N) pair)
        {
            return new Vec2<N> {X = pair.Item1, Y = pair.Item2};
        }
        
        public static implicit operator Vec2<N> (Vector2f sfmlVector)
        {
            return new Vec2<N> {X = (N)(dynamic)sfmlVector.X, Y = (N)(dynamic)sfmlVector.Y};
        }
        
        public static implicit operator Vec2<N> (Vector2i sfmlVector)
        {
            return new Vec2<N> {X = (dynamic) sfmlVector.X, Y = (dynamic) sfmlVector.Y};
        }
        
        public static implicit operator Vec2<N> (Vector2u sfmlVector)
        {
            return new Vec2<N> {X = (dynamic) sfmlVector.X, Y = (dynamic) sfmlVector.Y};
        }
        
        public static implicit operator (N, N) (Vec2<N> vector)
        {
            return (vector.X, vector.Y);
        }
        
        public static implicit operator Vector2f (Vec2<N> vector)
        {
            var sfmlVector = new Vector2f {X = (float)(dynamic) vector.X, Y = (float)(dynamic) vector.Y};
            return sfmlVector;
        }
        
        public static implicit operator Vector2i (Vec2<N> vector)
        {
            return new Vector2i {X = (dynamic) vector.X, Y = (dynamic) vector.Y};
        }
        
        public static implicit operator Vector2u (Vec2<N> vector)
        {
            return new Vector2u {X = (dynamic) vector.X, Y = (dynamic) vector.Y};
        }

        public Vec2<OtherNumericType> ConvertMemberType <OtherNumericType>() where OtherNumericType : 
            struct, 
            IComparable, 
            IComparable<OtherNumericType>, 
            IConvertible, 
            IEquatable<OtherNumericType>, 
            IFormattable
        {
            return new Vec2<OtherNumericType>((OtherNumericType) (dynamic) X, (OtherNumericType) (dynamic) Y);
        }

        public N this[uint index]
        {
            get
            {
                if (index == 0)
                {
                    return X;
                }
                else if (index == 1)
                {
                    return Y;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (index == 0)
                {
                    X = value;
                }
                else if (index == 1)
                {
                    Y = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public static Boolean operator == (Vec2<N> vector0, Vec2<N> vector1) 
        {
            return ((dynamic) vector0.X == (dynamic) vector1.X) &&
                   ((dynamic) vector0.Y == (dynamic) vector1.Y);
        }
        
        public static Boolean operator == (Vec2<N> vector, (N,N) pair) 
        {
            return ((dynamic) vector.X == (dynamic) pair.Item1) &&
                   ((dynamic) vector.Y == (dynamic) pair.Item2);
        }

        public static bool operator != (Vec2<N> vector, (N, N) pair) 
        {
            return !(vector == pair);
        }

        public static bool operator != (Vec2<N> vector0, Vec2<N> vector1) 
        {
            return !(vector0 == vector1);
        }

        public override Boolean Equals(object @object) 
        {
            if (@object?.GetType() == this.GetType())
            {
                return this.Equals((Vec2<N>) @object);
            }
            else if (@object?.GetType() == typeof((N, N)))
            {
                return this.Equals((ValueTuple<N,N>) @object);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public bool Equals(Vec2<N> other) 
        {
            return this == other;
        }
        
        public bool Equals((N, N) pair) 
        {
            return this == pair;
        }

        public override int GetHashCode() 
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public static Vec2<N> operator + (Vec2<N> vector0, Vec2<N> vector1) 
        {
            return new Vec2<N>(checked((dynamic)vector0.X + (dynamic)vector1.X), checked((dynamic) vector0.Y + (dynamic) vector1.Y));
        }
        
        public static Vec2<long> operator + (Vec2<N> vector0, Vec2<short> vector1) 
        {
            Vec2<int> v0 = vector0.ConvertMemberType<int>();
            return new Vec2<long>(v0.X + vector1.X, v0.Y + vector1.Y);
        }

        public static Vec2<N> operator - (Vec2<N> vector0, Vec2<N> vector1)
        {
            return new Vec2<N>(checked((dynamic)vector0.X - (dynamic)vector1.X), checked((dynamic) vector0.Y - (dynamic) vector1.Y));
        }
        
        public static Vec2<N> operator * (Vec2<N> vector, N n)
        {
            N x = (N) ((dynamic) vector.X * n);
            N y = (N) ((dynamic) vector.Y * n);
            
            return new Vec2<N>(x, y);
        }
        
        public static Vec2<double> operator / (Vec2<N> vector0, Vec2<N> vector1)
        {
            double x = ((double) (dynamic) vector0.X / (double) (dynamic) vector1.X);
            double y = ((double) (dynamic) vector0.Y / (double) (dynamic) vector1.Y);
            
            return new Vec2<double>(x, y);
        }
        
        public static Vec2<N> operator / (Vec2<N> vector, N n)
        {
            N x = (N) ((dynamic) vector.X / n);
            N y = (N) ((dynamic) vector.Y / n);
            
            return new Vec2<N>(x, y);
        }

        public static double Distance(Vec2<N> point0, Vec2<N> point1) 
        {
            Vec2<double> p0 = point0.ConvertMemberType<double>();
            Vec2<double> p1 = point1.ConvertMemberType<double>();

            return distance(p0, p1);
        }
        public void Rotate(Angle change)
        {
            change = change.GetValueInUnitType(AngleUnitType.Radians);
            var oldX = this.X;
            var oldY = this.Y;
			
            this.X = (N)((Math.Cos(change) * (dynamic)oldX) - (Math.Sin(change) * (dynamic)oldY));
            this.Y = (N)((Math.Sin(change) * (dynamic)oldX) + (Math.Cos(change) * (dynamic)oldY));       
        }

        public static double Distance<M>(Vec2<N> point0, Vec2<M> point1) where M : 
            struct, 
            IComparable, 
            IComparable<M>, 
            IConvertible, 
            IEquatable<M>, 
            IFormattable 
        {
            Vec2<double> p0 = point0.ConvertMemberType<double>();
            Vec2<double> p1 = point1.ConvertMemberType<double>();

            return distance(p0, p1);
        }

        public double Magnitude 
        {
            get
            {
                double dblX = (double) ((dynamic) X);
                double dblY = (double) ((dynamic) Y);
                double sumSquares = Math.Pow(dblX, 2) + Math.Pow(dblY, 2);
                return Math.Sqrt(sumSquares);
            }
        }

        public Vec2<double> Normalize()
        {
            Vec2<double> normalized = this.ConvertMemberType<double>();
            normalized.normalize();
            return normalized;
        }
        
        protected void normalize() 
        {
            double magnitude = this.Magnitude;
            
            if ((dynamic) magnitude != 0)
            {
                dynamic normalX = ((dynamic) X) / ((dynamic)magnitude);
                dynamic normalY = ((dynamic) Y) / ((dynamic)magnitude);

                X = (N) normalX;
                Y = (N) normalY;
            }
        }

        private static double distance(Vec2<double> point0, Vec2<double> point1) 
        {
            double xDifference = point1.X - point0.X;
            double yDifference = point1.Y - point0.Y;

            xDifference = Math.Abs(xDifference);
            yDifference = Math.Abs(yDifference);

            double sum = Math.Pow(xDifference, 2) + Math.Pow(yDifference, 2);

            double result = Math.Sqrt(sum);

            return result;
        }
    }

    public class NormalizedVec2<N> : Vec2<N> where N : struct, IComparable, IComparable<N>, IConvertible, IEquatable<N>, IFormattable
    {
        
        public NormalizedVec2(N x, N y) :
            base(x, y)
        {
            normalize();
        }
    }
}