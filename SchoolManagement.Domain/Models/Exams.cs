using Shared.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class Exams : DomainModel
    {
        public  string? Name { get; set; }   
        public int Type { get; set; }
        public DateTime? Date { get; set; }
    }
}
