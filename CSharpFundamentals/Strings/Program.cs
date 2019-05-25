using System;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var firstName = "Jihun";
            var lastName = "Park";

            var fullName = firstName + " " + lastName;

            var myFullName = string.Format("My name is {0} {1}", firstName, lastName);

            var names = new string[3] {"Andy", "Jack", "Mary"};
            var formattedNames = string.Join(",", names);

            var text = @"Hi John
            look into the following paths
            folder1/folder2
            folder3/folder4";
            System.Console.WriteLine(text);

            
        }
    }
}
