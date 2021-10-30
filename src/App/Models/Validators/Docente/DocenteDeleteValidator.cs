using App.Models.InputModels.Docenti;
using FluentValidation;

namespace App.Models.Validators.Docente
{
    public class DocenteDeleteValidator : AbstractValidator<DocenteDeleteInputModel>
    {
        public DocenteDeleteValidator()
        {
            RuleFor(m => m.IdDocente)
                .NotEmpty();
        }
    }
}