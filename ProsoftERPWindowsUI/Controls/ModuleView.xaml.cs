using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prosoft.WindowsUI.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy ModuleView.xaml
    /// </summary>
    public partial class ModuleView : UserControl

    {

        public string ModuleName { get; }

        public ModuleView()
        {
            InitializeComponent();
            ModuleName = "TEST";
            DataContext = this;
        }

        //public ModuleView(string moduleName)
        //{
        //    InitializeComponent();
        //    ModuleName = moduleName;
        //    DataContext = this;

        //}
    }
}