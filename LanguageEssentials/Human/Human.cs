namespace Human{

    public class Human{

        // this is my constructor
        public string name;
        public int strength = 3; // default values of 3
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100; // defaul values of 100

        public Human(string str)
        {
            name = str;
        }
        // setting attributes
        public Human(int val)
        {
            strength = val;
            intelligence = val;
            dexterity = val;
            health = val;
        }

        public string Attack(object thing, int damage)
        {
            if (thing is Human2)
            {
                Human2 person = (Human2)thing;
                damage = strength * 5;
                person.health -= damage;
                strength += 1;
                // return ("person");
                return $"{person.name} was damaged {damage}. Health is now {person.health}. {name}'s strength is now {strength}.";
            }
            else
            {
                return ("Not attacking human!");
            }
        }
    }


}
