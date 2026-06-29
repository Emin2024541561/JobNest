# 💼 JobNest – Job Portal Mobile Application

JobNest is a cross-platform mobile application developed as a university team project. The application connects job seekers with employers through a modern and intuitive interface, allowing companies to publish job opportunities while enabling candidates to search, apply, and manage their careers from a single platform.

The project was developed using **.NET MAUI**, allowing deployment on Android, iOS, Windows and macOS from a single shared codebase.

---

# 📖 Project Overview

JobNest was created to simplify the recruitment process by providing two different user experiences:

- 👤 Candidates searching and applying for jobs
- 🏢 Companies creating and managing job advertisements

The application includes authentication, profile management, job recommendations, notifications, dashboards, company profiles, candidate profiles, and application management.

The goal of the project was to demonstrate modern mobile application development using Microsoft's cross-platform technologies while following clean architecture principles and team collaboration practices.

---

# 🚀 Main Features

## Candidate Features

- User registration
- Secure login
- Personal dashboard
- Browse available jobs
- Search jobs using filters
- View detailed job information
- Apply for job positions
- Manage personal profile
- View notifications
- Receive job recommendations

---

## Company Features

- Company registration
- Company dashboard
- Create job advertisements
- Manage published jobs
- Review applications
- Edit company profile
- View candidate information

---

## General Features

- Cross-platform application
- Responsive mobile interface
- Navigation using Shell
- Local database support
- Profile management
- User role separation
- Modern UI
- Splash screen
- Onboarding experience

---

# 🏗 Project Structure

```
JobNest
│
├── Models
│   ├── User
│   ├── JobPost
│   ├── JobApplication
│   ├── CandidateProfile
│   ├── CompanyProfile
│   ├── Category
│   ├── Skill
│   ├── CandidateSkill
│   └── JobRecommendation
│
├── Services
│   ├── DatabaseService
│   └── CurrentUserService
│
├── Resources
│   ├── Images
│   ├── Fonts
│   ├── Splash
│   ├── Styles
│   ├── Raw
│   └── AppIcon
│
├── Platforms
│   ├── Android
│   ├── iOS
│   ├── Windows
│   ├── MacCatalyst
│   └── Tizen
│
├── Pages
│   ├── SplashPage
│   ├── WelcomePage
│   ├── OnboardingPage
│   ├── LoginPage
│   ├── RegisterPage
│   ├── UserTypeSelectionPage
│   ├── CandidateDashboardPage
│   ├── CompanyDashboardPage
│   ├── SearchPage
│   ├── JobCreationPage
│   ├── JobApplicationsPage
│   ├── SimpleJobDetailPage
│   ├── CompanyProfileEditPage
│   ├── SimpleCompanyProfilePage
│   ├── ProfilePage
│   └── NotificationsPage
│
└── JobNest.sln
```

---

# 📂 Project Components

## Pages

### SplashPage

Initial loading screen displayed while the application initializes resources.

### WelcomePage

Introduces users to the application before authentication.

### OnboardingPage

Guides first-time users through the application's main features.

### LoginPage

Allows registered users to securely access the application.

### RegisterPage

Supports creation of new candidate and company accounts.

### UserTypeSelectionPage

Allows users to choose whether they are registering as:

- Candidate
- Company

### CandidateDashboardPage

Main dashboard for job seekers displaying available features.

### CompanyDashboardPage

Employer dashboard for managing recruitment activities.

### SearchPage

Search engine for job listings with filtering capabilities.

### JobCreationPage

Interface used by companies to create new job postings.

### JobApplicationsPage

Displays submitted applications for companies.

### SimpleJobDetailPage

Detailed information about individual job postings.

### CompanyProfileEditPage

Allows companies to update business information.

### SimpleCompanyProfilePage

Displays public company information.

### ProfilePage

User profile management.

### NotificationsPage

Displays user notifications and updates.

---

# 📦 Models

## User

Stores authentication and account information.

## CandidateProfile

Contains candidate personal information.

## CompanyProfile

Contains employer company information.

## JobPost

Represents published job vacancies.

## JobApplication

Stores submitted applications.

## Category

Represents job categories.

## Skill

Stores available professional skills.

## CandidateSkill

Many-to-many relationship between candidates and skills.

## JobRecommendation

Stores personalized job recommendations.

---

# ⚙ Services

## DatabaseService

Responsible for:

- Database initialization
- CRUD operations
- Data retrieval
- Data persistence

---

## CurrentUserService

Responsible for:

- Logged user information
- Session management
- User state throughout the application

---

# 🎨 Resources

## Images

Application images.

## Fonts

Custom fonts used throughout the application.

## Styles

Global styling resources.

## Splash

Splash screen assets.

## Raw

Raw resource files.

## AppIcon

Application icons.

---

# 📱 Supported Platforms

- Android
- iOS
- Windows
- macOS (MacCatalyst)
- Tizen

---

# 🛠 Technologies Used

### Programming Languages

- C#
- XAML

### Frameworks

- .NET MAUI
- .NET

### Database

- SQLite

### Development Environment

- Visual Studio 2022

### UI Technologies

- XAML
- MAUI Shell
- Resource Dictionaries
- Styles
- Data Binding

---

# 💡 Software Engineering Concepts

- Object-Oriented Programming
- MVVM-inspired architecture
- Service Layer
- Modular Design
- Reusable Components
- Cross-platform Development
- Clean Code Principles

---

# 👥 Team Collaboration

This project was developed as a collaborative university project.

Team members worked together throughout the software development lifecycle, including:

- Requirement analysis
- UI/UX design
- Database modeling
- Application architecture
- Feature implementation
- Testing
- Bug fixing
- Documentation

Version control and task distribution enabled efficient collaboration while maintaining code quality and consistency.

---

# 📚 Learning Outcomes

During development, the team gained practical experience with:

- Cross-platform mobile development
- C# programming
- XAML UI design
- SQLite database integration
- User authentication
- Mobile navigation
- CRUD operations
- Mobile application architecture
- Team software development
- Git version control

---

# 🔮 Possible Future Improvements

- Cloud database integration
- REST API backend
- JWT authentication
- Push notifications
- CV upload
- Company verification
- Messaging system
- AI-powered job recommendations
- Dark mode
- Localization
- Admin panel
- Email verification
- Password recovery
- Analytics dashboard

---

# 📄 License

This repository is intended for educational purposes as part of a university software development project.

---

# 🤝 Contributors

This project was developed collaboratively by a student development team as part of a university coursework assignment.

Each contributor participated in different aspects of planning, designing, implementing, testing, and documenting the application.

---

# ⭐ Project Status

✔ Completed

The application successfully demonstrates a fully functional cross-platform mobile job portal built with .NET MAUI, providing separate experiences for candidates and employers while showcasing modern mobile development practices.
