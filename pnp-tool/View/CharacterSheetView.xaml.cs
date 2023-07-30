using pnp_tool.ViewModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

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

        /// <summary>
        /// Validation / Sanitizing of TextBoxes that only accept Numeric characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Only numbers may be entered, else set handled true => nothing else will be done.
            e.Handled = !HasTextNonNumericCharacters(e.Text);


        }

        /// <summary>
        /// Regular expression that finds non-numeric characters
        /// Returns true if the given text has Non-Numeric Characters, otherwise false
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool HasTextNonNumericCharacters(string text)
        {
            Regex regex = new Regex(@"\D");
            return !regex.IsMatch(text);
        }


        /// <summary>
        /// Sanitizes Numerical TextBoxes, so that if it's left empty, it gets set to "0".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0";
            }
        }

        /* Strengths Events */
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
        private void NewWeaknessTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrWhiteSpace(NewWeaknessTextBox.Text))
            {
                CharacterSheetViewModel viewModel = DataContext as CharacterSheetViewModel;
                viewModel.AddWeaknessCommand.Execute(NewWeaknessTextBox.Text);
                NewWeaknessTextBox.Text = string.Empty;
            }
        }

        /* Inventory Events */
        private void NewItemTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(NewItemTextBox.Text))
            {
                CharacterSheetViewModel viewModel = DataContext as CharacterSheetViewModel;
                viewModel.AddItemCommand.Execute(NewItemTextBox.Text);
                NewItemTextBox.Text = string.Empty;
            }
        }

    }
}
