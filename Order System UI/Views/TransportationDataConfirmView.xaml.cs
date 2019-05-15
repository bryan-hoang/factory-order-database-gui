using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using Order_System_UI.LINQ_SQL_Connection;
using Order_System_UI.Models;

namespace Order_System_UI.Views
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataConfirmView : Window
    {
        // field to pass transportationData to transportationData input window
        private readonly TransportationDataModel transportationData;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataConfirmView"/> class.
        /// </summary>
        /// <param name="transportationDataModel">Class for passing the data from the input window to this window</param>
        public TransportationDataConfirmView(TransportationDataModel transportationDataModel)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.transportationData = transportationDataModel;
            this.DataContext = transportationData;
        }// end constructor

        /// <summary>
        /// Button to go back to the previous window to make corrections.
        /// </summary/>
        private void GoBackToTransportationDataInputWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }// end method

        /// <summary>
        /// Button to make the transportation data be sent to the SQL DataBase.
        /// </summary>
        private void SqlWindow(object sender, RoutedEventArgs e)
        {
            LinqSqlDeclaration connect = new LinqSqlDeclaration();
            TransportLinkDataContext dataContext = connect.DataContext;
            try
            {
                TransportationDataLog1 cc = new TransportationDataLog1
                {
                    Name_of_Seller = transportationData.Seller,
                    Number_of_Bags = transportationData.NumberOfBags,
                    Price = transportationData.Price,
                    Quality = transportationData.Quality,
                    Shipment_Number = transportationData.ShipmentNumber,
                    Total_Cost = transportationData.Result,
                    Truck_Company = transportationData.TruckingCompany,
                    Weight = transportationData.Weight,
                    Freight_Charges = transportationData.FreightCharges,
                    Date_of_Arrival = transportationData.DateOfArrival,
                };

                dataContext.TransportationDataLog1s.InsertOnSubmit(cc);

                dataContext.SubmitChanges();

                MessageBox.Show("Data has been successfully inserted");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Data UNsuccessfully inserted" + "\n" + ee.ToString());
            }// end try-catch block
        }// end method
    }// end class
}// end name space