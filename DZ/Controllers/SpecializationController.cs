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
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        DataManager db;

        public SpecializationController(ApiContext context)
        {
            db = new DataManager(context);
        }

        [HttpGet("Вывод всех специализаций")]
        public  IEnumerable<Information> Get()
        {
            return db.GetAllSpecialization();
        }

        [HttpPost("Добавление новой специализации")]
        public ActionResult<Specialization> Post(string name)
        {
            if (name == null || !db.Post(name))
            {
                return BadRequest();
            }
            return Ok(name);
        }

        [HttpDelete("Удаление специализации по ID")]
        public ActionResult<Specialization> Delete(int id)
        {

            if (!db.DeleteS(id))
            {
                return BadRequest();
            }
            return Ok(id);
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
