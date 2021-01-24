using DZ.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DZ
{
    public class test : Information
    {
        public List<Specialization> Specialization { get; set; } = new List<Specialization>();
        public List<Employee> Employies { get; set; } = new List<Employee>();
    }
}
