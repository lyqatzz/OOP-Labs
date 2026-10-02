using System;

namespace Lab3_15var_OOP
{
    class Program
    {
        const double a = 0.1;
        const double b = 1.0;
        const int k = 9;
        const int n = 30;
        const double eps = 0.0001;

        static void Main()
        {
            Console.WriteLine("Лабораторная работа №3. Вариант 15.");
            Console.WriteLine("y = (1 + x^2)/2 * arctg(x) - x/2");
            Console.WriteLine("S = x^3/3 - x^5/15 + ... + (-1)^(n+1) * x^(2n+1)/(4n^2 - 1)");
            Console.WriteLine($"a = {a}, b = {b}, k = {k}, n = {n}, eps = {eps}");
            Console.WriteLine();

            Console.WriteLine($"{"X",10} {"SN",12} {"SE",12} {"Y",12}");
            Console.WriteLine("-------------------------------------------------");

            double step = (b - a) / k;
            for (double x = a; x <= b; x += step)
            {
                double SN = SumN(x, n);
                double SE = SumEps(x);
                double Y = ExactY(x);
                Console.WriteLine($"{x,10:F3} {SN,12:F6} {SE,12:F6} {Y,12:F6}");
            }
        }

        static double NextVal(double a, double x, int n) => -x* x *(4 * n * n - 1) / (4 * n * n + 8 * n + 3) * a;

        static double SumN(double x, int n)
        {
            double sum = 0;
            double a = x * x * x / 3;
            for (int i = 1; i <= n; i++)
            {
                sum += a;
                a = NextVal(a, x, i);
            }
            return sum;
        }

        static double SumEps(double x)
        {
            double sum = 0;
            double a = x * x * x / 3;
            int i = 1;
            while (Math.Abs(a) >= eps)
            {
                sum += a;
                a = NextVal(a, x, i);
                i++;
            }
            return sum;
        }

        static double ExactY(double x) => (1 + x * x) / 2 * Math.Atan(x) - x / 2;
    }
}