// In the name of Allah

using System.Linq;

namespace RestaurantManagementSystem.Models
{
    public class Customer : User
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public enum EGender { Man, Woman }
        public EGender? Gender { get; set; }
        public string HomeAddress { get; set; }

        public enum EType { Normal, Bronze, Silver, Gold}
        public EType Type { get; set; }

        public Customer(string Username, string Password, string fullName, string phoneNumber, string email, EGender? gender = null, string homeAddress = null) : base((User.customers.Count() + 1) * 1000, Username, Password)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
            HomeAddress = homeAddress;
            Type = EType.Normal;
        }

        public Customer(int Id, string Username, string Password, string fullName, string phoneNumber, string email, EGender? gender, string homeAddress, EType type) : base(Id, Username, Password)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
            HomeAddress = homeAddress;
            Type = type;
        }
    }
}
