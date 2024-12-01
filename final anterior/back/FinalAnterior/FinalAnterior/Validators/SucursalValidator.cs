using FinalAnterior.Dto;
using FluentValidation;

namespace FinalAnterior.Validators;

public class SucursalValidator : AbstractValidator<SucursalDto>
{
    public SucursalValidator()
    {
        RuleFor(s=>s.Id).NotEmpty().WithMessage("El campo Id es requerido");
        RuleFor(s=> s.IdProvincia).NotEmpty().WithMessage("El campo Id provincia es requerido");
        RuleFor(s=> s.IdCiudad).NotEmpty().WithMessage("El campo Id ciudad es requerido");
        RuleFor(s=>s.IdTipo).NotEmpty().WithMessage("El campo Id tipo es requerido");
        
    }
}