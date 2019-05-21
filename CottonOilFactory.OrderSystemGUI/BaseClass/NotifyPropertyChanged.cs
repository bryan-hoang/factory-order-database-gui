using System.ComponentModel;
using System.Runtime.CompilerServices;
using CottonOilFactory.OrderSystemGUI.Properties;

namespace CottonOilFactory.OrderSystemGUI.BaseClass
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
