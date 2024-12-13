//using Microsoft.EntityFrameworkCore;


//public class OnetoManyAppDbContext(DbContextOptions<OnetoManyAppDbContext> options)
//    : DbContext(options)
//{
//    // dotnet ef migrations add InitialCreate
//    // dotnet ef database update
//    public DbSet<Blog> Blogs { get; set; }
//    public DbSet<Post> Posts { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        //Flunet API
//        modelBuilder.Entity<Post>()
//        .HasOne(p => p.Blog)
//        .WithMany(b => b.Posts)
//        .HasForeignKey(p => p.BlogId);


//        // Seed Data for Blogs
//        modelBuilder.Entity<Blog>().HasData(
//        new Blog { Id = 1, Title = "BugandFix" },
//        new Blog { Id = 2, Title = "Travel Diaries" },
//        new Blog { Id = 3, Title = "Food Adventures" });

//        // Seed Data for Posts
//        modelBuilder.Entity<Post>().HasData(
//        new Post { Id = 1, Content = "Latest in AI", BlogId = 1 },
//        new Post { Id = 2, Content = "Quantum Computing", BlogId = 1 },
//        new Post { Id = 3, Content = "Exploring Japan", BlogId = 2 },
//        new Post { Id = 4, Content = "Backpacking Europe", BlogId = 2 },
//        new Post { Id = 5, Content = "Best Street Foods", BlogId = 3 },
//        new Post { Id = 6, Content = "Gourmet Experiences", BlogId = 3 });
//    }

//}