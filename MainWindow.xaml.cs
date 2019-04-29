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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Order_System_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataCollection Data;

        /// <summary>
        /// Creates the window for the first time when Tranportation UI is selected
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Data = new DataCollection { NameofSeller = null, TruckingCompany = null, Weight = null, Price = null, NumberofBags = null, FreightCharges = null, ShipmentNumber = null, DateofArrival = null};
            this.DataContext = Data;

        }// end method

        /// <summary>
        /// Creates the window when user want to make changes to the order before final confirmation
        /// </summary>
        /// <param name="d">Data Binding file</param>
        /// <param name="Quality">String to indicates the quality for the radio button</param>
        public MainWindow(DataCollection d, string Quality)
        {
            InitializeComponent();
            if (Quality.Equals("Bad"))
            {
                bbadQuality.IsChecked = true;
                Data = d;
                this.DataContext = Data;
            }// end if
            else if (Quality.Equals("Medium"))
            {
                mmediumQuality.IsChecked = true;
                Data = d;
                this.DataContext = Data;
            }// end else if
            else if (Quality.Equals("Good"))
            {
                ggoodQuality.IsChecked = true;
                Data = d;
                this.DataContext = Data;
            }// end else if

        }// end constructor

        /// <summary>
        /// Calls the order confirmation window
        /// </summary>
        /// <param name="sender">event for button</param>
        /// <param name="e">event handler for button</param>
        private void orderConfirmation(object sender, RoutedEventArgs e)
        {
            if(bbadQuality.IsChecked == true)
            {
                Window1 win1 = new Window1(Data, bbadQuality.Content.ToString());
                this.Close();
                win1.ShowDialog();
            }// end if
            else if(mmediumQuality.IsChecked == true)
            {
                Window1 win1 = new Window1(Data, mmediumQuality.Content.ToString());
                this.Close();
                win1.ShowDialog();
            }// end else if
            else if(ggoodQuality.IsChecked == true)
            {
                Window1 win1 = new Window1(Data, ggoodQuality.Content.ToString());
                this.Close();
                win1.ShowDialog();
            }// end else if

        }// end method

        private void GoHomeScreen(object sender, RoutedEventArgs e)
        {
            HomeWindow hmWin = new HomeWindow();
            this.Close();
            hmWin.Show();
        }// end method

        /// <summary>
        /// Goes back to the home screen
        /// </summary>
        /// <param name="sender">event for button</param>
        /// <param name="e">event handler for button</param>

    }// end class
}// end namespace
