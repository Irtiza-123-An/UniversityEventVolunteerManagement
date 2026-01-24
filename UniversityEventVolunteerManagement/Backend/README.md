# Backend Documentation

## Overview

This backend folder contains all the backend functionality for the University Event Volunteer Management system with JSON file-based data persistence.

## Structure

```
Backend/
├── Models/           # Data models
│   ├── User.cs      # User model with authentication and profile info
│   ├── Event.cs     # Event model for managing university events
│   └── Volunteer.cs # Volunteer registration model
├── Services/        # Business logic and data operations
│   ├── UserService.cs       # User management operations
│   ├── EventService.cs      # Event management operations
│   └── VolunteerService.cs  # Volunteer registration operations
└── Data/            # Data persistence layer
    └── JsonDataService.cs   # Generic JSON file storage service
```

## Data Storage

All data is stored in JSON files located in the `Data/` folder at the application's base directory:

- **users.json** - Stores user accounts (admins, organizers, volunteers)
- **events.json** - Stores event information
- **volunteers.json** - Stores volunteer registration records

## Models

### User

Properties:

- `Id` - Unique identifier
- `Username` - Login username
- `Password` - User password
- `Role` - User role (Admin, Organizer, Volunteer)
- `Email` - User email address
- `FullName` - User's full name
- `CreatedAt` - Account creation date

### Event

Properties:

- `Id` - Unique identifier
- `Name` - Event name
- `Description` - Event description
- `EventDate` - Date and time of the event
- `Location` - Event location
- `OrganizerId` - ID of the user who created the event
- `RequiredVolunteers` - Number of volunteers needed
- `Status` - Event status (Active, Cancelled, Completed)
- `CreatedAt` - Event creation date

### Volunteer

Properties:

- `Id` - Unique identifier
- `UserId` - ID of the volunteer user
- `EventId` - ID of the event
- `Status` - Registration status (Registered, Approved, Rejected)
- `RegisteredAt` - Registration date
- `Notes` - Additional notes

## Services

### UserService

Methods:

- `Login(username, password)` - Authenticate user
- `GetAllUsers()` - Get all users
- `GetUserById(id)` - Get user by ID
- `GetUserByUsername(username)` - Get user by username
- `AddUser(user)` - Create new user
- `UpdateUser(user)` - Update existing user
- `DeleteUser(id)` - Delete user
- `GetUsersByRole(role)` - Get users by role

### EventService

Methods:

- `GetAllEvents()` - Get all events
- `GetEventById(id)` - Get event by ID
- `GetEventsByOrganizer(organizerId)` - Get events by organizer
- `GetUpcomingEvents()` - Get upcoming active events
- `AddEvent(event)` - Create new event
- `UpdateEvent(event)` - Update existing event
- `DeleteEvent(id)` - Delete event
- `CancelEvent(id)` - Cancel event
- `SearchEvents(searchTerm)` - Search events

### VolunteerService

Methods:

- `GetAllVolunteers()` - Get all volunteer registrations
- `GetVolunteerById(id)` - Get volunteer registration by ID
- `GetVolunteersByEvent(eventId)` - Get volunteers for an event
- `GetVolunteersByUser(userId)` - Get events a user volunteered for
- `RegisterVolunteer(volunteer)` - Register a volunteer
- `UpdateVolunteer(volunteer)` - Update volunteer registration
- `ApproveVolunteer(id)` - Approve volunteer registration
- `RejectVolunteer(id)` - Reject volunteer registration
- `RemoveVolunteer(id)` - Remove volunteer registration
- `GetVolunteerCountForEvent(eventId, status)` - Count volunteers for event
- `IsUserRegistered(userId, eventId)` - Check if user is registered

## Usage Example

```csharp
using UniversityEventVolunteerManagement.Backend.Services;
using UniversityEventVolunteerManagement.Backend.Models;

// Initialize services
var userService = new UserService();
var eventService = new EventService();
var volunteerService = new VolunteerService();

// Login a user
var user = userService.Login("admin", "12345");

// Create a new event
var newEvent = new Event
{
    Name = "Tech Workshop",
    Description = "Learn about new technologies",
    EventDate = DateTime.Now.AddDays(7),
    Location = "Computer Lab",
    OrganizerId = user.Id,
    RequiredVolunteers = 10
};
eventService.AddEvent(newEvent);

// Register a volunteer
var volunteer = new Volunteer
{
    UserId = user.Id,
    EventId = newEvent.Id
};
volunteerService.RegisterVolunteer(volunteer);
```

## Default Users

The system initializes with three default users:

1. **Admin**
    - Username: `admin`
    - Password: `12345`
    - Role: Admin

2. **Organizer**
    - Username: `organizer`
    - Password: `1234`
    - Role: Organizer

3. **Volunteer**
    - Username: `volunteer`
    - Password: `123456`
    - Role: Volunteer

## Data Persistence

The `JsonDataService<T>` class provides generic JSON file storage with:

- Automatic directory creation
- File initialization
- Error handling
- Pretty-printed JSON format
- Synchronous and asynchronous save operations

Data is automatically saved whenever changes are made through the service methods.
