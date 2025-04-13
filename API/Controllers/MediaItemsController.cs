using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediaNest.Domain.Model;
using MediaNest.Application.UseCases.MediaManagment;

namespace API.Controllers
{
    public class MediaItemsController : Controller
    {
        // We implement the interface for servies (normally) because services adjusts the data given back by the Irepository files and adds extra logic (normally)
        // and so we depend on that implementation Controller <- Services <- Repository <- DB
        private readonly MediaItemService _mediaItemService;
        private static readonly string[] items = new[] { "SciFi", "Adventure", "Romance" };

        public MediaItemsController(MediaItemService mediaItemService)
        {
            _mediaItemService = mediaItemService;
        }

        // GET: MediaItems
        public async Task<IActionResult> Index()
        {
            return View(await _mediaItemService.GetMediaItemsAsync());
        }

        // GET: MediaItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaItem = await _mediaItemService.GetMediaItemById((int)id);
            if (mediaItem == null)
            {
                return NotFound();
            }

            return View(mediaItem);
        }

        // GET: MediaItems/Create
        public IActionResult Create()
        {
            ViewData["Genres"] = new MultiSelectList(items);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ISBN,Title,Description,Type,Year,Language,Genres,Rating")] MediaItem mediaItem)
        {
            if (ModelState.IsValid)
            {

                await _mediaItemService.AddMediaItem(mediaItem);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Genres = new MultiSelectList(items);

            return View(mediaItem);
        }

        // GET: MediaItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaItem = await _mediaItemService.GetMediaItemById((int)id);
            if (mediaItem == null)
            {
                return NotFound();
            }
            ViewBag.Genres = new MultiSelectList(items);

            return View(mediaItem);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ISBN,Title,Description,Type,Year,Language,Genres,Rating")] MediaItem mediaItem)
        {
            if (id != mediaItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _mediaItemService.UpdateMediaItem(mediaItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaItemExists(mediaItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mediaItem);
        }

        // GET: MediaItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaItem = await _mediaItemService.GetMediaItemById((int)id);
            if (mediaItem == null)
            {
                return NotFound();
            }

            return View(mediaItem);
        }

        // POST: MediaItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaItem = await _mediaItemService.GetMediaItemById(id);
            if (mediaItem != null)
            {
                await _mediaItemService.DeleteMediaItem(mediaItem);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MediaItemExists(int id)
        {
            return _mediaItemService.Exists(id);
        }
    }
}
