using pnp_tool.ViewModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace pnp_tool.View
{
    /// <summary>
    /// Interaction logic for CharacterSheetView.xaml
    /// </summary>
    public partial class CharacterSheetView : UserControl
    {
        public CharacterSheetView()
        {
            InitializeComponent();
            DataContext = new CharacterSheetViewModel();
        }

        /* Strengths Events */
        private void NewStrengthTextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Neue Stärke")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void NewStrengthTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdatePlaceholderVisibility((TextBox)sender, "Neue Stärke");
        }

        private void NewStrengthTextBox_Initialized(object sender, System.EventArgs e)
        {
            UpdatePlaceholderVisibility((TextBox)sender, "Neue Stärke");
        }

        private void NewStrengthTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrWhiteSpace(newStrengthTextBox.Text))
            {
                CharacterSheetViewModel viewModel = DataContext as CharacterSheetViewModel;
                viewModel.AddStrengthCommand.Execute(newStrengthTextBox.Text);
                newStrengthTextBox.Text = string.Empty;
            }
        }

        /* Weaknesses Events */
        private void NewWeaknessTextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Neue Schwäche")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void NewWeaknessTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdatePlaceholderVisibility((TextBox)sender, "Neue Schwäche");
        }

        private void NewWeaknessTextBox_Initialized(object sender, System.EventArgs e)
        {
            UpdatePlaceholderVisibility((TextBox)sender, "Neue Schwäche");
        }

        private void NewWeaknessTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrWhiteSpace(NewWeaknessTextBox.Text))
            {
                CharacterSheetViewModel viewModel = DataContext as CharacterSheetViewModel;
                viewModel.AddWeaknessCommand.Execute(NewWeaknessTextBox.Text);
                NewWeaknessTextBox.Text = string.Empty;
            }
        }


        private void UpdatePlaceholderVisibility(TextBox textBox, string text)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = text;
                textBox.Foreground = Brushes.Gray;
            }
        }
    }
}
