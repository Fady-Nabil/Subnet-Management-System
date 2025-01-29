# Subnet Management System

This project consists of an **ASP.NET Core Web API** and an **Angular frontend** for managing subnets and their associated IP addresses.

## Table of Contents
- [Getting Started](#getting-started)
- [Technologies Used](#technologies-used)
- [Setup Instructions](#setup-instructions)
  - [Running the API Locally](#running-the-api-locally)
  - [Running the Angular Frontend](#running-the-angular-frontend)
- [API Endpoints](#api-endpoints)
- [Improvements & Known Issues](#improvements--known-issues)

---

## Getting Started
Follow the steps below to get both the **backend API** and **frontend UI** running locally.

---

## Technologies Used
- **Backend:** ASP.NET Core Web API (Version 9 or later)
- **Frontend:** Angular (Version 15 or later)
- **Database:** SQLSERVER
- **Authentication:** JWT (JSON Web Token)
- **UI Components:** Angular Material

---

## Setup Instructions

### Prerequisites
Make sure you have the following installed:
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/en/)
- [Angular CLI](https://angular.io/guide/setup-local) (Run `npm install -g @angular/cli`)
- [SQlServer](https://dev.mysql.com/downloads/)

---

### Running the API Locally

1. **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/subnet-management.git
    cd subnet-management/backend
    ```

2. **Set up the database:**
   - Create a MySQL database named `SubnetDB`.
   - Update the connection string in `appsettings.json`:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "server=localhost;database=SubnetDB;user=root;password=yourpassword"
       }
     }
     ```

3. **Apply database migrations:**
    ```bash
    dotnet ef database update
    ```

4. **Run the API:**
    ```bash
    dotnet run
    ```
---

### Running the Angular Frontend

1. **Navigate to the frontend directory:**
    ```bash
    cd ../frontend
    ```

2. **Install dependencies:**
    ```bash
    npm install
    ```

3. **Update the API endpoint in `environment.ts`:**
   Open `src/environments/environment.ts` and set the `apiUrl`:
   ```typescript
   export const environment = {
     production: false,
     apiUrl: 'https://localhost:5001/api'
   };
