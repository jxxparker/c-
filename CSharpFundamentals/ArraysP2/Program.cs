using System;

namespace ArraysP2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new [] {3, 7, 9, 2, 14, 6};
            System.Console.WriteLine("Length: " + numbers.Length);

            //indexof()
            var index = Array.IndexOf(numbers, 9);
            System.Console.WriteLine(index);

            Array.Clear(numbers, 0, 2);
            foreach (var n in numbers)
            System.Console.WriteLine(n);


        }
    }
}
