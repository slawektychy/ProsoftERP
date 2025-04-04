using Prosoft.Core;
using Prosoft.WindowsUI.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Xml;

namespace Prosoft.WindowsUI
{

    /// <summary>
    /// Logika interakcji dla klasy StartPage.xaml
    /// </summary>
    public partial class StartPage : UserControl, INotifyPropertyChanged
    {
        public IEnumerable<IModule> Modules { get; set; } = ApplicationContext.Instance.GetLoadedModules();
        MainWindowViewModel _mainViewModel;

        public StartPage()
        {
            DataContext = this;
            InitializeComponent();
        }

        public StartPage(MainWindowViewModel mainWindowViewModel)
        {
            DataContext = this;
            InitializeComponent();
            _mainViewModel = mainWindowViewModel;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;

            if (border != null)
            {
                UserControl ctr = new ModuleView();
                var table = border.DataContext as ITable;
                if (table != null)
                {
                    _mainViewModel.SetTabContent(table.GetTableName(), new ModuleView());

                }
            }
        }
    }
}
