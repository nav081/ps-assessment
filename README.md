# 🏥 ABC Pharmacy Management System

A responsive Single Page Application (SPA) designed to manage medicine inventory, track stock levels, and seamlessly handle sales. 

---

## 🚀 Tech Stack

### Frontend
* **Framework:** React + TypeScript
* **UI Component Library:** Material UI (MUI)
* **HTTP Client:** Axios

### Backend
* **Framework:** .NET Core Web API
* **Validation:** FluentValidation (for robust request validation)
* **Storage:** JSON file storage (lightweight persistence)

---

## ✅ Features & Highlights

* **Core Inventory Actions:** Add medicines, view the medicine list, and search inventory.
* **Sales Tracking:** Sell medicines directly from the UI, automatically reducing the stock quantity.
* **Business Rules Engine:**
  * 🔴 **Expiry < 30 days:** Rows/Cards are highlighted in **Red**.
  * 🟡 **Quantity < 10:** Rows/Cards are highlighted in **Yellow**.
* **Responsive UI Design:** Utilizes an MUI `DataGrid` for desktop screens and dynamically switches to a clean `Card` layout for mobile devices.
* **User Experience:** Implements global loaders for API calls and toast notifications for success/error states.
* **Robust Backend:** Built with a clean separation of concerns, centralized error handling, and file-based JSON persistence.

---

## 📂 Project Structure

### Frontend (`medicine-ui`)
```text
src/
 ├── components/
 │    ├── AddMedicine.tsx
 │    ├── SalesDialog.tsx
 │    └── MedicineList.tsx
 ├── types/
 │    └── types.ts
 ├── services/
 │    └── api.ts
 └── App.tsx
```

### Backend (`MedicinesApi`)

```text
├── Controllers/
│   ├── SalesController.cs
│   └── MedicineController.cs
├── Models/
│   ├── SaleRecord.cs
│   └── Medicine.cs
├── Services/
│   ├── Interfaces
│   │   ├── IMedicineService.cs
│   │   ├── ISalesService.cs
│   │   └── IStorageService.cs
│   ├── MedicineService.cs
│   ├── SalesService.cs 
│   └── StorageService.cs 
├── Ioc/
│   └── ServicesExtensions.cs
├── Validators/
│   ├── Models/
│   │   └── MedicineValidationModel.cs
│   ├── Extensions/
│   │   └── MedicineValidationExtensions.cs
│   └── MedicineValidator.cs
├── medicines.json
├── sales.json
└── Program.cs
```

## ⚙️ Setup Instructions

Follow these steps to get your local development environment up and running.

### 1️⃣ Clone the Repository
```bash
git clone [<repo-url>](https://github.com/nav081/ps-assessment.git)
cd medicine-ui
```
### 2️⃣ Setup Frontend
Navigate to the frontend directory (if separate) or stay in the medicine-ui root, then run:

```Bash
npm install
npm start
```

### 3️⃣ Setup Backend
Open a separate terminal window, navigate to your backend project directory, and spin up the .NET Core Web API:
```Bash
dotnet run
```

### 4️⃣ Environment Configuration
Create a .env file in the root of your frontend project and add the backend API URL connection string:

```Bash
REACT_APP_API_URL=http://localhost:5297/api
```
