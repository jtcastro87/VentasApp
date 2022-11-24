using Venta.AppServices.Core;

namespace Venta.AppServices.Response
{
    public class ProductUpdateResponse : ServicesResponse
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Categoria { get; set; }
    }
}
