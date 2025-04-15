using MediaNest.Application.UseCases.UserCollectionManagment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class MyCollectionController : Controller
    {
        private readonly IUserCollectionService _userCollectionService;

        public MyCollectionController(IUserCollectionService collectionService)
        {
            _userCollectionService = collectionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task AddToCollection([FromBody] int mediaItemId)
        {
            if (ModelState.IsValid)
            {
                var items = await _userCollectionService.GetAllUserMediaItems("1");
                Console.WriteLine(items);
            }
            
        }
    }
}
