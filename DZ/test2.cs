using DZ.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DZ
{
    public class test2 : Information
    {
        public int Id { get; set; }
     
        public string NameSpecialization { get; set; }
        public List<Company> Companies { get; set; } = new List<Company>();
    }
}
