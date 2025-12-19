using ip2DonemOdev.DAL.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ip2DonemOdev.Controllers
{
   
    public class CountryCitiesController : Controller
    {   
        [Authorize]
        public IActionResult Index()
        {          
            return View();
        }
    }
}