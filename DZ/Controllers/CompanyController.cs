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
    public class CompanyController : ControllerBase
    {
        ApiContext db;

        public CompanyController(ApiContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Get()
        {
            return await db.Companies.ToListAsync();
        }

        //[HttpPost]
        //public async Task<ActionResult<Company>> Post(string nameSpecialization)
        //{
        //    if (nameSpecialization == null || db.Companies.Any(u => u.NameCamp == nameSpecialization))
        //    {
        //        return BadRequest();
        //    }
        //    Specialization sp = new Company { NameCamp = nameSpecialization };
        //    db.Companies.Add(sp);
        //    await db.SaveChangesAsync();
        //    return Ok(sp);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Company>> Delete(int id)
        //{
        //    Specialization special = db.Companies.FirstOrDefault(x => x.Id == id);
        //    if (special == null)
        //    {
        //        return NotFound();
        //    }
        //    db.Companies.Remove(special);
        //    await db.SaveChangesAsync();
        //    return Ok(special);
        //}

        [HttpPut]
        public async Task<ActionResult<Company>> Put(Company special)
        {
            if (special == null)
            {
                return BadRequest();
            }
            if (!db.Companies.Any(x => x.Id == special.Id))
            {
                return NotFound();
            }

            db.Update(special);
            await db.SaveChangesAsync();
            return Ok(special);
        }
    }
}
