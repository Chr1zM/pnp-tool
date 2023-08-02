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
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        /* Dark Mode */
        private void DarkModeToggle_Checked(object sender, RoutedEventArgs e)
        {
            var darkSkin = new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml")
            };
            var primaryColor = new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Brown.xaml")
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
