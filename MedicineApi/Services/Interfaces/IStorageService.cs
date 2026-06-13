using MedicineApi.Models;

namespace MedicineApi.Services.Interfaces
{
    public interface IStorageService 
    { 
        List<Medicine> GetAll();
        void SaveAll(List<Medicine> medicines);
    }
}