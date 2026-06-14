using MedicineApi.Models;
using System.Text.Json;
using MedicineApi.Services.Interfaces;

namespace MedicineApi.Services
{
    public class StorageService: IStorageService
    {
        private readonly string filePath = "medicines.json";
        private readonly string filePathSales = "sales.json";
        private readonly ILogger<StorageService> _logger;
        public StorageService(ILogger<StorageService> logger)
        {
            _logger = logger;
        }

        public List<Medicine> GetAll()
        {
            try
            {
                if (!CheckorSeedFile(filePath))
                    return new List<Medicine>();

                var json = File.ReadAllText(filePath);
                _logger.LogInformation("Reading data from file");
                return JsonSerializer.Deserialize<List<Medicine>>(json) ?? new List<Medicine>();
            }
            catch (Exception er)
            {
                _logger.LogError(er, "error in StorageService_GetAll");
                throw;
            }
        }

        public void SaveAll(List<Medicine> medicines)
        {
            try
            {
                var json = JsonSerializer.Serialize(medicines, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filePath, json);
            }
            catch (Exception er)
            {
                _logger.LogError(er, "error in StorageService_SaveAll");
                throw;
            }
        }

        public List<SaleRecord> GetAllSales()
        {
            try
            {
                if (!CheckorSeedFile(filePathSales))
                    return new List<SaleRecord>();

                var json = File.ReadAllText(filePathSales);
                _logger.LogInformation("Reading data from file");
                return JsonSerializer.Deserialize<List<SaleRecord>>(json) ?? new List<SaleRecord>();
            }
            catch (Exception er)
            {
                _logger.LogError(er, "error in StorageService_GetAll");
                throw;
            }
        }

        public void Sell(SaleRecord saleRecord)
        {
            try
            {
                var sales = GetAllSales();
                saleRecord.Id = sales.Count + 1;
                _logger.LogInformation("Recording sale for medicine {name} with quantity {Quantity}", saleRecord.MedicineName, saleRecord.QuantitySold);
                sales.Add(saleRecord);

                _logger.LogInformation("Saving sales data to file");
                SaveAllSales(sales);
            }
            catch (Exception er)
            {
                _logger.LogError(er, "error in StorageService_Sell");
                throw;
            }
        }



        private void SaveAllSales(List<SaleRecord> sales)
        {
            try
            {
                var json = JsonSerializer.Serialize(sales, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filePathSales, json);
            }
            catch (Exception er)
            {
                _logger.LogError(er, "error in StorageService_SaveAll");
                throw;
            }
        }


        private bool CheckorSeedFile(string path)
        {
            try
            {
                if(!File.Exists(path))
                {
                    _logger.LogInformation("File do not exist");

                // Create the file and close it immediately
                    using (FileStream fs = File.Create(path))
                    {
                        byte[] info = new System.Text.UTF8Encoding(true).GetBytes("[]");
                        fs.Write(info, 0, info.Length);
                        _logger.LogInformation("File created");
                    }
                }
                return true; 
            }
             catch (Exception er)
            {
                _logger.LogError(er, "error in StorageService_CheckorSeedFile");
                throw;
            }
        }
    }
}