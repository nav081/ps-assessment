🏥 ABC Pharmacy Management System
A responsive Single Page Application (SPA) to manage medicine inventory, track stock, and handle sales.

🚀 Tech Stack
Frontend

React + TypeScript
Material UI (MUI)
Axios

Backend

.NET Core Web API
FluentValidation (for request validation)
JSON file storage


✅ Features

Add medicines
View medicines list
Sell medicines (reduce quantity)
Search medicines


📊 Business Rules

🔴 Expiry < 30 days → Red highlight
🟡 Quantity < 10 → Yellow highlight


💻 UI Highlights

Responsive design (Mobile + Desktop)
DataGrid (desktop view)
Card layout (mobile view)
Toast notifications for errors & success
Loader for API calls


🔧 Backend Highlights

RESTful API using .NET Core
Data stored in JSON file (lightweight persistence)
Centralized error handling
FluentValidation used for input validation


✅ Validation (FluentValidation)
Backend validations include:

Required fields (medicine name, brand, expiry, etc.)
Valid date format
Quantity > 0
Price > 0


📂 Project Structure
medicine-ui
src/
 ├── components/
 │    ├── AddMedicine.tsx
 │    └── MedicineList.tsx
 ├── types
 │    └── types.ts
 ├── services/
 │    └── api.ts
 └── App.tsx


Backend
├── Controllers/
│   └── MedicineController.cs
├── Models/
│   └── Medicine.cs
├── Services/
│   ├── Interfaces
│   │   ├── IMedicineService.cs
│   │   └── IStorageService.cs
│   ├── MedicineService.cs 
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
└── Program.cs


⚙️ Setup Instructions

1️⃣ Clone Repository
Shellgit clone <repo-url>cd medicine-uiShow more lines

2️⃣ Setup Frontend
Shellnpm installnpm startShow more lines

3️⃣ Setup Backend
Shelldotnet runShow more lines

4️⃣ Environment Configuration
Create .env file:
Plain Textenv isn’t fully supported. Syntax highlighting is based on Plain Text.REACT_APP_API_URL=http://localhost:5000/api/medicinesShow more lines

🔌 API Endpoints

Method         Endpoint                    Description
GET            /api/medicines                  Get all medicines
POST           /api/medicines                  Add medicine
POST           /api/medicines/sell/{id}        Sell medicine

❗ Error Handling

FluentValidation handles request validation
UI handles:

Validation errors
Business errors
API errors


404 → "Inventory not found"

📱 UI Behavior
Desktop

DataGrid table
Row color coding

Mobile

Card layout
Full-width UI


🧹 Clean Before Upload
Remove unnecessary files:
node_modules/
package-lock.json
bin/
obj/


🚀 Future Improvements

Edit / Delete medicine
Lazy Loading
Filters (Low stock / Expiring)
Dashboard analytics
Authentication system

⭐ Highlights

Clean architecture (frontend + backend separation)
FluentValidation for robust backend validation
Responsive UI design
Business rule implementation
Scalable structure
