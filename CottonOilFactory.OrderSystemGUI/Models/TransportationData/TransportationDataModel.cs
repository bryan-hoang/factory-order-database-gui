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
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                }// end else if
                else
                {
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
                    _numberOfBags = value;
                    OnPropertyChanged(nameof(NumberOfBags));
                }// end else if
                else
                {
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
                    _shipmentNumber = value;
                    OnPropertyChanged(nameof(this.ShipmentNumber));
                }// end else if
                else
                {
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
                    OnPropertyChanged(nameof(Result));
                    OnPropertyChanged(nameof(ButtonStatus));
                }// end else if
                else
                {
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
                    OnPropertyChanged(nameof(FreightCharges));
                    OnPropertyChanged(nameof(Result));
                }// end else if
                else
                {
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
    }// end class
}// end namespace
