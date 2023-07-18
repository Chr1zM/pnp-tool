using GalaSoft.MvvmLight.Command;
using pnp_tool.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pnp_tool.ViewModel
{
    internal class MainViewModel
    {
        public ObservableCollection<Tab> Tabs { get; }
        public RelayCommand AddTabCommand { get; }
        public RelayCommand<Tab> RemoveTabCommand { get; }

        public MainViewModel()
        {
            Tabs = new ObservableCollection<Tab>();

            AddTabCommand = new RelayCommand(AddTab);
            RemoveTabCommand = new RelayCommand<Tab>(RemoveTab);
        }

        /// <summary>
        /// Creates a new tab item
        /// <br/> Selects the created tab to display it.
        /// </summary>
        private void AddTab()
        {
            Tabs.Add(new Tab());
            // TODO display / select the created Tab
        }

        /// <summary>
        /// Deletes a tab item and removes it from the tab control.
        /// </summary>
        /// <param name="tab">Tab that's getting removed</param>
        private void RemoveTab(Tab tab)
        {
            // TODO kommt nicht hier hin
            if (tab != null) Tabs.Remove(tab);
        }
    }
}
