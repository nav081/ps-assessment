using MedicineApi.Models;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using MedicineApi.Services.Interfaces;
using FluentValidation;
using MedicineApi.Validators.Models;

namespace MedicineApi.Services
{
    public class MedicinesService: IMedicinesService
    {
        private readonly ILogger<MedicinesService> _logger;
        private readonly IStorageService _storage;
        private readonly IValidator<MedicineValidationModel> _validator;

        public MedicinesService(ILogger<MedicinesService> logger,IStorageService storage, IValidator<MedicineValidationModel> validator)
        {
            _logger = logger;
            _storage = storage;
            _validator = validator;
        }

        public List<Medicine> GetAll(string search)
        {
            try
            {
                if(string.IsNullOrEmpty(search))
                {
                    return _storage.GetAll();
                }
                return _storage.GetAll();
            }
            catch (System.Exception er)
            {
                _logger.LogError(er, "error in MedicinesService_GetAll");
                throw;
            }
        }

        public (bool, List<string>) Add(Medicine med)
        {
            try
            {
                var list = _storage.GetAll();

                var validateModel = _validator.Validate(new MedicineValidationModel(med,list));
                if (!validateModel.IsValid) return (false, validateModel.Errors.Select(x => x.ErrorMessage).ToList());
                
                med.Id = list.Count + 1;
                list.Add(med);

                _storage.SaveAll(list);
                return (true, new List<string>());
            }
            catch (System.Exception er)
            {
                _logger.LogError(er, "error in MedicinesService_Add");
                throw;
            }
        }

        public Medicine Sell(int id, int quantity)
        {
            var list = _storage.GetAll();
            var med = list.FirstOrDefault(x => x.Id == id);

            if (med == null) return new Medicine{ FullName = "", Brand = ""};

            med.Quantity -= quantity;
            _storage.SaveAll(list);

            return med;
        }
    }
}