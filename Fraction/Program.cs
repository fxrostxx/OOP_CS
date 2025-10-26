//#define CONSTRUCTORS
//#define ARITHMETICAL_OPERATORS
//#define INCREMENT_DECREMENT
//#define COMPARISON_OPERATORS
//#define CONVERSION_FROM_CLASS_TO_OTHER
#define HAVE_A_NICE_DAY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if CONSTRUCTORS
			Fraction A = new Fraction();
			A.Print();

			Fraction B = new Fraction(5);
			B.Print();

			Fraction C = new Fraction(1, 2);
			C.Print();

			Fraction D = new Fraction(2, 3, 4);
			D.Print();

			Fraction E = new Fraction(D);
			E.Print();
#endif

#if ARITHMETICAL_OPERATORS
			Fraction A = new Fraction(2, 3, 4);
			A.Print();
			Fraction B = new Fraction(3, 4, 5);
			B.Print();

			Fraction C = new Fraction(A * B);
			Console.Write("Проивзедение: "); C.Print();

			C = A / B;
			Console.Write("Частное: "); C.Print();

			C = A + B;
			Console.Write("Сумма: "); C.Print();

			C = A - B;
			Console.Write("Разность: "); C.Print();

			A += B;
			Console.Write("Сумма (+=): "); A.Print();

			Fraction D = new Fraction(1, 2, 3);
			Fraction E = new Fraction(2, 3, 4);

			D -= E;
			Console.Write("Разность (-=): "); D.Print();

			Fraction F = new Fraction(1, 2, 3);
			Fraction G = new Fraction(2, 3, 4);

			F *= G;
			Console.Write("Произведение (*=): "); F.Print();

			F /= G;
			Console.Write("Частное (/=): "); F.Print();
#endif

#if INCREMENT_DECREMENT
			Fraction H = new Fraction(1, 2, 3);
			Fraction I = new Fraction(2, 3, 4);

			I = ++H;
			Console.Write("Префиксный инкремент: "); I.Print();

			I = H++;
			Console.Write("Постфиксный инкремент: "); I.Print();
#endif

#if COMPARISON_OPERATORS
			Fraction J = new Fraction(1, 5, 3); J.Print();
			Fraction K = new Fraction(1, 2, 3); K.Print();

			Console.WriteLine($"Оператор сравнения (==): {J == K}");
			Console.WriteLine($"Оператор сравнения (!=): {J != K}");
			Console.WriteLine($"Оператор сравнения (>): {J > K}");
			Console.WriteLine($"Оператор сравнения (<): {J < K}");
			Console.WriteLine($"Оператор сравнения (>=): {J >= K}");
			Console.WriteLine($"Оператор сравнения (<=): {J <= K}");

			Fraction L = new Fraction(1, 15, 3);

			L.ReduceFraction();
			Console.Write($"Сокращение дроби: "); L.Print();
#endif

#if CONVERSION_FROM_CLASS_TO_OTHER
			Fraction A = new Fraction(1, 2, 3); A.Print();
			A.ToImproper();

			int a = (int)A;

			Console.WriteLine(a);

			double b = (double)A;

			Console.WriteLine(b);
#endif

#if HAVE_A_NICE_DAY
			Fraction A = new Fraction(2.75);
			A.Print();
#endif
		}
	}
}
