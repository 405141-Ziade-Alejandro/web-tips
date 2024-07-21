using FluentValidation;
using parcialSimulacro.Dto;

namespace parcialSimulacro.Validator;

public class AlbanilXObraValidator : AbstractValidator<AlbanilXObraDto>
{
    public AlbanilXObraValidator()
    {
        RuleFor(a => a.IdAlbanil).NotEmpty().WithMessage("obligatorio id de albañil");
        RuleFor(a => a.IdObra).NotEmpty().WithMessage("obligatorio id de la obra");
        RuleFor(a => a.TareaArealizar).NotEmpty().WithMessage("hay que agregar la tarea a realizar");
    }
}