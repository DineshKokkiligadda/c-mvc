using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SpendSmartDB _context;
        public HomeController(ILogger<HomeController> logger, SpendSmartDB context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Expence()
        {
            var allExpence = _context.Expence.ToList();
            return View(allExpence);
        }
        public IActionResult CreateEditExpence(int? id)
        {
            if (id != null)
            {
                var expenceDB = _context.Expence.SingleOrDefault(expence => expence.Id == id);
                return View(expenceDB);
            }
            return View();
        }
        public IActionResult DeleteExpence(int Id)
        {
            var expenceDB = _context.Expence.SingleOrDefault(expence => expence.Id == Id);
            _context.Expence.Remove(expenceDB);
            _context.SaveChanges();
            return RedirectToAction("Expence");
        }
        public IActionResult CreateEditExpenceForm(Expence model)
        {
            if (model.Id == 0)
            {
                _context.Expence.Add(model);
            }
            else
            {
                _context.Expence.Update(model);
            }
            _context.Expence.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Expence");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
