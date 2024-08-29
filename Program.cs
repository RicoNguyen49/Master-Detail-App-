using System;

abstract class Animal
{
    // Property
    public abstract string Name { get; set; }

    // Methods
    public abstract string Describe();
    public string whatAmI()
    {
        return "I am an animal";
    }
}
class Program
{
    class Dog : Animal
    {
        // override the abstract property
        public override string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }


        // Default constructor
        public Dog(){
           Species = "Unknown";
           Age = 0;
        }

        public Dog(string name, string species, int age)
        {
            Name = name;
            Species = species;
            Age = age;
        }

        // Override Describe method
        public override string Describe()
        {
            return $"{Name} is a {Species} and is {Age} years old.";
        }
    }
    static void Main(string[] args)
    {
        // Using default constructor for Dog1
        Dog dog1 = new Dog();
        dog1.Name = "Tido";
        dog1.Species = "Dog";
        dog1.Age = 3;

        // Using parameterized constructor for Dog2
        Dog dog2 = new Dog("Jake", "Dog", 5);

        // Display information
        Console.WriteLine(dog1.Describe());
        Console.WriteLine(dog1.whatAmI());

        Console.WriteLine(dog2.Describe());
        Console.WriteLine(dog2.whatAmI());
    }
}
