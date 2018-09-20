using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VentasMvc.Models
{
    public class FacturasAgregarArticuloModel
    {
        [Display(Name = "Articulo")]
        public int ArticuloId { get; set; }

        public int Cantidad { get; internal set; }

        public SelectList ListaArticulos { get; set; }
    }
}