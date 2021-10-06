using System.Threading.Tasks;
using App.Models.InputModels.Docenti;
using App.Models.ViewModels.Docenti;

namespace App.Models.Services.Application.Docenti
{
    public interface IDocentiService
    {
        Task<DocenteDetailViewModel> CreateDocenteAsync(DocenteCreateInputModel inputModel);
    }
}