using MedicineApi.Models;
using System.Collections.Generic;

namespace MedicineApi.Validators.Models
{
    public class MedicineValidationModel
    {
        public Medicine medicine {get; set;}

        public List<Medicine> listofMedicines {get;set;}

        public MedicineValidationModel(Medicine _medicine,List<Medicine> _medicines)
        {
            medicine = _medicine;
            listofMedicines = _medicines;
        }
    }
}