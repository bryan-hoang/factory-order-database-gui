using System.Windows;
using CottonOilFactory.OrderSystemGUI.Interfaces;

namespace CottonOilFactory.OrderSystemGUI.Views.SalesData
{
    /// <summary>
    /// Interaction logic for SalesDataConfirmWindow.xaml.
    /// </summary>
    public partial class SalesDataConfirmView : Window, IClosableWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesDataConfirmView"/> class.
        /// </summary>
        public SalesDataConfirmView() => InitializeComponent();
    }
}
