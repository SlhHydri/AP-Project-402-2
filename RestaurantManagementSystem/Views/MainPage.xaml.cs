using System.Windows;
using RestaurantManagementSystem.ViewModels;

namespace RestaurantManagementSystem.Views
{
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
