// In the name of Allah
using RestaurantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace RestaurantManagementSystem.DataBase
{
    public class DataBase
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MousaviWin\Documents\1\RestaurantManagementSystem\RestaurantManagementSystem\DataBase\data.mdf;Integrated Security=True;Connect Timeout=30";

        int Connection(string command, int Id, params string[] values)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", Id);

                    for (int i = 0; i < values.Length; i += 2)
                    {
                        sqlCommand.Parameters.AddWithValue(values[i], values[i + 1]);
                    }

                    rowsAffected = sqlCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
            return rowsAffected;
        }

        public bool InsertAdmin(Admin admin)
        {
            string command = @"INSERT INTO Admins (Id , Username, Password) VALUES (@Id, @Username, @Password)";
            int rowsAffected = Connection(command, admin.Id, "@Username", admin.Username, "@Password", admin.Password);
            if (rowsAffected == 1)
            {
                return true;
            }
            else
            { 
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            string command = @"DELETE FROM Admins WHERE Id = @Id";
            int rowsAffected = Connection(command, user.Id);
            if (rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAdmin(Admin admin)
        {
            string command = @"UPDATE Admins SET Username = @Username, Password = @Password WHERE Id = @Id";
            int rowsAffected = Connection(command, admin.Id, "@Username", admin.Username, "@Password", admin.Password);
            if (rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Admin> SelectAdmin()
        {
            string command = @"SELECT * from Admins";
            List<Admin> admins = new List<Admin>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Username = reader.GetString(1);
                            string Password = reader.GetString(2);

                            admins.Add(new Admin(Id, Username, Password));
                        }
                    }
                }
            }
            return admins;
        }

        public bool InsertCustomer(Customer customer)
        {
            string command = @"INSERT INTO Customer (Id , Username, Password, FullName, PhoneNumber, Email, Gender, HomeAddress, Type)" +
                        @"VALUES (@Id, @Username, @Password, @FullName, @PhoneNumber, @Email, @Gender, @HomeAddress, @Type)";
            int rowsAffected = Connection(command, customer.Id, "@Username", customer.Username, "@Password", customer.Password,
                "@FullName", customer.FullName, "@PhoneNumber", customer.PhoneNumber, "@Email", customer.Email, "@Gender",
                customer.Gender == null ? "N" : ((int)customer.Gender).ToString(), "@HomeAddress",
                customer.HomeAddress == null ? "null" : customer.HomeAddress, "@Type", ((int)customer.Type).ToString());
            if (rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            string command = @"UPDATE Customer SET Username = @Username, Password = @Password, FullName = @FullName," +
                @"PhoneNumber = @PhoneNumber, Email = @Email, Gender = @Gender, HomeAddress = @HomeAddress, Type = @Type WHERE Id = @Id";
            int rowsAffected = Connection(command, customer.Id, "@Username", customer.Username, "@Password", customer.Password,
                "@FullName", customer.FullName, "@PhoneNumber", customer.PhoneNumber, "@Email", customer.Email, "@Gender",
                customer.Gender == null ? "N" : ((int)customer.Gender).ToString(), "@HomeAddress",
                customer.HomeAddress == null ? "null" : customer.HomeAddress, "@Type", ((int)customer.Type).ToString());
            if (rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Customer> SelectCustomer()
        {
            string command = @"SELECT * from Customer";
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Username = reader.GetString(1).Trim();
                            string Password = reader.GetString(2).Trim();
                            string FullName = reader.GetString(3).Trim();
                            string PhoneNumber = reader.GetString(4).Trim();
                            string Email = reader.GetString(5).Trim();
                            int gender;
                            Customer.EGender? Gender;
                            if (int.TryParse(reader.GetString(6), out gender))
                            {
                                Gender = (Customer.EGender)gender;
                            }
                            else
                            {
                                Gender = null;
                            }
                            string HomeAddress = reader.GetString(7) == "null" ? null : reader.GetString(7);
                            Customer.EType Type = (Customer.EType)int.Parse(reader.GetString(8));

                            customers.Add(new Customer(Id, Username, Password, FullName, PhoneNumber, Email, Gender, HomeAddress, Type));
                        }
                    }
                }
            }
            return customers;
        }

        public bool InsertRestaurantManager(RestaurantManager resManager)
        {
            string command = @"INSERT INTO Admins (Id , Username, Password, NameOfRestaurant, Address, City, Type, Score)" +
                            @"VALUES (@Id, @Username, @Password, @NameOfRestaurant, @Address, @City, @Type, @Score)";
            int rowsAffected = Connection(command, resManager.Id, "@Username", resManager.Username, "@Password", resManager.Password,
                "@NameOfRestaurant", resManager.NameOfRestaurant, "@Address", resManager.Address, "@City", resManager.City,
                "@Type", resManager.Type.ToString(), "@Score", resManager.Score.ToString());
            if (rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateRestaurantManager(RestaurantManager resManager)
        {
            string command = @"UPDATE RestaurantManagers SET Username = @Username, Password = @Password, NameOfRestaurant = @NameOfRestaurant," +
                @"Address = @Address, City = @City, Type = @Type, Score = @Score WHERE Id = @Id";
            int rowsAffected = Connection(command, resManager.Id, "@Username", resManager.Username, "@Password", resManager.Password,
                "@NameOfRestaurant", resManager.NameOfRestaurant, "@Address", resManager.Address, "@City", resManager.City, "@Type",
                resManager.Type.ToString(), "@Score", resManager.Score.ToString());
            if (rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<RestaurantManager> SelectRestaurantManager()
        {
            string command = @"SELECT * from RestaurantManagers";
            List<RestaurantManager> restaurantManagers = new List<RestaurantManager>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Username = reader.GetString(1).Trim();
                            string Password = reader.GetString(2).Trim();
                            string NameOfRestaurant = reader.GetString(3).Trim();
                            string Address = reader.GetString(4).Trim();
                            string City = reader.GetString(5).Trim();
                            RestaurantManager.EType Type = reader.GetString(6).Trim() == "Delivery" ? RestaurantManager.EType.Delivery : RestaurantManager.EType.Dine_in;
                            int Score = int.Parse(reader.GetString(7));
                            restaurantManagers.Add(new RestaurantManager(Id, Username, Password, NameOfRestaurant, Address, City, Type, Score));
                        }
                    }
                }
            }
            return restaurantManagers;
        }

    }
}

