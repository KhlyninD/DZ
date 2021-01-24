using Microsoft.EntityFrameworkCore;
using DZ.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DZ
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Employee> Employies { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sp = new Specialization[]
            {
                new Specialization {Id = 1, NameSpecialization="IT" },
                new Specialization {Id = 2, NameSpecialization="Bank" },
            };

            var camp = new Company[]
            {
                new Company { Id=1, NameCamp="Giga" },
                new Company { Id=2, NameCamp="MKB"}
            };

            //var camp = new Company[]
            //{
            //    new Company { Id=1, NameCamp="Giga", Specializations = new List<Specialization>() { sp[0] } },
            //    new Company { Id=2, NameCamp="MKB", Specializations = new List<Specialization>() { sp[1] } }
            //};


            var emp = new Employee[]
            {
                new Employee { Id=1, Name="Ivan", Surname="Ivanov", Otchestvo="Ivanovich", Birthday = "28 февраля 1990", CompanyId = 1},
                new Employee { Id=2, Name="Sergey", Surname="Sergeev", Otchestvo="Sergeevich", Birthday = "15 июня 1995", CompanyId = 2}
            };
            modelBuilder.Entity<Specialization>().HasData(sp);
            modelBuilder.Entity<Company>().HasData(camp);
            modelBuilder.Entity<Employee>().HasData(emp);

        }

    }
}
