using System.Threading.Tasks;
using App.Models.InputModels.Docenti;
using App.Models.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace App.Customizations.ModelBinders
{
    public class DocenteListInputModelBinder : IModelBinder
    {
        private readonly IOptionsMonitor<DocenteOptions> docenteOptions;
        
        public DocenteListInputModelBinder(IOptionsMonitor<DocenteOptions> docenteOptions)
        {
            this.docenteOptions = docenteOptions;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string search = bindingContext.ValueProvider.GetValue("Search").FirstValue;
            string orderBy = bindingContext.ValueProvider.GetValue("OrderBy").FirstValue;
            
            int.TryParse(bindingContext.ValueProvider.GetValue("Page").FirstValue, out int page);
            bool.TryParse(bindingContext.ValueProvider.GetValue("Ascending").FirstValue, out bool ascending);

            DocenteOptions options = docenteOptions.CurrentValue;
            DocenteListInputModel inputModel = new(search, page, orderBy, ascending, options.PerPage, options.Order);

            bindingContext.Result = ModelBindingResult.Success(inputModel);

            return Task.CompletedTask;
        }
    }
}