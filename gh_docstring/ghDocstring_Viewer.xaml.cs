using Grasshopper.Kernel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Grasshopper;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ghDocstring
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Viewer : Window
    {
        public List<string> tags = new List<string>();
        private System.Timers.Timer timer = new System.Timers.Timer(200);
        public Viewer()
        {
            timer.Elapsed += (sender, e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    refresh_selection();
                });
            };
            timer.AutoReset = true;
            timer.Enabled = true;
            tags.Add("Tag1");
            tags.Add("Tag2");
            this.Topmost = true;
            InitializeComponent();
        }

        private void refresh_selection()
        {
            // Clear StackPanel
            DocstringCardsPanel.Children.Clear();
            GH_Document doc = Instances.ActiveCanvas.Document;
            if (doc == null)
                return;
            var selectedObjects = doc.SelectedObjects();
            List<string> selectedComponents = new List<string>();
            foreach (var obj in selectedObjects)
            {
                string GuidStr = obj.InstanceGuid.ToString();
                if (ghDocstring_Data.metaData.ContainsKey(GuidStr))
                {
                    AddDocstringCard(obj.Name, ghDocstring_Data.metaData[GuidStr], GuidStr,tags);
                }
            }
        }
        private void SaveButtonClicked(object sender, RoutedEventArgs e)
        {
            GH_Document doc = Instances.ActiveCanvas.Document;
            
            if (doc.SelectedCount == 1)
            {
                Guid guid = doc.SelectedObjects().First().InstanceGuid;
                ghDocstring_Data.metaData[guid.ToString()] = UserTextboxInput.Text;
            }
        }
        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void AddDocstringCard(string compnentName, string userString, string guid, List<string> tags)
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
