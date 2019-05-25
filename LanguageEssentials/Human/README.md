# Human
 Create a base Human class with five attributes: name, strength, intelligence, dexterity, and health.
 Give a default value of 3 for strength, intelligence, and dexterity. Health should have a default of 100.
 When an object is constructed from this class it should have the ability to pass a name
 Let's create an additional constructor that accepts 5 parameters, so we can set custom values for every field.
 Now add a new method called attack, which when invoked, should attack another Human object that is passed as a parameter. The damage done should be 5 * strength (5 points of damage to the attacked, for each 1 point of strength of the attacker).
 (Optional) Change the last function to accept any object and just make sure it is of type Human before applying damage. Hint you may need to refer back to the Boxing/Unboxing tab!