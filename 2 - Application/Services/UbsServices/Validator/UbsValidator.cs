using Dtos.Dto;
using FluentValidation;

namespace Services.UbsServices.Validator
{
    public class UbsValidator : AbstractValidator<UbsFormDTO>
    {
        public UbsValidator()
        {
            RuleFor(m => m.ValorLatitude)
                   .Must((formDto, valor) => ValidarValores(valor)).WithMessage("A latitude deve ser entre -90 e 90.");

            RuleFor(m => m.ValorLongitude)
                .Must((formDto, valor) => ValidarValores(valor)).WithMessage("A logintude deve ser entre -90 e 90.");
        }

        private bool ValidarValores(double valor)
        {
            if (valor <= 90 && valor >= -90)
                return true;

            return false;
        }
    }
}