using System.Net;
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

                message: "La pagina richiesta non esiste.",
                statusCode: HttpStatusCode.NotFound,
                viewName: "NotFound"),

                _ => new ErrorViewData(message: "")
            };
        }
    }
}