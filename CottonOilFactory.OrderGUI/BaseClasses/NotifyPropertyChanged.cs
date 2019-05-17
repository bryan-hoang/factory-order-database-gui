using System.ComponentModel;
using System.Runtime.CompilerServices;
using CottonOilFactory.OrderGUI.Annotations;

namespace CottonOilFactory.OrderGUI.BaseClasses
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
