using SchoolManagement.Interfaces;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly List<UserModel> _users =new() {
            new UserModel {  Id = 1, Username = "admin", Password = "admin"} 
        };

        public void Add(UserModel userModel)
        {
            if (_users is null)
            {
                userModel.Id = 1;
            }
            else
            {
                userModel.Id = _users.MaxBy(x => x.Id).Id++;
            }
            _users.Add(userModel);
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            return _users.Any(x => x.Username == credential.UserName && x.Password == credential.Password);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _users;
        }

        public UserModel GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public UserModel GetByUsername(string username)
        {
            return _users.FirstOrDefault(x => x.Username == username);

        }

        public int Remove(int id)
        {
            var user = GetById(id);
            if (user is not null)
            {
                _users.Remove(user);
                return id;
            }
            return -1;
        }

        public UserModel Update()
        {
            return null;
        }
    }
}
