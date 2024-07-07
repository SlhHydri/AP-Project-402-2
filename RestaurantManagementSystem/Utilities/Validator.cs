using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Utilities
{
    public static class Validator
    {
        public static bool ValidateFullName(string name)
        {
            string pattern = @"^[a-zA-Z]{3,32}$";
            return Regex.IsMatch(name, pattern);
        }

        public static bool ValidateEmail(string email)
        {
            string pattern = @"^(?={3,32}[a-zA-Z])([a-zA-Z0-9._-]{3,32})@(?={3,32}[a-zA-Z])([a-zA-Z0-9.-]{3,32})\.[a-zA-Z]{2,3}$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool ValidatePhoneNumber(string phone)
        {
            string pattern = @"^09[0-9]{9}$";
            return Regex.IsMatch(phone, pattern);
        }

        public static bool ValidatePassword(string pass)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]{8,32}$";
            return Regex.IsMatch(pass, pattern);
        }

        public static bool ValidateUsername(string username)
        {
            string pattern = @"^(?=(.*[a-zA-Z]){3})[a-zA-Z0-9]{3,}$";
            return Regex.IsMatch(username, pattern);
        }
    }
    
}