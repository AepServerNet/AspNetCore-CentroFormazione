using App.Models.InputModels.Corsi;
using FluentValidation;

namespace App.Models.Validators.Corso
{
    public class CorsoDeleteValidator : AbstractValidator<CorsoDeleteInputModel>
    {
        public CorsoDeleteValidator()
        {
            RuleFor(m => m.IdCorso)
                .NotEmpty();
        }
    }
}