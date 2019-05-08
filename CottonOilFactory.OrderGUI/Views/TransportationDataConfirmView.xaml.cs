using System.Windows;
using CottonOilFactory.OrderGUI.Models;

namespace CottonOilFactory.OrderGUI.Views
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataConfirmView : Window
    {
        // field to pass transportationData to transportationData input window
        private readonly TransportationDataModel transportationData;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataConfirmView"/> class.
        /// Start up the window screen.
        /// </summary>
        /// <param name="transportationDataModel"></param>
        public TransportationDataConfirmView(TransportationDataModel transportationDataModel)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.transportationData = transportationDataModel;
            this.DataContext = transportationData;
        }// end constructor

        /// <summary>
        /// Button to go back to the previous window to make corrections.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackToTransportationDataInputWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }// end method

        /// <summary>
        /// Button to make transportationData sent to SQL DataBase.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SqlWindow(object sender, RoutedEventArgs e)
        {
            // will be done with SQL part
        }// end method

    }
}
