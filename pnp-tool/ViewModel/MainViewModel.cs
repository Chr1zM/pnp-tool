using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using pnp_tool.Model;
using pnp_tool.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pnp_tool.ViewModel
{
    public class MainViewModel : ViewModelBase
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
            CharacterSheetView characterSheet = new CharacterSheetView();

            Tabs.Add(new Tab(this, characterSheet));
            // TODO display / select the created Tab
        }

        /// <summary>
        /// Deletes a tab item and removes it from the tab control.
        /// </summary>
        /// <param name="tab">Tab that's getting removed</param>
        private void RemoveTab(Tab tab)
        {
            // TODO kommt nicht hier hin
            System.Diagnostics.Debug.WriteLine("RemoveTab method called");
            if (tab != null) Tabs.Remove(tab);
        }
    }
}
