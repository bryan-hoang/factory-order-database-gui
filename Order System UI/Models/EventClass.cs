using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_System_UI.Models
{
    /// <summary>
    /// Base class which implements the INotifyPropertChanged interface.
    /// </summary>
    public class EventClass : INotifyPropertyChanged
    {
        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Implemented event handler for data binding in XAML files.
        /// </summary>
        /// <param name="property">Property that will be launched by the event handler.</param>
        protected void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

    }// end class
}// end namespace
