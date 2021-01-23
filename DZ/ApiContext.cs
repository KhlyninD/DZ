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
            test();
            SaveChanges();
        }


        public DbSet<Company> Companies { get; set; }

        public DbSet<Employee> Employies { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Specialization>().HasData(
        //        new Specialization[]
        //        {
        //            new Specialization {Id = 1, NameSpecialization="IT" },
        //            new Specialization {Id = 2, NameSpecialization="Bank" },
        //        });
        //    modelBuilder.Entity<Company>().HasData(
        //        new Company[]
        //        {
        //            new Company { Id=1, NameCamp="Giga", Specialization = "IT"},
        //            new Company { Id=2, NameCamp="MKB"},
        //        });
        //    modelBuilder.Entity<Employee>().HasData(
        //        new Employee[]
        //        {
        //            new Employee { Id=1, Name="Ivan", Surname="Ivanov", Otchestvo="Ivanovich", Birthday = new DateTime(2008, 5, 15)},
        //            new Employee { Id=2, Name="Sergey", Surname="Sergeev", Otchestvo="Sergeevich", Birthday = new DateTime(2001, 2, 20)}
        //        });
        //    algorithms.Students.AddRange(new List<Student>() { tom, bob });
        //    Specializations.Where(u => u.Id = 1)
        //}
        //using (ApiContext db = new ApiContext())
        //{
        //}
        void test()
        {
            Specialization it = new Specialization {Id = 1, NameSpecialization = "IT" };
            Specialization bank = new Specialization {Id = 2, NameSpecialization = "Bank" };
            Specializations.AddRange(it, bank);

            Company giga = new Company { Id = 1, NameCamp = "Giga" };
            Company mkb = new Company { Id = 2, NameCamp = "MKB" };
            Companies.AddRange(giga, mkb);

            giga.Specialization.Add(it);
            mkb.Specialization.Add(bank);
        }
    }
}
