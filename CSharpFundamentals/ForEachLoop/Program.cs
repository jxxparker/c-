using System;

namespace ForEachLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "jihun park";

            for (var i = 0; i < name.Length; i++)
            {
                System.Console.WriteLine(name[i]);
            }

            foreach (var character in name)
            {
                System.Console.WriteLine(character);
            }

            var numbers = new int[] {1, 2, 3, 4};
            foreach (var number in numbers)
            {
                System.Console.WriteLine(number);
            }
        }
    }
}
