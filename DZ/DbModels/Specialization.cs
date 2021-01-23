using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DZ.DbModels
{
    public class Specialization
    {
        public int Id { get; set; }
        [Required] 
        public string NameSpecialization { get; set; }
        public List<Company> Companies { get; set; } = new List<Company>();
    }
}
