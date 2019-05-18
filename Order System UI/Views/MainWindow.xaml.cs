using System.Windows;
using Order_System_UI.ViewModels;

namespace Order_System_UI.Views
{
    /// <inheritdoc cref="Window" />
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Start up the Home Window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new HomeWindowViewModel();
        }// end constructor
    }// end class
}// end namespace