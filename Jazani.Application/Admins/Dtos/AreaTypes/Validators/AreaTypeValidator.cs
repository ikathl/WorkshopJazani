using FluentValidation;

namespace Jazani.Application.Admins.Dtos.AreaTypes.Validators
{
    public class AreaTypeValidator:AbstractValidator<AreaTypeSaveDto>
    {
        public AreaTypeValidator() 
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Campo Name es requerido")
                .NotEmpty().WithMessage("Campo no vacio")
                .Length(3, 50).WithMessage("El campo name debe tener como entre 3 y 50 caracteres");
            

            RuleFor(x => x.Description)
                .MaximumLength(100).WithMessage("El campo descripcion solo puede tener 100 caracteres");
        }
    }
}
