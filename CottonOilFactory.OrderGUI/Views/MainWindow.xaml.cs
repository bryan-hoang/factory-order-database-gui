using System.Windows;
using CottonOilFactory.OrderGUI.Factories;
using CottonOilFactory.OrderGUI.Interfaces;
using CottonOilFactory.OrderGUI.ViewModels;

namespace CottonOilFactory.OrderGUI.Views
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
