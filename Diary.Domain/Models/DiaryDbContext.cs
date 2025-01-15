using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Diary.Domain.Models;

public class DiaryDbContext : DbContext
{
    public DbSet<DiaryEntry> DiaryEntries { get; set; }
    
    public DiaryDbContext(DbContextOptions<DiaryDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DiaryEntry>().HasData(
            new DiaryEntry()
            {
                Id = 1,
                Title = "Went Hiking",
                Content = "Hiked to the top of a mountain and saw amazing views.",
                CreateDate =
                    new DateTime(2024, 1, 2) // Non usare UtcNow perchè ad ogni migration EF core pensa ci siano dei cambiamenti. Utilizzare una data specifica.
            },
            new DiaryEntry()
            {
                Id = 2,
                Title = "Went Shopping",
                Content = "Went shopoping with Joe",
                CreateDate =
                    new DateTime(2024, 1, 2) // Non usare UtcNow perchè ad ogni migration EF core pensa ci siano dei cambiamenti. Utilizzare una data specifica.
            },
            new DiaryEntry()
            {
                Id = 3,
                Title = "Went Diving",
                Content = "Went diving with Joe",
                CreateDate =
                    new DateTime(2024, 1, 2) // Non usare UtcNow perchè ad ogni migration EF core pensa ci siano dei cambiamenti. Utilizzare una data specifica.
            }
        );
    }
}