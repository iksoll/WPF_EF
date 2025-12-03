using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfApp12.Models;

namespace WpfApp12.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<InterestGroup> InterestGroups { get; set; }
        public DbSet<UserInterestGroup> UserInterestGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=WPF_EF;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId)
                .IsRequired(false);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<UserInterestGroup>()
                .HasKey(ug => new { ug.UserId, ug.InterestGroupId });

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.InterestGroups)
                .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(ug => ug.InterestGroup)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(ug => ug.InterestGroupId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login).IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<InterestGroup>()
                .HasIndex(g => g.Title).IsUnique();

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Title = "Пользователь" },
                new Role { Id = 2, Title = "Менеджер" },
                new Role { Id = 3, Title = "Администратор" }
            );

            modelBuilder.Entity<User>()
                .Property(u => u.RoleId)
                .HasDefaultValue(1);
        }
    }
}

