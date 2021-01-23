

using System;
using System.ComponentModel.DataAnnotations;

namespace DZ.DbModels
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Otchestvo { get; set; }
        public DateTime Birthday { get; set; }
        
        public int CompanyId { get; set; }
       // [Required]
        public Company Company { get; set; }

    }
}
