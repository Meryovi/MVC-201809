using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasMvc.Modelos;

namespace VentasMvc.Controllers
{
    public class ClientesController : Controller
    {
        private VentasEntities context = new VentasEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = context.Clientes.ToList();

            return View(clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var cliente = context.Clientes.Find(id);

            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = context.Clientes.Find(id);

            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                context.Clientes.Attach(cliente);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = context.Clientes.Find(id);

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                context.Clientes.Remove(cliente);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }
    }
}
