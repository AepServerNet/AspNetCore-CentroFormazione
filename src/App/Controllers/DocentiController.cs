using App.Models.Enums;
using App.Models.InputModels.Docenti;
using App.Models.Services.Application.Docenti;
using App.Models.ValueTypes;
using Microsoft.AspNetCore.Mvc;
using SequentialGuid;

namespace App.Controllers
{
    public class DocentiController : Controller
    {
        private readonly IDocentiService docenti;
        public DocentiController(IDocentiService docenti)
        {
            this.docenti = docenti;
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Creazione scheda docente";

            DocenteCreateInputModel inputModel = new();

            inputModel.IdDocente = SequentialGuidGenerator.Instance.NewGuid().ToString();
            inputModel.Telefono = "Dato mancante";
            inputModel.Email = "Dato mancante";
            inputModel.Residenza = "Dato mancante";
            inputModel.CodiceCorso = "Dato mancante";
            inputModel.CodiceDipartimento = "Dato mancante";
            inputModel.CostoOrario = new Money(Currency.EUR, 0);

            return View(inputModel);
        }

    }
}