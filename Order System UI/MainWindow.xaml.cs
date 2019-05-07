using System.Windows;

namespace Order_System_UI
{
    public partial class MainWindow : Window
    {
        // field for passing data across different windows
        private DataCollection Data;

        /// <summary>
        /// Creates the window for the first time when Tranportation U.I is selected from the home screen
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.Data = new DataCollection { };
            this.DataContext = Data;
        }

        /// <summary>
        /// Creates the same window with the data input only when when user wants to make changes to the order before sending to the data base
        /// </summary>
        /// <param name="d">Data Binding file</param>
        public MainWindow(DataCollection d)
        {
            InitializeComponent();
            this.Data = d;
            this.DataContext = Data;
        }

        /// <summary>
        /// Goes to the order confirmation window
        /// </summary>
        /// <param name="sender">event for button</param>
        /// <param name="e">event handler for button</param>
        private void orderConfirmation(object sender, RoutedEventArgs e)
        {
            orderButton.IsEnabled = true;
            Window1 win1 = new Window1(Data);
            this.Close();
            win1.Show();
        }
        
        /// <summary>
        /// Goes to the home screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoHomeScreen(object sender, RoutedEventArgs e)
        {
            HomeWindow hmWin = new HomeWindow();
            this.Close();
            hmWin.Show();
        }

    }// end class
}// end namespace
