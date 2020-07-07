using BirdWatchersWorld.Models;
using BirdWatchersWorld.Models.Spotting;
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
    public class SpotterController : Controller
    {
        // GET: Spotter
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpotterService(userId);
            var model = service.GetSpotters();

            return View(model);
        }

        // GET: Spotter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spotter/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpotterCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSpotterService();

            if (service.CreateSpotter(model))
            {
                TempData["SaveResult"] = "The potter was added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The spotter could not be added.");

            return View(model);
        }

        public ActionResult Details(string id)
        {
            var svc = CreateSpotterService();
            var model = svc.GetSpotterByID(id);

            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var service = CreateSpotterService();
            var detail = service.GetSpotterByID(id);
            var model =
                new SpotterEdit
                {
                    Id = detail.Id,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, SpotterEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateSpotterService();

            if (service.UpdateSpotter(model))
            {
                TempData["SaveResult"] = "The spotter was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The spotter could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(string id)
        {
            var svc = CreateSpotterService();
            var model = svc.GetSpotterByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSpotter(string id)
        {
            var service = CreateSpotterService();

            service.DeleteSpotter(id);

            TempData["SaveResult"] = "The spotter was deleted";

            return RedirectToAction("Index");
        }

        private SpotterService CreateSpotterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpotterService(userId);
            return service;
        }
    }
}