using System.Windows;
using CottonOilFactory.OrderSystemGUI.Factories;
using CottonOilFactory.OrderSystemGUI.Interfaces;
using CottonOilFactory.OrderSystemGUI.ViewModels;

namespace CottonOilFactory.OrderSystemGUI.Views
{
    /// <inheritdoc cref="Window" />
    public partial class Main : Window, IClosableWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// Start up the Home Window.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new SalesDataInputWindowFactory(), new SalesDataSearchWindowFactory());
        }
    }
}
