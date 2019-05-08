
using System.Windows;
using CottonOilFactory.OrderGUI.Models;

namespace CottonOilFactory.OrderGUI.Views
{

    /// <summary>
    /// Interaction logic for Window2.xaml.
    /// </summary>
    public partial class SalesDataInputView : Window
    {

        private readonly SalesDataModel salesDataModel;

        /// <inheritdoc />
        public SalesDataInputView()
        {
            InitializeComponent();
            salesDataModel = new SalesDataModel();
            DataContext = salesDataModel;
        }

        /// <inheritdoc />
        public SalesDataInputView(SalesDataModel salesDataModel)
        {
            InitializeComponent();
            this.salesDataModel = salesDataModel;
            DataContext = salesDataModel;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var salesDataConfirmWindow = new SalesDataConfirmView(salesDataModel);
            salesDataConfirmWindow.ShowDialog();
        }
    }
}
