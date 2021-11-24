using ContosoStudent.Models;

namespace ContosoStudent.Services;

public static class StudentService
{
    static List<Student> Students { get; }
    static int nextId = 3;
    static StudentService()
    {
        Students = new List<Student>
        {
            new Student { Id = 1, Name = "TOm", Address = "home" },
            new Student { Id = 2, Name = "Jerry", Address = "house" }
        };
    }

    public static List<Student> GetAll() => Students;

    public static Student? Get(int id) => Students.FirstOrDefault(p => p.Id == id);

    public static void Add(Student student)
    {
        student.Id = nextId++;
        Students.Add(student);
    }

    public static void Delete(int id)
    {
        var student = Get(id);
        if(student is null)
            return;

        Students.Remove(student);
    }

    public static void Update(Student student)
    {
        var index = Students.FindIndex(p => p.Id == student.Id);
        if(index == -1)
            return;

        Students[index] = student;
    }
}