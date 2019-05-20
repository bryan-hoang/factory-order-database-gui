using System.Windows;
using MVVM_Practice.ViewModels;

namespace MVVM_Practice.Views
{
    /// <summary>
    /// Interaction logic for ConfirmationWindowView.xaml
    /// </summary>
    public partial class ConfirmationWindowView : Window
    {
        public ConfirmationWindowView(ProjectViewModel viewmd)
        {
            InitializeComponent();
            this.DataContext = viewmd;
        }
    }
}