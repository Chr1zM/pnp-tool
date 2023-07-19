using GalaSoft.MvvmLight.Command;
using pnp_tool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnp_tool.Model
{
    public class Tab
    {
        private static int Id = 1;
        private static int getNextId() { return Id++; }

        public string TabTitle { get; set; }
        public object TabContent { get; set; }
        public MainViewModel ViewModel { get; set; }

        public Tab(string title, object tabContent)
        {
            TabTitle = title;
            TabContent = tabContent;
        }

        public Tab(MainViewModel viewModel, object tabContent)
        {
            ViewModel = viewModel;
            TabTitle = "Tab" + getNextId();
            TabContent = tabContent;
        }

        public RelayCommand<Tab> RemoveTabCommand => ViewModel.RemoveTabCommand;
    }
}
