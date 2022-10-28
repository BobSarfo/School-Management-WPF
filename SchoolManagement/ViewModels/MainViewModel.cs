using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FontAwesome.WPF;
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
using System.Windows.Media;
namespace SchoolManagement.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableObject _currentChildView;

        [ObservableProperty]
        private string _caption;

        [ObservableProperty]
        private FontAwesomeIcon _icon;




        private IUserRepository _userRepository;
        public MainViewModel()
        {
            _userRepository = new UserRepository();
            LoadCurrentUserAccount();
            ShowHomeView();
        }

        [ObservableProperty]
        private UserAccountModel _currentUser = new();

        public void LoadCurrentUserAccount()
        {
            var loggedInPrincipal = Thread.CurrentPrincipal;
            if (loggedInPrincipal is not null && loggedInPrincipal.Identity is not null && loggedInPrincipal.Identity.Name is not null)
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


        [RelayCommand]
        public void ShowHomeView()
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Home";
            Icon = FontAwesomeIcon.Home;
        }

        [RelayCommand]
        public void ShowStudentView() 
        {
            CurrentChildView = new StudentsViewModel();
            Caption = "Students";
            Icon = FontAwesomeIcon.Users;
        }





    }
}
