using System.Windows;
using CottonOilFactory.OrderSystemGUI.Models.TransportationData;

namespace CottonOilFactory.OrderSystemGUI.Views.TransportationData
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataInputView : Window
    {
        // field for passing transportation data across different windows
        private readonly TransportationDataModel _transportationDataModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataInputView"/> class.
        /// Creates the window for the first time when Transportation U.I is selected from the home screen.
        /// </summary>
        public TransportationDataInputView()
        {
            InitializeComponent();
            _transportationDataModel = new TransportationDataModel();
            DataContext = _transportationDataModel;
        }// end constructor

        /// <summary>
        /// Goes back to the home window.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event handler.</param>
        private void GoToHomeWindow(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        /// <summary>
        /// Go to the data confirm window.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event handler.</param>
        private void GoToDataConfirmWindow(object sender, RoutedEventArgs e)
        {
            var confirmWin = new TransportationDataConfirmView(_transportationDataModel);
            confirmWin.ShowDialog();
        }// end method
    }// end class
}// end namespace