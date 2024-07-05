using RestaurantManagementSystem.Utilities;
using System.Windows.Input;

namespace RestaurantManagementSystem.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        private string _fullName;
        private string _phoneNumber;
        private string _username;
        private string _email;
        private string _errorMessage;

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
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

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
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

        public ICommand SignUpCommand => new RelayCommand(SignUp);

        private void SignUp()
        {
            if (ValidateInputs())
            {
                // Implement sign-up logic
                Navigate("Validation");
            }
        }

        private bool ValidateInputs()
        {
            if (!Validator.ValidateFullName(FullName))
            {
                ErrorMessage = "Invalid Full Name";
                return false;
            }
            if (!Validator.ValidatePhoneNumber(PhoneNumber))
            {
                ErrorMessage = "Invalid Phone Number";
                return false;
            }
            if (!Validator.ValidateUsername(Username))
            {
                ErrorMessage = "Invalid Username";
                return false;
            }
            if (!Validator.ValidateEmail(Email))
            {
                ErrorMessage = "Invalid Email";
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
