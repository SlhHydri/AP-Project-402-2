using System.Collections.Generic;

namespace RestaurantManagementSystem.Models
{
    public class User
    {
        public static List<Customer> customers { get; set; }
        public static List<RestaurantManager> restaurantManagers { get; set; }
        public static List<Admin> admins {  get; set; } 
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        static User()
        {
            customers = new List<Customer>();
            restaurantManagers = new List<RestaurantManager>();
            admins = new List<Admin>();
        }
    }
}
