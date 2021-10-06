using App.Models.ValueTypes;
using Microsoft.AspNetCore.Http;

namespace App.Models.Services.Infrastructure
{
    public interface IErrorViewSelectorService
    {
        ErrorViewData GetErrorViewData(HttpContext context);
    }
}