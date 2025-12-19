using System.Diagnostics;
using ip2DonemOdev.DAL.Context;
using ip2DonemOdev.Models;
using Microsoft.AspNetCore.Mvc;

namespace ip2DonemOdev.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MyContext _context = new MyContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Name = _context.Countries.Select(x => x.Name).FirstOrDefault();
            ViewBag.Description = _context.Countries.Select(x => x.Description).FirstOrDefault();
            ViewBag.Climate = _context.Countries.Select(x => x.Climate).FirstOrDefault();
            ViewBag.LocalLanguages = _context.Countries.Select(x => x.LocalLanguages).FirstOrDefault();
            ViewBag.Location = _context.Countries.Select(x => x.Location).FirstOrDefault();
            ViewBag.OfficialLanguage = _context.Countries.Select(x => x.OfficialLanguage).FirstOrDefault();
            ViewBag.Population = _context.Countries.Select(x => x.Population).FirstOrDefault();
            ViewBag.Capital = _context.Countries.Select(x => x.Capital).FirstOrDefault();
            return View();   
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
