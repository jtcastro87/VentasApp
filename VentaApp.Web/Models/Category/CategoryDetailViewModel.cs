using Newtonsoft.Json;

namespace VentaApp.Web.Models.Category
{
    public class CategoryDetailViewModel
    {
        [JsonProperty("data")]
        public CategoryModel DataModel { get; set; }
    }
}
