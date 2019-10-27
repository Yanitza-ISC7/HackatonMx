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
    public class ParamedicoesController : Controller
    {
        private clinicaContext db = new clinicaContext();

        // GET: Paramedicoes
        public ActionResult Index()
        {
            return View(db.Paramedicoes.ToList());
        }

        // GET: Paramedicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paramedico paramedico = db.Paramedicoes.Find(id);
            if (paramedico == null)
            {
                return HttpNotFound();
            }
            return View(paramedico);
        }

        // GET: Paramedicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paramedicoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParamedicoID,Nombre,Apellido,Edad,NumTrabajador")] Paramedico paramedico)
        {
            if (ModelState.IsValid)
            {
                db.Paramedicoes.Add(paramedico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paramedico);
        }

        // GET: Paramedicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paramedico paramedico = db.Paramedicoes.Find(id);
            if (paramedico == null)
            {
                return HttpNotFound();
            }
            return View(paramedico);
        }

        // POST: Paramedicoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParamedicoID,Nombre,Apellido,Edad,NumTrabajador")] Paramedico paramedico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paramedico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paramedico);
        }

        // GET: Paramedicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paramedico paramedico = db.Paramedicoes.Find(id);
            if (paramedico == null)
            {
                return HttpNotFound();
            }
            return View(paramedico);
        }

        // POST: Paramedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paramedico paramedico = db.Paramedicoes.Find(id);
            db.Paramedicoes.Remove(paramedico);
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
