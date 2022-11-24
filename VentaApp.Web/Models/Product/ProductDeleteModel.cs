
using Newtonsoft.Json;

namespace VentaApp.Web.Models.Product
{
    public class ProductDeleteModel
    {
        [JsonProperty("productoID")]
        public int ProductID { get; set; }
    }
}
