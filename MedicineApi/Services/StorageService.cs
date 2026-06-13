using MedicineApi.Models;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using MedicineApi.Services.Interfaces;

namespace MedicineApi.Services
{
    public class StorageService: IStorageService
    {
        private readonly string filePath = "medicines.json";
        private readonly ILogger<StorageService> _logger;
        public StorageService(ILogger<StorageService> logger)
        {
            _logger = logger;
        }

        public List<Medicine> GetAll()
        {
            try
            {
                if (!File.Exists(filePath))
                    return new List<Medicine>();

                var json = File.ReadAllText(filePath);
                _logger.LogInformation("Reading data from file");
                return JsonSerializer.Deserialize<List<Medicine>>(json) ?? new List<Medicine>();
            }
            catch (System.Exception er)
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
            catch (System.Exception er)
            {
                _logger.LogError(er, "error in StorageService_SaveAll");
                throw;
            }
        }

        private bool CheckorSeedFile()
        {
            try
            {
                if(!File.Exists(filePath))
                {
                    _logger.LogInformation("File do not exist");

                // Create the file and close it immediately
                    using (FileStream fs = File.Create(filePath))
                    {
                        byte[] info = new System.Text.UTF8Encoding(true).GetBytes("{}");
                        fs.Write(info, 0, info.Length);
                        _logger.LogInformation("File created");
                    }
                }
                return true; 
            }
             catch (System.Exception er)
            {
                _logger.LogError(er, "error in StorageService_CheckorSeedFile");
                throw;
            }
        }
    }
}