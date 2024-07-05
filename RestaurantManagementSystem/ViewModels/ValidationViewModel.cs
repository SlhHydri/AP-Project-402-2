using System.Windows.Input;

namespace RestaurantManagementSystem.ViewModels
{
    public class ValidationViewModel : BaseViewModel
    {
        private string _validationCode;
        private string _errorMessage;

        public string ValidationCode
        {
            get => _validationCode;
            set
            {
                _validationCode = value;
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

        public ICommand ValidateCommand => new RelayCommand(Validate);

        private void Validate()
        {
            if (ValidateInputs())
            {
                // Implement validation logic
                Navigate("SetPassword");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(ValidationCode))
            {
                ErrorMessage = "Validation code cannot be empty";
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
