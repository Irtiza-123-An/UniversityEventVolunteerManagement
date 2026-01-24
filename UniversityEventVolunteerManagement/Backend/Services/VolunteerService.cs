using System;
using System.Collections.Generic;
using System.Linq;
using UniversityEventVolunteerManagement.Backend.Data;
using UniversityEventVolunteerManagement.Backend.Models;

namespace UniversityEventVolunteerManagement.Backend.Services
{
    public class VolunteerService
    {
        private readonly JsonDataService<Volunteer> _dataService;
        private List<Volunteer> _volunteers;

        public VolunteerService()
        {
            _dataService = new JsonDataService<Volunteer>("volunteers.json");
            _volunteers = _dataService.LoadData();
        }

        public List<Volunteer> GetAllVolunteers()
        {
            return _volunteers;
        }

        public Volunteer GetVolunteerById(int id)
        {
            return _volunteers.FirstOrDefault(v => v.Id == id);
        }

        public List<Volunteer> GetVolunteersByEvent(int eventId)
        {
            return _volunteers.Where(v => v.EventId == eventId).ToList();
        }

        public List<Volunteer> GetVolunteersByUser(int userId)
        {
            return _volunteers.Where(v => v.UserId == userId).ToList();
        }

        public bool RegisterVolunteer(Volunteer volunteer)
        {
            try
            {
                // Check if already registered
                if (_volunteers.Any(v => v.UserId == volunteer.UserId && v.EventId == volunteer.EventId))
                {
                    return false;
                }

                volunteer.Id = _volunteers.Count > 0 ? _volunteers.Max(v => v.Id) + 1 : 1;
                volunteer.RegisteredAt = DateTime.Now;
                volunteer.Status = "Registered";

                _volunteers.Add(volunteer);
                _dataService.SaveData(_volunteers);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering volunteer: {ex.Message}");
                return false;
            }
        }

        public bool UpdateVolunteer(Volunteer volunteer)
        {
            try
            {
                var existingVolunteer = _volunteers.FirstOrDefault(v => v.Id == volunteer.Id);
                if (existingVolunteer == null)
                {
                    return false;
                }

                existingVolunteer.Status = volunteer.Status;
                existingVolunteer.Notes = volunteer.Notes;

                _dataService.SaveData(_volunteers);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating volunteer: {ex.Message}");
                return false;
            }
        }

        public bool ApproveVolunteer(int id)
        {
            try
            {
                var volunteer = _volunteers.FirstOrDefault(v => v.Id == id);
                if (volunteer == null)
                {
                    return false;
                }

                volunteer.Status = "Approved";
                _dataService.SaveData(_volunteers);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error approving volunteer: {ex.Message}");
                return false;
            }
        }

        public bool RejectVolunteer(int id)
        {
            try
            {
                var volunteer = _volunteers.FirstOrDefault(v => v.Id == id);
                if (volunteer == null)
                {
                    return false;
                }

                volunteer.Status = "Rejected";
                _dataService.SaveData(_volunteers);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error rejecting volunteer: {ex.Message}");
                return false;
            }
        }

        public bool RemoveVolunteer(int id)
        {
            try
            {
                var volunteer = _volunteers.FirstOrDefault(v => v.Id == id);
                if (volunteer == null)
                {
                    return false;
                }

                _volunteers.Remove(volunteer);
                _dataService.SaveData(_volunteers);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing volunteer: {ex.Message}");
                return false;
            }
        }

        public int GetVolunteerCountForEvent(int eventId, string status = null)
        {
            if (string.IsNullOrEmpty(status))
            {
                return _volunteers.Count(v => v.EventId == eventId);
            }
            return _volunteers.Count(v => v.EventId == eventId && v.Status == status);
        }

        public bool IsUserRegistered(int userId, int eventId)
        {
            return _volunteers.Any(v => v.UserId == userId && v.EventId == eventId);
        }
    }
}
