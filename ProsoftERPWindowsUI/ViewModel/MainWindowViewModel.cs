﻿using Prosoft.Core;
using Prosoft.WindowsUI;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
