using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{


    public partial class RentalCarDbContext : DbContext
    {
        public RentalCarDbContext()
        {
        }

        public RentalCarDbContext(DbContextOptions<RentalCarDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<CarName> CarNames { get; set; }

        public virtual DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Vehicle>(entity =>
            //{
            //    // entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            //    // Primary key
            //    entity.HasKey(u => u.Id);

            //    entity.Property(e => e.CarNameId);
            //    entity.Property(e => e.ModelId);
            //    entity.Property(e => e.Year);
            //    entity.Property(e => e.ImageName);
            //    entity.Property(e => e.ImageData);
            //});

            modelBuilder.Entity<User>(entity =>
            {
                // Primary key
                entity.HasKey(u => u.UserId);

                entity.Property(e => e.UserName)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            var ph = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User[]
            {
                CreateUser(1, "Gavriel", "9876", "email1@gmail.com", 0, ph),
                CreateUser(2, "Israel", "1234", "email12@gmail1.com", 0, ph),
                CreateUser(3, "Iris", "5678", "email13@gmail.com", 1, ph)
            });

            modelBuilder.Entity<CarName>().HasData(new CarName[]
            {
                new CarName{ Id = 1, Name = "BMW" },
                new CarName{ Id = 2, Name = "Audi" },
                new CarName{ Id = 3, Name = "Mazda" },
                new CarName{ Id = 4, Name = "Toyota" },
                new CarName{ Id = 5, Name = "Tesla" },
                new CarName{ Id = 6, Name = "Mercedes" }
            });

            modelBuilder.Entity<CarModel>().HasData(new CarModel[]
            {
                new CarModel{ Id = 1, CarNameId = 1, Name = "i4 M50" },
                new CarModel{ Id = 2, CarNameId = 1, Name = "5 Series" },
                new CarModel{ Id = 3, CarNameId = 1, Name = "4 Series Coupé" },
                new CarModel{ Id = 4, CarNameId = 2, Name = "A3" },
                new CarModel{ Id = 5, CarNameId = 2, Name = "A6 Avant" },
                new CarModel{ Id = 6, CarNameId = 2, Name = "Q3 Sportback" },
                new CarModel{ Id = 7, CarNameId = 3, Name = "CX-5" },
                new CarModel{ Id = 8, CarNameId = 3, Name = "CX-30" },
                new CarModel{ Id = 9, CarNameId = 3, Name = "MX-5" },
                new CarModel{ Id = 10, CarNameId = 4, Name = "Prius" },
                new CarModel{ Id = 11, CarNameId = 4, Name = "Yaris" },
                new CarModel{ Id = 12, CarNameId = 4, Name = "C-HR" },
                new CarModel{ Id = 13, CarNameId = 5, Name = "3" },
                new CarModel{ Id = 14, CarNameId = 5, Name = "X" },
                new CarModel{ Id = 15, CarNameId = 5, Name = "Y" },
                new CarModel{ Id = 16, CarNameId = 6, Name = "GLC" },
                new CarModel{ Id = 17, CarNameId = 6, Name = "GLE" },
                new CarModel{ Id = 18, CarNameId = 6, Name = "GLS" },
            });

            OnModelCreatingPartial(modelBuilder);
        }

        User CreateUser(int id, string userName, string password, string email, int roleID, PasswordHasher<User> ph)
        {
            User user = new User { UserId = id, UserName = userName, Email = email, RoleId = roleID };
            user.Password = ph.HashPassword(user, password);
            return user;
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}