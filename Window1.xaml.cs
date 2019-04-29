using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Order_System_UI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private DataCollection Data;

        public Window1(DataCollection d, string Quality)
        {
            InitializeComponent();
            quality.Text = Quality;
            Data = d;
            this.DataContext = Data;

        }// end constructor

        // button to go back to make corrections
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win0 = new MainWindow(Data, quality.Text);
            this.Close();
            win0.Show();
        }// end method

        // button to make data sent to transportation object
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }// end method

    }
}
