using System;
using System.Collections.Generic;
using System.Linq;
using UniversityEventVolunteerManagement.Backend.Data;
using UniversityEventVolunteerManagement.Backend.Models;

namespace UniversityEventVolunteerManagement.Backend.Services
{
    public class EventService
    {
        private readonly JsonDataService<Event> _dataService;
        private List<Event> _events;

        public EventService()
        {
            _dataService = new JsonDataService<Event>("events.json");
            _events = _dataService.LoadData();
        }

        public List<Event> GetAllEvents()
        {
            return _events;
        }

        public Event GetEventById(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public List<Event> GetEventsByOrganizer(int organizerId)
        {
            return _events.Where(e => e.OrganizerId == organizerId).ToList();
        }

        public List<Event> GetUpcomingEvents()
        {
            return _events.Where(e => e.EventDate >= DateTime.Now && e.Status == "Active").ToList();
        }

        public bool AddEvent(Event eventItem)
        {
            try
            {
                eventItem.Id = _events.Count > 0 ? _events.Max(e => e.Id) + 1 : 1;
                eventItem.CreatedAt = DateTime.Now;
                eventItem.Status = "Active";

                _events.Add(eventItem);
                _dataService.SaveData(_events);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding event: {ex.Message}");
                return false;
            }
        }

        public bool UpdateEvent(Event eventItem)
        {
            try
            {
                var existingEvent = _events.FirstOrDefault(e => e.Id == eventItem.Id);
                if (existingEvent == null)
                {
                    return false;
                }

                existingEvent.Name = eventItem.Name;
                existingEvent.Description = eventItem.Description;
                existingEvent.EventDate = eventItem.EventDate;
                existingEvent.Location = eventItem.Location;
                existingEvent.RequiredVolunteers = eventItem.RequiredVolunteers;
                existingEvent.Status = eventItem.Status;

                _dataService.SaveData(_events);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating event: {ex.Message}");
                return false;
            }
        }

        public bool DeleteEvent(int id)
        {
            try
            {
                var eventItem = _events.FirstOrDefault(e => e.Id == id);
                if (eventItem == null)
                {
                    return false;
                }

                _events.Remove(eventItem);
                _dataService.SaveData(_events);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting event: {ex.Message}");
                return false;
            }
        }

        public bool CancelEvent(int id)
        {
            try
            {
                var eventItem = _events.FirstOrDefault(e => e.Id == id);
                if (eventItem == null)
                {
                    return false;
                }

                eventItem.Status = "Cancelled";
                _dataService.SaveData(_events);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cancelling event: {ex.Message}");
                return false;
            }
        }

        public List<Event> SearchEvents(string searchTerm)
        {
            return _events.Where(e =>
                e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.Location.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }
}
