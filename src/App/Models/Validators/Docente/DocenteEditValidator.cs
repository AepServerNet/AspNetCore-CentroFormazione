using App.Models.InputModels.Docenti;
using FluentValidation;

namespace App.Models.Validators.Docente
{
    public class DocenteEditValidator : AbstractValidator<DocenteEditInputModel>
    {
        public DocenteEditValidator()
        {
            RuleFor(m => m.Id)
                .NotEmpty();

            RuleFor(m => m.IdDocente)
                .NotEmpty();

            RuleFor(m => m.NominativoDocente)
                .NotEmpty().WithMessage("Il nominativo docente non può essere vuoto");

            RuleFor(m => m.MateriaInsegnata)
                .NotEmpty().WithMessage("La materia insegnata non può essere vuota");
        }
    }
}