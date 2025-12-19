using ip2DonemOdev.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ip2DonemOdev.ViewComponents
{
    public class _CountryPromotionComponentPartial : ViewComponent
    {
        MyContext _context = new MyContext();
        public IViewComponentResult Invoke()
        {
            var cities = _context.Cities.ToList();
            return View();
        }
    }
}
