using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
