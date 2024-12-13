using EF_Relations.Models;
using Microsoft.EntityFrameworkCore;


public class ManytoManyAppDbContext(DbContextOptions<ManytoManyAppDbContext> options)
    : DbContext(options)
{
    // dotnet ef migrations add InitialCreate
    // dotnet ef database update
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.StudentId);

        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(sc => sc.CourseId);

        // Configure Many-to-Many relationship between Students and Courses
        modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });



        //Seed Data
        // Seed data for Students
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, Name = "Ali" },
            new Student { Id = 2, Name = "Reza" },
            new Student { Id = 3, Name = "Farhad" }
        );

        // Seed data for Courses
        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "C#" },
            new Course { Id = 2, Name = "SQL Server" },
            new Course { Id = 3, Name = "Printing" }
        );

        // Seed data for StudentCourse
        modelBuilder.Entity<StudentCourse>().HasData(
            new StudentCourse { StudentId = 1, CourseId = 1 },
            new StudentCourse { StudentId = 1, CourseId = 2 },
            new StudentCourse { StudentId = 2, CourseId = 2 },
            new StudentCourse { StudentId = 3, CourseId = 3 }
        );

    }

}