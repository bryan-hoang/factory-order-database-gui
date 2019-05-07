using System.Windows;
using CottonOilFactory.OrderGUI.Data;

namespace CottonOilFactory.OrderGUI.UI
{

    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class SalesDataInputWindow : Window
    {

        private SalesData salesData;

        public SalesDataInputWindow()
        {
            InitializeComponent();
            SalesData salesData = new SalesData();
            this.salesData = salesData;
            this.DataContext = salesData;
        }

        public SalesDataInputWindow(SalesData salesData)
        {
            InitializeComponent();
            this.salesData = salesData;
            this.DataContext = salesData;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var salesDataConfirmWindow = new SalesDataConfirmWindow(salesData);
        }
    }
}
