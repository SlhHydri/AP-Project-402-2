using RestaurantManagementSystem.Utilities;
using System.Windows.Input;

namespace RestaurantManagementSystem.ViewModels
{
    public class SetPasswordViewModel : BaseViewModel
    {
        private string _newPassword;
        private string _repeatPassword;
        private string _errorMessage;

        public string NewPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }

        public string RepeatPassword
        {
            get => _repeatPassword;
            set
            {
                _repeatPassword = value;
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

        public ICommand SetPasswordCommand => new RelayCommand(SetPassword);

        private void SetPassword()
        {
            if (ValidateInputs())
            {
                // Implement set password logic
                Navigate("Login");
            }
        }

        private bool ValidateInputs()
        {
            if (!Validator.ValidatePassword(NewPassword))
            {
                ErrorMessage = "Password must be at least 6 characters long";
                return false;
            }
            if (NewPassword != RepeatPassword)
            {
                ErrorMessage = "Passwords do not match";
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
