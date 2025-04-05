using Prosoft.Core;
using Prosoft.WindowsUI;
using Prosoft.WindowsUI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Prosoft.WindowsUI
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TabItemModel> Tabs { get; set; } = new ObservableCollection<TabItemModel>();
        //public ObservableCollection<IModule> Modules { get; } = new ObservableCollection<IModule>(ApplicationContext.Instance.GetLoadedModules());

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
            MenuItems = new List<LeftMenuItemModel>
                 {
            new LeftMenuItemModel { Header = "Kartoteki", Children = new List<LeftMenuItemModel>
                {
                    new LeftMenuItemModel { Header = "Klient Nowy" },
                    new LeftMenuItemModel { Header = "Dostawca" },
                    new LeftMenuItemModel { Header = "Produkt" }
                }
            },
            new LeftMenuItemModel { Header = "Developer", Children = new List<LeftMenuItemModel>
                {
                    new LeftMenuItemModel { Header = "Opcja 1" },
                    new LeftMenuItemModel { Header = "Opcja 2", Children = new List<LeftMenuItemModel>
                        {
                            new LeftMenuItemModel { Header = "Subopcja 2.1" },
                            new LeftMenuItemModel { Header = "Subopcja 2.2" }
                        }
                    },
                    new LeftMenuItemModel { Header = "Opcja 3" }
                }
            }
        };
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
