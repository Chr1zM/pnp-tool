using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using pnp_tool.ViewModel;
using System;
using System.Windows;

namespace pnp_tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            Messenger.Default.Register<SnackbarMessage>(
                this,
                (message) => MainSnackbar.MessageQueue.Enqueue(message.Content, null, null, null, false, true)
            );
        }
    }
}
