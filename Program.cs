using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Objects
        StudentManager manager = new StudentManager();
        FileManager fileManager = new FileManager();
        Menu menu = new Menu();

        bool running = true;

        // Menu loop
        while (running)
        {
            try
            {
                menu.MainScreen();

                string choiceInput = Console.ReadLine();

                int choice = int.Parse(choiceInput);

                switch (choice)
                {
                    case 1:
                        AddStudent(manager);
                        break;

                    case 2:
                        manager.ViewAllStudents();
                        break;

                    case 3:
                        SearchStudent(manager);
                        break;

                    case 4:
                        UpdateStudent(manager);
                        break;

                    case 5:
                        DeleteStudent(manager);
                        break;

                    case 6:
                        fileManager.SaveStudents(
                            manager.GetStudents());
                        break;

                    case 7:
                        List<Student> loadedStudents =
                            fileManager.LoadStudents();

                        manager.SetStudents(loadedStudents);
                        break;

                    case 8:
                        running = false;
                        Console.WriteLine(
                            "\nThank You!");
                        break;

                    default:
                        Console.WriteLine(
                            "\nInvalid Choice.");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(
                    "\nPlease enter a valid number.");

                Console.WriteLine(
                    "Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "\nSomething went wrong.");

                Console.WriteLine(
                    "Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine(
                    "\nOperation completed.");
            }
        }
    }


    // ==================================================
    // ADD STUDENT
    // ==================================================

    static void AddStudent(StudentManager manager)
    {
        try
        {
            Console.Write("\nEnter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Roll Number: ");
            int rollNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Course: ");
            string course = Console.ReadLine();

            Console.Write("Enter Marks: ");
            int marks = int.Parse(Console.ReadLine());


            // Create Student Object
            Student student = new Student(
                rollNo,
                name,
                age,
                course,
                marks
            );


            // Add Student
            bool result = manager.AddStudent(student);

            if (result)
            {
                Console.WriteLine(
                    "\nStudent Added Successfully.");
            }
            else
            {
                Console.WriteLine(
                    "\nStudent could not be added.");
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine(
                "\nPlease enter correct numeric value.");

            Console.WriteLine(
                "Error: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(
                "\nInvalid Student Data.");

            Console.WriteLine(
                "Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                "\nError: " + ex.Message);
        }
    }


    // ==================================================
    // SEARCH STUDENT
    // ==================================================

    static void SearchStudent(StudentManager manager)
    {
        try
        {
            Console.Write(
                "\nEnter Roll Number to Search: ");

            int rollNo = int.Parse(
                Console.ReadLine());


            Student student =
                manager.SearchStudent(rollNo);


            // Student not found
            if (student == null)
            {
                Console.WriteLine(
                    "\nStudent Not Found.");

                return;
            }


            // Student found
            Console.WriteLine(
                "\nStudent Found!");

            Console.WriteLine(
                "\nName         : " + student.name);

            Console.WriteLine(
                "Age          : " + student.age);

            Console.WriteLine(
                "Roll Number  : " + student.RollNo);

            Console.WriteLine(
                "Course       : " + student.Course);

            Console.WriteLine(
                "Marks        : " + student.Marks);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(
                "\nInvalid Roll Number.");

            Console.WriteLine(
                "Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                "\nError: " + ex.Message);
        }
    }


    // ==================================================
    // UPDATE STUDENT
    // ==================================================

    static void UpdateStudent(StudentManager manager)
    {
        try
        {
            Console.Write(
                "\nEnter Roll Number to Update: ");

            int rollNo = int.Parse(
                Console.ReadLine());


            Student existingStudent =
                manager.SearchStudent(rollNo);


            // Student not found
            if (existingStudent == null)
            {
                Console.WriteLine(
                    "\nStudent Not Found.");

                return;
            }


            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter New Age: ");
            int age = int.Parse(
                Console.ReadLine());

            Console.Write("Enter New Course: ");
            string course = Console.ReadLine();

            Console.Write("Enter New Marks: ");
            int marks = int.Parse(
                Console.ReadLine());


            bool result =
                manager.UpdateStudent(
                    rollNo,
                    name,
                    age,
                    course,
                    marks
                );


            if (result)
            {
                Console.WriteLine(
                    "\nStudent Updated Successfully.");
            }
            else
            {
                Console.WriteLine(
                    "\nStudent Update Failed.");
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine(
                "\nPlease enter valid values.");

            Console.WriteLine(
                "Error: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(
                "\nInvalid Student Data.");

            Console.WriteLine(
                "Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                "\nError: " + ex.Message);
        }
    }


    // ==================================================
    // DELETE STUDENT
    // ==================================================

    static void DeleteStudent(StudentManager manager)
    {
        try
        {
            Console.Write(
                "\nEnter Roll Number to Delete: ");

            int rollNo = int.Parse(
                Console.ReadLine());


            Student student =
                manager.SearchStudent(rollNo);


            // Student not found
            if (student == null)
            {
                Console.WriteLine(
                    "\nStudent Not Found.");

                return;
            }


            bool result =
                manager.DeleteStudent(rollNo);


            if (result)
            {
                Console.WriteLine(
                    "\nStudent Deleted Successfully.");
            }
            else
            {
                Console.WriteLine(
                    "\nStudent Delete Failed.");
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine(
                "\nInvalid Roll Number.");

            Console.WriteLine(
                "Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                "\nError: " + ex.Message);
        }
    }
}