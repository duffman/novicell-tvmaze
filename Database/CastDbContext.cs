using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TvMazeWebApp.DataProvider.Types;

namespace TvMazeWebApp.Database
{
    public class CastDbContext : DbContext
    {
        public DbSet<CastMember> CastMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TestDatabase.db",
                options => { options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName); });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<CastMember>().ToTable("CastMembers", "test");
            modelBuilder.Entity<CastMember>(entity =>
            {
                entity.HasKey(e => e.Person.Id);
                entity.HasIndex(e => e.Person.Name).IsUnique();
                entity.Property(e => e.Person.Birthday).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}