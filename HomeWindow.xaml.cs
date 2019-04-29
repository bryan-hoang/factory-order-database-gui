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
using System.Windows.Shapes;

namespace Order_System_UI
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void InputTranportationData(object sender, RoutedEventArgs e)
        {
            MainWindow win0 = new MainWindow();
            this.Close();
            win0.Show();
        }// end method

        private void SearchTransportationData(object sender, RoutedEventArgs e)
        {
            
        }// end method

        private void InputSalesData(object sender, RoutedEventArgs e)
        {

        }// end method

        private void SearchSalesData(object sender, RoutedEventArgs e)
        {

        }// end method


    }
}
