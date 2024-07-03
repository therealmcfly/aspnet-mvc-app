# ASP.NET MVC App

Welcome to the `aspnet-mvc-app`! This project is a web application built using ASP.NET MVC and ASP.NET Identity. It serves as a starting point application with basic login functionality for building robust and scalable web applications.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

These instructions will help you set up and run the project on your local machine for development and testing purposes.

### Prerequisites

Before you begin, ensure you have met the following requirements:

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or later with the ASP.NET and web development workload installed.
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or later.
- A code editor such as [Visual Studio Code](https://code.visualstudio.com/) (optional).
- [PostgreSQL](https://www.postgresql.org/download/) installed and running on your local machine or accessible via a network.

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/therealmcfly/aspnet-mvc-app.git
   cd aspnet-mvc-app
   ```

2. Restore the NuGet packages:

   ```bash
   dotnet restore
   ```

3. Open the project in your code editor and navigate to the `.csproj` file.

4. Remove the `UserSecretsId` in the `<PropertyGroup>` section of the `.csproj` file.

5. Initialize user secrets:

   ```bash
   dotnet user-secrets init
   ```

6. Add the PostgreSQL connection string to the user secrets:

   ```bash
   dotnet user-secrets set "ConnectionStrings:DatabaseConnection" "Host={host here};Port={port here};Username={database username here};Password={database password here};Database={database name here}"
   ```

7. Update the database:
   ```bash
   dotnet ef database update
   ```

## Running the Application

To run the application, follow these steps:

1. Open the solution file (`aspnet-mvc-app.sln`) in Visual Studio.

2. Set the `aspnet-mvc-app` project as the startup project.

3. Build the solution:

   ```bash
   dotnet build
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

5. Open your browser and navigate to `https://localhost:5163` (or the port specified in your launch settings).

## Project Structure

Here is an overview of the project structure:

```
aspnet-mvc-app/
├── Controllers/       # Controllers for handling HTTP requests
├── Data/              # Data access layer (contains ApplicationDbContext.cs)
├── Dtos/              # Data Transfer Objects
├── Migrations/        # Entity Framework migrations
├── Models/            # Data models
├── ViewModels/        # View Models for passing data to views
├── Views/             # Razor views for rendering UI
├── wwwroot/           # Static files (CSS, JS, images)
├── appsettings.json   # Configuration settings
├── Program.cs         # Entry point of the application
├── Startup.cs         # Configuration for the application's services and middleware
└── aspnet-mvc-app.sln # Solution file
```

<!--
## Contributing

We welcome contributions! Please read the [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct and the process for submitting pull requests. -->

<!-- ## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details. -->
