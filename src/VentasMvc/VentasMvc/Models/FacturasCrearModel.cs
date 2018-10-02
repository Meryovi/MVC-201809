using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VentasMvc.Models
{
    public class FacturasCrearModel
    {
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Impuestos")]
        public decimal MontoImpuesto { get; set; }

        [Display(Name = "Descuentos")]
        public decimal MontoDescuento { get; set; }

        public List<FacturasDetalleModel> Detalle { get; set; }

        public SelectList ListaClientes { get; set; }
        public SelectList ListaArticulos { get; internal set; }
    }

    public class FacturasDetalleModel
    {
        public int ArticuloId { get; set; }

        public int Cantidad { get; set; }
    }
}