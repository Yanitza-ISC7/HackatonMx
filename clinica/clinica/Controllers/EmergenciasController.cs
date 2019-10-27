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
    public class EmergenciasController : Controller
    {
        private clinicaContext db = new clinicaContext();

        // GET: Emergencias
        public ActionResult Index()
        {
            var emergencias = db.Emergencias.Include(e => e.Hospital).Include(e => e.Paciente).Include(e => e.Paramedico);
            return View(emergencias.ToList());
        }

        // GET: Emergencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emergencia emergencia = db.Emergencias.Find(id);
            if (emergencia == null)
            {
                return HttpNotFound();
            }
            return View(emergencia);
        }

        // GET: Emergencias/Create
        public ActionResult Create()
        {
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "Nombre");
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre");
            ViewBag.ParamedicoID = new SelectList(db.Paramedicoes, "ParamedicoID", "Nombre");
            return View();
        }

        // POST: Emergencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmergenciaID,FechaEmergencia,PacienteID,ParamedicoID,HospitalID")] Emergencia emergencia)
        {
            if (ModelState.IsValid)
            {
                db.Emergencias.Add(emergencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "Nombre", emergencia.HospitalID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", emergencia.PacienteID);
            ViewBag.ParamedicoID = new SelectList(db.Paramedicoes, "ParamedicoID", "Nombre", emergencia.ParamedicoID);
            return View(emergencia);
        }

        // GET: Emergencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emergencia emergencia = db.Emergencias.Find(id);
            if (emergencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "Nombre", emergencia.HospitalID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", emergencia.PacienteID);
            ViewBag.ParamedicoID = new SelectList(db.Paramedicoes, "ParamedicoID", "Nombre", emergencia.ParamedicoID);
            return View(emergencia);
        }

        // POST: Emergencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmergenciaID,FechaEmergencia,PacienteID,ParamedicoID,HospitalID")] Emergencia emergencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emergencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "Nombre", emergencia.HospitalID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", emergencia.PacienteID);
            ViewBag.ParamedicoID = new SelectList(db.Paramedicoes, "ParamedicoID", "Nombre", emergencia.ParamedicoID);
            return View(emergencia);
        }

        // GET: Emergencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emergencia emergencia = db.Emergencias.Find(id);
            if (emergencia == null)
            {
                return HttpNotFound();
            }
            return View(emergencia);
        }

        // POST: Emergencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emergencia emergencia = db.Emergencias.Find(id);
            db.Emergencias.Remove(emergencia);
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
