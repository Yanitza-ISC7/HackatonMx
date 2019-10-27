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
    public class HistorialMedicoesController : Controller
    {
        private clinicaContext db = new clinicaContext();

        // GET: HistorialMedicoes
        public ActionResult Index()
        {
            var historialMedicoes = db.HistorialMedicoes.Include(h => h.Doctor).Include(h => h.Paciente);
            return View(historialMedicoes.ToList());
        }

        // GET: HistorialMedicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialMedico historialMedico = db.HistorialMedicoes.Find(id);
            if (historialMedico == null)
            {
                return HttpNotFound();
            }
            return View(historialMedico);
        }

        // GET: HistorialMedicoes/Create
        public ActionResult Create()
        {
            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "Nombre");
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre");
            return View();
        }

        // POST: HistorialMedicoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HistorialMedicoID,Diagnostico,Tratamiento,ExamenMedico,Peso,Altura,FechaRealizacion,PacienteID,DoctorID")] HistorialMedico historialMedico)
        {
            if (ModelState.IsValid)
            {
                db.HistorialMedicoes.Add(historialMedico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "Nombre", historialMedico.DoctorID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", historialMedico.PacienteID);
            return View(historialMedico);
        }

        // GET: HistorialMedicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialMedico historialMedico = db.HistorialMedicoes.Find(id);
            if (historialMedico == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "Nombre", historialMedico.DoctorID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", historialMedico.PacienteID);
            return View(historialMedico);
        }

        // POST: HistorialMedicoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HistorialMedicoID,Diagnostico,Tratamiento,ExamenMedico,Peso,Altura,FechaRealizacion,PacienteID,DoctorID")] HistorialMedico historialMedico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historialMedico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "Nombre", historialMedico.DoctorID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nombre", historialMedico.PacienteID);
            return View(historialMedico);
        }

        // GET: HistorialMedicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialMedico historialMedico = db.HistorialMedicoes.Find(id);
            if (historialMedico == null)
            {
                return HttpNotFound();
            }
            return View(historialMedico);
        }

        // POST: HistorialMedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistorialMedico historialMedico = db.HistorialMedicoes.Find(id);
            db.HistorialMedicoes.Remove(historialMedico);
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
