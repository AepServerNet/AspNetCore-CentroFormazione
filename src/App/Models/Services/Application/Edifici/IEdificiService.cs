using System.Threading.Tasks;
using App.Models.InputModels.Edifici;
using App.Models.ViewModels;
using App.Models.ViewModels.Edifici;

namespace App.Models.Services.Application.Edifici
{
    public interface IEdificiService
    {
        Task<ListViewModel<EdificioViewModel>> GetEdificiAsync(EdificioListInputModel model);
        Task<EdificioDetailViewModel> CreateEdificioAsync(EdificioCreateInputModel inputModel);
        Task<EdificioEditInputModel> GetEdificioForEditingAsync(string IdEdificio);
        Task<EdificioDetailViewModel> EditEdificioAsync(EdificioEditInputModel inputModel);
        Task<EdificioDetailViewModel> GetEdificioAsync(string IdEdificio);
        Task DeleteEdificioAsync(EdificioDeleteInputModel inputModel);
    }
}