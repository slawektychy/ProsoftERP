using Prosoft.Core;
using Prosoft.Core.Atributes;
using Prosoft.WindowsUI;
using Prosoft.WindowsUI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Prosoft.WindowsUI
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TabItemModel> Tabs { get; set; } = new ObservableCollection<TabItemModel>();
        //public ObservableCollection<IModule> Modules { get; } = new ObservableCollection<IModule>(ApplicationContext.Instance.GetLoadedModules());
        //ObservableCollection<Type> MenuRegistredClasses { get;} = new ObservableCollection<Type>(ApplicationContext.Instance.GetLoadedModules());

        #region Zakładki

        private int _selectedTabIndex;

        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set
            {
                _selectedTabIndex = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            // Dodajemy stronę startową
            SetTabContent("...", new StartPage(this));
            SetLeftMenuContent();
        

        }

        public void SetTabContent(string title, UserControl content)
        {
            var existingTab = Tabs.Where(t=>t.Title == title).FirstOrDefault();
            if (existingTab != null)
            {
                SelectedTabIndex = Tabs.IndexOf(existingTab);
            }
            else
            {
                var newTab = new TabItemModel(title, content);
                Tabs.Add(newTab);
                SelectedTabIndex = Tabs.Count - 1;
            }
        }

        #endregion


        #region Menu po lewej stronie

        void SetLeftMenuContent()
        {

            MenuItems = new List<LeftMenuItemModel>();
            List<string> levelOne = new List<string>();

            ObservableCollection<Type> MenuRegistredClasses = new ObservableCollection<Type> (ApplicationContext.Instance.GetMenuItems());
            foreach (var type in MenuRegistredClasses)
            {
                var attr = type.GetCustomAttribute<MenuRegistrationAttribute>();
                string menuPath = attr.MenuPath;

                string[] items = menuPath.Split('/');
                LeftMenuItemModel? item = MenuItems.Where(i=>i.Header == items[0]).FirstOrDefault();
                if(item == null) {
                    item = new LeftMenuItemModel { Header = items[0] };
                    MenuItems.Add(item);
                }
                item.Children.Add(new LeftMenuItemModel { Header = items[1] });
            }
            OnPropertyChanged(nameof(MenuItems));



        }

        public List<LeftMenuItemModel> MenuItems { get; set; }



        #endregion





        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
