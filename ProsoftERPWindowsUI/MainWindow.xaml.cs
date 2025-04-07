using System;
using System.Reflection;
using System.Windows;
using Prosoft.Core;
using Prosoft.Core.Atributes;

namespace Prosoft.WindowsUI
{
    public partial class MainWindow
    {
        private ModuleLoader _loader = new ModuleLoader();

        public MainWindow()
        {
            InitializeComponent();
            LoadModules();
            DataContext = new MainWindowViewModel();
        }

        private void LoadModules()
        {
            _loader.LoadModules("./Modules");
            foreach (var module in _loader.Modules)
            {
                ApplicationContext.Instance.RegisterModule(module);
            }
            RegisterMenuInContext();
        }

        private void RegisterMenuInContext()
        {
            ApplicationContext.Instance.RegisterMenuAtributClasses(
                AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetCustomAttributes<MenuRegistrationAttribute>().Any())
                .ToList()
            );

        }
       


    private void DeveloperMenuClick(object sender, RoutedEventArgs e)
        {
            var devWindow = new DeveloperWindow();
            devWindow.Show();
        }
    }
}
