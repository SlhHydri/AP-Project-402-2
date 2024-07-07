// In the name of Allah

using RestaurantManagementSystem.Utilities;
using RestaurantManagementSystem.Views;
using RestaurantManagementSystem.Models;
using System.Windows.Input;
using System.Linq;

namespace RestaurantManagementSystem.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private readonly MainViewModel _mainViewModel;

        public LoginViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand => new RelayCommand(Login);
        public ICommand SignUpCommand => new RelayCommand(() => Navigate("SignUp"));

        private void Login()
        {
            if (ValidateInputs())
            {
                if (UserExistence())
                {
                    Navigate("Main");
                }
                else
                {
                    ErrorMessage = "Invalid Username or Password";
                }
            }
        }

        private bool ValidateInputs()
        {
            if (Username == null || !Validator.ValidateUsername(Username))
            {
                ErrorMessage = "Invalid Username";
                return false;
            }
            if (Password == null || !Validator.ValidatePassword(Password))
            {
                ErrorMessage = "Invalid Password";
                return false;
            }
            ErrorMessage = string.Empty;
            return true;
        }

        bool UserExistence()
        {
            User user = User.admins.FirstOrDefault(x => x.Username.Equals(Username) && x.Password.Equals(Password));
            User user1 = User.customers.FirstOrDefault(x => x.Username.Equals(Username) && x.Password.Equals(Password));
            User user2 = User.restaurantManagers.FirstOrDefault(x => x.Username.Equals(Username) && x.Password.Equals(Password));

            return user != null || user1 != null || user2 != null;
        }

        private void Navigate(string viewName)
        {
            _mainViewModel.Navigate(viewName);
        }
    }
}
