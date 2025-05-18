using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Infrastructure.Repository;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller

    {
        //private readonly IVillaRepository _villaRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment; // FOR IMAGE TO UPLOAD

        public VillaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            //_villaRepo = villaRepo;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //var villas = _db.Villas.ToList();
            //var villas = _villaRepo.GetAll();
            var villas = _unitOfWork.Villa.GetAll();

            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa obj)


        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The Decription Cannot exactly match the same.");
            }
            if (ModelState.IsValid)
            {
                //Image part started
                if (obj.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImage");

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    obj.Image.CopyTo(fileStream);

                    obj.ImageUrl = @"\images\VillaImage\" + fileName;

                }
                else
                {
                    obj.ImageUrl = "https://placehold.co/600*400";

                }
                // Image  upload part ended here.
                    //db.Villas.Add(obj);
                    /* _villaRepo.Add(obj); *///model implementation
                    _unitOfWork.Villa.Add(obj);
                //db.SaveChanges();
               /* _villaRepo.Save();*/ //model save implementation
                _unitOfWork.Save();
                TempData["success"] = "The villa has been Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Update(int villaId)
        {
            //Villa? obj = db.Villas.FirstOrDefault(u => u.Id == villaId);

            Villa? obj = _unitOfWork.Villa.Get(u => u.Id == villaId);

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

                if (obj.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImage");

                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.Trim('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    obj.Image.CopyTo(fileStream);

                    obj.ImageUrl = @"\images\VillaImage\" + fileName;

                }
               

                //db.Villas.Update(obj);
                /*_villaRepo.Update(obj); */ // model implementation of update
                _unitOfWork.Villa.Update(obj);
                //db.SaveChanges();
                _unitOfWork.Save();
                /*_villaRepo.Save();  */  // model implementation of update
                TempData["success"] = "The villa has been updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            //Villa? obj = db.Villas.FirstOrDefault(u => u.Id == villaId);
            Villa? obj = _unitOfWork.Villa.Get(u => u.Id == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            //Villa? objFromDb = db.Villas.FirstOrDefault(u => u.Id == obj.Id);
            Villa? objFromDb = _unitOfWork.Villa.Get(u => u.Id == obj.Id);

            if (objFromDb is not null)
            {

                if (!string.IsNullOrEmpty(objFromDb.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.ImageUrl.Trim('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                //db.Villas.Remove(objFromDb);
                _unitOfWork.Villa.Remove(objFromDb);
                //db.SaveChanges();
                _unitOfWork.Save();
                TempData["error"] = "The villa has been Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    
    }
}
