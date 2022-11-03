using Shared.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Models
{
    public class Student : Person
    {
        public Guardian Guardian { get; set; }
    }
}
