using System;
using System.Collections.Generic;

class StudentManager : StudentOperations
{
    // List to store students
    private List<Student> students = new List<Student>();


    // Add Student
    public override bool AddStudent(Student student)
    {
        try
        {
            if (student == null)
            {
                Console.WriteLine("Student data is null.");
                return false;
            }

            // Check duplicate Roll Number
            foreach (Student s in students)
            {
                if (s.RollNo == student.RollNo)
                {
                    Console.WriteLine("Roll Number already exists.");
                    return false;
                }
            }

            students.Add(student);

            Console.WriteLine("Student added successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }


    // View All Students
    public override void ViewAllStudents()
    {
        try
        {
            // Check List empty or not
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo Student Found.\n");
                return;
            }

            // Check null student
            foreach (Student student in students)
            {
                if (student == null)
                {
                    Console.WriteLine("Student data is null.");
                    return;
                }
            }

            Console.WriteLine(
                "\n================================================================================");

            Console.WriteLine(
                "                            ALL STUDENTS");

            Console.WriteLine(
                "================================================================================");


            // Display every student
            foreach (Student student in students)
            {
                Console.WriteLine("\nName         : " + student.name);
                Console.WriteLine("Age          : " + student.age);
                Console.WriteLine("Roll Number  : " + student.RollNo);
                Console.WriteLine("Course       : " + student.Course);
                Console.WriteLine("Marks        : " + student.Marks);

                Console.WriteLine(
                    "--------------------------------------------------------------------------------");
            }
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Student data is null.");
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("View operation completed.");
        }
    }


    // Search Student
    public override Student SearchStudent(int rollNo)
    {
        try
        {
            foreach (Student student in students)
            {
                if (student.RollNo == rollNo)
                {
                    return student;
                }
            }

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return null;
        }
    }


    // Update Student
    public override bool UpdateStudent(
        int rollNo,
        string name,
        int age,
        string course,
        int marks)
    {
        try
        {
            Student student = SearchStudent(rollNo);

            // Student not found
            if (student == null)
            {
                Console.WriteLine("Student Not Found.");
                return false;
            }

            student.name = name;
            student.age = age;
            student.Course = course;
            student.Marks = marks;

            Console.WriteLine("Student updated successfully.");

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }


    // Delete Student
    public override bool DeleteStudent(int rollNo)
    {
        try
        {
            Student student = SearchStudent(rollNo);

            // Student not found
            if (student == null)
            {
                Console.WriteLine("Student Not Found.");
                return false;
            }

            students.Remove(student);

            Console.WriteLine("Student deleted successfully.");

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
        finally
        {
            Console.WriteLine("Delete operation completed.");
        }
    }


    // Return Student List
    public List<Student> GetStudents()
    {
        return students;
    }


    // Set Student List
    public void SetStudents(List<Student> loadedStudents)
    {
        if (loadedStudents == null)
        {
            Console.WriteLine("Student list is null.");
            return;
        }

        students = loadedStudents;
    }
}