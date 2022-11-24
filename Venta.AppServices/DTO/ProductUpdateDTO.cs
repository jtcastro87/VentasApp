
namespace Venta.AppServices.DTO
{
    public class ProductUpdateDTO
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Categoria { get; set; }
    }
}
