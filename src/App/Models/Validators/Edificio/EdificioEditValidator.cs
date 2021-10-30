using App.Models.InputModels.Edifici;
using FluentValidation;

namespace App.Models.Validators.Docente
{
    public class EdificioEditValidator : AbstractValidator<EdificioEditInputModel>
    {
        public EdificioEditValidator()
        {
            RuleFor(m => m.Id)
                .NotEmpty();

            RuleFor(m => m.IdEdificio)
                .NotEmpty();

            RuleFor(m => m.CodiceDipartimento)
                .NotEmpty().WithMessage("Il dipartimento è un campo obbligatorio");

            RuleFor(m => m.Aula)
                .NotEmpty().WithMessage("L'aula è un campo obbligatorio");

            RuleFor(m => m.Laboratorio)
                .NotEmpty().WithMessage("Il laboratorio è un campo obbligatorio");

            RuleFor(m => m.Posti)
                .NotEmpty().WithMessage("I posti sono un campo obbligatorio");
        }
    }
}