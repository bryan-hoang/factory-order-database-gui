using System.Windows;
using Order_System_UI.Models;
using System.Collections.Generic;
using Order_System_UI.Models;
using System.Configuration;
using System;

namespace Order_System_UI.Views
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataSearchView : Window
    {
        // declare private field to pass data to SQL
        private readonly TransportationSearchModel transportationSearchModel;

        // declare private field for LINQ operations
        private TransportLinkDataContext datacontext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataSearchView"/> class.
        /// Start up the window.
        /// </summary>
        public TransportationDataSearchView()
        {
            InitializeComponent();
            this.transportationSearchModel = new TransportationSearchModel();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // set up SQL-LINQ connections
            string connectionString = ConfigurationManager.ConnectionStrings["Order_System_UI.Properties.Settings.modelConnectionString"].ConnectionString;
            datacontext = new TransportLinkDataContext(connectionString);

            // setting the DataContext for data binding
            this.DataContext = transportationSearchModel;
        }

        /// <summary>
        /// Go back to home screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackHome(object sender, RoutedEventArgs e)
        {
            MainWindow hm = new MainWindow();
            this.Close();
            hm.Show();
        }

        /// <summary>
        /// Sums up the yearly numerical data displaying it as a messagebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SummationYearlyData(object sender, RoutedEventArgs e)
        {
            var list = datacontext.TransportationDataLog1s;

            decimal weightTotal = 0;
            decimal priceTotal = 0;
            int numberofbagsTotal = 0;
            decimal freightChargesTotal = 0;
            decimal costsTotal = 0;

            foreach (TransportationDataLog1 x in list)
            {
                string[] compare = x.Date_of_Arrival.Split('/');
                if (YearSelect.Text.ToString().Equals(compare[2]))
                {
                    weightTotal += decimal.Parse(x.Weight);
                    priceTotal += decimal.Parse(x.Price);
                    numberofbagsTotal += int.Parse(x.Number_of_Bags);
                    freightChargesTotal += decimal.Parse(x.Freight_Charges);
                    costsTotal += decimal.Parse(x.Total_Cost);
                }// end if
            }// end loop
            MessageBox.Show("Yearly Cost Summary" + "\n" + "Total weight: " + weightTotal + "\n" + "Total price: " + priceTotal
                + "\n" + "Total Number of Bags: " + numberofbagsTotal + "\n" + "Total Freight Charges: " + freightChargesTotal
                + "\n" + "Total Costs: " + costsTotal);
        }// end method

        /// <summary>
        /// Deletes a piece of data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TransportationSearchModel s1 = new TransportationSearchModel();

            try
            {
                s1.del = (Order_System_UI.TransportationDataLog1)DataTable.SelectedItem;
                object oo = s1.DataTable;
            }
            catch (Exception)
            {
                MessageBox.Show("Do not delete this empty row");
            }// end try-catch
        }// end method
    }// end class
}// end namespace