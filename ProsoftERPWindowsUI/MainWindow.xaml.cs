using System;
using System.Windows;
using MahApps.Metro.Controls;
using Prosoft.Core;
using ProsoftERPWindowsUI.Windows;

namespace ProsoftERP.WPF
{
    public partial class MainWindow
    {
        private ModuleLoader _loader = new ModuleLoader();

        public MainWindow()
        {
            InitializeComponent();
            LoadModules();
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
