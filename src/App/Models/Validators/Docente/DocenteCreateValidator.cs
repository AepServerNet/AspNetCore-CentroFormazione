using App.Models.InputModels.Docenti;
using FluentValidation;

namespace App.Models.Validators.Docente
{
    public class DocenteCreateValidator : AbstractValidator<DocenteCreateInputModel>
    {
        public DocenteCreateValidator()
        {
            RuleFor(m => m.NominativoDocente)
                .NotEmpty().WithMessage("Il nominativo docente non può essere vuoto");

            RuleFor(m => m.MateriaInsegnata)
                .NotEmpty().WithMessage("La materia insegnata non può essere vuota");
        }
    }
}