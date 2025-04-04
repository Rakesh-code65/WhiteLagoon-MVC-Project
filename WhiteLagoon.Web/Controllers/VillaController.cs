﻿using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller

    {
        private readonly IVillaRepository _villaRepo;
        public VillaController(IVillaRepository villaRepo)
        {
            _villaRepo = villaRepo;
        }
        public IActionResult Index()
        {
            //var villas = _db.Villas.ToList();
            var villas = _villaRepo.GetAll();

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
                //db.Villas.Add(obj);
                _villaRepo.Add(obj); //model implementation
                //db.SaveChanges();
                _villaRepo.Save(); //model save implementation
                TempData["success"] = "The villa has been Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Update(int villaId)
        {
            //Villa? obj = db.Villas.FirstOrDefault(u => u.Id == villaId);
            Villa? obj = _villaRepo.Get(u => u.Id == villaId);
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
                //db.Villas.Update(obj);
                _villaRepo.Update(obj);  // model implementation of update
                //db.SaveChanges();
                _villaRepo.Save();    // model implementation of update
                TempData["success"] = "The villa has been updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            //Villa? obj = db.Villas.FirstOrDefault(u => u.Id == villaId);
            Villa? obj = _villaRepo.Get(u => u.Id == villaId);
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
            Villa? objFromDb = _villaRepo.Get(u => u.Id == obj.Id);

            if (objFromDb is not null)
            {
                //db.Villas.Remove(objFromDb);
                _villaRepo.Remove(objFromDb);
                //db.SaveChanges();
                _villaRepo.Save();
                TempData["error"] = "The villa has been Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    
    }
}
