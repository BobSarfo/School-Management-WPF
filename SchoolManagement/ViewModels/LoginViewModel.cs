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
using System.Windows.Input;

namespace SchoolManagement.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private readonly IUserRepository _userRepository;
        public LoginViewModel()
        {
            _userRepository = new UserRepository();
            LoginCommand = new RelayCommand(ExecuteLoginCommand,CanExecuteLoginCommand);
            //RecoverPasswordCommand = new DelegateCommand(x => ExecuteRecoverPasswordCommand("", ""));
        }

        private string? _username;
        private SecureString? _password;
        private string? _errorMessage;
        private bool? _isViewVisible;

        public string? Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string? ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool? IsViewVisible
        {
            get => _isViewVisible; set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }



        public ICommand LoginCommand { get; }
        //public ICommand RecoverPasswordCommand { get; }
        //public ICommand RememberUserPasswordCommand { get; }
        //public ICommand ShowPasswordCommand { get; }


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
        private void ExecuteLoginCommand()
        {
            var creds = new NetworkCredential(Username, Password);
            var authenticated = _userRepository.AuthenticateUser(creds);
            if (authenticated)
            {
                ErrorMessage = String.Empty;
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username == null ? "" : Username), null);
            }
            else ErrorMessage = "Invalid Login Details";

            IsViewVisible = false;
        }

        private void ExecuteRecoverPasswordCommand(string username, string password)
        {
            throw new NotImplementedException();
        }


    }
}
