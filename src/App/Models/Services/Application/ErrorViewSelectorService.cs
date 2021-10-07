using System.Net;
using App.Models.Exceptions.Application;
using App.Models.Services.Infrastructure;
using App.Models.ValueTypes;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace App.Models.Services.Application
{
    public class ErrorViewSelectorService : IErrorViewSelectorService
    {
        public ErrorViewData GetErrorViewData(HttpContext context)
        {
            var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;

            return exception switch
            {
                null => new ErrorViewData(

                //NOT FOUND
                    message: "La pagina richiesta non esiste.",
                    statusCode: HttpStatusCode.NotFound,
                    viewName: "NotFound"),

                DocenteNotFoundException exc => new ErrorViewData(
                    message: $"Docente {exc.IdDocente} non trovato",
                    statusCode: HttpStatusCode.NotFound,
                    viewName: "NotFound"),

                DatabaseUpdateException exc => new ErrorViewData(
                    message: $"Errore durante la creazione del docente {exc.NominativoDocente}",
                    statusCode: HttpStatusCode.InternalServerError,
                    viewName: "Unavailable"),

                _ => new ErrorViewData(message: "")
            };
        }
    }
}