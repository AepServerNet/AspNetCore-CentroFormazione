using App.Models.InputModels.Edifici;
using FluentValidation;

namespace App.Models.Validators.Docente
{
    public class EdificioDeleteValidator : AbstractValidator<EdificioDeleteInputModel>
    {
        public EdificioDeleteValidator()
        {
            RuleFor(m => m.IdEdificio)
                .NotEmpty();
        }
    }
}