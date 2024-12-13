using EF_Relations.Models;
using Microsoft.EntityFrameworkCore;
using System;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container

//One to one DBContext
//builder.Services.AddDbContext<OnetoOneAppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//One to Many DBContext
//builder.Services.AddDbContext<OnetoManyAppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Many to Many DBContext
builder.Services.AddDbContext<ManytoManyAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




#region Many-to-Many

// Many-to-Many relationship APIs
app.MapGet("/students", async (ManytoManyAppDbContext context) =>
{
    var students = await context.Students
        .Include(s => s.StudentCourses)
        .ThenInclude(sc => sc.Course)
        .Select(s => new
        {
            Id = s.Id,
            Name = s.Name,
            Courses = s.StudentCourses.Select(sc => new
            {
                Id = sc.Course.Id,
                Name = sc.Course.Name
            }).ToList()
        })
        .ToListAsync();

    return Results.Ok(students);
});


app.MapPost("/students", async (Student student, ManytoManyAppDbContext db) =>
{
    db.Students.Add(student);
    await db.SaveChangesAsync();
    return Results.Created($"/students/{student.Id}", student);
});

#endregion


#region One-to-ManyEndPoint

// One-to-Many relationship APIs
//app.MapGet("/blogs", async (OnetoManyAppDbContext db) => await db.Blogs.Include(b => b.Posts).ToListAsync());
//app.MapPost("/blogs", async (Blog blog, OnetoManyAppDbContext db) =>
//{
//    db.Blogs.Add(blog);
//    await db.SaveChangesAsync();
//    return Results.Created($"/blogs/{blog.Id}", blog);
//});


#endregion


#region OnetoOneEndPoints

// One-to-One relationship APIs
//app.MapGet("/taxpayers", async (OnetoOneAppDbContext db) => await db.Taxpayers.Include(u => u.Taxrecord).ToListAsync());
//app.MapPost("/taxpayer", async (TaxPayer taxpayer, OnetoOneAppDbContext db) =>
//{
//    db.Taxpayers.Add(taxpayer);
//    await db.SaveChangesAsync();
//    return Results.Created($"/taxpayers/{taxpayer.Id}", taxpayer);
//});

#endregion


app.Run();