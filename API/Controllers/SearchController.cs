using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
    }
}
