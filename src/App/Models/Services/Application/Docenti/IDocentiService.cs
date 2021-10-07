using System.Threading.Tasks;
using App.Models.InputModels.Docenti;
using App.Models.ViewModels;
using App.Models.ViewModels.Docenti;

namespace App.Models.Services.Application.Docenti
{
    public interface IDocentiService
    {
        Task<ListViewModel<DocenteViewModel>> GetDocentiAsync(DocenteListInputModel model);
        Task<DocenteDetailViewModel> CreateDocenteAsync(DocenteCreateInputModel inputModel);
        Task<DocenteEditInputModel> GetDocenteForEditingAsync(string IdDocente);
        Task<DocenteDetailViewModel> EditDocenteAsync(DocenteEditInputModel inputModel);
        Task<DocenteDetailViewModel> GetDocenteAsync(string IdDocente);
        Task DeleteDocenteAsync(DocenteDeleteInputModel inputModel);
    }
}