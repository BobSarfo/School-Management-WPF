using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SchoolManagement.DAL.Repositories;
using SchoolManagement.Interfaces;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolManagement.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private IUserRepository _userRepository;
        public MainViewModel()
        {
            _userRepository = new UserRepository();
            LoadCurrentUserAccount();
        }

        [ObservableProperty]
        private UserAccountModel _currentUser = new();

        public void LoadCurrentUserAccount()
        {
            var loggedInPrincipal = Thread.CurrentPrincipal;
            if (loggedInPrincipal is not null)
            {
                var user = _userRepository.GetByUsername(loggedInPrincipal.Identity.Name);
                _currentUser = new UserAccountModel
                {
                    DisplayName = $"{user.FirstName} {user.LastName}",
                    Username = user.Username,
                    ProfilePicture = null
                };
            }
            else
            {
                _currentUser.DisplayName = ("Invalid User");
                //Application.Current.Shutdown();

            }
        }



    }
}
