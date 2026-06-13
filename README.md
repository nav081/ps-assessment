# Assesment

This repository contains mainly two folders MedicineApi & MedicineUi.

## MedicineApi

Folder Structure

```bash
MedicineApi/
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
```

## Usage MedicineApi

```python
dotnet run

# Output
Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5297
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\..\..\PS\MedicineApi
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
```

## Contributing

Pull Request and Comments are welcome
