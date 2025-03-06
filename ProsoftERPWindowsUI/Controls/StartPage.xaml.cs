using MahApps.Metro.Controls;
using Prosoft.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Prosoft.WindowsUI
{

    public partial class tmpCtrl
    {
        public int ID { get; set; } 
        public string TileName { get; set; } = string.Empty;
    }


    /// <summary>
    /// Logika interakcji dla klasy StartPage.xaml
    /// </summary>
    public partial class StartPage : UserControl, INotifyPropertyChanged
    {


        List<tmpCtrl> tmpTiles;
        public List<tmpCtrl> TmpTiles 
        {
            get { return tmpTiles; }
            set { tmpTiles = value; OnPropertyChanged("TmpTiles"); } 
        }





        public IEnumerable<IModule> Modules { get; set; } = ApplicationContext.Instance.GetLoadedModules();
        
        

        public StartPage()
        {
            DataContext = this;
            InitializeComponent();

            TmpTiles = new List<tmpCtrl>();
            TmpTiles.Add(new tmpCtrl { TileName = "Kontrahenci" });
            TmpTiles.Add(new tmpCtrl { TileName = "Pracownicy" });


            var x = TmpTiles;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //private void OpenModule(object sender, RoutedEventArgs e)
        //{
        //    var tile = sender as Tile;
        //    if (tile == null) return;

        //    string moduleName = tile.Tag.ToString();
        //    var mainViewModel = (MainWindowViewModel)Application.Current.MainWindow.DataContext;

        //    switch (moduleName)
        //    {
        //        case "Kartoteki":
        //            //mainViewModel.AddTab("Kartoteki", new ModuleView("Kartoteki"));
        //            break;
        //        case "Developer":
        //            //mainViewModel.AddTab("Developer", new ModuleView("Developer"));
        //            break;
        //    }
        //}
    }
}
