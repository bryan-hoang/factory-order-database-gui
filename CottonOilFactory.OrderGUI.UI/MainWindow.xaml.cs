using System.Windows;

namespace CottonOilFactory.OrderGUI.UI
{

    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InputTransportationData(object sender, RoutedEventArgs e)
        {
            var transportDataInputWindow = new TransportDataInputWindow();
            this.Close();
            transportDataInputWindow.Show();
        }// end method

        private void SearchTransportationData(object sender, RoutedEventArgs e)
        {

        }// end method

        private void InputSalesData(object sender, RoutedEventArgs e)
        {
            var salesDataInputWindow = new SalesDataInputWindow();
            this.Close();
            salesDataInputWindow.Show();
        }// end method

        private void SearchSalesData(object sender, RoutedEventArgs e)
        {

        }// end method


    }
}
