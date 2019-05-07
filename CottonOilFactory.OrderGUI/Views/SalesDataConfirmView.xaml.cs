using System.Windows;
using CottonOilFactory.OrderGUI.Models;
using Microsoft.Win32.SafeHandles;

namespace CottonOilFactory.OrderGUI.Views
{
    /// <summary>
    /// Interaction logic for SalesDataConfirmWindow.xaml
    /// </summary>
    public partial class SalesDataConfirmView : Window
    {

        SalesDataModel salesDataModel;

        public SalesDataConfirmView() => InitializeComponent();

        public SalesDataConfirmView(SalesDataModel salesDataModel)
        {
            InitializeComponent();
            this.salesDataModel = salesDataModel;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
