using ip2DonemOdev.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ip2DonemOdev.ViewComponents
{
    public class CountryCitiesComponentPartial : ViewComponent
    {
        MyContext _context = new MyContext();

        public IViewComponentResult Invoke()
        {
            var value = _context.Cities.ToList();
            return View(value);
        }
    }
}
