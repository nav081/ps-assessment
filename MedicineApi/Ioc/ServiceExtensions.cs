using MedicineApi.Services;
using MedicineApi.Services.Interfaces;
using MedicineApi.Validators;
using MedicineApi.Validators.Models;
using FluentValidation;

namespace MedicineApi.Ioc
{
    public static class ServicesExtensions
    {
        public static void AddDataServices(this IServiceCollection service)
        {
            service.AddSingleton<IStorageService, StorageService>();
        }

        public static void AddMedicinesServices(this IServiceCollection service)
        {
            service.AddScoped<IMedicinesService, MedicinesService>();
        }

        public static void AddCustomValidators(this IServiceCollection service)
        {
            service.AddScoped<IValidator<MedicineValidationModel>, MedicineValidator>();
        }
    }
}