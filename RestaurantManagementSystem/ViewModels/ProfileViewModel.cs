using RestaurantManagementSystem.Utilities;
using System.Windows.Input;

namespace RestaurantManagementSystem.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private string _fullName;
        private string _email;
        private string _gender;
        private string _homeAddress;
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

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        public string HomeAddress
        {
            get => _homeAddress;
            set
            {
                _homeAddress = value;
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

        public ICommand SaveProfileCommand => new RelayCommand(SaveProfile);

        private void SaveProfile()
        {
            if (ValidateInputs())
            {
                // Implement save profile logic
            }
        }

        private bool ValidateInputs()
        {
            if (!Validator.ValidateFullName(FullName))
            {
                ErrorMessage = "Invalid Full Name";
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
    }
}
