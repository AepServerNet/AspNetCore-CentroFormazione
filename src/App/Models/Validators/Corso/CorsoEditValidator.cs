using App.Models.InputModels.Corsi;
using FluentValidation;

namespace App.Models.Validators.Corso
{
    public class CorsoEditValidator : AbstractValidator<CorsoEditInputModel>
    {
        public CorsoEditValidator()
        {
            RuleFor(m => m.Id)
                .NotEmpty();

            RuleFor(m => m.IdCorso)
                .NotEmpty();

            RuleFor(m => m.CodiceDipartimento)
                .NotEmpty().WithMessage("Il nominativo docente è un campo obbligatorio");

            RuleFor(m => m.NomeCorso)
                .NotEmpty().WithMessage("La materia insegnata è un campo obbligatorio");

            RuleFor(m => m.DataInizioCorso)
                .NotEmpty().WithMessage("La materia insegnata è un campo obbligatorio");

            RuleFor(m => m.DataFineCorso)
                .NotEmpty().WithMessage("La materia insegnata è un campo obbligatorio");

            RuleFor(m => m.OreCorso)
                .NotEmpty().WithMessage("La materia insegnata è un campo obbligatorio");
        }
    }
}