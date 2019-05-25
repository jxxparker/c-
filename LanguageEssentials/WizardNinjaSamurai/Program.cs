using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Ashe = new Human("Ashe");
            Wizard Temo = new Wizard("Temo");
            Ninja MasterYi = new Ninja("MasterYi");
            Samurai Yasuo = new Samurai("Yasuo");


            // ----------------------------------- Game to see points ----------------------
            MasterYi.Steal(Temo);
            Console.WriteLine("MasterYi steals from {0}. {1} goes to MasterYi!", Temo.name, MasterYi.health);
            MasterYi.get_away();
            Console.WriteLine("MasterYi tries to get away! Health decrease {0}", MasterYi.health);
            Temo.fireball(MasterYi);
            Console.WriteLine("Temo fire back at {0}, and {0} health decrease to {1}", MasterYi.name, MasterYi.health);
            Yasuo.meditate();
            Console.WriteLine("Yasuo does not want to fight! His health is {0}", Yasuo.health);

            // Console.WriteLine(count);
            // Yasuo.how_many();
        }
    }
}