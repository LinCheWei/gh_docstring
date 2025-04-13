using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DocStringWindowLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Viewer : Window
    {
        public string TxtInput { get; set; }
        public Viewer()
        {
            InitializeComponent();
        }

        private void SaveButtonClicked(object sender, RoutedEventArgs e)
        {
            TxtInput = UserTextboxInput.Text;
        }
        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            TxtInput = UserTextboxInput.Text;
            this.Close();
        }
        public void AddDocstringCard(string compnentName, string userString, string guid, string[] tags)
        {
            var border = new Border
            {
                CornerRadius = new CornerRadius(10),
                Background = Brushes.WhiteSmoke,
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(1),
                Margin = new Thickness(5),
                Padding = new Thickness(10)
            };

            var stack = new StackPanel();

            stack.Children.Add(new TextBlock { Text = userString, FontWeight = FontWeights.Bold });

            // Tags
            var tagPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 10, 0, 0) };
            foreach (var tag in tags)
            {
                tagPanel.Children.Add(new Button
                {
                    Content = tag,
                    Margin = new Thickness(0, 0, 5, 0)
                });
            }
            stack.Children.Add(tagPanel);

            // Footer
            var footerPanel = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
            footerPanel.Children.Add(new TextBlock { Text = compnentName, FontWeight = FontWeights.Bold });
            footerPanel.Children.Add(new TextBlock { Text = $"GUID : {guid}", FontStyle = FontStyles.Italic, FontSize = 10, Margin = new Thickness(10, 0, 0, 0) });

            stack.Children.Add(footerPanel);

            border.Child = stack;

            // Add to the main StackPanel
            DocstringCardsPanel.Children.Add(border);
        }

    }
}
