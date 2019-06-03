using System;
using System.Windows;
using CottonOilFactory.OrderSystemGUI.Database;
using CottonOilFactory.OrderSystemGUI.Models.TransportationData;

namespace CottonOilFactory.OrderSystemGUI.Views.TransportationData
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataConfirmView : Window
    {
        // field to pass transportationData to transportationData input window
        private readonly TransportationDataModel _transportationDataModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataConfirmView"/> class.
        /// </summary>
        /// <param name="transportationDataModelModel">Class for passing the data from the input window to this window.</param>
        public TransportationDataConfirmView(TransportationDataModel transportationDataModelModel)
        {
            InitializeComponent();
            _transportationDataModel = transportationDataModelModel;
            DataContext = _transportationDataModel;
        }// end constructor

        /// <summary>
        /// Button to go back to the previous window to make corrections.
        /// </summary>
        private void GoBackToTransportationDataInputWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }// end method

        /// <summary>
        /// Button to make the transportation data be sent to the SQL DataBase.
        /// </summary>
        private void SqlWindow(object sender, RoutedEventArgs e)
        {
            var linqToSqlConnection = new LinqToSqlConnection();
            var dataClassesDataContext = linqToSqlConnection.DataClassesDataContext;
            try
            {
                var transportationDataLog = new TransportationDatum
                {
                    Name_of_Seller = _transportationDataModel.Seller,
                    Number_of_Bags = _transportationDataModel.NumberOfBags,
                    Price = _transportationDataModel.Price,
                    Quality = _transportationDataModel.Quality,
                    Shipment_Number = _transportationDataModel.ShipmentNumber,
                    Total_Cost = _transportationDataModel.Result,
                    Truck_Company = _transportationDataModel.TruckingCompany,
                    Weight = _transportationDataModel.Weight,
                    Freight_Charges = _transportationDataModel.FreightCharges,
                    Date_of_Arrival = _transportationDataModel.DateOfArrival,
                };

                dataClassesDataContext.TransportationDatums.InsertOnSubmit(transportationDataLog);

                dataClassesDataContext.SubmitChanges();

                MessageBox.Show("The transportation data has been successfully inserted!");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Data Unsuccessfully inserted" + "\n" + exception);
            }// end try-catch block
        }// end method
    }// end class
}// end namespace