using RestaurantManagementSystem.Utilities;
using System.Windows.Input;

namespace RestaurantManagementSystem.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _errorMessage;

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
                // Implement login logic
                Navigate("Main");
            }
        }

        private bool ValidateInputs()
        {
            if (!Validator.ValidateUsername(Username))
            {
                ErrorMessage = "Invalid Username";
                return false;
            }
            if (!Validator.ValidatePassword(Password))
            {
                ErrorMessage = "Invalid Password";
                return false;
            }
            ErrorMessage = string.Empty;
            return true;
        }

        private void Navigate(string viewName)
        {
            // Implement navigation logic
        }
    }
}
