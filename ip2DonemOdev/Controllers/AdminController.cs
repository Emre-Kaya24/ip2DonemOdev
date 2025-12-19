using ip2DonemOdev.DAL.Context;
using ip2DonemOdev.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json.Linq;

namespace ip2DonemOdev.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        MyContext _context = new MyContext();

        //nufüs CRUD işlemleri
        public IActionResult GetPopulation()
        {
            var value = _context.Populations.ToList();
            return View(value);
        }
        
        public IActionResult GetCreatePopulation()
        {
                return View();
        }
        [HttpPost]
        public IActionResult CreatePopulation(Population population)
        {
            population.Value = int.Parse(Request.Form["Value"].ToString().Replace(".", "").Replace(",", ""));
            _context.Populations.Add(population);
            _context.SaveChanges();
            return RedirectToAction("GetPopulation");
        }
        [HttpGet]
        public IActionResult UpdatePopulation(int id)
        {
            var value = _context.Populations.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdatePopulation(Population population)
        {
            _context.Populations.Update(population);
            _context.SaveChanges();
            return RedirectToAction("GetPopulation");
        }

        public IActionResult DeletePopulation(int id)
        {
            var value = _context.Populations.Find(id);
            _context.Populations.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("GetPopulation");
        }
        //nufüs CRUD işlemleri Bitiş



        //Admin Cities CRUD işlemleri

        public IActionResult GetCities()
        {
            var value = _context.Cities.ToList();
            return View(value);
        }

        public IActionResult Cities()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCities(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
            return RedirectToAction("GetCities");
        }

        [HttpGet]
        public IActionResult UpdateCities(int id)
        {
            var value = _context.Cities.Find(id)
                ;
            return View(value);

        }
        [HttpPost]
        public IActionResult UpdateCities(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
            return RedirectToAction("GetCities");
        }
        public IActionResult DeleteCities(int id)
        {
            var value = _context.Cities.Find(id);
            _context.Cities.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("GetCities");
        }
        //Admin Cities BİTİŞ 


        //Admin  CRUD işlemleri

        public IActionResult Travel()
        {
            var value = _context.Places.ToList();
            return View(value);
        }
        [HttpGet]
        public IActionResult CreatePlace()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePlace(Place place)
        {
            var value = _context.Places.Add(place);
            _context.SaveChanges();
            return RedirectToAction("Travel");
        }
        [HttpGet]
        public IActionResult UpdatePlace(int id)
        {
            var value = _context.Places.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdatePlace(Place place)
        {
            _context.Places.Update(place);
            _context.SaveChanges();
            return RedirectToAction("Travel");

        }

        public IActionResult DeletePlace(int id)
        {
            var value = _context.Places.Find(id);
            _context.Places.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Travel");
        }


        //Slider CRUD işlemleri
        public IActionResult Slider()
        {
            var value = _context.Sliders.ToList();
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }
        [HttpPost]

        public IActionResult CreateSlider(Slider slider, IFormFile ImageFile)
        {
            if (ImageFile == null || ImageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Slider resmi seçmelisiniz.");
                return View(slider);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Slider", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                ImageFile.CopyTo(stream);
            }

            slider.Image = "/Slider/" + fileName;

            if (string.IsNullOrWhiteSpace(slider.Description))
            {
                slider.Description = "Açıklama bulunmuyor.";
            }

            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction("Slider");
        }

        [HttpGet]
        public IActionResult UpdateSlider(int id)
        {
            var slider = _context.Sliders.Find(id);
            
            return View(slider);
        }

        [HttpPost]
        public IActionResult UpdateSlider(Slider slider, IFormFile ImageFile)
        {
            var existingSlider = _context.Sliders.Find(slider.Id);
            if (existingSlider == null)
            {
                return NotFound();
            }

            // Başlığı ve açıklamayı güncelle
            existingSlider.Title = slider.Title;
            existingSlider.Description = string.IsNullOrWhiteSpace(slider.Description)
                ? "Açıklama bulunmuyor."
                : slider.Description;

            // Resim yüklenmişse kaydet ve güncelle
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Slider", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                existingSlider.Image = "/Slider/" + fileName;
            }
            // Resim yüklenmemişse eski resim korunur

            _context.Sliders.Update(existingSlider);
            _context.SaveChanges();

            return RedirectToAction("Slider");
        }


        public IActionResult DeleteSlider(int id)
        {
            var slider = _context.Sliders.Find(id);
            if (slider == null)
            {
                return NotFound();
            }

            // Slider resmini sil (varsa)
            if (!string.IsNullOrEmpty(slider.Image))
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", slider.Image.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.Sliders.Remove(slider);
            _context.SaveChanges();

            return RedirectToAction("Slider");
        }

        public IActionResult GetUsers()
        {
            var value = _context.Users.ToList();
            return View(value);
        }

        [HttpGet]
        public IActionResult UpdateUsers(int id)
        {
            var value = _context.Users.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateUsers(User user, string Password)
        {
            var existingUser = _context.Users.Find(user.Id);

            if (existingUser == null)
                return NotFound();

            existingUser.Email = user.Email;
            existingUser.IsAdmin = user.IsAdmin;

            // Şifre boş değilse hashleyip güncelle
            if (!string.IsNullOrWhiteSpace(Password))
            {
                existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);
            }

            _context.SaveChanges();
            return RedirectToAction("GetUsers");
        }

        public IActionResult DeleteUsers(int id)
        {
            var value = _context.Users.Find(id);
            _context.Users.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("GetUsers");
        }

    }
}


