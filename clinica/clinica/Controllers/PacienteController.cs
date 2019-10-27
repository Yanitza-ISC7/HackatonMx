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
    public class PacienteController : Controller
    {
        private clinicaContext db = new clinicaContext();

        // GET: Paciente
        public ActionResult Index()
        {
            var pacientes = db.Pacientes.Include(p => p.Alergias).Include(p => p.EnfermedadesCongenitas).Include(p => p.EnfermedadesCronicas);
            return View(pacientes.ToList());
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            ViewBag.AlergiasID = new SelectList(db.Alergias, "AlergiasID", "Nombre");
            ViewBag.EnfermedadesCongenitasID = new SelectList(db.EnfermedadesCongenitas, "EnfermedadesCongenitasID", "Nombre");
            ViewBag.EnfermedadesCronicasID = new SelectList(db.EnfermedadesCronicas, "EnfermedadesCronicasID", "Nombre");
            return View();
        }

        // POST: Paciente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PacienteID,Nombre,Apellido,Edad,Sexo,Curp,Telefono,TipoSangre,Seguro,EnfermedadesCronicasID,EnfermedadesCongenitasID,AlergiasID")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlergiasID = new SelectList(db.Alergias, "AlergiasID", "Nombre", paciente.AlergiasID);
            ViewBag.EnfermedadesCongenitasID = new SelectList(db.EnfermedadesCongenitas, "EnfermedadesCongenitasID", "Nombre", paciente.EnfermedadesCongenitasID);
            ViewBag.EnfermedadesCronicasID = new SelectList(db.EnfermedadesCronicas, "EnfermedadesCronicasID", "Nombre", paciente.EnfermedadesCronicasID);
            return View(paciente);
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlergiasID = new SelectList(db.Alergias, "AlergiasID", "Nombre", paciente.AlergiasID);
            ViewBag.EnfermedadesCongenitasID = new SelectList(db.EnfermedadesCongenitas, "EnfermedadesCongenitasID", "Nombre", paciente.EnfermedadesCongenitasID);
            ViewBag.EnfermedadesCronicasID = new SelectList(db.EnfermedadesCronicas, "EnfermedadesCronicasID", "Nombre", paciente.EnfermedadesCronicasID);
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PacienteID,Nombre,Apellido,Edad,Sexo,Curp,Telefono,TipoSangre,Seguro,EnfermedadesCronicasID,EnfermedadesCongenitasID,AlergiasID")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlergiasID = new SelectList(db.Alergias, "AlergiasID", "Nombre", paciente.AlergiasID);
            ViewBag.EnfermedadesCongenitasID = new SelectList(db.EnfermedadesCongenitas, "EnfermedadesCongenitasID", "Nombre", paciente.EnfermedadesCongenitasID);
            ViewBag.EnfermedadesCronicasID = new SelectList(db.EnfermedadesCronicas, "EnfermedadesCronicasID", "Nombre", paciente.EnfermedadesCronicasID);
            return View(paciente);
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
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
