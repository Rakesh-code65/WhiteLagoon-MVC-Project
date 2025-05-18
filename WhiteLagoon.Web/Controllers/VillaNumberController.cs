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
    public class VillaNumberController : Controller
    {
        //ApplicationDbContext app = new ApplicationDbContext()
        //{
        //    // use this in net framework old  dotnet technology 
        //}
        //private readonly ApplicationDbContext _db;

        //public VillaNumberController(ApplicationDbContext db)
        //{
        //    _db = db;
        //} // These lines are used but now it is replaced with the new Iunitofwork.
        private readonly IUnitOfWork _unitOfWork;
        public VillaNumberController(IUnitOfWork unitOfWork)
        {
            //_villaRepo = villaRepo;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //var villaNumbers = _db.VillaNumbers.Include(u=>u.Villa).ToList();
            //replaced with the new words i.e, unitofwork
            var villaNumbers = _unitOfWork.VillaNumber.GetAll(inlcudeProperties: "Villa");
            // This will be property name of IVillaRepository inside the IUnitofWork interface.
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            VillaNumberVM villaNumberVM = new()
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
            bool roomNumberExists = _unitOfWork.VillaNumber.Any(u => u.Villa_Number == obj.VillaNumber.Villa_Number);

            if (ModelState.IsValid && !roomNumberExists)
            {
                //_db.VillaNumbers.Add(obj.VillaNumber);
                //_db.SaveChanges();
                _unitOfWork.VillaNumber.Add(obj.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "The villa Numbers has been Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            if (roomNumberExists)
            {
                TempData["error"] = "The villa Number already exists";

            }
            obj.VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            
            return View(obj);
        }
       
        public IActionResult Update(int villaNumberId)
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                VillaNumber = _unitOfWork.VillaNumber.Get(u=> u.Villa_Number == villaNumberId)
            };
            //Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);
            //Villa? obj = _db.Villas.Find(villaId);
            // var VillaList = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 0);
            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberVM);
        }
        [HttpPost]
        public IActionResult Update(VillaNumberVM villaNumberVM)
        {
            
            if (ModelState.IsValid )
            {
                //_db.VillaNumbers.Update(villaNumberVM.VillaNumber);
                //_db.SaveChanges();
                _unitOfWork.VillaNumber.Update(villaNumberVM.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "The villa Numbers has been updated Successfully";
                return RedirectToAction(nameof(Index));
            }

            villaNumberVM.VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(villaNumberVM);


        }

        public IActionResult Delete(int villaNumberId)
        {
            //Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);
            //if (obj is null)
            //{
            //    return RedirectToAction("Error", "Home");
            //}
            //return View(obj);

            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                VillaNumber = _unitOfWork.VillaNumber.Get(u => u.Villa_Number == villaNumberId)
            };
            
            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberVM);
        }
        [HttpPost]
        public IActionResult Delete(VillaNumberVM villaNumberVM)
        {
            Domain.Entities.VillaNumber? objFromDb = _unitOfWork.VillaNumber.Get(u => u.Villa_Number == villaNumberVM.VillaNumber.Villa_Number);

            if (objFromDb is not null)
            {
                //_db.VillaNumbers.Remove(objFromDb);
                _unitOfWork.VillaNumber.Remove(objFromDb);
                //_db.SaveChanges();
                _unitOfWork.Save();
                TempData["success"] = "The villa Number has been Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The villa number could not be deleted.";
            return View();
        }

    }
}
