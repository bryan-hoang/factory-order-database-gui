using System;
using System.Windows;
using CottonOilFactory.OrderSystemGUI.Database;
using CottonOilFactory.OrderSystemGUI.Models.TransportationData;

namespace CottonOilFactory.OrderSystemGUI.Views.TransportationData
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataSearchView : Window
    {
        // declare private field to pass data to SQL

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataSearchView"/> class.
        /// Start up the window.
        /// </summary>
        public TransportationDataSearchView()
        {
            InitializeComponent();
            var transportationSearchModel = new TransportationSearchModel();
            DataContext = transportationSearchModel;
        }

        /// <summary>
        /// Goes back to home screen.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event handler.</param>
        private void GoBackHome(object sender, RoutedEventArgs e)
        {
            var hm = new MainWindow();
            Close();
            hm.Show();
        }

        /// <summary>
        /// Sums up the yearly numerical data displaying it as a messagebox.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event handler.</param>
        private void SummationYearlyData(object sender, RoutedEventArgs e)
        {
            var linqToSqlConnection = new LinqToSqlConnection();
            var transportationDatumTable = linqToSqlConnection.TransportationDatumTable;

            decimal weightTotal = 0;
            decimal priceTotal = 0;
            int numberOfBagsTotal = 0;
            decimal freightChargesTotal = 0;
            decimal costsTotal = 0;

            foreach (var transportationDatum in transportationDatumTable)
            {
                var compare = transportationDatum.Date_of_Arrival.Split('/');
                if (YearSelect.Text.Equals(compare[2]))
                {
                    weightTotal += decimal.Parse(transportationDatum.Weight);
                    priceTotal += decimal.Parse(transportationDatum.Price);
                    numberOfBagsTotal += int.Parse(transportationDatum.Number_of_Bags);
                    freightChargesTotal += decimal.Parse(transportationDatum.Freight_Charges);
                    costsTotal += decimal.Parse(transportationDatum.Total_Cost);
                }// end if
            }// end loop
            MessageBox.Show(
                "Yearly Cost Summary" + "\n" + "Total weight: " + weightTotal + "\n" + "Total price: " + priceTotal +
                "\n" + "Total Number of Bags: " + numberOfBagsTotal + "\n" + "Total Freight Charges: " + freightChargesTotal +
                "\n" + "Total Costs: " + costsTotal);
        }// end method

        /// <summary>
        /// Deletes a row of data.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event handler.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var transportationSearchModel = new TransportationSearchModel();
            var transportationDataSearchView = new TransportationDataSearchView();

            try
            {
                var transportationDatumToDelete = (TransportationDatum)DataTable.SelectedItem;
                transportationSearchModel.DeleteRow(transportationDatumToDelete);
                Close();
                transportationDataSearchView.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Do not delete this empty row");
            }// end try-catch
        }// end method
    }// end class
}// end namespace