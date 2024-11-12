using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WebApp.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }

    private string DbPath { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: $"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Kowal",
                    Email = "asd@asd.asd",
                    PhoneNumber = "123 123 123",
                    BirthDate = new DateOnly(year: 2000, month: 12, day: 13),
                    Created = DateTime.Now
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "asd",
                    LastName = "Kfdsfds",
                    Email = "afdsfsdf@afdsfsdf.asd",
                    PhoneNumber = "555 123 123",
                    BirthDate = new DateOnly(year: 1999, month: 5, day: 5),
                    Created = DateTime.Now
                }
            );
    }
}