namespace CottonOilFactory.OrderSystemGUI.Models.TransportationData
{
    /// <inheritdoc />
    public class TransportationDataModel : ModelBase
    {
        // This is the string portion of the U.I
        private string _seller;
        private string _truckingCompany;
        private bool _isIsBadQuality;
        private bool _isMediumQuality = true;
        private bool _isGoodQuality;
        private string _weight;
        private string _price;
        private string _numberOfBags;
        private string _freightCharges;
        private string _shipmentNumber;
        private string _dateOfArrival;
        // This is the status portion of the U.I
        private string _status;
        private int _count;

        /// <summary>
        /// Gets or sets the name of seller of the cotton seeds.
        /// </summary>
        public string Seller
        {
            get => _seller;
            set
            {
                _seller = value;
                OnPropertyChanged(nameof(ButtonStatus));
            }
        }

        /// <summary>
        /// Gets or sets the name of the trucking company transporting the cotton seeds.
        /// </summary>
        public string TruckingCompany
        {
            get => _truckingCompany;
            set
            {
                _truckingCompany = value;
                OnPropertyChanged(nameof(TruckingCompany));
                OnPropertyChanged(nameof(ButtonStatus));
            }
        }

        /// <summary>
        /// Gets the quality from the radio buttons.
        /// </summary>
        public string Quality
        {
            get
            {
                if (_isIsBadQuality)
                {
                    return "Bad";
                }
                return _isMediumQuality ? "Medium" : "Good";
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether checks if the quality is bad.
        /// </summary>
        public bool IsBadQuality
        {
            get => _isIsBadQuality;
            set
            {
                _isIsBadQuality = value;
                OnPropertyChanged(nameof(ButtonStatus));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether checks if the quality is medium.
        /// </summary>
        public bool IsMediumQuality
        {
            get => _isMediumQuality;
            set
            {
                _isMediumQuality = value;
                OnPropertyChanged(nameof(ButtonStatus));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether checks if the quality is good.
        /// </summary>
        public bool IsGoodQuality
        {
            get => _isGoodQuality;
            set
            {
                _isGoodQuality = value;
                OnPropertyChanged(nameof(ButtonStatus));
            }
        }

        /// <summary>
        /// Gets or sets the total weight per truck.
        /// </summary>
        public string Weight
        {
            get => _weight;
            set
            {
                if (decimal.TryParse(value, result: out decimal kg) && kg > 0.0M)
                {
                    StatusEvent(true);
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                }// end else if
                else
                {
                    StatusEvent(false);
                    _weight = null;
                }

                OnPropertyChanged(nameof(ButtonStatus));
            }
        }

        /// <summary>
        /// Gets or sets the number of bags per truck.
        /// </summary>
        public string NumberOfBags
        {
            get => _numberOfBags;
            set
            {
                if (int.TryParse(value, out int num) && num > 0)
                {
                    StatusEvent(true);
                    _numberOfBags = value;
                    OnPropertyChanged(nameof(NumberOfBags));
                }// end else if
                else
                {
                    StatusEvent(false);
                    _numberOfBags = null;
                }

                OnPropertyChanged(nameof(ButtonStatus));
            }
        }

        /// <summary>
        /// Gets or sets the shipment number.
        /// </summary>
        public string ShipmentNumber
        {
            get => _shipmentNumber;
            set
            {
                if (int.TryParse(value, out int shipNum) && shipNum > 0)
                {
                    StatusEvent(true);
                    _shipmentNumber = value;
                    OnPropertyChanged(nameof(ShipmentNumber));
                }// end else if
                else
                {
                    StatusEvent(false);
                    _shipmentNumber = null;
                }// end else

                OnPropertyChanged(nameof(ButtonStatus));
            }
        }

        /// <summary>
        /// Gets or sets the date of arrival of the truck.
        /// </summary>
        public string DateOfArrival
        {
            get
            {
                var splitDate = _dateOfArrival?.Split();
                return splitDate?[0];
            }

            set
            {
                _dateOfArrival = value;
                OnPropertyChanged(nameof(ButtonStatus));
            }
        }

        // This is the arithmetic portion of the U.I

        /// <summary>
        /// Gets or sets the price of the cotton seeds.
        /// </summary>
        public string Price
        {
            get => _price;
            set
            {
                if (decimal.TryParse(value, out decimal cost) && cost >= 0)
                {
                    _price = value;
                    StatusEvent(true);
                    OnPropertyChanged(nameof(Result));
                    OnPropertyChanged(nameof(ButtonStatus));
                }// end else if
                else
                {
                    StatusEvent(false);
                    _price = null;
                }// end else

                OnPropertyChanged(nameof(ButtonStatus));
            }
        }

        /// <summary>
        /// Gets or sets the cost from the truck company.
        /// </summary>
        public string FreightCharges
        {
            get => _freightCharges;
            set
            {
                if (decimal.TryParse(value, out decimal cost) && cost >= 0)
                {
                    _freightCharges = value;
                    StatusEvent(true);
                    OnPropertyChanged(nameof(FreightCharges));
                    OnPropertyChanged(nameof(Result));
                }// end else if
                else
                {
                    StatusEvent(false);
                    _freightCharges = null;
                }// end else

                OnPropertyChanged(nameof(ButtonStatus));
            }
        }

        /// <summary>
        /// Gets the total cost (freight charges + cotton seed cost).
        /// </summary>
        public string Result
        {
            get
            {
                if (FreightCharges == null || Price == null)
                {
                    return null;
                }
                var res = decimal.Parse(FreightCharges) + decimal.Parse(Price);
                return res.ToString();
            }
        }

        /// <summary>
        /// Gets the text for the status bar in the U.I.
        /// </summary>
        public string Status
        {
            get
            {
                _status = _count == 0 ? string.Empty : "Invalid input";

                return _status;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the confirm button is enabled.
        /// </summary>
        public bool ButtonStatus => !string.IsNullOrWhiteSpace(_seller)
                                    && !string.IsNullOrWhiteSpace(_truckingCompany)
                                    && !string.IsNullOrWhiteSpace(_weight)
                                    && !string.IsNullOrWhiteSpace(_price)
                                    && !string.IsNullOrWhiteSpace(_numberOfBags)
                                    && !string.IsNullOrWhiteSpace(_shipmentNumber)
                                    && !string.IsNullOrWhiteSpace(_freightCharges)
                                    && !string.IsNullOrWhiteSpace(_dateOfArrival);

        /// <summary>
        /// Method to deal with status text.
        /// </summary>
        /// <param name="check">bool value to change count number. </param>
        private void StatusEvent(bool check)
        {
            if (check)
            {
                _count = 0;
                OnPropertyChanged(nameof(Status));
            }// end if
            else
            {
                _count = 1;
                OnPropertyChanged(nameof(Status));
            }// end else

            OnPropertyChanged(nameof(ButtonStatus));
        }// end property
    }// end class
}// end namespace
