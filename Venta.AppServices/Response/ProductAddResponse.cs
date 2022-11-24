using Venta.AppServices.Core;

namespace Venta.AppServices.Response
{
    public class ProductAddResponse : ServicesResponse
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
    }
}
