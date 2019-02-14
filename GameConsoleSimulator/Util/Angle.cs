using static MathNet.Numerics.Trig;
using static GameConsoleSimulator.Util.Maths; 

namespace GameConsoleSimulator.Util
{
	/// <summary>
	/// Represents angle values in degrees, with the ability to convert to radians
	/// </summary>
	public struct Angle
	{
		float numericValue;

		/// <summary>
		/// The numeric value of the Angle
		/// </summary>
		public float Value 
		{
			get { return numericValue; }
			set
			{
				numericValue = (float) Modulo(value, 360.0f);
			}
		}
		
		/// <summary>
		/// Creates an Angle with the given value and unit type
		/// </summary>
		/// <param name="value"></param>
		public Angle(float value, AngleUnitType unitType = AngleUnitType.Degrees) : this()
		{
			if (unitType == AngleUnitType.Radians)
			{
				value = (float) RadianToDegree(value);
			}

			this.Value = value;
		}
		
		/// <summary>
		/// Implicitly converts an Angle to a floating point number
		/// </summary>
		/// <param name="angle"></param>
		/// <returns></returns>
		public static implicit operator float (Angle angle)
		{
			return angle.Value;
		}
		
		/// <summary>
		/// Implicitly converts a floating point number to an Angle (with the unit type Degrees)
		/// </summary>
		/// <returns></returns>
		public static implicit operator Angle (float floatingPointNumber)
		{
			return new Angle(floatingPointNumber);
		}
		
		
		/// <summary>
		/// Adds the two Angles together. If one is degrees and the other is radians, the result will
		/// be in degrees
		/// </summary>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <returns></returns>
		public static Angle operator + (Angle first, Angle second) 
		{
			var sum = new Angle(first.Value + second.Value);
			return sum;
		}
		
		/// <summary>
		/// Subtracts the second angle from the first. If one is degrees and the other is radians, the result will
		/// be in degrees
		/// </summary>
		/// <param name="first">The angle subtracted from</param>
		/// <param name="second">The angle to subtract</param>
		/// <returns></returns>
		public static Angle operator - (Angle first, Angle second) 
		{
			var difference = new Angle(first.Value - second.Value);
			return difference;
		}
		
		/// <summary>
		/// Gets the value of the angle in the desired unit type
		/// </summary>
		/// <param name="type">The type of unit value to return</param>
		/// <returns></returns>
		public float GetValueInUnitType(AngleUnitType type)
		{
			if (type == AngleUnitType.Degrees)
			{
				return this.Value;
			}
			else /* if (type == AngleUnitType.Radians) */
			{
				float result = (float) DegreeToRadian(Value);
				return result;
			}
		}
	}
	
	public enum AngleUnitType
	{
		Degrees,
		Radians
	}
}