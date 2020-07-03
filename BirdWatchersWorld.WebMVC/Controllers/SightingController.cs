using BirdWatchersWorld.Models;
using BirdWatchersWorld.Models.Sighting;
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
    public class SightingController : Controller
    {
        // GET: Sighting
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SightingService(userId);
            var model = service.GetSightings();

            return View(model);
        }

        // GET: Sighting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sighting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SightingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSightingService();

            if (service.CreateSighting(model))
            {
                TempData["SaveResult"] = "The sighting was added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The sighting could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSightingService();
            var model = svc.GetSightingByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSightingService();
            var detail = service.GetSightingByID(id);
            var model =
                new SightingEdit
                {
                    SightingID = detail.SightingID,
                    TimeSeen = detail.TimeSeen
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SightingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SightingID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateSightingService();

            if (service.UpdateSighting(model))
            {
                TempData["SaveResult"] = "The sighting was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The sighting could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSightingService();
            var model = svc.GetSightingByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSighting(int id)
        {
            var service = CreateSightingService();

            service.DeleteSighting(id);

            TempData["SaveResult"] = "The sighting was deleted";

            return RedirectToAction("Index");
        }

        private SightingService CreateSightingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SightingService(userId);
            return service;
        }
    }
}