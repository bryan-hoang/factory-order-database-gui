using System;
using MVVM_Practice.PropertyChanged;

namespace MVVM_Practice.Models
{
    public class ProjectDataModel
    {
        private string decimaltext;

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
            }
        }

        public DateTime DateText { get; set; }

    }// end class
}// end namespace