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

        public Window1()
        {
            InitializeComponent();
        }

        public Window1(string SellerName, string TruckingCompanyName, string Quality, string Weight, string Price, string NumberOfBags, string FreightCharges, string ShipmentNumber, string DateOfArrival, string TotalCost)
        {
            InitializeComponent();

            sellerName.Text = SellerName;
            truckingCompanyName.Text = TruckingCompanyName;
            quality.Text = Quality;
            weight.Text = Weight;
            price.Text = Price;
            numberOfBags.Text = NumberOfBags;
            freightCharges.Text = FreightCharges;
            shipmentNumber.Text = ShipmentNumber;
            dateOfArrival.Text = DateOfArrival;
            totalCost.Text = TotalCost;

        }// end constructor method

        // button to go back to make corrections
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                    

        }// end method

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }// end method

    }
}
