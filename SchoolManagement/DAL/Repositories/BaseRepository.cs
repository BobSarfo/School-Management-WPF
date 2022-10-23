using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DAL.Repositories
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;

        public BaseRepository()
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=wpfdb;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

  
    }
}
