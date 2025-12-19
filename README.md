# ASP.NET Core MVC Authorization Project

This project is a web application developed using ASP.NET Core MVC.
Authentication and role-based authorization mechanisms are implemented.

Users who do not have permission to access certain pages are redirected
to an Access Denied (403) page.

---

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server
- Cookie Authentication
- Bootstrap
- C#

---

## Authentication & Authorization

- Unauthenticated users are redirected to the Login page.
- Authenticated users without permission are redirected to the Access Denied page.
- Users with the Admin role can access authorized pages.

---

## Access Denied Page

The Access Denied page is shown to users who are logged in but do not have
permission to access the requested page.

It provides:
- A clear authorization warning
- Navigation back to the home page
- Option to return to the previous page

---

## Project Structure

Controllers
- AccountController
- AdminController

Models
- Entities
- ViewModels

Views
- Account
  - Login
  - AccessDenied
- Admin
- Shared

wwwroot
- css
- js

Program.cs  
appsettings.json

---

## Setup & Run

1. Clone or download the project.
2. Open the `.sln` file with Visual Studio.
3. Check the database connection in `appsettings.json`.
4. Create the database.
5. Run the project using F5.

---

## Developer

Emre Kaya  
Computer Programming Student  
ASP.NET Core MVC
