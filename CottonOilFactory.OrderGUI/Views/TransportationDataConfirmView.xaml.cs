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
using CottonOilFactory.OrderGUI.Models;

namespace CottonOilFactory.OrderGUI.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TransportationDataConfirmView : Window
    {
        private TransportationDataModel transportationDataModel;

        public TransportationDataConfirmView(TransportationDataModel d, string quality)
        {
            InitializeComponent();
            Quality.Text = quality;
            transportationDataModel = d;
            this.DataContext = transportationDataModel;

        }// end constructor

        // button to go back to make corrections
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var transportDataInputWindow= new TransportationDataInputView(transportationDataModel, Quality.Text);
            this.Close();
            transportDataInputWindow.Show();
        }// end method

        // button to make data sent to transportation object
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }// end method

    }
}
