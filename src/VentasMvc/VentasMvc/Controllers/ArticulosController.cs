using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasMvc.Modelos;

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
    }
}