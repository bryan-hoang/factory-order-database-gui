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
using CottonOilFactory.OrderGUI.Data;

namespace CottonOilFactory.OrderGUI.UI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TransportDataConfirmWindow : Window
    {
        private TransportationData transportationData;

        public TransportDataConfirmWindow(TransportationData d, string quality)
        {
            InitializeComponent();
            Quality.Text = quality;
            transportationData = d;
            this.DataContext = transportationData;

        }// end constructor

        // button to go back to make corrections
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var transportDataInputWindow= new TransportDataInputWindow(transportationData, Quality.Text);
            this.Close();
            transportDataInputWindow.Show();
        }// end method

        // button to make data sent to transportation object
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }// end method

    }
}
