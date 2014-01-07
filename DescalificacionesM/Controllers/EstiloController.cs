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
    public class EstiloController : Controller
    {
        private DescalificacionesFMNEntities db = new DescalificacionesFMNEntities();

        //
        // GET: /Estilo/

        public ActionResult Index()
        {
            return View(db.Estiloes.ToList());
        }

        //
        // GET: /Estilo/Details/5

        public ActionResult Details(int id = 0)
        {
            Estilo estilo = db.Estiloes.Find(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        //
        // GET: /Estilo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Estilo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estilo estilo)
        {
            if (ModelState.IsValid)
            {
                db.Estiloes.Add(estilo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estilo);
        }

        //
        // GET: /Estilo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Estilo estilo = db.Estiloes.Find(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        //
        // POST: /Estilo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Estilo estilo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estilo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estilo);
        }

        //
        // GET: /Estilo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Estilo estilo = db.Estiloes.Find(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        //
        // POST: /Estilo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estilo estilo = db.Estiloes.Find(id);
            db.Estiloes.Remove(estilo);
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