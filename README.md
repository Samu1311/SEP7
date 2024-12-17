# 🚀 Gjensidige Personalized Insurance WebApp

This project is a **Blazor Server Web Application** 🖥️ designed to provide tailored insurance packages using advanced **AI analysis** 🤖. The application emulates the design and functionality of the Gjensidige website to align with their professional standards.

---

## 📝 Project Overview

The WebApp allows users to:

- 🔐 **Log in or Register**: Secure authentication using JWT.
- 📋 **Input Medical Records**: Answer surveys to provide health-related data.
- 📊 **Receive Personalized Insurance Packages**: Based on their health profile through AI-powered analysis.

---

## ✨ Features

- 🔑 **User Authentication**: Secure login and registration using JWT.
- 🧠 **AI-Driven Analysis**: Medical data is analyzed to offer customized insurance plans.
- 🎨 **Modern Design**: Inspired by Gjensidige's clean, professional layout.
- 💾 **Database Management**: Powered by EF Core and SQLite for efficient data handling.
- 📱 **Responsive Interface**: Optimized for both desktop and mobile views.

---

## 🛠️ Technologies Used

- **Frontend** 🎨:
  - Blazor Server
  - HTML5/CSS3
  - Bootstrap 5

- **Backend** 🖥️:
  - ASP.NET Core Web API
  - Entity Framework Core (EF Core)
  - SQLite

- **Machine Learning** 🤖:
  - Python
  - TensorFlow/Keras
  - FastAPI
  - Uvicorn

- **Authentication** 🔐:
  - JSON Web Tokens (JWT)

---

## 🗄️ Database Information

The application uses **SQLite** for data storage. The database is **pre-loaded with testing data**, allowing you to log in and explore the full functionality without additional setup.

### 🧪 Test User Credentials

The following test user accounts are available for demonstration purposes:

| 👤 Name     | 📧 Email            | 🔑 Password   | 📝 Profile Details                                                               |
|-------------|---------------------|---------------|----------------------------------------------------------------------------------|
| Samuele     | `samuele@test.com`  | `password1`   | Male, DOB: 1990-01-01, Discount: 10%, Emergency Contact: Jane Doe                |
| Ana         | `ana@test.com`      | `password2`   | Female, DOB: 1985-05-15, Discount: 20%, Emergency Contact: John Smith            |
| Eliza       | `eliza@test.com`    | `password3`   | Female, DOB: 1975-10-20, Discount: 15%, Emergency Contact: Bob Johnson           |
| Eric        | `eric@test.com`     | `password4`   | Male, DOB: 2000-03-30, Discount: 5%, Emergency Contact: Alice Brown              |

> **Note**: Each user has distinct medical profiles to demonstrate personalized insurance recommendations.

---

## 🎮 Usage

1. **Log In**: Use the provided test credentials to log in.
2. **Explore Features**:
   - Answer medical surveys to input health data.
   - Receive AI-driven insurance recommendations.
3. **Test Scenarios**: Try different test users to observe how results and recommendations change.

---

## 📂 Project Structure

The project follows a clean, modular structure:

- **ML Model** 🤖: Contains the FastAPI server and TensorFlow model.
- **WebApiSEP7** 🖥️: Backend API built with ASP.NET Core.
- **WebAppSEP7** 🎨: Frontend Blazor Server application.
- **Data** 💾: Pre-configured SQLite database with test data.

---

## 🤝 Contributing

Contributions are welcome! Follow these steps:

1. Fork the repository.
2. Create a new feature branch.
3. Commit and push your changes.
4. Create a pull request with a clear explanation.

---

## 📜 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for more details.

---

## 🙌 Acknowledgements

- **Gjensidige Insurance**: Inspiration for the professional layout and functionality.
- **Open-Source Libraries**: Blazor, ASP.NET Core, FastAPI, TensorFlow, and more.

---

## 📞 Contact

For questions or support, feel free to reach out:

**Samuele Biondi**  
- 📧 Email: [samuele@test.com](mailto:samuele@test.com)  
- 🌐 GitHub: [Samu1311](https://github.com/Samu1311)  

---

## ⚙️ Running Instructions

Follow these steps to run the project smoothly:

### 1. Start the Machine Learning API 🤖

Navigate to the **ML Model** folder and start the Python server.


```bash
cd "ML Model"
python main.py
```

---

### 2. Start the Web API 🖥️

In a new terminal window, navigate to the **WebApiSEP7** folder and run the backend.

```bash
cd "WebApiSEP7"
dotnet run
```

---

### 3. Start the Blazor Server Application 🎨

Open another terminal window, navigate to the **WebAppSEP7** folder, and start the frontend application.

```bash
cd "WebAppSEP7"
dotnet run
```

---

### 4. Access the Application 🌐

Once all parts are running:

- Open your web browser and navigate to: http://localhost:5075 or the one showing on your machine's console


---

The application is now ready for use! 🎉

- Log in using the provided **test credentials** in the section above.
- Input your data, run AI-powered analysis, and receive personalized insurance recommendations.

---

### 🔄 Order of Execution

For smooth operation, ensure you **start each component in this order**:

1. **ML Model** (Python FastAPI server)
2. **Web API** (ASP.NET Core backend)
3. **WebApp** (Blazor Server frontend)

---

### 🧪 Example Workflow

1. **Start the ML API** to process user data through the AI model.
2. **Launch the backend** to handle user authentication and database interactions.
3. **Run the frontend** for the user interface.
4. Access the application at `http://localhost:5000`.

---

That’s it! Once you’ve completed the steps, your project will be ready to go. 🚀  
Add the specific commands where placeholders are noted to finalize this section.


