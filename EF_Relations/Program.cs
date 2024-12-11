using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container

//One to one DBContext
builder.Services.AddDbContext<OnetoOneAppDbContext>(options =>
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


// One-to-One relationship APIs
app.MapGet("/taxpayers", async (OnetoOneAppDbContext db) => await db.Taxpayers.Include(u => u.Taxrecord).ToListAsync());
app.MapPost("/taxpayer", async (TaxPayer taxpayer, OnetoOneAppDbContext db) =>
{
    db.Taxpayers.Add(taxpayer);
    await db.SaveChangesAsync();
    return Results.Created($"/taxpayers/{taxpayer.Id}", taxpayer);
});


app.Run();