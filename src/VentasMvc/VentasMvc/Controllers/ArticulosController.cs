using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasMvc.Modelos;
using VentasMvc.Models;

namespace VentasMvc.Controllers
{
    public class ArticulosController : Controller
    {
        // GET: Articulos
        public ActionResult Index()
        {
            var context = new VentasMvc.Modelos.VentasEntities();
            var articulos = context.Articulos.ToList();

            return View(articulos);
        }


        public ActionResult Registrar()
        {
            var modelo = new ArticulosCrearModel();

            var context = new VentasEntities();

            modelo.CategoriasLista = new SelectList(
                context.ArticuloCategorias,
                "Id", "Nombre");

            return View(modelo);
        }

        [HttpPost]
        public ActionResult Registrar(ArticulosCrearModel modelo)
        {
            if (ModelState.IsValid)
            {
                var context = new VentasMvc.Modelos.VentasEntities();

                var articulo = new Articulo();

                articulo.Nombre = modelo.Nombre;
                articulo.Descripcion = modelo.Descripcion;
                articulo.CantidadExistencia = modelo.CantidadExistencia;
                articulo.Precio = modelo.Precio;
                articulo.CategoriaId = modelo.CategoriaId;
                articulo.FechaRegistro = DateTime.Now;
                articulo.FechaModificacion = DateTime.Now;

                context.Articulos.Add(articulo);
                int registros = context.SaveChanges();

                if (registros > 0)
                    return RedirectToAction("Index");
            }

            return View(modelo);
        }
    }
}