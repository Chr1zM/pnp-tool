using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using pnp_tool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace pnp_tool.View
{
    /// <summary>
    /// Interaction logic for TabView.xaml
    /// </summary>
    public partial class ClosableTabView : UserControl
    {
        public ClosableTabView()
        {
            InitializeComponent();
            DataContext = new ClosableTabViewModel();

            Messenger.Default.Register<SnackbarMessage>(
                this,
                (message) => MainSnackbar.MessageQueue.Enqueue(message.Content, null, null, null, true, false, TimeSpan.FromSeconds(1))
            );
        }
    }
}
