using System;

class Menu
{
    public void MainScreen()
    {
        Console.WriteLine();
        Console.WriteLine("================================================================================");
        Console.WriteLine("                         STUDENT MANAGEMENT SYSTEM");
        Console.WriteLine("================================================================================");

        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. View All Students");
        Console.WriteLine("3. Search Student");
        Console.WriteLine("4. Update Student");
        Console.WriteLine("5. Delete Student");
        Console.WriteLine("6. Save Students");
        Console.WriteLine("7. Load Students");
        Console.WriteLine("8. Exit");

        Console.WriteLine("================================================================================");

        Console.Write("Enter Your Choice: ");
    }
}