using FluentValidation;
using MedicineApi.Validators.Models;
using MedicineApi.Validators.Extensions;

namespace MedicineApi.Validators
{
    public class MedicineValidator : AbstractValidator<MedicineValidationModel>
    {
        public MedicineValidator()
        {
            RuleFor(o => o.ValidateMedicineName()).NotEqual(false)
               .WithMessage("Please Add Medicine Name");

            RuleFor(o => o.ValidateBrandName()).NotEqual(false)
               .WithMessage("Please Add Brand Name");

            RuleFor(o => o.ValidateQuantity()).NotEqual(false)
               .WithMessage("Please check quantity again");

            RuleFor(o => o.ValidatePrice()).NotEqual(false)
               .WithMessage("Please check price again");

            RuleFor(o => o.ValidateExpiry()).NotEqual(false)
               .WithMessage("Please check price again");

            RuleFor(o => o.ValidateAlreadyExists()).NotEqual(false)
               .WithMessage("Medicine Already Exists");
        }
    }
}