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

        [Range(1, 9999, ErrorMessage = "La cantidad de articulos no es correcta, por favor verifique")]
        public int Cantidad { get; set; }

        public SelectList ListaArticulos { get; set; }
    }
}