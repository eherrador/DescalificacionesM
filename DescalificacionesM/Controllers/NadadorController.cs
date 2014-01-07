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
    public class NadadorController : Controller
    {
        private DescalificacionesFMNEntities db = new DescalificacionesFMNEntities();

        //
        // GET: /Nadador/

        public ActionResult Index()
        {
            var nadadors = db.Nadadors.Include(n => n.Descalificacion);
            return View(nadadors.ToList());
        }

        //
        // GET: /Nadador/Details/5

        public ActionResult Details(int id = 0)
        {
            Nadador nadador = db.Nadadors.Find(id);
            if (nadador == null)
            {
                return HttpNotFound();
            }
            return View(nadador);
        }

        //
        // GET: /Nadador/Create

        public ActionResult Create()
        {
            ViewBag.DescalificacionID = new SelectList(db.Descalificacions, "DescalificacionID", "CodigoFINA1");
            return View();
        }

        //
        // POST: /Nadador/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nadador nadador)
        {
            if (ModelState.IsValid)
            {
                db.Nadadors.Add(nadador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DescalificacionID = new SelectList(db.Descalificacions, "DescalificacionID", "CodigoFINA1", nadador.DescalificacionID);
            return View(nadador);
        }

        //
        // GET: /Nadador/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Nadador nadador = db.Nadadors.Find(id);
            if (nadador == null)
            {
                return HttpNotFound();
            }
            ViewBag.DescalificacionID = new SelectList(db.Descalificacions, "DescalificacionID", "CodigoFINA1", nadador.DescalificacionID);
            return View(nadador);
        }

        //
        // POST: /Nadador/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Nadador nadador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nadador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DescalificacionID = new SelectList(db.Descalificacions, "DescalificacionID", "CodigoFINA1", nadador.DescalificacionID);
            return View(nadador);
        }

        //
        // GET: /Nadador/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Nadador nadador = db.Nadadors.Find(id);
            if (nadador == null)
            {
                return HttpNotFound();
            }
            return View(nadador);
        }

        //
        // POST: /Nadador/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nadador nadador = db.Nadadors.Find(id);
            db.Nadadors.Remove(nadador);
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