using System;
using System.Windows;
using ProsoftERP;

namespace ProsoftERP.WPF
{
    public partial class MainWindow : Window
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
                ModulesList.Items.Add(module.Name);
            }
        }
    }
}
