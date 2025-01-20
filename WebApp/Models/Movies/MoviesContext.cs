using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Movies
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieCast> MovieCasts { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public object ProductionCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.HasKey(m => m.MovieId);
                entity.Property(m => m.MovieId).HasColumnName("movie_id");
                entity.Property(m => m.Title).HasColumnName("title");
                entity.Property(m => m.Budget).HasColumnName("budget");
                entity.Property(m => m.Homepage).HasColumnName("homepage");
                entity.Property(m => m.Overview).HasColumnName("overview");
                entity.Property(m => m.Popularity).HasColumnName("popularity");
                entity.Property(m => m.ReleaseDate).HasColumnName("release_date");
                entity.Property(m => m.Revenue).HasColumnName("revenue");
                entity.Property(m => m.Runtime).HasColumnName("runtime");
                entity.Property(m => m.MovieStatus).HasColumnName("movie_status");
                entity.Property(m => m.Tagline).HasColumnName("tagline");
                entity.Property(m => m.VoteAverage).HasColumnName("vote_average");
                entity.Property(m => m.VoteCount).HasColumnName("vote_count");

                entity.HasMany(m => m.MovieCasts)
                    .WithOne(mc => mc.Movie)
                    .HasForeignKey(mc => mc.MovieId);
            });

            modelBuilder.Entity<MovieCast>(entity =>
            {
                entity.ToTable("movie_cast");
                
                entity.HasKey(mc => new { mc.MovieId, mc.PersonId });

                entity.Property(mc => mc.MovieId).HasColumnName("movie_id");
                entity.Property(mc => mc.PersonId).HasColumnName("person_id");
                entity.Property(mc => mc.CharacterName).HasColumnName("character_name");
                entity.Property(mc => mc.GenderId).HasColumnName("gender_id");
                entity.Property(mc => mc.CastOrder).HasColumnName("cast_order");

                entity.HasOne(mc => mc.Movie)
                    .WithMany(m => m.MovieCasts)
                    .HasForeignKey(mc => mc.MovieId);

                entity.HasOne(mc => mc.Person)
                    .WithMany()
                    .HasForeignKey(mc => mc.PersonId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasKey(p => p.PersonId);
                entity.Property(p => p.PersonId).HasColumnName("person_id");
                entity.Property(p => p.PersonName).HasColumnName("person_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}