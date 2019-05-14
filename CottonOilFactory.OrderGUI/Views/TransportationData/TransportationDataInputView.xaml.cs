using System.Windows;
using CottonOilFactory.OrderGUI.Models;

namespace CottonOilFactory.OrderGUI.Views.TransportationData
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataInputView : Window
    {
        // field for passing transportationDataModel across different windows
        private readonly TransportationDataModel transportationDataModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataInputView"/> class.
        /// Creates the window for the first time when Transportation U.I is selected from the home screen.
        /// </summary>
        public TransportationDataInputView()
        {
            InitializeComponent();
            transportationDataModel = new TransportationDataModel();
            DataContext = transportationDataModel;
        }

        /// <summary>
        /// Goes to the order confirmation window.
        /// </summary>
        /// <param name="sender">event for button.</param>
        /// <param name="e">event handler for button.</param>
        private void ShowDataConfirmationDialog(object sender, RoutedEventArgs e)
        {
            var transportationDataConfirmView = new TransportationDataConfirmView(transportationDataModel);
            transportationDataConfirmView.ShowDialog();
        }

        /// <summary>
        /// Goes to the home screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackToHomeScreen(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

    }// end class
}// end namespace
