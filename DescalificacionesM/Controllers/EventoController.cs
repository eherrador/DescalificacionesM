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
    public class EventoController : Controller
    {
        private DescalificacionesFMNEntities db = new DescalificacionesFMNEntities();

        //
        // GET: /Evento/

        public ActionResult Index()
        {
            var eventoes = db.Eventoes.Include(e => e.Categoria).Include(e => e.Estilo).Include(e => e.Rama);
            return View(eventoes.ToList());
        }

        //
        // GET: /Evento/Details/5

        public ActionResult Details(int id = 0)
        {
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        //
        // GET: /Evento/Create

        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descripcion");
            ViewBag.EstiloID = new SelectList(db.Estiloes, "EstiloID", "Descripcion");
            ViewBag.RamaID = new SelectList(db.Ramas, "RamaID", "Descripcion");
            return View();
        }

        //
        // POST: /Evento/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Eventoes.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descripcion", evento.CategoriaID);
            ViewBag.EstiloID = new SelectList(db.Estiloes, "EstiloID", "Descripcion", evento.EstiloID);
            ViewBag.RamaID = new SelectList(db.Ramas, "RamaID", "Descripcion", evento.RamaID);
            return View(evento);
        }

        //
        // GET: /Evento/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descripcion", evento.CategoriaID);
            ViewBag.EstiloID = new SelectList(db.Estiloes, "EstiloID", "Descripcion", evento.EstiloID);
            ViewBag.RamaID = new SelectList(db.Ramas, "RamaID", "Descripcion", evento.RamaID);
            return View(evento);
        }

        //
        // POST: /Evento/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descripcion", evento.CategoriaID);
            ViewBag.EstiloID = new SelectList(db.Estiloes, "EstiloID", "Descripcion", evento.EstiloID);
            ViewBag.RamaID = new SelectList(db.Ramas, "RamaID", "Descripcion", evento.RamaID);
            return View(evento);
        }

        //
        // GET: /Evento/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        //
        // POST: /Evento/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventoes.Find(id);
            db.Eventoes.Remove(evento);
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