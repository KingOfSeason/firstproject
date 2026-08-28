// Parent class
class Person
{
    // Encapsulation
    private string name;
    private int age;

    // Properties
    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");

            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 1 || value > 100)
                throw new ArgumentException("Age must be between 1 and 100.");

            age = value;
        }
    }

    // Constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Polymorphism
    public virtual void Display()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age : {Age}");
    }
}