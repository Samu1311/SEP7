# Gjensidige Personalized Insurance WebApp

This project is a **Blazor Server WebApp** designed to provide tailored insurance packages using advanced AI analysis. The application emulates the design and functionality of the Gjensidige website to align with their portfolio and standards.

## 📋 Project Overview
The WebApp allows users to:
- Log in or register with secure JWT-based authentication.
- Input medical records or answer surveys to provide health-related data.
- Receive personalized insurance packages based on their health profile through an AI-powered analysis.

## 🚀 Features
- **User Authentication**: Secure login and registration using JWT.
- **AI-Driven Analysis**: Medical data is analyzed to offer customized insurance plans (AI model integration planned in the future).
- **Modern Design**: Inspired by Gjensidige's clean, professional layout.
- **Database Management**: Powered by **EF Core** and **SQLite** for efficient data handling.
- **Responsive Interface**: Optimized for desktop and mobile views.

## 🔧 Technologies Used
- **Frontend**: Blazor Server with **Blazorise** and **Bootstrap 5** for responsive design.
- **Backend**: ASP.NET Core Web API.
- **Database**: Entity Framework Core with SQLite.
- **Authentication**: JSON Web Tokens (JWT).
- **Future Integration**: AI analysis using Python (to be developed and integrated).

## 📂 Project Structure
- `/Pages`: Contains Razor components for the UI.
- `/Shared`: Shared components like NavMenu and Footer.
- `/Data`: Database models and EF Core configurations.
- `/wwwroot`: Static assets (CSS, images, etc.).
- `/API`: Backend services for handling requests and JWT authentication.

## 💻 How to Run the Project
1. Clone this repository:
   ```bash
   git clone https://github.com/Samu1311/SEP7.git
