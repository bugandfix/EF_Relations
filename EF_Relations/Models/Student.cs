using System;
using System.Text.Json.Serialization;

namespace EF_Relations.Models;

// A single student can enroll in multiple courses.

// A single course can have multiple students enrolled.


public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonIgnore]
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}

public class Course
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [JsonIgnore]  
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}

public class StudentCourse
{
    
    public Student? Student { get; set; }
    public Course? Course { get; set; }
    public int CourseId { get; set; }

    public int StudentId { get; set; }

}
