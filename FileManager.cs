using System;
using System.Collections.Generic;
using System.IO;

class FileManager
{
    private string filePath = "students.txt";


    // =========================
    // SAVE STUDENTS - OVERWRITE
    // =========================
    public void SaveStudents(List<Student> students)
    {
        try
        {
            // Check list
            if (students == null)
            {
                Console.WriteLine("Student list is null.");
                return;
            }

            // false = Overwrite
            using (StreamWriter writer =
                   new StreamWriter(filePath, false))
            {
                foreach (Student student in students)
                {
                    if (student == null)
                    {
                        Console.WriteLine("Student data is null.");
                        return;
                    }

                    writer.WriteLine(
                        student.name + "|" +
                        student.age + "|" +
                        student.RollNo + "|" +
                        student.Course + "|" +
                        student.Marks
                    );
                }
            }

            Console.WriteLine("Data saved successfully.");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Access denied: " + ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine("File error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Save operation completed.");
        }
    }


    // =========================
    // APPEND STUDENT
    // =========================
    public void AppendStudent(Student student)
    {
        try
        {
            if (student == null)
            {
                Console.WriteLine("Student data is null.");
                return;
            }

            // true = Append
            using (StreamWriter writer =
                   new StreamWriter(filePath, true))
            {
                writer.WriteLine(
                    student.name + "|" +
                    student.age + "|" +
                    student.RollNo + "|" +
                    student.Course + "|" +
                    student.Marks
                );
            }

            Console.WriteLine("Student appended successfully.");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Access denied: " + ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine("File error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Append operation completed.");
        }
    }


    // =========================
    // LOAD STUDENTS - READ
    // =========================
    public List<Student> LoadStudents()
    {
        List<Student> students = new List<Student>();

        try
        {
            // Check file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return students;
            }

            // Read file
            using (StreamReader reader =
                   new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    // Separate data
                    string[] data = line.Split('|');

                    if (data.Length != 5)
                    {
                        Console.WriteLine(
                            "Invalid student data found.");
                        continue;
                    }

                    string name = data[0];
                    int age = int.Parse(data[1]);
                    int rollNo = int.Parse(data[2]);
                    string course = data[3];
                    int marks = int.Parse(data[4]);

                    Student student = new Student(
                        rollNo,
                        name,
                        age,
                        course,
                        marks
                    );

                    students.Add(student);
                }
            }

            Console.WriteLine("Data loaded successfully.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine(
                "Invalid number format: " + ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(
                "File not found: " + ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(
                "File error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                "Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Load operation completed.");
        }

        return students;
    }
}