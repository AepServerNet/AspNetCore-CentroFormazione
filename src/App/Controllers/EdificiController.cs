using System.Threading.Tasks;
using App.Models.InputModels.Edifici;
using App.Models.Services.Application.Edifici;
using App.Models.ViewModels;
using App.Models.ViewModels.Edifici;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class EdificiController : Controller
    {
        private readonly IEdificiService edifici;
        public EdificiController(IEdificiService edifici)
        {
            this.edifici = edifici;
        }

        public async Task<IActionResult> Index(EdificioListInputModel input)
        {
            ViewData["Title"] = "Gestione edifici";
            ListViewModel<EdificioViewModel> edificio = await edifici.GetEdificiAsync(input);
            EdificioListViewModel viewModel = new()
            {
                Edificio = edificio,
                Input = input
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Creazione scheda edificio";
            EdificioCreateInputModel inputModel = new();

            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EdificioCreateInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                EdificioDetailViewModel edificio = await edifici.CreateEdificioAsync(inputModel);
                TempData["ConfirmationMessage"] = "Il laboratorio è stato creato con successo";
                return RedirectToAction(nameof(EdificiController.Edit), "Edifici", new { IdEdificio = edificio.IdEdificio });
            }

            return View(inputModel);
        }

        public async Task<IActionResult> Detail(string IdEdificio)
        {
            ViewData["Title"] = "Dettaglio scheda edificio";
            EdificioDetailViewModel viewModel = await edifici.GetEdificioAsync(IdEdificio);
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(string IdEdificio)
        {
            ViewData["Title"] = "Modifica scheda edificio";
            EdificioEditInputModel inputModel = await edifici.GetEdificioForEditingAsync(IdEdificio);
            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EdificioEditInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                EdificioDetailViewModel docente = await edifici.EditEdificioAsync(inputModel);
                TempData["ConfirmationMessage"] = "I dati sono stati aggiornati con successo";
                return RedirectToAction(nameof(EdificiController.Detail), "Edifici", new { IdEdificio = inputModel.IdEdificio });
            }

            ViewData["Title"] = "Modifica scheda laboratorio";
            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EdificioDeleteInputModel inputModel)
        {
            await edifici.DeleteEdificioAsync(inputModel);
            TempData["ConfirmationMessage"] = "Il laboratorio è stato eliminato";
            return RedirectToAction(nameof(DocentiController.Index));
        }
    }
}