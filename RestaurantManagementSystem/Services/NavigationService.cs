using RestaurantManagementSystem.Views;
using System.Windows;

namespace RestaurantManagementSystem.Services
{
    public class NavigationService
    {
        public void NavigateTo(Window window)
        {
            window.Show();
        }

        public void NavigateToLogin()
        {
            var loginPage = new LoginPage();
            loginPage.Show();
        }

        public void NavigateToSignUp()
        {
            var signUpPage = new SignUpPage();
            signUpPage.Show();
        }

        public void NavigateToValidationCode()
        {
            var validationCodePage = new ValidationPage();
            validationCodePage.Show();
        }

        public void NavigateToSetPassword()
        {
            var setPasswordPage = new SetPasswordPage();
            setPasswordPage.Show();
        }
    }
}
