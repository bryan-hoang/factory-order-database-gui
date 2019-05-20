using MVVM_Practice.ViewModels;
using System.Windows;

namespace MVVM_Practice.Views
{
    /// <summary>
    /// Interaction logic for HomeWindowView.xaml
    /// </summary>
    public partial class HomeWindowView : Window
    {
        public HomeWindowView()
        {
            InitializeComponent();
            this.DataContext = new ProjectViewModel();
        }// end constructor
    }// end class
}// end namespace