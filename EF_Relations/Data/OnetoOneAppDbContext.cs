
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Storage;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//public class OnetoOneAppDbContext(DbContextOptions<OnetoOneAppDbContext> options)
//    : DbContext(options)
//{
//    // dotnet ef migrations add InitialCreate
//    // dotnet ef database update
//    public DbSet<TaxPayer>? Taxpayers { get; set; }
//    public DbSet<TaxRecord>? TaxRecords { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<TaxPayer>()
//       .HasOne(u => u.Taxrecord)
//       .WithOne(p => p.Taxpayer)
//       .HasForeignKey<TaxRecord>(p => p.TaxPayerID)
//       .OnDelete(DeleteBehavior.Cascade); // ===> Optional: Cascade delete behavior


//        // Seed Data for TaxPayers
//        modelBuilder.Entity<TaxPayer>().HasData(
//            new TaxPayer { Id = 1, FullName = "Ali" },
//            new TaxPayer { Id = 2, FullName = "Reza" },
//            new TaxPayer { Id = 3, FullName = "Sara" }
//        );

//        // Seed Data for TaxRecords
//        modelBuilder.Entity<TaxRecord>().HasData(
//            new TaxRecord { Id = 1, TaxCode = "TAX12345", TotalTaxPaid = 5000.00M, TaxPayerID = 1 },
//            new TaxRecord { Id = 2, TaxCode = "TAX67890", TotalTaxPaid = 7500.00M, TaxPayerID = 2 },
//            new TaxRecord { Id = 3, TaxCode = "TAX54321", TotalTaxPaid = 3000.00M, TaxPayerID = 3 }
//        );
//    }

//}








//#region onetooneflunetApi

//// modelBuilder.Entity<TaxPayer>()
////.HasOne(u => u.Taxrecord)
////.WithOne(p => p.Taxpayer)
////.HasForeignKey<TaxRecord>(p => p.TaxPayerID)
////.OnDelete(DeleteBehavior.Cascade); // ===> Optional: Cascade delete behavior

//#endregion

