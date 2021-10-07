using App.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Customizations.ViewComponents
{
    public class PaginationBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPaginationInfo model)
        {
            return View(model);
        }
    }
}