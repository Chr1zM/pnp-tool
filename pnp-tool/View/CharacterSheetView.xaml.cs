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
    }
}
