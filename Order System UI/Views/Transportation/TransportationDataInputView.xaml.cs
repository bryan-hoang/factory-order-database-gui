using System.Windows;
using Order_System_UI.Models;

namespace Order_System_UI.Views
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataInputView : Window
    {
        // field for passing transportation data across different windows
        private readonly TransportationDataModel TransportationDataModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataInputView"/> class.
        /// Creates the window for the first time when Transportation U.I is selected from the home screen.
        /// </summary>
        public TransportationDataInputView()
        {
            InitializeComponent();
            this.TransportationDataModel = new TransportationDataModel();
            this.DataContext = this.TransportationDataModel;
        }// end constructor

        /// <summary>
        /// Goes back to the home window.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event handler.</param>
        private void GoToHomeWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mnWin = new MainWindow();
            mnWin.Show();
            this.Close();
        }

        /// <summary>
        /// Go to the data confirm window.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event handler.</param>
        private void GoToDataConfirmWindow(object sender, RoutedEventArgs e)
        {
            TransportationDataConfirmView confirmWin = new TransportationDataConfirmView(this.TransportationDataModel);
            confirmWin.ShowDialog();
        }// end method
    }// end class
}// end namespace