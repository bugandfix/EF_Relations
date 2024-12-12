using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container

//One to one DBContext
//builder.Services.AddDbContext<OnetoOneAppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//One to Many DBContext
builder.Services.AddDbContext<OnetoManyAppDbContext>(options =>
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


#region One-to-ManyEndPoint

// One-to-Many relationship APIs
app.MapGet("/blogs", async (OnetoManyAppDbContext db) => await db.Blogs.Include(b => b.Posts).ToListAsync());
app.MapPost("/blogs", async (Blog blog, OnetoManyAppDbContext db) =>
{
    db.Blogs.Add(blog);
    await db.SaveChangesAsync();
    return Results.Created($"/blogs/{blog.Id}", blog);
});


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