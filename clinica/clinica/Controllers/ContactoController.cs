﻿using System;
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
    public class ContactoController : Controller
    {
        private clinicaContext db = new clinicaContext();

        // GET: Contacto
        public ActionResult Index()
        {
            var contactoes = db.Contactoes.Include(c => c.ContactoEmergencia).Include(c => c.Paciente);
            return View(contactoes.ToList());
        }

        // GET: Contacto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactoes.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // GET: Contacto/Create
        public ActionResult Create()
        {
            ViewBag.ContactoEmergenciaID = new SelectList(db.ContactoEmergencias, "ContactoEmergenciaID", "Nombre");
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre");
            return View();
        }

        // POST: Contacto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactoID,PacienteID,ContactoEmergenciaID")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Contactoes.Add(contacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactoEmergenciaID = new SelectList(db.ContactoEmergencias, "ContactoEmergenciaID", "Nombre", contacto.ContactoEmergenciaID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", contacto.PacienteID);
            return View(contacto);
        }

        // GET: Contacto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactoes.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactoEmergenciaID = new SelectList(db.ContactoEmergencias, "ContactoEmergenciaID", "Nombre", contacto.ContactoEmergenciaID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", contacto.PacienteID);
            return View(contacto);
        }

        // POST: Contacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactoID,PacienteID,ContactoEmergenciaID")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactoEmergenciaID = new SelectList(db.ContactoEmergencias, "ContactoEmergenciaID", "Nombre", contacto.ContactoEmergenciaID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", contacto.PacienteID);
            return View(contacto);
        }

        // GET: Contacto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactoes.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: Contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacto contacto = db.Contactoes.Find(id);
            db.Contactoes.Remove(contacto);
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
