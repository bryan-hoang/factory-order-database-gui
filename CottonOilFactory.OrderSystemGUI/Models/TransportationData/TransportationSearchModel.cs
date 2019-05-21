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
                if (!string.IsNullOrWhiteSpace(value))
                {
                    DeleteStatus = false;
                }// end if
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
                if (!string.IsNullOrWhiteSpace(value))
                {
                    DeleteStatus = false;
                }// end if
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
                var spiltDate = _dateOfArrival?.Split();
                return spiltDate?[0];
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    DeleteStatus = false;
                }

                _dateOfArrival = value;
                OnPropertyChanged(nameof(DateofArrival));
                OnPropertyChanged(nameof(DataTable));
            }
        }

        /// <summary>
        /// Gets or Sets the year to display the net costs.
        /// </summary>
        public string NetCosts
        {
            get => _netCosts;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    DeleteStatus = false;
                }// end if
                _netCosts = value;
                OnPropertyChanged(nameof(NetCosts));
                OnPropertyChanged(nameof(DeleteStatus));
                OnPropertyChanged(nameof(ButtonStatus));
                OnPropertyChanged(nameof(TextStatus));
            }
        }

        /// <summary>
        /// Gets a value indicating whether the NetCost is an integer.
        /// </summary>
        public bool ButtonStatus
        {
            get
            {
                if (int.TryParse(_netCosts, out int a))
                {
                    return true;
                }// end if
                return false;
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
        /// Sets a value indicating whether a row has been selected.
        /// </summary>
        public object TableStatus
        {
            set
            {
                if (value == null)
                {
                    OnPropertyChanged(nameof(DeleteStatus));
                    return;
                }// end if
                DeleteStatus = true;
                OnPropertyChanged(nameof(DeleteStatus));
            }
        }

        /// <summary>
        /// Gets a value indicating whether the button should be enabled.
        /// </summary>
        public bool DeleteStatus { get; private set; }

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
        }// end method
    }// end class
}// end namespace