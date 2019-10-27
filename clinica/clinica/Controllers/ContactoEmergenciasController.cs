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
    public class ContactoEmergenciasController : Controller
    {
        private clinicaContext db = new clinicaContext();

        // GET: ContactoEmergencias
        public ActionResult Index()
        {
            return View(db.ContactoEmergencias.ToList());
        }

        // GET: ContactoEmergencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactoEmergencia contactoEmergencia = db.ContactoEmergencias.Find(id);
            if (contactoEmergencia == null)
            {
                return HttpNotFound();
            }
            return View(contactoEmergencia);
        }

        // GET: ContactoEmergencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactoEmergencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactoEmergenciaID,Nombre,Apellido,Telefono,CorreoElectronico,Parentesco")] ContactoEmergencia contactoEmergencia)
        {
            if (ModelState.IsValid)
            {
                db.ContactoEmergencias.Add(contactoEmergencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactoEmergencia);
        }

        // GET: ContactoEmergencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactoEmergencia contactoEmergencia = db.ContactoEmergencias.Find(id);
            if (contactoEmergencia == null)
            {
                return HttpNotFound();
            }
            return View(contactoEmergencia);
        }

        // POST: ContactoEmergencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactoEmergenciaID,Nombre,Apellido,Telefono,CorreoElectronico,Parentesco")] ContactoEmergencia contactoEmergencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactoEmergencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactoEmergencia);
        }

        // GET: ContactoEmergencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactoEmergencia contactoEmergencia = db.ContactoEmergencias.Find(id);
            if (contactoEmergencia == null)
            {
                return HttpNotFound();
            }
            return View(contactoEmergencia);
        }

        // POST: ContactoEmergencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactoEmergencia contactoEmergencia = db.ContactoEmergencias.Find(id);
            db.ContactoEmergencias.Remove(contactoEmergencia);
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
