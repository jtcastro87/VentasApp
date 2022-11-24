using Venta.AppServices.Core;

namespace Venta.AppServices.Response
{
    public class ProductDeleteResponse : ServicesResponse
    {
        public int ProductoID { get; set; }

        public string Nombre { get; set; }
    }
}
