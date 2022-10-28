using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolManagement.DAL.Repositories;
using SchoolManagement.Interfaces;
using SchoolManagement.ViewModels;
using SchoolManagement.Views;
using System;
using System.Threading.Tasks;
using System.Windows;


namespace SchoolManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            host.Start();

            App app = new();

            app.InitializeComponent();


            var loginView = host.Services.GetRequiredService<LoginView>();
            var mainWindow = host.Services.GetRequiredService<MainWindow>();

            var loginViewModel = host.Services.GetRequiredService<LoginViewModel>();
            app.MainWindow = mainWindow;
            //loginView.DataContext = loginViewModel;
            mainWindow.Show();
            //app.MainWindow = loginView;
            //loginView.Show();
            //loginView.IsVisibleChanged += (s, ev) =>
            //{
            //    if (!loginView.IsVisible && loginView.IsLoaded)
            //    {
            //        loginView.Close();
            //        app.MainWindow = mainWindow;
            //        mainWindow.Show();
            //    }
            //};

            app.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            {
                var a = string.Empty;
                services.AddSingleton<LoginView>();
                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<IUserRepository, UserRepository>();
            });

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (!loginView.IsVisible && loginView.IsLoaded)
                {
                    var mainView = new MainWindow();
                    mainView.Show();
                    loginView.Close();
                }
            };
        }
    }
}
