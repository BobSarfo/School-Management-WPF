using Shared.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    internal class Subject : DomainModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Grade { get; set; }  
    }
}
