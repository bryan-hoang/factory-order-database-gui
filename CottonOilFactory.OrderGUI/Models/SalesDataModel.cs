using System.ComponentModel;

namespace CottonOilFactory.OrderGUI.Models
{
    public class SalesDataModel : INotifyPropertyChanged
    {

        public const string ProductName = "Product Name (Placeholder)";

        private decimal pricePerBag;
        private int numberOfBags;
        private decimal totalCost;

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        public string Buyer { get; set; }

        public string PricePerBag
        {
            get => pricePerBag.ToString();

            set
            {
                if (decimal.TryParse(value, out decimal price) && price >= 0)
                {
                    pricePerBag = price;
                }
            }
        }

        public string NumberOfBags
        {
            get => numberOfBags.ToString();
            set
            {
                if (int.TryParse(value, out int numBags) && numBags >= 0)
                {
                    numberOfBags = numBags;
                }
            }
        }

        public string TotalCost
        {
            get => totalCost.ToString();
            set => totalCost = pricePerBag * numberOfBags;
        }

        protected void OnPropertyChange(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

    }
}
