using MedicineApi.Models;

namespace MedicineApi.Services.Interfaces
{
    public interface ISalesService 
    {
        List<SaleRecord> GetAllSales(string search);
        (string,bool) Sell(int medicineId, int quantity);
    }
}