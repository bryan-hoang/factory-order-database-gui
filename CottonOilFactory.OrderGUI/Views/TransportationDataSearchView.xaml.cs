using System.Windows;

namespace CottonOilFactory.OrderGUI.Views
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataSearchView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataSearchView"/> class.
        /// Start up the window.
        /// </summary>
        public TransportationDataSearchView()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// Go back to home screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackHome(object sender, RoutedEventArgs e)
        {
            MainWindow hm = new MainWindow();
            this.Close();
            hm.Show();
        }

        private void SearchYearlyData(object sender, RoutedEventArgs e)
        {
            MainWindow hm = new MainWindow();
            this.Close();
            hm.Show();
        }
    }
}
