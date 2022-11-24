using Newtonsoft.Json;
using System.Collections.Generic;
using VentaApp.Web.Models.Product.Core;

namespace VentaApp.Web.Models.Product
{
    public class ProductViewModel
    {
        [JsonProperty("data")]
        public List<ProductModel> Data { get; set; }
    }
}
