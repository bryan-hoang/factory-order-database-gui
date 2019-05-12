using System;
using System.Configuration;
using System.Windows;
using Order_System_UI.Models;

namespace Order_System_UI.Views
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataConfirmView : Window
    {
        // field to pass transportationData to transportationData input window
        private readonly TransportationDataModel transportationData;

        // field for LINQ operations
        private TransportLinkDataContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataConfirmView"/> class.
        /// Start up the window screen.
        /// </summary>
        public TransportationDataConfirmView(TransportationDataModel transportationDataModel)
        {
            InitializeComponent();
            // transfer data to current window
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.transportationData = transportationDataModel;
            this.DataContext = transportationData;

            // set up SQL connection
            string connectionString = ConfigurationManager.ConnectionStrings["Order_System_UI.Properties.Settings.modelConnectionString"].ConnectionString;
            dataContext = new TransportLinkDataContext(connectionString);
        }// end constructor

        /// <summary>
        /// Button to go back to the previous window to make corrections.
        /// </summary/>
        private void GoBackToTransportationDataInputWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }// end method

        /// <summary>
        /// Button to make transportationData sent to SQL DataBase.
        /// </summary>
        private void SqlWindow(object sender, RoutedEventArgs e)
        {
            try
            {
                TransportationDataLog1 cc = new TransportationDataLog1();
                cc.Name_of_Seller = transportationData.Seller;
                cc.Number_of_Bags = transportationData.NumberOfBags;
                cc.Price = transportationData.Price;
                cc.Quality = transportationData.Quality;
                cc.Shipment_Number = transportationData.ShipmentNumber;
                cc.Total_Cost = transportationData.Result;
                cc.Truck_Company = transportationData.TruckingCompany;
                cc.Weight = transportationData.Weight;
                cc.Freight_Charges = transportationData.FreightCharges;
                cc.Date_of_Arrival = transportationData.DateOfArrival;

                dataContext.TransportationDataLog1s.InsertOnSubmit(cc);

                dataContext.SubmitChanges();

                MessageBox.Show("Data has been successfully inserted");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Data UNsuccessfully inserted");
            }
        }// end method

    }// end class
}// end name space