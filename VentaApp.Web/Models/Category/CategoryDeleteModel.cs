
using Newtonsoft.Json;

namespace VentaApp.Web.Models.Category
{
    public class CategoryDeleteModel
    {
        [JsonProperty("CategoryID")]
        public int CategoryID { get; set; }
    }
}
