using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasMvc.Modelos;
using VentasMvc.Models;

namespace VentasMvc.Controllers
{
    public class FacturasController : Controller
    {
        private VentasEntities context = new VentasEntities();

        // GET: Facturas
        public ActionResult Index()
        {
            var facturas = context.Facturas.ToList();

            return View(facturas);
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            var model = new FacturasCrearModel();

            // Consultamos todos los clientes y los agregamos
            // a un SelectList.
            var clientes = context.Clientes.ToList();
            model.ListaClientes = new SelectList(clientes, "Id", "Nombre");

            return View(model);
        }

        // POST: Facturas/Create
        [HttpPost]
        public ActionResult Create(FacturasCrearModel model)
        {
            if (ModelState.IsValid)
            {
                var factura = new Factura();

                factura.ClienteId = model.ClienteId;
                factura.FechaRegistro = DateTime.Now;

                context.Facturas.Add(factura);
                context.SaveChanges();

                return RedirectToAction("Edit", new { id = factura.Id });
            }

            return View(model);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new FacturasEditarModel();
            var factura = context.Facturas.Find(id);

            model.IdFactura = id;
            model.ClienteId = factura.ClienteId;
            model.ListaClientes = new SelectList(context.Clientes, "Id", "Nombre");
            model.MontoDescuento = factura.MontoDescuento;
            model.MontoImpuesto = factura.MontoImpuesto;

            return View(model);
        }

        // POST: Facturas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FacturasEditarModel model)
        {
            if (ModelState.IsValid)
            {
                var factura = context.Facturas.Find(id);

                factura.ClienteId = model.ClienteId;
                factura.MontoDescuento = model.MontoDescuento;
                factura.MontoImpuesto = model.MontoImpuesto;

                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult AgregarArticulo(int idFactura)
        {
            var model = new FacturasAgregarArticuloModel();

            var articulos = context.Articulos;
            model.ListaArticulos = new SelectList(articulos, "Id", "Nombre");

            return View(model);
        }

        [HttpPost]
        public ActionResult AgregarArticulo(int idFactura, FacturasAgregarArticuloModel model)
        {
            if (ModelState.IsValid)
            {
                var articulo = context.Articulos.Find(model.ArticuloId);
                var factura = context.Facturas.Find(idFactura);

                var detalle = new FacturaDetalle();

                detalle.FacturaId = idFactura;
                detalle.ArticuloId = articulo.Id;
                detalle.Cantidad = model.Cantidad;
                detalle.Monto = detalle.Cantidad * articulo.Precio;

                factura.MontoNeto = factura.MontoNeto + detalle.Monto;
                factura.MontoTotal = factura.MontoTotal + detalle.Monto;

                context.FacturaDetalles.Add(detalle);
                context.SaveChanges();

                return RedirectToAction("Details", new { id = idFactura });
            }

            return View(model);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Facturas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
