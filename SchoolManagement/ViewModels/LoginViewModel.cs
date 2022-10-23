using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SchoolManagement.DAL.Repositories;
using SchoolManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IUserRepository _userRepository;
        public LoginViewModel()
        {
            _userRepository = new UserRepository();
        }


        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string? username;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private SecureString? password;

        [ObservableProperty]
        private string? errorMessage;

        private bool? IsViewVisible;


        private bool CanExecuteLoginCommand()
        {
            bool isValidData = true;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                isValidData = false;
                ErrorMessage = "Invalid Input";
            }

            return isValidData;
        }


        [RelayCommand(CanExecute = nameof(CanExecuteLoginCommand))]
        private void Login()
        {
            var creds = new NetworkCredential(Username, Password);
            var authenticated = _userRepository.AuthenticateUser(creds);
            if (authenticated)
            {
                ErrorMessage = String.Empty;
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username == null ? "" : Username), null);
                 IsViewVisible = false;
            }
            else ErrorMessage = "Invalid Login Details";

        }

    }
}
