using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using Microsoft.Xaml.Behaviors.Core;
using pnp_tool.Model;
using pnp_tool.Utils;
using pnp_tool.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace pnp_tool.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const int MAX_TABS = 16;
        private const string MAX_TABS_MESSAGE = "Maximale Anzahl an Tabs erreicht!";

        public ObservableCollection<Tab> Tabs { get; }
        private HashSet<string> usedTabNames;
        public ICommand AddTabCommand { get; }

        private Tab _selectedTab;
        public Tab SelectedTab
        {
            get => _selectedTab;
            set
            {
                if (_selectedTab != value)
                {
                    _selectedTab = value;
                    RaisePropertyChanged();
                }
            }
        }

        public MainViewModel()
        {
            Tabs = new ObservableCollection<Tab>();
            Tabs.CollectionChanged += Tabs_CollectionChanged;

            usedTabNames = new HashSet<string>();

            AddTabCommand = new ActionCommand(AddTab);
        }



        /// <summary>
        /// Creates a new tab item
        /// <br/> Selects the created tab to display it.
        /// </summary>
        private void AddTab()
        {
            if (Tabs.Count == MAX_TABS)
            {
                Messenger.Default.Send(new SnackbarMessage { Content = MAX_TABS_MESSAGE });
                return;
            }

            CharacterSheetView characterSheet = new CharacterSheetView();

            Tab tab = new Tab(TabUtils.GenerateUniqueTabName(usedTabNames), characterSheet);
            Tabs.Add(tab);

            // display the created Tab
            SelectedTab = tab;
        }

        /// <summary>
        /// Deletes a tab item and removes it from the tab control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTabCloseRequested(object sender, EventArgs e)
        {
            if (sender is Tab tab)
            {
                Tabs.Remove(tab);
                usedTabNames.Remove(tab.Title);
            }
        }

        private void Tabs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Tab tab;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (Tab)e.NewItems[0];
                    tab.CloseRequested += OnTabCloseRequested;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    tab = (Tab)e.OldItems[0];
                    tab.CloseRequested -= OnTabCloseRequested;
                    break;
                default: break;
            }
        }
    }
}
