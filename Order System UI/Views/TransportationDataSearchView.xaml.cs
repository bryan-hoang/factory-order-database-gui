using System;
using System.Windows;
using Order_System_UI.Models;
using Order_System_UI.LINQ_SQL_Connection;

namespace Order_System_UI.Views
{
    /// <inheritdoc cref="Window" />
    public partial class TransportationDataSearchView : Window
    {
        // declare private field to pass data to SQL
        private readonly TransportationSearchModel transportationSearchModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportationDataSearchView"/> class.
        /// Start up the window.
        /// </summary>
        public TransportationDataSearchView()
        {
            InitializeComponent();
            this.transportationSearchModel = new TransportationSearchModel();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

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
            LINQSQLConnection connect = new LINQSQLConnection();
            var list = connect.List;

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
            MessageBox.Show(
                "Yearly Cost Summary" + "\n" + "Total weight: " + weightTotal + "\n" + "Total price: " + priceTotal +
                "\n" + "Total Number of Bags: " + numberofbagsTotal + "\n" + "Total Freight Charges: " + freightChargesTotal +
                "\n" + "Total Costs: " + costsTotal);
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
                var deletedItem = s1.DataTable;
                TransportationDataSearchView x = new TransportationDataSearchView();
                this.Close();
                x.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Do not delete this empty row");
            }// end try-catch
        }// end method
    }// end class
}// end namespace