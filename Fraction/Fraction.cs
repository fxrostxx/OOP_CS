using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	internal class Fraction
	{
		private int denominator;
		public int Integer { get; set; }
		public int Numerator { get; set; }
		public int Denominator
		{
			get { return denominator; }
			set { denominator = (value == 0 ? 1 : value); }
		}
		public Fraction()
		{
			Integer = 0;
			Numerator = 0;
			Denominator = 1;
			Console.WriteLine($"DefaultConstructor: {this.GetHashCode()}");
		}
		public Fraction(double value)
		{
			const int precision = 1000000000;
			Integer = (int)value;
			Numerator = (int)Math.Round((value - Integer) * precision);
			Denominator = precision;
			ReduceFraction(this);
			Console.WriteLine($"SingleArgumentConstructor: {this.GetHashCode()}");
		}
		public Fraction(int numerator, int denominator)
		{
			Integer = 0;
			Numerator = numerator;
			Denominator = denominator;
			Console.WriteLine($"Constructor: {this.GetHashCode()}");
		}
		public Fraction(int integer, int numerator, int denominator)
		{
			Integer = integer;
			Numerator = numerator;
			Denominator = denominator;
			Console.WriteLine($"Constructor: {this.GetHashCode()}");
		}
		public Fraction(Fraction other)
		{
			Integer = other.Integer;
			Numerator = other.Numerator;
			Denominator = other.Denominator;
			Console.WriteLine($"CopyConstructor: {this.GetHashCode()}");
		}
		~Fraction()
		{
			Console.WriteLine($"Destructor: {this.GetHashCode()}");
		}
		//public Fraction operator=(Fraction other)
		//{
		//	Console.WriteLine($"CopyAssignment: {this.GetHashCode()}");
		//	return new Fraction(other);
		//}
		public static Fraction operator++(Fraction This)
		{
			return new Fraction(This.Integer + 1, This.Numerator, This.Denominator);
		}
		public static Fraction operator--(Fraction This)
		{
			return new Fraction(This.Integer - 1, This.Numerator, This.Denominator);
		}
		public static Fraction operator*(Fraction left, Fraction right)
		{
			left = ToImproper(left);
			right = ToImproper(right);
			return ToProper(ReduceFraction(new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator)));
		}
		public static Fraction operator/(Fraction left, Fraction right)
		{
			return new Fraction(left * Invert(right));
		}
		public static Fraction operator+(Fraction left, Fraction right)
		{
			if (left.Denominator == right.Denominator) return new Fraction
			(
				left.Integer + right.Integer,
				left.Numerator + right.Numerator,
				left.Denominator
			);
			int lcm = LCM(left.Denominator, right.Denominator);
			return ToProper(new Fraction
			(
				left.Integer + right.Integer,
				left.Numerator * (lcm / left.Denominator) +
				right.Numerator * (lcm / right.Denominator),
				lcm
			));
		}
		public static Fraction operator-(Fraction left, Fraction right)
		{
			if (left.Denominator == right.Denominator) return new Fraction
			(
				left.Integer - right.Integer,
				left.Numerator - right.Numerator,
				left.Denominator
			);
			int lcm = LCM(left.Denominator, right.Denominator);
			return ToProper(new Fraction
			(
				left.Integer - right.Integer,
				left.Numerator * (lcm / left.Denominator) -
				right.Numerator * (lcm / right.Denominator),
				lcm
			));
		}
		public static bool operator==(Fraction left, Fraction right)
		{
			left = ToImproper(left);
			right = ToImproper(right);
			return left.Numerator * right.Denominator == left.Denominator * right.Numerator;
		}
		public static bool operator!=(Fraction left, Fraction right)
		{
			return !(left == right);
		}
		public static bool operator>(Fraction left, Fraction right)
		{
			left = ToImproper(left);
			right = ToImproper(right);
			return left.Numerator * right.Denominator > left.Denominator * right.Numerator;
		}
		public static bool operator<(Fraction left, Fraction right)
		{
			left = ToImproper(left);
			right = ToImproper(right);
			return left.Numerator * right.Denominator < left.Denominator * right.Numerator;
		}
		public static bool operator>=(Fraction left, Fraction right)
		{
			return !(left < right);
		}
		public static bool operator<=(Fraction left, Fraction right)
		{
			return !(left > right);
		}
		public static explicit operator int(Fraction This)
		{
			return This.Integer + This.Numerator / This.Denominator;
		}
		public static explicit operator double(Fraction This)
		{
			return This.Integer + (double)This.Numerator / This.Denominator;
		}
		public void Print()
		{
			if (Integer != 0) Console.Write(Integer);
			if (Numerator != 0)
			{
				if (Integer != 0) Console.Write("(");
				Console.Write($"{Numerator} / {Denominator}");
				if (Integer != 0) Console.Write(")");
			}
			else if (Integer == 0) Console.Write(0);
			Console.WriteLine();
		}
		public static int GCD(int a, int b)
		{
			if (a == 0) return b;
			return GCD(b % a, a);
		}
		public static int LCM(int a, int b)
		{
			return (a * b) / GCD(a, b);
		}
		public static Fraction ReduceFraction(Fraction other)
		{
			int gcd = GCD(other.Numerator, other.Denominator);
			other.Numerator /= gcd;
			other.Denominator /= gcd;
			return other;
		}
		public Fraction ReduceFraction()
		{
			int gcd = GCD(this.Numerator, this.Denominator);
			this.Numerator /= gcd;
			this.Denominator /= gcd;
			return this;
		}
		public static Fraction ToProper(Fraction other)
		{
			other.Integer += other.Numerator / other.Denominator;
			other.Numerator %= other.Denominator;
			return other;
		}
		public static Fraction ToImproper(Fraction other)
		{
			other.Numerator += other.Integer * other.Denominator;
			other.Integer = 0;
			return other;
		}
		public Fraction ToImproper()
		{
			this.Numerator += this.Integer * this.Denominator;
			this.Integer = 0;
			return this;
		}
		public static Fraction Invert(Fraction other)
		{
			other = ToImproper(other);
			int temp = other.Numerator;
			other.Numerator = other.Denominator;
			other.Denominator = temp;
			return other;
		}
	}
}
