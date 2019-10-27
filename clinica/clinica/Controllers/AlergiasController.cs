using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using clinica.Models;

namespace clinica.Controllers
{
    public class AlergiasController : Controller
    {
        private clinicaContext db = new clinicaContext();

        // GET: Alergias
        public ActionResult Index()
        {
            return View(db.Alergias.ToList());
        }

        // GET: Alergias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alergias alergias = db.Alergias.Find(id);
            if (alergias == null)
            {
                return HttpNotFound();
            }
            return View(alergias);
        }

        // GET: Alergias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alergias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlergiasID,Nombre,Tipo")] Alergias alergias)
        {
            if (ModelState.IsValid)
            {
                db.Alergias.Add(alergias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alergias);
        }

        // GET: Alergias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alergias alergias = db.Alergias.Find(id);
            if (alergias == null)
            {
                return HttpNotFound();
            }
            return View(alergias);
        }

        // POST: Alergias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlergiasID,Nombre,Tipo")] Alergias alergias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alergias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alergias);
        }

        // GET: Alergias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alergias alergias = db.Alergias.Find(id);
            if (alergias == null)
            {
                return HttpNotFound();
            }
            return View(alergias);
        }

        // POST: Alergias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alergias alergias = db.Alergias.Find(id);
            db.Alergias.Remove(alergias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
