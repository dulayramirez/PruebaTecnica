using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplicacion_Prueba_Tecnica.Models;

namespace Aplicacion_Prueba_Tecnica.Controllers
{
    public class CONTACTOController : Controller
    {
        private PRUEBA_TECNICAEntities2 db = new PRUEBA_TECNICAEntities2();

        // GET: CONTACTO
        public ActionResult Index()
        {
            var cONTACTO = db.CONTACTO.Include(c => c.CLIENTE).Include(c => c.TIPO_CONTACTO);
            return View(cONTACTO.ToList());
        }

        // GET: CONTACTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTO);
        }

        // GET: CONTACTO/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRES");
            ViewBag.ID_TIPO_CONTACTO = new SelectList(db.TIPO_CONTACTO, "ID_TIPO_CONTACTO", "DESCRIPCION_TIPO_CONTACTO");
            return View();
        }

        // POST: CONTACTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CONTACTO,ID_CLIENTE,ID_TIPO_CONTACTO,VALOR_CONTACTO")] CONTACTO cONTACTO)
        {
            if (ModelState.IsValid)
            {
                db.CONTACTO.Add(cONTACTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRES", cONTACTO.ID_CLIENTE);
            ViewBag.ID_TIPO_CONTACTO = new SelectList(db.TIPO_CONTACTO, "ID_TIPO_CONTACTO", "DESCRIPCION_TIPO_CONTACTO", cONTACTO.ID_TIPO_CONTACTO);
            return View(cONTACTO);
        }

        // GET: CONTACTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRES", cONTACTO.ID_CLIENTE);
            ViewBag.ID_TIPO_CONTACTO = new SelectList(db.TIPO_CONTACTO, "ID_TIPO_CONTACTO", "DESCRIPCION_TIPO_CONTACTO", cONTACTO.ID_TIPO_CONTACTO);
            return View(cONTACTO);
        }

        // POST: CONTACTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CONTACTO,ID_CLIENTE,ID_TIPO_CONTACTO,VALOR_CONTACTO")] CONTACTO cONTACTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTACTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRES", cONTACTO.ID_CLIENTE);
            ViewBag.ID_TIPO_CONTACTO = new SelectList(db.TIPO_CONTACTO, "ID_TIPO_CONTACTO", "DESCRIPCION_TIPO_CONTACTO", cONTACTO.ID_TIPO_CONTACTO);
            return View(cONTACTO);
        }

        // GET: CONTACTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTO);
        }

        // POST: CONTACTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            db.CONTACTO.Remove(cONTACTO);
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
