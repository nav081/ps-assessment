using MedicineApi.Models;
using MedicineApi.Services.Interfaces;
using FluentValidation;
using MedicineApi.Validators.Models;

namespace MedicineApi.Services
{
    public class SalesService: ISalesService
    {
        private readonly ILogger<SalesService> _logger;
        private readonly IStorageService _storage;

        public SalesService(ILogger<SalesService> logger,IStorageService storage, IValidator<MedicineValidationModel> validator)
        {
            _logger = logger;
            _storage = storage;
        }

        
        public List<SaleRecord> GetAllSales(string search)
        {
            try
            {
                if(string.IsNullOrEmpty(search))
                {
                    return _storage.GetAllSales();
                }
                var list = _storage.GetAllSales();

                //filter the list based on search
                return list.Where(x => x.MedicineName.ToLower().Contains(search.ToLower())).ToList();
            }
            catch (Exception er)
            {
                _logger.LogError(er, "error in SalesService_GetAllSales");
                throw;
            }
        }

        public (string,bool) Sell(int id, int quantity)
        {
            try
            {
                var list = _storage.GetAll();
                var med = list.FirstOrDefault(x => x.Id == id);

                _logger.LogInformation("Attempting to sell medicine with id {Id} and quantity {Quantity}", id, quantity);
                if (med == null) return ("Medicine not found", false);

                _logger.LogInformation("We got the medicine {name} and quantity {Quantity}", med.FullName, med.Quantity);
                if(med.Quantity < 1) return ("Insufficient quantity", false);
            
                //update the quantity
                _logger.LogInformation("updating the quantity for medicine {name} from {oldQuantity} to {newQuantity}", med.FullName, med.Quantity, med.Quantity - quantity);
                med.Quantity -= quantity;
            
                //record the sale
                _storage.Sell(new SaleRecord {
                    MedicineName = med.FullName,
                    QuantitySold = quantity,
                    Price = med.Price,
                    SoldOn = DateTime.Now
                });

                _storage.SaveAll(list);

                return ("Sale recorded successfully", true); 
            }
            catch (Exception er)
            {
                _logger.LogError(er, "error in SalesService_Sell");
                throw;
            }
            
        }
    }
}