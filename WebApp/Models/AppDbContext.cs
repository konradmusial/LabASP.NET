using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WebApp.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organization { get; set; }
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
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organization")
            .HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    NIP = "2837984",
                    Name = "WSEI",
                    REGON = "19273918739",
                },
                new OrganizationEntity()
                {
                    Id = 102,
                    NIP = "276567764",
                    Name = "ASDASD",
                    REGON = "192876876876718739",
                }
            );

        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .HasData(
                new { OrganizationEntityId = 101, Street = "św. Filipa 17", City = "Kraków" },
                new { OrganizationEntityId = 102, Street = "Dworcowa 7", City = "Łódź" }
            );

        modelBuilder.Entity<ContactEntity>()
            .Property(c => c.OrganizationId)
            .HasDefaultValue(101);
        
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
                    Created = DateTime.Now,
                    OrganizationId = 101,
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "asd",
                    LastName = "Kfdsfds",
                    Email = "afdsfsdf@afdsfsdf.asd",
                    PhoneNumber = "555 123 123",
                    BirthDate = new DateOnly(year: 1999, month: 5, day: 5),
                    Created = DateTime.Now,
                    OrganizationId = 102
                }
            );
    }
}