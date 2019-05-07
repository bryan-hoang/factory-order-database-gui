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
    public partial class TransportationSearchData : Window
    {
        /// <summary>
        /// Start up the window
        /// </summary>
        public TransportationSearchData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Go back to home screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackHome(object sender, RoutedEventArgs e)
        {
            HomeWindow hm = new HomeWindow();
            this.Close();
            hm.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchYearlyData(object sender, RoutedEventArgs e)
        {
            HomeWindow hm = new HomeWindow();
            this.Close();
            hm.Show();
        }
    }
}
