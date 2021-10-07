using System.Threading.Tasks;
using App.Models.InputModels.Docenti;
using App.Models.Services.Application.Docenti;
using App.Models.ViewModels;
using App.Models.ViewModels.Docenti;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class DocentiController : Controller
    {
        private readonly IDocentiService docenti;
        public DocentiController(IDocentiService docenti)
        {
            this.docenti = docenti;
        }

        public async Task<IActionResult> Index(DocenteListInputModel input)
        {
            ViewData["Title"] = "Gestione docenti";
            ListViewModel<DocenteViewModel> docente = await docenti.GetDocentiAsync(input);
            DocenteListViewModel viewModel = new()
            {
                Docente = docente,
                Input = input
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Creazione scheda docente";
            DocenteCreateInputModel inputModel = new();

            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DocenteCreateInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                DocenteDetailViewModel docente = await docenti.CreateDocenteAsync(inputModel);
                TempData["ConfirmationMessage"] = "Il docente è stato creato con successo";
                return RedirectToAction(nameof(DocentiController.Edit), "Docenti", new { IdDocente = docente.IdDocente });
            }

            return View(inputModel);
        }

        public async Task<IActionResult> Detail(string IdDocente)
        {
            ViewData["Title"] = "Dettaglio scheda docente";
            DocenteDetailViewModel viewModel = await docenti.GetDocenteAsync(IdDocente);
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(string IdDocente)
        {
            ViewData["Title"] = "Modifica scheda docente";
            DocenteEditInputModel inputModel = await docenti.GetDocenteForEditingAsync(IdDocente);
            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DocenteEditInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                DocenteDetailViewModel docente = await docenti.EditDocenteAsync(inputModel);
                TempData["ConfirmationMessage"] = "I dati sono stati aggiornati con successo";
                return RedirectToAction(nameof(DocentiController.Detail), "Docenti", new { IdDocente = inputModel.IdDocente });
            }

            ViewData["Title"] = "Modifica scheda docente";
            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DocenteDeleteInputModel inputModel)
        {
            await docenti.DeleteDocenteAsync(inputModel);
            TempData["ConfirmationMessage"] = "Il docente è stato eliminato";
            return RedirectToAction(nameof(DocentiController.Index));
        }
    }
}