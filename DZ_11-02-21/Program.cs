using System;

namespace DZ_11_02_21
{
	class Program
	{
		delegate T Operation<T>(T x, T y);
		public static T Add<T>(T x, T y) => (dynamic)x + (dynamic)y;
		public static T Substract<T>(T x, T y) => (dynamic)x - (dynamic)y;
		public static T Multiplication<T>(T x, T y) => (dynamic)x * (dynamic)y;
		public static T Division<T>(T x, T y)
		{
			if ((dynamic)y == 0)
			{
				throw new Exception("Ошибка деления на ноль");
			}
			return (dynamic)x / (dynamic)y;
		}
		static void Main(string[] args)
		{
			Operation<double> operation;
			double x, y;
			Console.WriteLine("Введите первое число:");
			while (!double.TryParse(Console.ReadLine(), out x))
			{
				Console.WriteLine("Введите корректное число:");
			}
			Console.WriteLine("Введите второе число");
			while (!double.TryParse(Console.ReadLine(), out y))
			{
				Console.WriteLine("Введите корректное число:");
			}
			Console.WriteLine("Введите операцию между этими числами");
			string oper = Console.ReadLine();
			switch (oper)
			{
				case "+":
					operation = Add;
					break;
				case "-":
					operation = Substract;
					break;
				case "*":
					operation = Multiplication;
					break;
				case "/":
					operation = Division;
					break;
				default:
					throw new Exception("Не верная оперция");
			}
			var rez = operation?.Invoke(x, y);
			Console.WriteLine(rez);
		}
	}
}
