using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pnp_tool.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public UserControl TabView { get; }
        
        public MainViewModel() 
        {
            TabView = new View.TabView();
        }
    }
}
