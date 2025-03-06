using System;
using System.Windows;
using MahApps.Metro.Controls;
using Prosoft.Core;

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
        }

        private void DeveloperMenuClick(object sender, RoutedEventArgs e)
        {
            var devWindow = new DeveloperWindow();
            devWindow.Show();
        }
    }
}
