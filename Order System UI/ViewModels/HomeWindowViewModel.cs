using Order_System_UI.ViewModels.Commands;

namespace Order_System_UI.ViewModels
{
    /// <summary>
    /// Class for implementing MVVM for the homescreen.
    /// </summary>
    public class HomeWindowViewModel
    {
        /// <summary>
        /// Constructor to instantiate the properties for data binding.
        /// </summary>
        public HomeWindowViewModel()
        {
            this.GoToTransportationInputWindow = new GoToTransportationInputWindow();
            this.GoToTransportationSearchWindow = new GoToTransportationSearchWindow();
        }// end constructor

        /// <summary>
        /// Property for the input tranposrtation button.
        /// </summary>
        public GoToTransportationInputWindow GoToTransportationInputWindow { get; set; }
        
        /// <summary>
        /// Property for the transportation search button.
        /// </summary>
        public GoToTransportationSearchWindow GoToTransportationSearchWindow { get; set; }

    }// end class
}// end namespace