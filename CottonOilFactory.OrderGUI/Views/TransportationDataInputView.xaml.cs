using System.Windows;
using CottonOilFactory.OrderGUI.Models;

namespace CottonOilFactory.OrderGUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TransportationDataInputView : Window
    {
        private TransportationDataModel transportationDataModel;

        /// <summary>
        /// Creates the window for the first time when Transportation UI is selected
        /// </summary>
        public TransportationDataInputView()
        {
            InitializeComponent();
            transportationDataModel = new TransportationDataModel { NameofSeller = null, TruckingCompany = null, Weight = null, Price = null, NumberOfBags = null, FreightCharges = null, ShipmentNumber = null, DateOfArrival = null};
            this.DataContext = transportationDataModel;

        }// end method

        /// <summary>
        /// Creates the window when user want to make changes to the order before final confirmation
        /// </summary>
        /// <param name="d">Data Binding file</param>
        /// <param name="quality">String to indicates the quality for the radio button</param>
        public TransportationDataInputView(TransportationDataModel d, string quality)
        {
            InitializeComponent();
            if (quality.Equals("Bad"))
            {
                bbadQuality.IsChecked = true;
                transportationDataModel = d;
                this.DataContext = transportationDataModel;
            }// end if
            else if (quality.Equals("Medium"))
            {
                mmediumQuality.IsChecked = true;
                transportationDataModel = d;
                this.DataContext = transportationDataModel;
            }// end else if
            else if (quality.Equals("Good"))
            {
                ggoodQuality.IsChecked = true;
                transportationDataModel = d;
                this.DataContext = transportationDataModel;
            }// end else if

        }// end constructor

        /// <summary>
        /// Calls the order confirmation window
        /// </summary>
        /// <param name="sender">event for button</param>
        /// <param name="e">event handler for button</param>
        private void OrderConfirmation(object sender, RoutedEventArgs e)
        {
            if(bbadQuality.IsChecked == true)
            {
                var win1 = new TransportationDataConfirmView(transportationDataModel, bbadQuality.Content.ToString());
                this.Close();
                win1.ShowDialog();
            }// end if
            else if(mmediumQuality.IsChecked == true)
            {
                var win1 = new TransportationDataConfirmView(transportationDataModel, mmediumQuality.Content.ToString());
                this.Close();
                win1.ShowDialog();
            }// end else if
            else if(ggoodQuality.IsChecked == true)
            {
                var win1 = new TransportationDataConfirmView(transportationDataModel, ggoodQuality.Content.ToString());
                this.Close();
                win1.ShowDialog();
            }// end else if

        }// end method

        private void GoToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }// end method

        /// <summary>
        /// Goes back to the home screen
        /// </summary>
        /// <param name="sender">event for button</param>
        /// <param name="e">event handler for button</param>

    }// end class
}// end namespace
