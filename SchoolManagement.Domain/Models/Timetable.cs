using Shared.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class Timetable : DomainModel
    {
        public string? Day { get; set; } 
        public string? Time { get; set; }
        public string? Subject { get; set; }
    }
}
