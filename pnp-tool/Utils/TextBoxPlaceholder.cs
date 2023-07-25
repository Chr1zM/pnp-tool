using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace pnp_tool.Utils
{
    public static class TextBoxPlaceholder
    {
        public static DependencyProperty PlaceholderTextProperty =
            DependencyProperty.RegisterAttached("PlaceholderText", typeof(string), typeof(TextBoxPlaceholder),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPlaceholderTextChanged));

        /* DependencyColors when TextBox got the Placeholder or not */
        public static DependencyProperty ForegroundWhenPlaceholderProperty =
            DependencyProperty.RegisterAttached("ForegroundWhenPlaceholder", typeof(Brush), typeof(TextBoxPlaceholder),
                new PropertyMetadata(Brushes.Gray));

        public static DependencyProperty ForegroundWhenNotEmptyProperty =
            DependencyProperty.RegisterAttached("ForegroundWhenNotEmpty", typeof(Brush), typeof(TextBoxPlaceholder),
                new PropertyMetadata(Brushes.Black));

        /* Getter for DependencyProperty Values */
        public static string GetPlaceholderText(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceholderTextProperty);
        }

        public static Brush GetForegroundWhenPlaceholder(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ForegroundWhenPlaceholderProperty);
        }

        public static Brush GetForegroundWhenNotEmpty(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ForegroundWhenNotEmptyProperty);
        }

        /// <summary>
        /// Event handler when PlaceholderText property is changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPlaceholderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = d as TextBox;
            if (textBox == null) return;

            textBox.GotFocus += TextBox_GotFocus;
            textBox.LostFocus += TextBox_LostFocus;

            UpdatePlaceholderVisibility(textBox);
        }

        /// <summary>
        /// Event handler when TextBox gets focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            textBox.Text = string.Empty;
            textBox.Foreground = GetForegroundWhenNotEmpty(textBox);
        }

        /// <summary>
        /// Event handler when TextBox loses focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = GetPlaceholderText(textBox);
                textBox.Foreground = GetForegroundWhenPlaceholder(textBox);
            }
        }

        /// <summary>
        /// Helper method to update placeholder visibility based on TextBox text
        /// </summary>
        /// <param name="textBox"></param>
        private static void UpdatePlaceholderVisibility(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = GetPlaceholderText(textBox);
                textBox.Foreground = GetForegroundWhenPlaceholder(textBox);
            }
            else
            {
                textBox.Foreground = GetForegroundWhenNotEmpty(textBox);
            }
        }
    }
}
