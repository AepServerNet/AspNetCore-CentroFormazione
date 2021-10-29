using System.Threading.Tasks;
using App.Models.InputModels.Docenti;
using App.Models.InputModels.Edifici;
using App.Models.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace App.Customizations.ModelBinders
{
    public class EdificioListInputModelBinder : IModelBinder
    {
        private readonly IOptionsMonitor<EdificioOptions> edificioOptions;
        
        public EdificioListInputModelBinder(IOptionsMonitor<EdificioOptions> edificioOptions)
        {
            this.edificioOptions = edificioOptions;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string search = bindingContext.ValueProvider.GetValue("Search").FirstValue;
            string orderBy = bindingContext.ValueProvider.GetValue("OrderBy").FirstValue;
            
            int.TryParse(bindingContext.ValueProvider.GetValue("Page").FirstValue, out int page);
            bool.TryParse(bindingContext.ValueProvider.GetValue("Ascending").FirstValue, out bool ascending);

            EdificioOptions options = edificioOptions.CurrentValue;
            EdificioListInputModel inputModel = new(search, page, orderBy, ascending, options.PerPage, options.Order);

            bindingContext.Result = ModelBindingResult.Success(inputModel);

            return Task.CompletedTask;
        }
    }
}