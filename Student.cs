// Student inherits Person
class Student : Person
{
    private int rollNo;
    private string course;
    private int marks;

    // Properties
    public int RollNo
    {
        get { return rollNo; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Roll number must be greater than 0.");

            rollNo = value;
        }
    }

    public string Course
    {
        get { return course; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Course cannot be empty.");

            course = value;
        }
    }

    public int Marks
    {
        get { return marks; }
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Marks must be between 0 and 100.");

            marks = value;
        }
    }

    // Constructor
    public Student(
        int rollNo,
        string name,
        int age,
        string course,
        int marks) : base(name, age)
    {
        RollNo = rollNo;
        Course = course;
        Marks = marks;
    }

    // Method
    public string GetResult()
    {
        if (Marks >= 40)
            return "Pass";
        else
            return "Fail";
    }

    // Method
    public override void Display()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Roll No : {RollNo}");
        Console.WriteLine($"Name    : {Name}");
        Console.WriteLine($"Age     : {Age}");
        Console.WriteLine($"Course  : {Course}");
        Console.WriteLine($"Marks   : {Marks}");
        Console.WriteLine($"Result  : {GetResult()}");
        Console.WriteLine("--------------------------------");
    }
}