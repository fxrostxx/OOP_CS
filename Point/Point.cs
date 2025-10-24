using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
	internal class Point
	{
		//private double x;
		//private double y;
		//public double X
		//{
		//	get
		//	{
		//		return x;
		//	}
		//	set
		//	{
		//		x = value;
		//	}
		//}
		//public double Y
		//{
		//	get
		//	{
		//		return y;
		//	}
		//	set
		//	{
		//		y = value;
		//	}
		//}
		public Point(double x = 0, double y = 0)
		{
			X = x;
			Y = y;
			Console.WriteLine($"Constructor: {this.GetHashCode()}");
		}
		public Point(Point other)
		{
			this.X = other.X;
			this.Y = other.Y;
			Console.WriteLine($"CopyConstructor: {this.GetHashCode()}");
		}
		~Point()
		{
			Console.WriteLine($"Destructor: {this.GetHashCode()}");
		}
		public static Point operator+(Point left, Point right)
		{
			return new Point(left.X + right.X, left.Y + right.Y);
		}
		public double X { get; set; }
		public double Y { get; set; }
		//public double GetX()
		//{
		//	return x;
		//}
		//public double GetY()
		//{
		//	return y;
		//}
		//public void SetX(double x)
		//{
		//	this.x = x;
		//}
		//public void SetY(double y)
		//{
		//	this.y = y;
		//}
		public void Info()
		{
			Console.WriteLine($"X = {X}, Y = {Y}");
		}
	}
}
