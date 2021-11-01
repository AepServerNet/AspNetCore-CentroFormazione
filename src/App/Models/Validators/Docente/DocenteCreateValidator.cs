using App.Models.InputModels.Docenti;
using FluentValidation;

namespace App.Models.Validators.Docente
{
    public class DocenteCreateValidator : AbstractValidator<DocenteCreateInputModel>
    {
        public DocenteCreateValidator()
        {
            RuleFor(m => m.NominativoDocente)
                .NotEmpty().WithMessage("Il nominativo docente è un campo obbligatorio");

            RuleFor(m => m.MateriaInsegnata)
                .NotEmpty().WithMessage("La materia insegnata è un campo obbligatorio");
        }
    }
}