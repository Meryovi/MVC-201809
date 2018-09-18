using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentasMvc.Modelos;

namespace VentasMvc.Controllers
{
    public class ArticuloCategoriasController : Controller
    {
        private VentasEntities db = new VentasEntities();

        // GET: ArticuloCategorias
        public ActionResult Index()
        {
            return View(db.ArticuloCategorias.ToList());
        }

        // GET: ArticuloCategorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloCategoria articuloCategoria = db.ArticuloCategorias.Find(id);
            if (articuloCategoria == null)
            {
                return HttpNotFound();
            }
            return View(articuloCategoria);
        }

        // GET: ArticuloCategorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticuloCategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] ArticuloCategoria articuloCategoria)
        {
            if (ModelState.IsValid)
            {
                db.ArticuloCategorias.Add(articuloCategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articuloCategoria);
        }

        // GET: ArticuloCategorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloCategoria articuloCategoria = db.ArticuloCategorias.Find(id);
            if (articuloCategoria == null)
            {
                return HttpNotFound();
            }
            return View(articuloCategoria);
        }

        // POST: ArticuloCategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] ArticuloCategoria articuloCategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articuloCategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articuloCategoria);
        }

        // GET: ArticuloCategorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloCategoria articuloCategoria = db.ArticuloCategorias.Find(id);
            if (articuloCategoria == null)
            {
                return HttpNotFound();
            }
            return View(articuloCategoria);
        }

        // POST: ArticuloCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticuloCategoria articuloCategoria = db.ArticuloCategorias.Find(id);
            db.ArticuloCategorias.Remove(articuloCategoria);
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
