using Venta.AppServices.Core;

namespace Venta.AppServices.Response
{
    public class CategoryDeleteResponse : ServicesResponse
    {
        public int CategoryID { get; set; }
        public string Nombre { get; set; }
    }
}
