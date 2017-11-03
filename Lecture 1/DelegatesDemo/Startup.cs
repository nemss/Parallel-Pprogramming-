namespace DelegatesDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private delegate void SimpleDelegate();
        private static int b;

        private static void Main(string[] args)
        {
            SimpleDelegate d = DoSimple;

            d();

            List<int> numbers = Enumerable.Range(0, 10).ToList();

            Console.WriteLine("Enter a boundary:");
            int boundary = Int32.Parse(Console.ReadLine());
            b = boundary;

            Predicate<int> p = IsGreaterThanX;
            numbers.Find(p);

            var i = numbers.Find(n => n > boundary);
            Console.WriteLine(i);
            Console.ReadLine();
        }

        private static void DoSimple()
        {
            Console.WriteLine("Simple method.");
        }

        private static bool IsGreaterThanX(int n)
        {
            return n > b;
        }
    }
}