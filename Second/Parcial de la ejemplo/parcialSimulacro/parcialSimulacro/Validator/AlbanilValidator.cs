using System.Data;
using FluentValidation;
using parcialSimulacro.Dto;

namespace parcialSimulacro.Validator;

public class AlbanilValidator : AbstractValidator<AlbanilDto>
{
    public AlbanilValidator()
    {
        RuleFor(a => a.Nombre).NotEmpty().WithMessage("Obligatorio nombre");
        RuleFor(a => a.Apellido).NotEmpty().WithMessage("Obligatorio apellido");
        RuleFor(a => a.Dni).NotEmpty().WithMessage("Obligatorio dni");
        RuleFor(a => a.Telefono).NotEmpty().WithMessage("Obligatorio telefono");
    }
}