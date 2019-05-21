using System.Windows;
using CottonOilFactory.OrderSystemGUI.Factories;
using CottonOilFactory.OrderSystemGUI.Interfaces;
using CottonOilFactory.OrderSystemGUI.ViewModels;

namespace CottonOilFactory.OrderSystemGUI.Views
{
    /// <inheritdoc cref="Window" />
    public partial class MainWindow : Window, IClosableWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Start up the Home Window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new SalesDataInputWindowFactory(), new SalesDataSearchWindowFactory());
        }
    }
}
