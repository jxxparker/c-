using System;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 1;
            var b = 2;
            var c = 3;
            System.Console.WriteLine(a + b);
            System.Console.WriteLine(a/b);
            System.Console.WriteLine((float)a / (float)b);
            System.Console.WriteLine(a + b * c);
            System.Console.WriteLine((a + b) * c);
            System.Console.WriteLine(a > b);
            System.Console.WriteLine(a == b);
            System.Console.WriteLine(a != b);
            System.Console.WriteLine(!(a != b));
            System.Console.WriteLine(c > b && c > a);
            System.Console.WriteLine(c > b || c == a);
        }
    }
}
