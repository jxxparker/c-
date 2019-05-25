using Classes.Math;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = new Person();
            name.FirstName = "Jihun";
            name.LastName = "Park";
            name.Introduce();

            Calculator calculator = new Calculator();
            var result = calculator.Add(1,2);
            System.Console.WriteLine(result);
        }
    }
}
