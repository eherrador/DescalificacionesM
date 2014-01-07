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
    public class RamaController : Controller
    {
        private DescalificacionesFMNEntities db = new DescalificacionesFMNEntities();

        //
        // GET: /Rama/

        public ActionResult Index()
        {
            return View(db.Ramas.ToList());
        }

        //
        // GET: /Rama/Details/5

        public ActionResult Details(int id = 0)
        {
            Rama rama = db.Ramas.Find(id);
            if (rama == null)
            {
                return HttpNotFound();
            }
            return View(rama);
        }

        //
        // GET: /Rama/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Rama/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rama rama)
        {
            if (ModelState.IsValid)
            {
                db.Ramas.Add(rama);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rama);
        }

        //
        // GET: /Rama/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Rama rama = db.Ramas.Find(id);
            if (rama == null)
            {
                return HttpNotFound();
            }
            return View(rama);
        }

        //
        // POST: /Rama/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rama rama)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rama).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rama);
        }

        //
        // GET: /Rama/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Rama rama = db.Ramas.Find(id);
            if (rama == null)
            {
                return HttpNotFound();
            }
            return View(rama);
        }

        //
        // POST: /Rama/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rama rama = db.Ramas.Find(id);
            db.Ramas.Remove(rama);
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