using App.Models.Services.Infrastructure;
using App.Models.ValueTypes;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index([FromServices] IErrorViewSelectorService errorViewSelectorService)
        {
            ErrorViewData errorViewData = errorViewSelectorService.GetErrorViewData(HttpContext);

            ViewData["Title"] = "Errore";
            ViewData["TitleMessage"] = errorViewData.Title;
            ViewData["Message"] = errorViewData.Message;

            Response.StatusCode = (int) errorViewData.StatusCode;
            return View(errorViewData.ViewName);
        }
    }
}