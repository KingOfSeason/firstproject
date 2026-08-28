using System;

abstract class StudentOperations
{
    // Abstract methods
    public abstract bool AddStudent(Student student);

    public abstract void ViewAllStudents();

    public abstract Student SearchStudent(int rollNo);

    public abstract bool UpdateStudent(
        int rollNo,
        string name,
        int age,
        string course,
        int marks);

    public abstract bool DeleteStudent(int rollNo);
}