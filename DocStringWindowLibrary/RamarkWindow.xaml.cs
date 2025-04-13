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
    /// Interaction logic for RemarkWindow.xaml
    /// </summary>
    public partial class RemarkWindow : Window
    {
        public string InputRemark { get; set; }
        Dictionary<string, string> myDict;
        public string OutputRemark { get; private set; }
        public RemarkWindow(Dictionary<string, string> Data,bool flag)
        {
            InitializeComponent();
            if (!flag)
            {
                writeGroupBox.Visibility = Visibility.Collapsed;
            }
            var dataList = new ObservableCollection<KeyValuePair<string, string>>();
            Window_Loaded(Data);
            //foreach (var kvp in myDict)
            //{
            //    dataList.Add(kvp);
            //}
            //dataGrid.ItemsSource = dataList;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputRemark= txtWriteRemark.Text;
            this.Close();
        }
        private void Window_Loaded(Dictionary<string, string> Data)
        {
            // Sample data to add to the dictionary
            //myDict.Add("GUID1", "This is the first remark.");
            //myDict.Add("GUID2", "This is the second remark.");
            // Convert the Dictionary to an ObservableCollection of KeyValuePairs
            //var dataList = new ObservableCollection<KeyValuePair<string, string>>(myDict);
            // Bind the ObservableCollection to the DataGrid
            dataGrid.ItemsSource = Data;
        }
        //public string GetRemark()
        //{
        //    return myDict[InputRemark];
        //}
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Dictionary<string, string> guidRemarkData = DataHandler.GetData();
        //    // Convert dictionary to ObservableCollection for data binding
        //    var dataList = new ObservableCollection<string>();
        //    foreach (var kvp in myDict)
        //    {
        //        dataList.Add(new GuidRemark { GUID = kvp.Key, Remark = kvp.Value });
        //    }
        //    // Bind the data to the DataGrid
        //    dataGrid.ItemsSource = dataList;
        //}
    }
}