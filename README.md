# One Kick Heroes Academy - Superhero Management System

## Project Overview

This C# Windows Forms application manages superhero records for the One Kick Heroes Academy. The system tracks trainee heroes, automatically calculates their ranks based on exam scores, and generates comprehensive reports to support the academy's assessment process.

## Features

### Core Functionality
- **Add New Superhero**: Input hero details including ID, name, age, superpower, and exam score
- **View All Superheroes**: Display all records in a DataGridView with calculated ranks and threat levels
- **Update Superhero Information**: Search by ID and modify hero details with automatic rank recalculation
- **Delete Superhero**: Remove heroes from the system with confirmation
- **Generate Summary Report**: Calculate statistics and save to summary.txt

### Ranking System
The application automatically determines hero ranks based on exam scores:

| Rank | Score Range | Threat Level |
|------|-------------|--------------|
| S-Rank | 81-100 | Finals Week (threat to the entire academy) |
| A-Rank | 61-80 | Midterm Madness (threat to a department) |
| B-Rank | 41-60 | Group Project Gone Wrong (threat to a study group) |
| C-Rank | 0-40 | Pop Quiz (potential threat to an individual student) |

## Technical Details

### Technologies Used
- **Language**: C# (.NET 8.0)
- **Framework**: Windows Forms
- **Data Storage**: Text files (superheroes.txt, summary.txt)
- **Version Control**: Git with GitHub integration

### Project Structure
```
Project_PRG282_Final/
├── Project_PRG282/
│   ├── Project_PRG282/
│   │   ├── Form1.cs              # Main form logic
│   │   ├── Form1.Designer.cs     # Form design
│   │   ├── Hero.cs               # Hero class definition
│   │   ├── Program.cs            # Application entry point
│   │   └── Project_PRG282.csproj # Project configuration
│   └── Project_PRG282.sln        # Solution file
├── .gitignore                    # Git ignore rules
└── README.md                     # This file
```

## Setup Instructions

### Prerequisites
- Visual Studio 2022 or later
- .NET 8.0 SDK
- Git (for version control)

### Installation
1. Clone the repository:
   ```bash
   git clone [your-github-repo-url]
   cd Project_PRG282_Final
   ```

2. Open the solution in Visual Studio:
   ```bash
   start Project_PRG282/Project_PRG282.sln
   ```

3. Build and run the application:
   - Press F5 or click "Start Debugging"
   - The application will compile and launch

### Usage
1. **Adding Heroes**: Fill in the form fields and click "Add"
2. **Viewing Heroes**: Click "View All" to display all records
3. **Updating Heroes**: Click on a row in the grid, modify fields, and click "Update"
4. **Deleting Heroes**: Select a row and click "Delete"
5. **Generating Reports**: Click "Generate Summary" to create statistics

## File Formats

### Superheroes.txt
Each line contains comma-separated values:
```
HeroID,Name,Age,Superpower,ExamScore,Rank,ThreatLevel
```

### Summary.txt
Contains formatted statistics report with:
- Total number of superheroes
- Average age and exam score
- Count of heroes per rank
- Generation timestamp

## Version Control

This project uses Git for version control with the following commit structure:
- Initial project setup
- Feature commits for each major functionality (add, update, delete, report)
- Meaningful commit messages describing changes

## Error Handling

The application includes comprehensive error handling for:
- File I/O operations
- Input validation (age, exam score ranges)
- Data parsing and conversion
- User input validation

## Development Team

This project was developed as part of PRG282 coursework for the One Kick Heroes Academy management system.

## License

This project is developed for educational purposes as part of academic coursework.

---

*Built with C# Windows Forms for the One Kick Heroes Academy*
