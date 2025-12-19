using ip2DonemOdev.DAL.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ip2DonemOdev.Controllers
{
    public class PopulationController : Controller
    {
        MyContext _context = new MyContext();

        [Authorize]
        public IActionResult GetPopulation()
        {
            var values = _context.Populations.ToList();
            return View(values);
        }

      
    }
}
