using Prosoft.Core;
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
using System.Windows.Shapes;

namespace Prosoft.WindowsUI
{
    /// <summary>
    /// Logika interakcji dla klasy DeveloperWindow.xaml
    /// </summary>
    public partial class DeveloperWindow
    {

        public List<IModule> LoadaedModules { get; } = (List<IModule>)(ApplicationContext.Instance.GetLoadedModules());

        public DeveloperWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
