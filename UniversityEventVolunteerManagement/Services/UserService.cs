using System.Collections.Generic;
using UniversityEventVolunteerManagement.Models;

namespace UniversityEventVolunteerManagement.Services
{
    public class UserService
    {
        private List<User> users = new List<User>()
        {
            new User { Username = "admin", Password = "12345", Role = "Admin" },
            new User { Username = "organizer", Password = "1234", Role = "Organizer" },
            new User { Username = "volunteer", Password = "123456", Role = "Volunteer" }
        };

        public User Login(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
