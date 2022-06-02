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
    [Route("api/Employee/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        DataManager db;

        public EmployeeController(ApiContext context)
        {
            db = new DataManager(context);
        }

        [HttpGet("GetAllEmployee")]
        public IEnumerable<Information> Get()
        {
            return db.GetAllEmployee();
        }

        [HttpPost("PostEmployeeId")]
        public ActionResult<Employee> Post(string name, string surname, string otchestvo, int idCompany, string birthday = "не задано")
        {
            if (name == null || surname == null || otchestvo == null || !db.Post(name, surname, otchestvo, idCompany, birthday))
            {
                return BadRequest();
            }

            return Ok(String.Join(", ", name, surname, otchestvo));
        }

        [HttpDelete("DeleteEmployee")]
        public ActionResult<Company> DeleteE(int id)
        {

            if (!db.DeleteE(id))
            {
                return BadRequest();
            }
            return Ok(id);
        }
    }
}
