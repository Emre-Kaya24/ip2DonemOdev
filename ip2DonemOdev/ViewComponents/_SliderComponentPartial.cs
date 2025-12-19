using ip2DonemOdev.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ip2DonemOdev.ViewComponents
{
    public class _SliderComponentPartial : ViewComponent
    {
        MyContext _context = new MyContext();
        public IViewComponentResult Invoke()
        {
            var sliders = _context.Sliders.ToList();
            return View(sliders);
        }
    }
}
