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


    public partial class Window1 : Window
    {
        // field to pass data to data input window
        private DataCollection Data;

        /// <summary>
        /// Start up the window screen
        /// </summary>
        /// <param name="d"></param>
        public Window1(DataCollection d)
        {
            InitializeComponent();
            this.Data = d;
            this.DataContext = Data;
        }// end constructor

        /// <summary>
        /// Button to go back to the pervious window to make corrections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataWindow(object sender, RoutedEventArgs e)
        {
            MainWindow win0 = new MainWindow(Data);
            this.Close();
            win0.Show();
        }// end method

        /// <summary>
        /// Button to make data sent to SQL DataBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SQLWindow(object sender, RoutedEventArgs e)
        {
            // will be done with SQL part    
        }// end method

    }
}
