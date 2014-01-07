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
    public class DescalificacionController : Controller
    {
        private DescalificacionesFMNEntities db = new DescalificacionesFMNEntities();

        //
        // GET: /Descalificacion/

        public ActionResult Index()
        {
            var descalificacions = db.Descalificacions.Include(d => d.Estilo);
            return View(descalificacions.ToList());
        }

        //
        // GET: /Descalificacion/Details/5

        public ActionResult Details(int id = 0)
        {
            Descalificacion descalificacion = db.Descalificacions.Find(id);
            if (descalificacion == null)
            {
                return HttpNotFound();
            }
            return View(descalificacion);
        }

        //
        // GET: /Descalificacion/Create

        public ActionResult Create()
        {
            ViewBag.EstiloID = new SelectList(db.Estiloes, "EstiloID", "Descripcion");
            return View();
        }

        //
        // POST: /Descalificacion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Descalificacion descalificacion)
        {
            if (ModelState.IsValid)
            {
                db.Descalificacions.Add(descalificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstiloID = new SelectList(db.Estiloes, "EstiloID", "Descripcion", descalificacion.EstiloID);
            return View(descalificacion);
        }

        //
        // GET: /Descalificacion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Descalificacion descalificacion = db.Descalificacions.Find(id);
            if (descalificacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstiloID = new SelectList(db.Estiloes, "EstiloID", "Descripcion", descalificacion.EstiloID);
            return View(descalificacion);
        }

        //
        // POST: /Descalificacion/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Descalificacion descalificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descalificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstiloID = new SelectList(db.Estiloes, "EstiloID", "Descripcion", descalificacion.EstiloID);
            return View(descalificacion);
        }

        //
        // GET: /Descalificacion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Descalificacion descalificacion = db.Descalificacions.Find(id);
            if (descalificacion == null)
            {
                return HttpNotFound();
            }
            return View(descalificacion);
        }

        //
        // POST: /Descalificacion/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Descalificacion descalificacion = db.Descalificacions.Find(id);
            db.Descalificacions.Remove(descalificacion);
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