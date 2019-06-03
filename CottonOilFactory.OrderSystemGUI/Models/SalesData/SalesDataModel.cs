using System;

namespace CottonOilFactory.OrderSystemGUI.Models.SalesData
{
    /// <inheritdoc />
    public class SalesDataModel : ModelBase
    {
        private string _buyerName;
        private decimal _pricePerBag;
        private int _numberOfBags;

        /// <summary>
        /// Gets the name of the product to sell.
        /// </summary>
        public static string ProductName { get; } = "Khan";

        public string BuyerName
        {
            get => _buyerName;
            set
            {
                _buyerName = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
                OnPropertyChanged(nameof(IsValidData));
            }
        }

        public BagWeight? WeightPerBag { get; set; }

        public string PricePerBag
        {
            get => _pricePerBag == 0 ? string.Empty : _pricePerBag.ToString();
            set
            {
                _pricePerBag = !decimal.TryParse(value, out decimal price) || price < 0 ? 0 : price;
                OnPropertyChanged(nameof(TotalCost));
                OnPropertyChanged(nameof(IsValidData));
            }
        }

        public string NumberOfBags
        {
            get => _numberOfBags == 0 ? string.Empty : _numberOfBags.ToString();
            set
            {
                _numberOfBags = !int.TryParse(value, out int numBags) || numBags < 0 ? 0 : numBags;
                OnPropertyChanged(nameof(TotalCost));
                OnPropertyChanged(nameof(IsValidData));
            }
        }

        public string TotalCost => (_pricePerBag * _numberOfBags).ToString();

        public MethodOfPayment? PaymentMethod { get; set; }

        public DateTime? DateOfSale { get; set; }

        public bool IsValidData => _buyerName != string.Empty
                                   && WeightPerBag != null
                                   && _pricePerBag != 0
                                   && _numberOfBags != 0
                                   && PaymentMethod != null
                                   && DateOfSale != null;
    }
}
