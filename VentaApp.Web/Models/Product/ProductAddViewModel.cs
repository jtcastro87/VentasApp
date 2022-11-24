using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaApp.Web.Models.Product
{
    public class ProductAddViewModel
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Categoria { get; set; }
    }
}
