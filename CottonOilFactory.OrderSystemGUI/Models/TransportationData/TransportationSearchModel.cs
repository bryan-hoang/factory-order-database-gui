using System.Collections.Generic;
using System.Linq;
using CottonOilFactory.OrderSystemGUI.Database;

namespace CottonOilFactory.OrderSystemGUI.Models.TransportationData
{
    /// <summary>
    /// Class for searching transportation data from SQL server.
    /// </summary>
    public class TransportationSearchModel : ModelBase
    {
        // declare private fields
        private string _truckCompanyName;
        private string _sellerName;
        private string _dateOfArrival;
        private string _netCosts;

        /// <summary>
        /// Gets or sets the truck company name in the database.
        /// </summary>
        public string TruckCompanyName
        {
            get
            {
                OnPropertyChanged(nameof(DataTable));
                return _truckCompanyName;
            }

            set
            {
                _truckCompanyName = value;
                OnPropertyChanged(nameof(DataTable));
            }
        }

        /// <summary>
        /// Gets or sets the seller name in the database.
        /// </summary>
        public string SellerName
        {
            get
            {
                OnPropertyChanged(nameof(DataTable));
                return _sellerName;
            }

            set
            {
                _sellerName = value;
                OnPropertyChanged(nameof(SellerName));
                OnPropertyChanged(nameof(DataTable));
            }
        }

        /// <summary>
        /// Gets or sets the date of arrival in the database.
        /// </summary>
        public string DateofArrival
        {
            get
            {
                if (this._dateOfArrival == null)
                {
                    return null;
                } // end if
                // year - month - date
                string[] splitDate = this._dateOfArrival.Split();
                string[] anotherSplitDate = splitDate[0].Split('/');
                if (anotherSplitDate[0].Length < 2)
                {
                    anotherSplitDate[0] = "0" + anotherSplitDate[0];
                }// end if
                if (anotherSplitDate[1].Length < 2)
                {
                    anotherSplitDate[1] = "0" + anotherSplitDate[1];
                }// end if
                return anotherSplitDate[2] + "-" + anotherSplitDate[0] + "-" + anotherSplitDate[1];
            }

            set
            {

                _dateOfArrival = value;
                OnPropertyChanged(nameof(DateofArrival));
                OnPropertyChanged(nameof(DataTable));
            }
        }

        /// <summary>
        /// Gets or Sets the year to calculate the net costs.
        /// </summary>
        public string NetCosts
        {
            get => _netCosts;
            set
            {
                if (!int.TryParse(value, out int check))
                {
                    _netCosts = null;
                    OnPropertyChanged(nameof(NetCosts));
                    return;
                }
                _netCosts = value;
                OnPropertyChanged(nameof(NetCosts));
                OnPropertyChanged(nameof(TextStatus));
            }
        }

        /// <summary>
        /// Gets the status if an integer was entered in the yearly textbox.
        /// </summary>
        public string TextStatus
        {
            get
            {
                if (_netCosts == null)
                {
                    return null;
                }// end if
                else if (int.TryParse(_netCosts, out int a))
                {
                    return null;
                }// end else if
                return "Invalid Input";
            }
        }

        /// <summary>
        /// Gets the data from the database into a list being data binded to the data grid also manipluating searches.
        /// </summary>
        public IEnumerable<TransportationDatum> DataTable
        {
            get
            {
                var linqToSqlConnection = new LinqToSqlConnection();

                IEnumerable<TransportationDatum> dataDisplay =
                    from table in linqToSqlConnection.TransportationDatumTable
                    where (table.Truck_Company.Contains(_truckCompanyName) || string.IsNullOrEmpty(_truckCompanyName)) &&
                          (table.Name_of_Seller.Contains(_sellerName) || string.IsNullOrEmpty(_sellerName)) && 
                          (table.Date_of_Arrival.Equals(DateofArrival) || string.IsNullOrEmpty(_dateOfArrival))
                    select table;
                return dataDisplay;
            }// end get
        }// end property

        /// <summary>
        /// Deletes a row of data from the SQL server.
        /// </summary>
        /// <param name="transportationDatumToDelete">Row to be deleted from data.</param>
        public void DeleteRow(TransportationDatum transportationDatumToDelete)
        {
            var linqToSqlConnection = new LinqToSqlConnection();
            var dataClassesDataContext = linqToSqlConnection.DataClassesDataContext;
            if (transportationDatumToDelete != null)
            {
                dataClassesDataContext.TransportationDatums.Attach(transportationDatumToDelete);
                dataClassesDataContext.TransportationDatums.DeleteOnSubmit(transportationDatumToDelete);
                dataClassesDataContext.SubmitChanges();
            }// end if
            OnPropertyChanged("DataTable");
        }// end method
    }// end class
}// end namespace