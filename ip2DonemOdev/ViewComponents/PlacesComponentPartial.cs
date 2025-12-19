using ip2DonemOdev.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ip2DonemOdev.ViewComponents
{
    public class PlacesComponentPartial : ViewComponent
    {
        MyContext MyContext = new MyContext();
        public IViewComponentResult Invoke()
        {
            var place = MyContext.Places.ToList();
            return View(place);
        }
    }
}
