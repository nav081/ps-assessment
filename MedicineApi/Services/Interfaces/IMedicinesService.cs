using MedicineApi.Models;

namespace MedicineApi.Services.Interfaces
{
    public interface IMedicinesService 
    { 
        List<Medicine> GetAll(string search);
        (bool isCorrect, List<string> errors) Add(Medicine med);
        Medicine Sell(int id, int quantity);
    }
}