using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Infrastructure.Migrations;
using WhiteLagoon.Web.Models.ViewModels;


namespace WhiteLagoon.Web.Controllers
{
    public class AmenityController : Controller
    {
        //ApplicationDbContext app = new ApplicationDbContext()
        //{
        //    // use this in net framework old  dotnet technology 
        //}
        //private readonly ApplicationDbContext _db;

        //public AmenityController(ApplicationDbContext db)
        //{
        //    _db = db;
        //} // These lines are used but now it is replaced with the new Iunitofwork.
        private readonly IUnitOfWork _unitOfWork;
        public AmenityController(IUnitOfWork unitOfWork)
        {
            //_villaRepo = villaRepo;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //var amenities = _db.Amenitys.Include(u=>u.Villa).ToList();
            //replaced with the new words i.e, unitofwork
            var amenities = _unitOfWork.Amenity.GetAll(inlcudeProperties: "Villa");
            // This will be property name of IVillaRepository inside the IUnitofWork interface.
            return View(amenities);
        }

        public IActionResult Create()
        {
            AmenityVM amenityVM = new()
            {
                //VillaList = _db.Villas.ToList().Select(u => new SelectListItem
                VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
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

            return View(amenityVM);
        }

        [HttpPost]
        public IActionResult Create(AmenityVM obj)


        {
            // ModelState.Remove("Villa");
            //if (obj.Name == obj.Description)
            //{
            //    ModelState.AddModelError("name", "The Decription Cannot exactly match the same.");
            //}
           

            if (ModelState.IsValid )
            {
                //_db.Amenitys.Add(obj.Amenity);
                //_db.SaveChanges();
                _unitOfWork.Amenity.Add(obj.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "The amenity has been Created Successfully";
                return RedirectToAction(nameof(Index));
            }
           
            obj.VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            
            return View(obj);
        }
       
        public IActionResult Update(int amenityId)
        {
            AmenityVM amenityVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Amenity = _unitOfWork.Amenity.Get(u=> u.Id == amenityId)
            };
            //Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);
            //Villa? obj = _db.Villas.Find(villaId);
            // var VillaList = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 0);
            if (amenityVM.Amenity == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(amenityVM);
        }
        [HttpPost]
        public IActionResult Update(AmenityVM amenityVM)
        {
            
            if (ModelState.IsValid )
            {
                //_db.Amenitys.Update(amenityVM.Amenity);
                //_db.SaveChanges();
                _unitOfWork.Amenity.Update(amenityVM.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "The amenity has been updated Successfully";
                return RedirectToAction(nameof(Index));
            }

            amenityVM.VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(amenityVM);


        }

        public IActionResult Delete(int amenityId)
        {
            //Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);
            //if (obj is null)
            //{
            //    return RedirectToAction("Error", "Home");
            //}
            //return View(obj);

            AmenityVM amenityVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
            };
            
            if (amenityVM.Amenity == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(amenityVM);
        }
        [HttpPost]
        public IActionResult Delete(AmenityVM amenityVM)
        {
            Domain.Entities.Amenity? objFromDb = _unitOfWork.Amenity.Get(u => u.Id == amenityVM.Amenity.Id);

            if (objFromDb is not null)
            {
                //_db.Amenitys.Remove(objFromDb);
                _unitOfWork.Amenity.Remove(objFromDb);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "The amenity has been Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The amenity could not be deleted.";
            return View();
        }

    }
}
