using System.Windows;
using CottonOilFactory.OrderGUI.Models;

namespace CottonOilFactory.OrderGUI.Views
{

    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class SalesDataInputView : Window
    {

        private SalesDataModel salesDataModel;

        public SalesDataInputView()
        {
            InitializeComponent();
            SalesDataModel salesDataModel = new SalesDataModel();
            this.salesDataModel = salesDataModel;
            this.DataContext = salesDataModel;
        }

        public SalesDataInputView(SalesDataModel salesDataModel)
        {
            InitializeComponent();
            this.salesDataModel = salesDataModel;
            this.DataContext = salesDataModel;
        }



        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var salesDataConfirmWindow = new SalesDataConfirmView(salesDataModel);
            salesDataConfirmWindow.ShowDialog();
        }
    }
}
