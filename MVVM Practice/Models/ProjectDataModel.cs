using System;
using MVVM_Practice.PropertyChanged;

namespace MVVM_Practice.Models
{
    public class ProjectDataModel
    {
        private string decimaltext;

        public bool Status
        {
            get => !(string.IsNullOrEmpty(decimaltext));
        }

        public string NameText { get; set; }

        public string DecimalText
        {
            get
            {
                return this.decimaltext;
            }
            set
            {
                if(!decimal.TryParse(value, out decimal c))
                {
                    this.decimaltext = null;
                }
                else
                {
                    this.decimaltext = value;
                }
                //OnPropertyChanged("Status");
            }
        }

        public DateTime DateText { get; set; }

    }// end class
}// end namespace