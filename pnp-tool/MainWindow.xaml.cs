using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using pnp_tool.View;
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
        }

        private void DarkModeToggle_Checked(object sender, RoutedEventArgs e)
        {
            var darkSkin = new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml")
            };
            var primaryColor = new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Amber.xaml")
            };

            Application.Current.Resources.MergedDictionaries.Add(darkSkin);
            Application.Current.Resources.MergedDictionaries.Add(primaryColor);
        }

        private void DarkModeToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            var lightSkin = new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml")
            };

            var primaryColor = new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Brown.xaml")
            };

            Application.Current.Resources.MergedDictionaries.Add(lightSkin);
            Application.Current.Resources.MergedDictionaries.Add(primaryColor);
        }

    }
}
