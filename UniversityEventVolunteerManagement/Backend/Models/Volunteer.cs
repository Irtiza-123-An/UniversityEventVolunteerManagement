using System;

namespace UniversityEventVolunteerManagement.Backend.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string Status { get; set; }
        public DateTime RegisteredAt { get; set; }
        public string Notes { get; set; }
    }
}
