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
    public class EnfermedadesCronicasController : Controller
    {
        private clinicaContext db = new clinicaContext();

        // GET: EnfermedadesCronicas
        public ActionResult Index()
        {
            return View(db.EnfermedadesCronicas.ToList());
        }

        // GET: EnfermedadesCronicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnfermedadesCronicas enfermedadesCronicas = db.EnfermedadesCronicas.Find(id);
            if (enfermedadesCronicas == null)
            {
                return HttpNotFound();
            }
            return View(enfermedadesCronicas);
        }

        // GET: EnfermedadesCronicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnfermedadesCronicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnfermedadesCronicasID,Nombre,Tipo,Clasificacion")] EnfermedadesCronicas enfermedadesCronicas)
        {
            if (ModelState.IsValid)
            {
                db.EnfermedadesCronicas.Add(enfermedadesCronicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enfermedadesCronicas);
        }

        // GET: EnfermedadesCronicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnfermedadesCronicas enfermedadesCronicas = db.EnfermedadesCronicas.Find(id);
            if (enfermedadesCronicas == null)
            {
                return HttpNotFound();
            }
            return View(enfermedadesCronicas);
        }

        // POST: EnfermedadesCronicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnfermedadesCronicasID,Nombre,Tipo,Clasificacion")] EnfermedadesCronicas enfermedadesCronicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enfermedadesCronicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enfermedadesCronicas);
        }

        // GET: EnfermedadesCronicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnfermedadesCronicas enfermedadesCronicas = db.EnfermedadesCronicas.Find(id);
            if (enfermedadesCronicas == null)
            {
                return HttpNotFound();
            }
            return View(enfermedadesCronicas);
        }

        // POST: EnfermedadesCronicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnfermedadesCronicas enfermedadesCronicas = db.EnfermedadesCronicas.Find(id);
            db.EnfermedadesCronicas.Remove(enfermedadesCronicas);
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
