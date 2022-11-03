using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class Guardian : Person
    {
        public List<Student> Student { get; set; } = new();
    }
}
