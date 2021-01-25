using DZ.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DZ.Controllers
{
    [Route("api/Company/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        DataManager db;

        public CompanyController(ApiContext context)
        {
            db = new DataManager(context);
        }
        // Вывод списка компаний
        [HttpGet("GetAllCompany")]
        public IEnumerable<Information> Get()
        {
            return db.GetAllCompany();
        }
        // Добавление новой компании
        [HttpPost("PostCompany")]
        public ActionResult<Company> Post(string nameCompany, int idSpecialization)
        {
            if (nameCompany == null || !db.Post(nameCompany, idSpecialization))
            {
                return BadRequest();
            }
            return Ok(nameCompany);
        }
        // Удаление компании
        [HttpDelete("DeleteCompany")]
        public ActionResult<Company> Delete(int idCompany)
        {

            if (!db.DeleteС(idCompany))
            {
                return BadRequest();
            }
            return Ok(idCompany);
        }

        //[HttpPut("Изменение компании")]
        //public ActionResult<Specialization> Put(string oldNameCamp, string newNameCamp, string oldSpecialization, string newSpecialization)
        //{
        //    if (oldNameCamp == null || newNameCamp == null || oldSpecialization == null || newSpecialization == null || !db.Put(oldNameCamp, newNameCamp, oldSpecialization, newSpecialization))
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(String.Join(", ", newNameCamp, oldSpecialization));
        //}

        //[HttpPost("Получение информации о компании")]
        //public ActionResult<Company> Post(int idCompany)
        //{
        //    if (idCompany == null || !db.PostnInfoCompany(idCompany))
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(nameCompany);
        //}
    }
}
