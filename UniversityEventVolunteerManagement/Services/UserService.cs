using System.Collections.Generic;
using UniversityEventVolunteerManagement.Models;
using UniversityEventVolunteerManagement.Backend.Services;
using BackendUserService = UniversityEventVolunteerManagement.Backend.Services.UserService;

namespace UniversityEventVolunteerManagement.Services
{
    public class UserService
    {
        private BackendUserService _backendUserService;

        public UserService()
        {
            _backendUserService = new BackendUserService();
        }

        public User Login(string username, string password)
        {
            var backendUser = _backendUserService.Login(username, password);
            if (backendUser == null)
            {
                return null;
            }

            // Map backend user to old model format for compatibility
            return new User
            {
                Username = backendUser.Username,
                Password = backendUser.Password,
                Role = backendUser.Role
            };
        }
    }
}
