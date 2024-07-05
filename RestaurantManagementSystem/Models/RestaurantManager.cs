// In the name oa Allah

using System.Linq;

namespace RestaurantManagementSystem.Models
{
    public class RestaurantManager : User
    {
        public string NameOfRestaurant { get; set; }
        public string Address { get; set; }
        public string City {  get; set; }
        public enum EType { Delivery, Dine_in }
        public EType Type { get; set; }
        public double Score { get; set; }
        
        public RestaurantManager(string Username, string Password, string nameOfRestaurant, string address, string city, EType type, double score) : base((User.restaurantManagers.Count() + 1) * 1000, Username, Password)
        {
            NameOfRestaurant = nameOfRestaurant;
            Address = address;
            City = city;
            Type = type;
            Score = score;
        }

        public RestaurantManager(int Id, string Username, string Password, string nameOfRestaurant, string address, string city, EType type, double score) : base(Id, Username, Password)
        {
            NameOfRestaurant = nameOfRestaurant;
            Address = address;
            City = city;
            Type = type;
            Score = score;
        }


    }
}
