using System.Windows;
using CottonOilFactory.OrderGUI.Data;

namespace CottonOilFactory.OrderGUI.UI
{
    /// <summary>
    /// Interaction logic for SalesDataConfirmWindow.xaml
    /// </summary>
    public partial class SalesDataConfirmWindow : Window
    {

        SalesData salesData;

        public SalesDataConfirmWindow() => InitializeComponent();

        public SalesDataConfirmWindow(SalesData salesData)
        {
            InitializeComponent();
            this.salesData = salesData;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
