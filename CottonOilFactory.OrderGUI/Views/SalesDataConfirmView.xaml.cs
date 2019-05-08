using System;
using System.Windows;
using CottonOilFactory.OrderGUI.Models;

namespace CottonOilFactory.OrderGUI.Views
{
    /// <summary>
    /// Interaction logic for SalesDataConfirmWindow.xaml.
    /// </summary>
    public partial class SalesDataConfirmView : Window
    {
        private readonly SalesDataModel salesDataModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesDataConfirmView"/> class.
        /// </summary>
        public SalesDataConfirmView() => InitializeComponent();

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesDataConfirmView"/> class.
        /// </summary>
        /// <param name="salesDataModel"></param>
        public SalesDataConfirmView(SalesDataModel salesDataModel)
        {
            InitializeComponent();
            this.salesDataModel = salesDataModel;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
