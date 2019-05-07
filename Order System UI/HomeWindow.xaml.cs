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


    public partial class HomeWindow : Window
    {
        /// <summary>
        /// Start up the Home Window
        /// </summary>
        public HomeWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// go to input transportation data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputTranportationData(object sender, RoutedEventArgs e)
        {
            MainWindow win0 = new MainWindow();
            this.Close();
            win0.Show();
        }

        /// <summary>
        /// go to search transportation data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTransportationData(object sender, RoutedEventArgs e)
        {
            TransportationSearchData tr = new TransportationSearchData();
            this.Close();
            tr.Show();
        }

        /// <summary>
        /// Go to input sales data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputSalesData(object sender, RoutedEventArgs e)
        {
            // N/A
        }

        /// <summary>
        /// Go to search sales data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchSalesData(object sender, RoutedEventArgs e)
        {
            // N/A
        }


    }
}
