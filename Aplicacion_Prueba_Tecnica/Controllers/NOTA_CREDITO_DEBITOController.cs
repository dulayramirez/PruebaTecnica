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
    public class NOTA_CREDITO_DEBITOController : Controller
    {
        private PRUEBA_TECNICAEntities2 db = new PRUEBA_TECNICAEntities2();

        // GET: NOTA_CREDITO_DEBITO
        public ActionResult Index()
        {
            var nOTA_CREDITO_DEBITO = db.NOTA_CREDITO_DEBITO.Include(n => n.CUENTA).Include(n => n.TIPO_CONDICION);
            return View(nOTA_CREDITO_DEBITO.ToList());
        }

        // GET: NOTA_CREDITO_DEBITO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTA_CREDITO_DEBITO nOTA_CREDITO_DEBITO = db.NOTA_CREDITO_DEBITO.Find(id);
            if (nOTA_CREDITO_DEBITO == null)
            {
                return HttpNotFound();
            }
            return View(nOTA_CREDITO_DEBITO);
        }

        // GET: NOTA_CREDITO_DEBITO/Create
        public ActionResult Create()
        {
            ViewBag.ID_CUENTA = new SelectList(db.CUENTA, "ID_CUENTA", "ID_CUENTA");
            ViewBag.ES_NOTA_CREDITO = new SelectList(db.TIPO_CONDICION, "ID_TIPO_CONDICION", "DESCRIPCION_TIPO_CONDICION");
            return View();
        }

        // POST: NOTA_CREDITO_DEBITO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NOTA_CREDITO_DEBITO,ID_CUENTA,ES_NOTA_CREDITO,FECHA_REGISTRO,VALOR_NOTA_CREDITO_DEBITO")] NOTA_CREDITO_DEBITO nOTA_CREDITO_DEBITO)
        {
            if (ModelState.IsValid)
            {
                db.NOTA_CREDITO_DEBITO.Add(nOTA_CREDITO_DEBITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CUENTA = new SelectList(db.CUENTA, "ID_CUENTA", "ID_CUENTA", nOTA_CREDITO_DEBITO.ID_CUENTA);
            ViewBag.ES_NOTA_CREDITO = new SelectList(db.TIPO_CONDICION, "ID_TIPO_CONDICION", "DESCRIPCION_TIPO_CONDICION", nOTA_CREDITO_DEBITO.ES_NOTA_CREDITO);
            return View(nOTA_CREDITO_DEBITO);
        }

        // GET: NOTA_CREDITO_DEBITO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTA_CREDITO_DEBITO nOTA_CREDITO_DEBITO = db.NOTA_CREDITO_DEBITO.Find(id);
            if (nOTA_CREDITO_DEBITO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CUENTA = new SelectList(db.CUENTA, "ID_CUENTA", "ID_CUENTA", nOTA_CREDITO_DEBITO.ID_CUENTA);
            ViewBag.ES_NOTA_CREDITO = new SelectList(db.TIPO_CONDICION, "ID_TIPO_CONDICION", "DESCRIPCION_TIPO_CONDICION", nOTA_CREDITO_DEBITO.ES_NOTA_CREDITO);
            return View(nOTA_CREDITO_DEBITO);
        }

        // POST: NOTA_CREDITO_DEBITO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NOTA_CREDITO_DEBITO,ID_CUENTA,ES_NOTA_CREDITO,FECHA_REGISTRO,VALOR_NOTA_CREDITO_DEBITO")] NOTA_CREDITO_DEBITO nOTA_CREDITO_DEBITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOTA_CREDITO_DEBITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CUENTA = new SelectList(db.CUENTA, "ID_CUENTA", "ID_CUENTA", nOTA_CREDITO_DEBITO.ID_CUENTA);
            ViewBag.ES_NOTA_CREDITO = new SelectList(db.TIPO_CONDICION, "ID_TIPO_CONDICION", "DESCRIPCION_TIPO_CONDICION", nOTA_CREDITO_DEBITO.ES_NOTA_CREDITO);
            return View(nOTA_CREDITO_DEBITO);
        }

        // GET: NOTA_CREDITO_DEBITO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTA_CREDITO_DEBITO nOTA_CREDITO_DEBITO = db.NOTA_CREDITO_DEBITO.Find(id);
            if (nOTA_CREDITO_DEBITO == null)
            {
                return HttpNotFound();
            }
            return View(nOTA_CREDITO_DEBITO);
        }

        // POST: NOTA_CREDITO_DEBITO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NOTA_CREDITO_DEBITO nOTA_CREDITO_DEBITO = db.NOTA_CREDITO_DEBITO.Find(id);
            db.NOTA_CREDITO_DEBITO.Remove(nOTA_CREDITO_DEBITO);
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
