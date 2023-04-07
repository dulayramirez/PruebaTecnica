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
    public class CUENTAsController : Controller
    {
        private PRUEBA_TECNICAEntities2 db = new PRUEBA_TECNICAEntities2();

        // GET: CUENTAs
        public ActionResult Index()
        {
            var cUENTA = db.CUENTA.Include(c => c.CLIENTE).Include(c => c.TIPO_CUENTA).Include(c => c.TIPO_ESTADO);
            return View(cUENTA.ToList());
        }

        // GET: CUENTAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA cUENTA = db.CUENTA.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }
            return View(cUENTA);
        }

        // GET: CUENTAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRES");
            ViewBag.ID_TIPO_CUENTA = new SelectList(db.TIPO_CUENTA, "ID_TIPO_CUENTA", "DESCRIPCION_TIPO_CUENTA");
            ViewBag.ID_ESTADO = new SelectList(db.TIPO_ESTADO, "ID_TIPO_ESTADO", "DESCRIPCION_TIPO_ESTADO");
            return View();
        }

        // POST: CUENTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CUENTA,NUMERO_CUENTA,ID_CLIENTE,ID_TIPO_CUENTA,CREDITO_LIMITE,FECHA_APERTURA,ID_ESTADO")] CUENTA cUENTA)
        {
            if (ModelState.IsValid)
            {
                db.CUENTA.Add(cUENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRES", cUENTA.ID_CLIENTE);
            ViewBag.ID_TIPO_CUENTA = new SelectList(db.TIPO_CUENTA, "ID_TIPO_CUENTA", "DESCRIPCION_TIPO_CUENTA", cUENTA.ID_TIPO_CUENTA);
            ViewBag.ID_ESTADO = new SelectList(db.TIPO_ESTADO, "ID_TIPO_ESTADO", "DESCRIPCION_TIPO_ESTADO", cUENTA.ID_ESTADO);
            return View(cUENTA);
        }

        // GET: CUENTAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA cUENTA = db.CUENTA.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRES", cUENTA.ID_CLIENTE);
            ViewBag.ID_TIPO_CUENTA = new SelectList(db.TIPO_CUENTA, "ID_TIPO_CUENTA", "DESCRIPCION_TIPO_CUENTA", cUENTA.ID_TIPO_CUENTA);
            ViewBag.ID_ESTADO = new SelectList(db.TIPO_ESTADO, "ID_TIPO_ESTADO", "DESCRIPCION_TIPO_ESTADO", cUENTA.ID_ESTADO);
            return View(cUENTA);
        }

        // POST: CUENTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CUENTA,NUMERO_CUENTA,ID_CLIENTE,ID_TIPO_CUENTA,CREDITO_LIMITE,FECHA_APERTURA,ID_ESTADO")] CUENTA cUENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRES", cUENTA.ID_CLIENTE);
            ViewBag.ID_TIPO_CUENTA = new SelectList(db.TIPO_CUENTA, "ID_TIPO_CUENTA", "DESCRIPCION_TIPO_CUENTA", cUENTA.ID_TIPO_CUENTA);
            ViewBag.ID_ESTADO = new SelectList(db.TIPO_ESTADO, "ID_TIPO_ESTADO", "DESCRIPCION_TIPO_ESTADO", cUENTA.ID_ESTADO);
            return View(cUENTA);
        }

        // GET: CUENTAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA cUENTA = db.CUENTA.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }
            return View(cUENTA);
        }

        // POST: CUENTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUENTA cUENTA = db.CUENTA.Find(id);
            db.CUENTA.Remove(cUENTA);
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
