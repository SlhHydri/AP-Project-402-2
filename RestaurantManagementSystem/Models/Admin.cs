// In the name of Allah

namespace RestaurantManagementSystem.Models
{
    public class Admin : User
    {
        public Admin(string Username, string Password) : base ( (User.admins.Count + 1) * 1000,Username, Password)
        {

        }

        public Admin(int Id, string Username, string Password) : base(Id, Username, Password)
        {

        }
    }
}
