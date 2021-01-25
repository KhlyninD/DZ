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
    [Route("api/Specialization/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        DataManager db;

        public SpecializationController(ApiContext context)
        {
            db = new DataManager(context);
        }

        // Вывод списка специализаций
        [HttpGet("GetAllSpecialization")]
        public  IEnumerable<Information> Get()
        {
            return db.GetAllSpecialization();
        }

        // Добавление специализации
        [HttpPost("PostSpecialization")]
        public ActionResult<Specialization> Post(string specialization)
        {
            if (specialization == null || !db.Post(specialization))
            {
                return BadRequest();
            }
            return Ok(specialization);
        }
        //Удаление специализации по ID
        [HttpDelete("DeleteSpecializationID")]
        public ActionResult<Specialization> Delete(int idSpecialization)
        {

            if (!db.DeleteS(idSpecialization))
            {
                return BadRequest();
            }
            return Ok(idSpecialization);
        }

        //[HttpPut("Изменение специализации")]
        //public ActionResult<Specialization> Put(string oldSpecial, string newSpecial)
        //{
        //    if (oldSpecial == null || newSpecial == null || !db.Put(oldSpecial, newSpecial))
        //    {
        //        return BadRequest();
        //    }
                      
        //    return Ok(newSpecial);
        //}



    }
}
