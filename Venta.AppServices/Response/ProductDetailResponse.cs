
namespace Venta.AppServices.Response
{
    public class ProductDetailResponse
    {
        public int ProductoID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int CategoriaID { get; set; }
    }
}
