using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SchoolManagement.DAL.Repositories;
using SchoolManagement.Interfaces;
using System;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        public IUserRepository _userRepository;


        public LoginViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string? _username;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private SecureString? _password;

        [ObservableProperty]
        private string? _errorMessage;

        [ObservableProperty]
        private bool? isViewVisible;


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



        [RelayCommand(CanExecute = nameof(CanExecuteLoginCommand), AllowConcurrentExecutions = false, IncludeCancelCommand = true)]
        private Task Login(CancellationToken cancellationToken)
        {
            try
            {
                Task.CompletedTask.Wait(4000, cancellationToken);

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
            catch (OperationCanceledException)
            {
                ErrorMessage = "An Error Occurred";
            }
            return Task.CompletedTask;
        }

    }
}
