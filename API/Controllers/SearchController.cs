using API.ViewModels;
using MediaNest.Application.UseCases.MediaManagment;
using MediaNest.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        
        private readonly MediaItemService _mediaItemService;


        public SearchController(MediaItemService mediaItems)
        {
            _mediaItemService = mediaItems;
        }
        public IActionResult Index()
        {
            var viewModel = new SearchPageViewModel
            {
                SearchRequest = new MediaItemSearchRequest
                {
                    SearchText = string.Empty // Initialize required property  
                },
                SearchResult = new List<MediaItem>()
            };
            return View(viewModel);
        }

        [HttpPost]
        // From body is from the js post 
        public async Task<IActionResult> SearchMediaItem([FromBody] MediaItemSearchRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.SearchText))
            {
                return BadRequest("Invalid search request.");
            }

            var results = await _mediaItemService.SearchMediaItems(request);
            return PartialView("_SearchResult", results);
        }

        // Show details + the option for user to add to list 
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return BadRequest("No Id Found");
            }
            var mediaItem = await _mediaItemService.GetMediaItemById((int)Id);
            return View(mediaItem);
        }
    }
}
