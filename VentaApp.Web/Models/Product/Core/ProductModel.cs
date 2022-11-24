using Newtonsoft.Json;

namespace VentaApp.Web.Models.Product.Core
{
    public class ProductModel
    {
        [JsonProperty("productoID")]
        public int ProductoID { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("precio")]
        public decimal Precio { get; set; }                  

        [JsonProperty("categoria")]
        public int Categoria { get; set; }




    }
}
