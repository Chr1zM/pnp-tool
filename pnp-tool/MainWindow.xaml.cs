using pnp_tool.View;
using pnp_tool.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace pnp_tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int tabCounter = 1;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        /// <summary>
        /// Creates a new tab item with a character sheet page and adds it to the tab control.
        /// <br/> Selects the created tab to display it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewTabButton_Click(object sender, RoutedEventArgs e)
        {
            Frame sheetFrame = new Frame();
            sheetFrame.Content = new CharacterSheetView();

            TabItem newTabItem = new TabItem();
            // TODO: Give the Tab (CharacterSheet) a Name https://github.com/Chr1zM/pnp-tool/issues/11
            // Am besten => Dialog öffnen und Namen eintippen
            // bearbeitbar machen => Rechtsklick oder Button einbauen zum nachbearbeiten des Namens
            newTabItem.Header = "Character Sheet " + tabCounter;
            newTabItem.Content = sheetFrame;

            CharacterSheetTabs.Items.Add(newTabItem);
            tabCounter++;

            // Navigate to the created Tab
            CharacterSheetTabs.SelectedItem = newTabItem;
        }

    }
}
