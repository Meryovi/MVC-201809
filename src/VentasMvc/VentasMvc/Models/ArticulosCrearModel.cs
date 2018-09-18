using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VentasMvc.Models
{
    public class ArticulosCrearModel
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Display(Name = "Cantidad en Existencia")]
        public int CantidadExistencia { get; set; }

        public decimal Precio { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public SelectList CategoriasLista { get; set; }
    }
}