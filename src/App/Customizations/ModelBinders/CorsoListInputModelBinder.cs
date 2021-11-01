using System.Threading.Tasks;
using App.Models.InputModels.Corsi;
using App.Models.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace App.Customizations.ModelBinders
{
    public class CorsoListInputModelBinder : IModelBinder
    {
        private readonly IOptionsMonitor<CorsoOptions> corsoOptions;
        
        public CorsoListInputModelBinder(IOptionsMonitor<CorsoOptions> corsoOptions)
        {
            this.corsoOptions = corsoOptions;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string search = bindingContext.ValueProvider.GetValue("Search").FirstValue;
            string orderBy = bindingContext.ValueProvider.GetValue("OrderBy").FirstValue;
            
            int.TryParse(bindingContext.ValueProvider.GetValue("Page").FirstValue, out int page);
            bool.TryParse(bindingContext.ValueProvider.GetValue("Ascending").FirstValue, out bool ascending);

            CorsoOptions options = corsoOptions.CurrentValue;
            CorsoListInputModel inputModel = new(search, page, orderBy, ascending, options.PerPage, options.Order);

            bindingContext.Result = ModelBindingResult.Success(inputModel);

            return Task.CompletedTask;
        }
    }
}