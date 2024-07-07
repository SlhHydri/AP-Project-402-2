using System.Windows.Input;

namespace RestaurantManagementSystem.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;

        public MainViewModel()
        {
            CurrentViewModel = new LoginViewModel(this);
        }

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateCommand => new RelayCommand<string>(Navigate);

        public void Navigate(string viewName)
        {
            switch (viewName)
            {
                case "Login":
                    CurrentViewModel = new LoginViewModel(this);
                    break;
                case "SignUp":
                    CurrentViewModel = new SignUpViewModel();
                    break;
                case "Validation":
                    CurrentViewModel = new ValidationViewModel();
                    break;
                case "SetPassword":
                    CurrentViewModel = new SetPasswordViewModel();
                    break;
                case "Main":
                    CurrentViewModel = new MainViewModel();
                    break;
                case "Profile":
                    CurrentViewModel = new ProfileViewModel();
                    break;
                default:
                    break;
            }
        }
    }
}
