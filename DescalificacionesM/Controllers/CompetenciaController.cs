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
    public class CompetenciaController : Controller
    {
        private DescalificacionesFMNEntities db = new DescalificacionesFMNEntities();

        //
        // GET: /Competencia/

        public ActionResult Index()
        {
            return View(db.Competencias.ToList());
        }

        //
        // GET: /Competencia/Details/5

        public ActionResult Details(int id = 0)
        {
            Competencia competencia = db.Competencias.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        //
        // GET: /Competencia/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Competencia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Competencia competencia)
        {
            if (ModelState.IsValid)
            {
                db.Competencias.Add(competencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competencia);
        }

        //
        // GET: /Competencia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Competencia competencia = db.Competencias.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        //
        // POST: /Competencia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Competencia competencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competencia);
        }

        //
        // GET: /Competencia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Competencia competencia = db.Competencias.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        //
        // POST: /Competencia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competencia competencia = db.Competencias.Find(id);
            db.Competencias.Remove(competencia);
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