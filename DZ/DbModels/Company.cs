

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DZ.DbModels
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string NameCamp { get; set; }
        [Required]
        public List<Specialization> Specializations { get; set; } = new List<Specialization>();

        public List<Employee> Employies { get; set; } = new List<Employee>();
    }
}
