using MediaNest.Application.UseCases.UserCollectionManagment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class MyCollectionController : Controller
    {
        private readonly IUserCollectionService _userCollectionService;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToCollection([FromBody] int mediaItemId)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
