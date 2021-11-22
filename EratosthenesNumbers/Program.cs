using System;

namespace Eratosthenes
{
    class Program
    {
        
        static void Main(string[] args)
        {
            primenumGenerator pnum = new primenumGenerator();
            Console.WriteLine("Введите число");
            int inp = Convert.ToInt32(Console.ReadLine());
            pnum.Setget_n = inp;
            var digits = pnum.prime();
            Console.WriteLine("Простые числа: ");
            Console.WriteLine(string.Join(", ", digits));
        }
    }
}
