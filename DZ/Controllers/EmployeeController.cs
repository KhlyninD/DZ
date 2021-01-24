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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        DataManager db;

        public EmployeeController(ApiContext context)
        {
            db = new DataManager(context);
        }

        [HttpGet("Вывод всех сотрудников")]
        public IEnumerable<Information> Get()
        {
            return db.GetAllEmployee();
        }

        [HttpPost("Добавление сотрудника по названию компании")]
        public ActionResult<Employee> Post(string name, string surname, string otchestvo, string nameCompany, string birthday = "не задано")
        {
            if (name == null || surname == null || otchestvo == null || nameCompany == null || !db.Post(name, surname, otchestvo, nameCompany, birthday))
            {
                return BadRequest();
            }

            return Ok(String.Join(", ", name, surname, otchestvo));
        }
        [HttpPost("Добавление сотрудника по Id компании")]
        public ActionResult<Employee> Post(string name, string surname, string otchestvo, int idCompany, string birthday = "не задано")
        {
            if (name == null || surname == null || otchestvo == null || !db.Post(name, surname, otchestvo, idCompany, birthday))
            {
                return BadRequest();
            }

            return Ok(String.Join(", ", name, surname, otchestvo));
        }

        [HttpDelete("Удаление Сотрудника")]
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
