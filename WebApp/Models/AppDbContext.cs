using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WebApp.Models;

public class AppDbContext: IdentityDbContext<IdentityUser>
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
        base.OnModelCreating(modelBuilder);
        var ADMIN_ID = Guid.NewGuid().ToString();
        var ADMIN_ROLE_ID = Guid.NewGuid().ToString();
        var USER_ID = Guid.NewGuid().ToString();
        var USER_ROLE_ID = Guid.NewGuid().ToString();
        //dodaj role user
        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole()
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "admin",
                    NormalizedName = "admin".ToUpper(),
                    ConcurrencyStamp = ADMIN_ROLE_ID
                },
        new IdentityRole()
            {
                Id = USER_ROLE_ID,
                Name = "user",
                NormalizedName = "user".ToUpper(),
                ConcurrencyStamp = USER_ROLE_ID
            }
            );
        var admin = new IdentityUser()
        {
            Id = ADMIN_ID,
            UserName = "karol",
            NormalizedUserName = "karol".ToUpper(),
            Email = "karol@wsei.edu.pl",
            NormalizedEmail = "karol@wsei.edu.pl".ToUpper(),
            EmailConfirmed = true
        };
        var user = new IdentityUser()
        {
            Id = USER_ID,
            UserName = "maciek",
            NormalizedUserName = "maciek".ToUpper(),
            Email = "maciek@wsei.edu.pl",
            NormalizedEmail = "maciek@wsei.edu.pl".ToUpper(),
            EmailConfirmed = true
        };
        // utworz uzytkownika user
        
        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        admin.PasswordHash = hasher.HashPassword(admin, "1234!");
        user.PasswordHash = hasher.HashPassword(user, "abcd@");
        modelBuilder.Entity<IdentityUser>()
            .HasData(admin, user);

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            },
                new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = ADMIN_ID
            }
            );
        
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
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
                    OrganizationId = 101
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