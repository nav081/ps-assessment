using MedicineApi.Validators.Models;
using System.Collections.Generic;

namespace MedicineApi.Validators.Extensions
{
    public static class MedicineValidationExtensions
    {
        public static bool ValidateMedicineName(this MedicineValidationModel model){
            return !string.IsNullOrEmpty(model.medicine.FullName);
        }

        public static bool ValidateBrandName(this MedicineValidationModel model){
            return !string.IsNullOrEmpty(model.medicine.Brand);
        }

        public static bool ValidateQuantity(this MedicineValidationModel model){
            return model.medicine.Quantity!=0;
        }

        public static bool ValidatePrice(this MedicineValidationModel model){
            return model.medicine.Price!=0;
        }

        public static bool ValidateExpiry(this MedicineValidationModel model){
            return model.medicine.ExpiryDate > DateTime.Now;
        }

        public static bool ValidateAlreadyExists(this MedicineValidationModel model){
            bool isAlreadyThere = model.listofMedicines.Any(m => m.FullName.ToLower().Contains(model.medicine.FullName.ToLower()));
            return !isAlreadyThere;
        }
    }
}