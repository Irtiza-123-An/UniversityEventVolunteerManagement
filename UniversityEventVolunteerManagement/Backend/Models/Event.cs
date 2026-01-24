using System;

namespace UniversityEventVolunteerManagement.Backend.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public int OrganizerId { get; set; }
        public int RequiredVolunteers { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
