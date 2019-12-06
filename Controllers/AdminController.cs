using Airways.Helper;
using Airways.Models;
using Airways.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Airways.Controllers
{
    public class AdminController : Controller
    {
        private readonly IFlyService _flyService;
        private readonly ICityService _cityService;

        public AdminController(IFlyService flyService, ICityService cityService)
        {
            _flyService = flyService;
            _cityService = cityService;
        }

        // GET: List
        [HttpGet("/List")]
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() =>
            {
                HttpContext.Session.SetString("_Identity", "Admin");
                return View();
            });
        }

        // GET: Admin/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            return await Task.Run(() =>
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Main");
            });
        }

        // GET: Admin/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var cities = await _cityService.All();
            ViewBag.Departure = new SelectList(cities, "Id", "Name");
            ViewBag.Arrival = new SelectList(cities, "Id", "Name");

            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fly flyModel)
        {
            flyModel.Number = StringUtilsHelper.getNumber();

            if (ModelState.IsValid)
            {
                await _flyService.Add(flyModel);

                return RedirectToAction(nameof(Index));
            }

            var cities = await _cityService.All();
            ViewBag.Departure = new SelectList(cities, "Id", "Name");
            ViewBag.Arrival = new SelectList(cities, "Id", "Name");

            return View(flyModel);
        }


        // GET: Admin/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _flyService.GetById(id);

            var cities = await _cityService.All();
            ViewBag.Departure = new SelectList(cities, "Id", "Name");
            ViewBag.Arrival = new SelectList(cities, "Id", "Name");

            return View(model);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fly flyModel)
        {
            if (ModelState.IsValid)
            {
                 await _flyService.Update(flyModel);

                 return RedirectToAction(nameof(Index));
            }

            var cities = await _cityService.All();
            ViewBag.Departure = new SelectList(cities, "Id", "Name");
            ViewBag.Arrival = new SelectList(cities, "Id", "Name");

            return View(flyModel);
        }

        // GET: Admin/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _flyService.Delete(id);
            }
            catch
            {
            }

            return RedirectToAction(nameof(Index));
        }

    }
}