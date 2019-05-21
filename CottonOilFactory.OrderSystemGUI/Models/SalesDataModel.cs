using System;

namespace CottonOilFactory.OrderSystemGUI.Models
{
    /// <inheritdoc />
    public class SalesDataModel : ModelBase
    {
        private string buyerName;
        private decimal pricePerBag;
        private int numberOfBags;

        /// <summary>
        /// Gets the name of the product to sell.
        /// </summary>
        public static string ProductName { get; } = "Khan";

        public string BuyerName
        {
            get => buyerName;
            set
            {
                buyerName = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
                OnPropertyChanged(nameof(IsValidData));
            }
        }

        public BagWeight? WeightPerBag { get; set; }

        public string PricePerBag
        {
            get => pricePerBag == 0 ? string.Empty : pricePerBag.ToString();
            set
            {
                pricePerBag = !decimal.TryParse(value, out decimal price) || price < 0 ? 0 : price;
                OnPropertyChanged(nameof(TotalCost));
                OnPropertyChanged(nameof(IsValidData));
            }
        }

        public string NumberOfBags
        {
            get => numberOfBags == 0 ? string.Empty : numberOfBags.ToString();
            set
            {
                numberOfBags = !int.TryParse(value, out int numBags) || numBags < 0 ? 0 : numBags;
                OnPropertyChanged(nameof(TotalCost));
                OnPropertyChanged(nameof(IsValidData));
            }
        }

        public string TotalCost => (pricePerBag * numberOfBags).ToString();

        public MethodOfPayment? PaymentMethod { get; set; }

        public DateTime? DateOfSale { get; set; }

        public bool IsValidData => buyerName != string.Empty
                                   && WeightPerBag != null
                                   && pricePerBag != 0
                                   && numberOfBags != 0
                                   && PaymentMethod != null
                                   && DateOfSale != null;
    }
}
