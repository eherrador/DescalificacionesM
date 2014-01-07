using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DescalificacionesM.Models;

namespace DescalificacionesM.Controllers
{
    public class HeatController : Controller
    {
        private DescalificacionesFMNEntities db = new DescalificacionesFMNEntities();

        //
        // GET: /Heat/

        public ActionResult Index()
        {
            var heats = db.Heats.Include(h => h.Prueba);
            return View(heats.ToList());
        }

        //
        // GET: /Heat/Details/5

        public ActionResult Details(int id = 0)
        {
            Heat heat = db.Heats.Find(id);
            if (heat == null)
            {
                return HttpNotFound();
            }
            return View(heat);
        }

        //
        // GET: /Heat/Create

        public ActionResult Create()
        {
            ViewBag.PruebaID = new SelectList(db.Pruebas, "PruebaID", "PruebaID");
            return View();
        }

        //
        // POST: /Heat/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Heat heat)
        {
            if (ModelState.IsValid)
            {
                db.Heats.Add(heat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PruebaID = new SelectList(db.Pruebas, "PruebaID", "PruebaID", heat.PruebaID);
            return View(heat);
        }

        //
        // GET: /Heat/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Heat heat = db.Heats.Find(id);
            if (heat == null)
            {
                return HttpNotFound();
            }
            ViewBag.PruebaID = new SelectList(db.Pruebas, "PruebaID", "PruebaID", heat.PruebaID);
            return View(heat);
        }

        //
        // POST: /Heat/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Heat heat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PruebaID = new SelectList(db.Pruebas, "PruebaID", "PruebaID", heat.PruebaID);
            return View(heat);
        }

        //
        // GET: /Heat/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Heat heat = db.Heats.Find(id);
            if (heat == null)
            {
                return HttpNotFound();
            }
            return View(heat);
        }

        //
        // POST: /Heat/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Heat heat = db.Heats.Find(id);
            db.Heats.Remove(heat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}