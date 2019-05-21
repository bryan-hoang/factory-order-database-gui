using System.Windows;

namespace CottonOilFactory.OrderSystemGUI.Views.TransportationData
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
        }

        /// <summary>
        /// Go back to home screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackHome(object sender, RoutedEventArgs e)
        {
            Main hm = new Main();
            Close();
            hm.Show();
        }

        private void SearchYearlyData(object sender, RoutedEventArgs e)
        {
            Main hm = new Main();
            Close();
            hm.Show();
        }
    }
}
