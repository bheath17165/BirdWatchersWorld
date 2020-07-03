using BirdWatchersWorld.Models;
using BirdWatchersWorld.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirdWatchersWorld.WebMVC.Controllers
{
    [Authorize]
    public class BirdController : Controller
    {
        // GET: Bird
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BirdService(userId);
            var model = service.GetBirds();

            return View(model);
        }

        // GET: Bird/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bird/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BirdCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBirdService();

            if (service.CreateBird(model))
            {
                TempData["SaveResult"] = "The bird was spotted!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The bird could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBirdService();
            var model = svc.GetBirdByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBirdService();
            var detail = service.GetBirdByID(id);
            var model =
                new BirdEdit
                {
                    BirdID = detail.BirdID,
                    Name = detail.Name,
                    MainColor = detail.MainColor,
                    SecondColor = detail.SecondColor
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BirdEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BirdID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateBirdService();

            if (service.UpdateBird(model))
            {
                TempData["SaveResult"] = "The bird was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The bird could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBirdService();
            var model = svc.GetBirdByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBird(int id)
        {
            var service = CreateBirdService();

            service.DeleteBird(id);

            TempData["SaveResult"] = "The bird was deleted";

            return RedirectToAction("Index");
        }

        private BirdService CreateBirdService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BirdService(userId);
            return service;
        }
    }
}