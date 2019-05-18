using System.Windows;
using CottonOilFactory.OrderGUI.Factories;
using CottonOilFactory.OrderGUI.Interfaces;
using CottonOilFactory.OrderGUI.ViewModels;

namespace CottonOilFactory.OrderGUI.Views
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
