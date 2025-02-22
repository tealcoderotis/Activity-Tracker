using ActivityTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ActivityTracker.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db, ILogger<HomeController> logger) {
            this.db = db;
            _logger = logger;
        }

        public IActionResult Index() {
            var activites = db.Activities.ToList();
            return View(activites);
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Activity activity) {
            if (ModelState.IsValid) {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                return BadRequest();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return base.View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
