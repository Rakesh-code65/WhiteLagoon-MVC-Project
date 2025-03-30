using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Web.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaNumberController(ApplicationDbContext db) : Controller
    {
        //ApplicationDbContext app = new ApplicationDbContext()
        //{
        //    // use this in net framework old  dotnet technology 
        //}
        private readonly ApplicationDbContext _db = db;

        public IActionResult Index()
        {
            var villaNumbers = _db.VillaNumbers.Include(u=>u.Villa).ToList();

            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _db.Villas.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            //IEnumerable<SelectListItem> list = _db.Villas.ToList().Select(u=>  new SelectListItem
            //{
            //    Text= u.Name,
            //    Value = u.Id.ToString()
            //});

            //ViewData["VillaList"] = list;
            //ViewBag.VillaList = list;

            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)


        {
            // ModelState.Remove("Villa");
            //if (obj.Name == obj.Description)
            //{
            //    ModelState.AddModelError("name", "The Decription Cannot exactly match the same.");
            //}
            bool roomNumberExists = _db.VillaNumbers.Any(u => u.Villa_Number == obj.VillaNumber.Villa_Number);

            if (ModelState.IsValid && !roomNumberExists)
            {
                _db.VillaNumbers.Add(obj.VillaNumber);
                _db.SaveChanges();
                TempData["success"] = "The villa Numbers has been Created Successfully";
                return RedirectToAction("Index");
            }
            if (roomNumberExists)
            {
                TempData["error"] = "The villa Number already exists";

            }
            obj.VillaList = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            
            return View(obj);
        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);
            //Villa? obj = _db.Villas.Find(villaId);
            // var VillaList = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 0);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Update(Villa obj)
        {

            if (ModelState.IsValid && obj.Id > 0)
            {
                _db.Villas.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "The villa has been updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _db.Villas.FirstOrDefault(u => u.Id == obj.Id);

            if (objFromDb is not null)
            {
                _db.Villas.Remove(objFromDb);
                _db.SaveChanges();
                TempData["error"] = "The villa has been Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
