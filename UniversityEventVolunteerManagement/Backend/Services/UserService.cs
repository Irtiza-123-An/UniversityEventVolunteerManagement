using System;
using System.Collections.Generic;
using System.Linq;
using UniversityEventVolunteerManagement.Backend.Data;
using UniversityEventVolunteerManagement.Backend.Models;

namespace UniversityEventVolunteerManagement.Backend.Services
{
    public class UserService
    {
        private readonly JsonDataService<User> _dataService;
        private List<User> _users;

        public UserService()
        {
            _dataService = new JsonDataService<User>("users.json");
            _users = _dataService.LoadData();

            // Initialize with default users if the list is empty
            if (_users.Count == 0)
            {
                InitializeDefaultUsers();
            }
        }

        private void InitializeDefaultUsers()
        {
            _users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "12345",
                    Role = "Admin",
                    Email = "admin@university.com",
                    FullName = "Administrator",
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    Username = "organizer",
                    Password = "1234",
                    Role = "Organizer",
                    Email = "organizer@university.com",
                    FullName = "Event Organizer",
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    Id = 3,
                    Username = "volunteer",
                    Password = "123456",
                    Role = "Volunteer",
                    Email = "volunteer@university.com",
                    FullName = "Volunteer User",
                    CreatedAt = DateTime.Now
                }
            };
            _dataService.SaveData(_users);
        }

        public User Login(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public bool AddUser(User user)
        {
            try
            {
                // Check if username already exists
                if (_users.Any(u => u.Username == user.Username))
                {
                    return false;
                }

                // Generate new ID
                user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
                user.CreatedAt = DateTime.Now;

                _users.Add(user);
                _dataService.SaveData(_users);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser == null)
                {
                    return false;
                }

                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
                existingUser.Email = user.Email;
                existingUser.FullName = user.FullName;

                _dataService.SaveData(_users);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var user = _users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return false;
                }

                _users.Remove(user);
                _dataService.SaveData(_users);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return false;
            }
        }

        public List<User> GetUsersByRole(string role)
        {
            return _users.Where(u => u.Role == role).ToList();
        }
    }
}
