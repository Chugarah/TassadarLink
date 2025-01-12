# TassadarLink - Contact Management System

## Project Overview
TassadarLink is a console-based contact management system built using C# and .NET Core that meets the requirements for grade G (Pass). The application allows users to manage contacts through a modern console interface.

## Project Requirements (Grade G - Pass)
✅ Console application implementation
✅ Menu option to list all contacts
✅ Menu option to create contacts
✅ JSON file storage implementation
✅ Auto-load contacts from JSON file
✅ Single Responsibility Principle (S in SOLID)
⚠️ Unit tests for core functionality (Partially Complete)

## Implementation Details
The project follows a structured architecture:
- **Domain**: Core business models and contact entity
- **Core**: Business logic and interfaces (implements Single Responsibility)
- **Infrastructure**: JSON file handling and data persistence
- **Nexus**: User interface and menu system
- **Tests**: Unit tests for core functionality

## Key Features
- Contact Management:
  - View all contacts in formatted table
  - Add new contacts with validation
- Data Persistence:
  - Automatic JSON file storage in AppData
  - File loading on application start
- Input Validation:
  - Email format validation
  - Phone number validation
  - Required field validation

## Testing Status
The project includes unit tests without MOQ as per G-level requirements:

**Completed Tests:**
- Core Layer:
  - Contact Factory tests
  - Menu Factory tests
  - ID Generator tests
- Nexus Layer:
  - Basic input validation tests

**Missing Tests:**
- Nexus Layer:
  - Menu navigation tests
  - Contact view tests
  - File handling integration tests

## AI Assistance & Development Notes
This project was developed with inspiration from Hans's codebase. For transparency, AI tools were used in the following components:

**Phind AI Assisted Development:**
- Menu system implementation (Core/Services/MenuService.cs)
- Contact factory pattern (Core/Factories/MenuFactory.cs)
- File service logic (Infrastructure/Services/FileService.cs)
- Input validation patterns (Nexus/Views/AddContacts.cs)
- Some unit test implementations (Core.Tests/Helpers/IdGenerator_Tests.cs)

**Current Limitations:**
- Basic CRUD (only Create and Read implemented)
- Simple error handling
- Limited unit test coverage in Nexus layer
- Basic UI functionality

*README generated by AI Assistant based on codebase analysis*

