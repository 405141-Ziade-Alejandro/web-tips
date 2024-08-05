using BackEnd.Dto;
using FluentValidation;

namespace BackEnd.Validator;

public class EmpleadoValidator : AbstractValidator<EmpleadoAltaDto>
{
    public EmpleadoValidator()
    {
        RuleFor(e => e.Dni).NotEmpty().WithMessage("el Dni es obligatorio");
        RuleFor(e => e.Nombre).NotEmpty().WithMessage("el Dni es obligatorio");
        RuleFor(e => e.Apellido).NotEmpty().WithMessage("el Dni es obligatorio");
        RuleFor(e => e.IdSucursal).NotEmpty().WithMessage("el Dni es obligatorio");
        RuleFor(e => e.Jefe).NotEmpty().WithMessage("el Dni es obligatorio");
    }
}