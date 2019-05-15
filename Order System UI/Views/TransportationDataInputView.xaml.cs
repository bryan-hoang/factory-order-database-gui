using System.Windows;
using Order_System_UI.Models;

namespace Order_System_UI.Views
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataInputView : Window
    {
        // field for passing transportation data across different windows
        private readonly TransportationDataModel transportationDataModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataInputView"/> class.
        /// Creates the window for the first time when Transportation U.I is selected from the home screen.
        /// </summary>
        public TransportationDataInputView()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.transportationDataModel = new TransportationDataModel();
            this.DataContext = transportationDataModel;
        }

        /// <summary>
        /// Goes to the order confirmation window.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">event handler.</param>
        private void ShowDataConfirmationDialog(object sender, RoutedEventArgs e)
        {
            var transportationDataConfirmView = new TransportationDataConfirmView(transportationDataModel);
            transportationDataConfirmView.ShowDialog();
        }

        /// <summary>
        /// Goes to the home screen.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event Handler.</param>
        private void GoBackToHomeScreen(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

    }// end class
}// end namespace
