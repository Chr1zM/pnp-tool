using pnp_tool.CharacterSheet;
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
        }

        /// <summary>
        /// Creates a new tab item with a character sheet page and adds it to the tab control.
        /// <br/> Optionally, selects the newly added tab to display it.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AddNewTabButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem newTabItem = new TabItem();
            // TODO: Give the Tab (CharacterSheet) a Name https://github.com/Chr1zM/pnp-tool/issues/11
            newTabItem.Header = "New Character Sheet";
            newTabItem.Content = new CharacterSheetPage();

            CharacterSheetTabs.Items.Add(newTabItem);

            // Navigate to the created Tab
            //CharacterSheetTabs.SelectedItem = newTabItem;
        }
    }
}
