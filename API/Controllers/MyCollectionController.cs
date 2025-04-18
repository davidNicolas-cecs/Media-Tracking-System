using MediaNest.Application.UseCases.UserCollectionManagment;
using MediaNest.Domain.Model;
using MediaNest.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class MyCollectionController : Controller
    {
        private readonly IUserCollectionService _userCollectionService;
        private UserManager<ApplicationUser> _userManager;

        public MyCollectionController(IUserCollectionService collectionService, UserManager<ApplicationUser> userManager)
        
        {
            _userCollectionService = collectionService;
            _userManager = userManager;

            }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            
            var id = user.Id;
            Console.WriteLine(id);
            if (id is not null)
            {

                if (ModelState.IsValid)
                {
                    var mediaItems = await _userCollectionService.GetAllUserMediaItems(id);
                    return View(mediaItems);
                }
                
            }
            return View();
        }

        [HttpPost]
        public async Task AddToCollection([FromBody] int mediaItemId) // pass in user id
        {
            if (ModelState.IsValid)
            {
                // get user first

                Console.WriteLine(1);
            }
            
        }
    }
}
