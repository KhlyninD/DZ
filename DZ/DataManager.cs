using DZ.DbModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace DZ
{
    public class DataManager
    {
        ApiContext db;

        public DataManager(ApiContext context)
        {
            db = context;
        }

        // Вывод всех специализаций
        public IEnumerable<Information> GetAllSpecialization()
        {
            return db.Specializations.Select(s => new Information() { Id = s.Id, Name = s.NameSpecialization }).ToList();
        }

        // Вывод всех компаний
        public IEnumerable<Information> GetAllCompany()
        {
            return db.Companies.Select(c => new Information() { Id = c.Id, Name = c.NameCamp }).ToList();
        }

        // Вывод всех сотрудников
        public IEnumerable<Information> GetAllEmployee()
        {
            return db.Employies.Select(e => new InformationDetals() { Id = e.Id, Name = String.Join(", ", e.Name, e.Otchestvo, e.Surname), Date = e.Birthday }).ToList();
        }

        // Добавление новой специализации
        public bool Post(string nameSpecialization)
        {
            if (db.Specializations.Any(u => u.NameSpecialization.ToLower() == nameSpecialization.ToLower()))
            {
                return false;
            }
            Specialization sp = new Specialization { NameSpecialization = nameSpecialization };
            db.Specializations.Add(sp);
            db.SaveChangesAsync();
            return true;
        }

        // Добавление новой компании
        public bool Post(string nameCompany, string nameSpecialization)
        {
            if (db.Companies.Any(u => u.NameCamp.ToLower() == nameCompany.ToLower()))
            {
                return false;
            }
            var sp = db.Specializations.Where(s => s.NameSpecialization.ToLower() == nameSpecialization.ToLower());
            Company cp = new Company { NameCamp = nameCompany, Specializations = new List<Specialization>(sp) }; 
            db.Companies.Add(cp);
            db.SaveChangesAsync();
            return true;
        }

        // Добавление нового сотрудника по названию компании
        public bool Post(string name, string surname, string otchestvo, string nameCompany, string birthday)
        {
            if (!db.Companies.Any(с => с.NameCamp.ToLower() == nameCompany.ToLower()))
                return false;
            
            Employee ep = new Employee { Name = name, Surname = surname, Otchestvo = otchestvo, Birthday = birthday, CompanyId = 1};
            db.Employies.Add(ep);
            db.SaveChangesAsync();
            return true;
        }

        // Добавление нового сотрудника по ID компании
        public bool Post(string name, string surname, string otchestvo, int idCompan, string birthday)
        {

            if (!db.Companies.Any(c => c.Id == idCompan))
                return false;

            Employee ep = new Employee { Name = name, Surname = surname, Otchestvo = otchestvo, Birthday = birthday, CompanyId = idCompan};
            db.Employies.Add(ep);
            db.SaveChangesAsync();
            return true;
        }

        // Удаление специализации
        public bool DeleteS(int idSp)
        {
            if (!db.Specializations.Any(u => u.Id == idSp))
            {
                return false;
            }
            if (db.Companies.Any(s => s.Specializations.Any(t => t.Id == idSp) == true))
            {
                return false;
            }
            //var t = db.Companies.Select(s => new test() { Specialization = s.Specialization }).ToList();
            //var s = t.Select(s => new test2() { Id = s.Id }).ToList();
            //if (t.Exists(x => x.Id == idSp))
            //{
            //    return false;
            //}

            //if (db.Companies.Any(s => s.Specialization.Exists(t => t.Id == idSp) == true))
            //{
            //    return false;
            //}
            Specialization special = db.Specializations.FirstOrDefault(x => x.Id == idSp);
            db.Specializations.Remove(special);
            db.SaveChanges();
            return true;
        }

        // Удаление компании
        public bool DeleteС(int idCp)
        {
            if (!db.Companies.Any(u => u.Id == idCp))
            {
                return false;
            }
            if (db.Companies.Any(s => s.Employies.Any(t => t.Id == idCp) == true))
            {
                return false;
            }
                        
            Company comany = db.Companies.FirstOrDefault(x => x.Id == idCp);
            db.Companies.Remove(comany);
            db.SaveChanges();
            return true;
        }

        // Удаление сотрудника
        public bool DeleteE(int idCp)
        {
            if (!db.Companies.Any(u => u.Id == idCp))
            {
                return false;
            }

            Employee emp = db.Employies.FirstOrDefault(x => x.Id == idCp);
            db.Employies.Remove(emp);
            db.SaveChanges();
            return true;
        }

        //// Изменение специализации
        //public bool Put(string oldSpecialization, string newSpecialization)
        //{
        //    if (!db.Specializations.Any(u => u.NameSpecialization.ToLower() == oldSpecialization.ToLower()))
        //    {
        //        return false;
        //    }
        //    var s = db.Specializations.Where();
        //    Specialization sp = new Specialization {Id = , NameSpecialization = newSpecialization };
        //    db.Update(sp);
        //    db.SaveChanges();
        //    return true;
        //}

        //// Изменение Компании
        //public bool Put(string oldNameCamp, string newNameCamp, string oldSpecialization, string newSpecialization)
        //{
        //    if (!db.Companies.Any(u => u.NameCamp.ToLower() == oldNameCamp.ToLower()))
        //    {
        //        return false;
        //    }
        //    var s = db.Companies.Where();
        //    Company cp = new Company { Id = , NameCamp = newSpecialization };
        //    db.Update(cp);
        //    db.SaveChanges();
        //    return true;
        //}


        //// Получение информации о компании
        //public bool PostnInfoCompany(int idCompany)
        //{
        //    if (db.Companies.Any(u => u.NameCamp.ToLower() == nameCompany.ToLower()))
        //    {
        //        return false;
        //    }
        //    var sp = db.Specializations.Where(s => s.NameSpecialization.ToLower() == nameSpecialization.ToLower());
        //    Company cp = new Company { NameCamp = nameCompany, Specialization = new List<Specialization>(sp) };
        //    db.Companies.Add(cp);
        //    db.SaveChangesAsync();
        //    return true;
        //}
    }
}
