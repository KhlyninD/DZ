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
        ApiContext db;

        public SpecializationController(ApiContext context)
        {
            db = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialization>>> Get()
        {
            return await db.Specializations.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Specialization>> Post(string nameSpecialization)
        {
            if (nameSpecialization == null || db.Specializations.Any(u => u.NameSpecialization == nameSpecialization))
            {
                return BadRequest();
            }
            Specialization sp = new Specialization { NameSpecialization = nameSpecialization };
            db.Specializations.Add(sp);
            await db.SaveChangesAsync();
            return Ok(sp);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Specialization>> Delete(int id)
        {
            Specialization special = db.Specializations.FirstOrDefault(x => x.Id == id);
            if (special == null)
            {
                return NotFound();
            }
            db.Specializations.Remove(special);
            await db.SaveChangesAsync();
            return Ok(special);
        }

        [HttpPut]
        public async Task<ActionResult<Specialization>> Put(Specialization special)
        {
            if (special == null)
            {
                return BadRequest();
            }
            if (!db.Specializations.Any(x => x.Id == special.Id))
            {
                return NotFound();
            }

            db.Update(special);
            await db.SaveChangesAsync();
            return Ok(special);
        }

        

    }
}
