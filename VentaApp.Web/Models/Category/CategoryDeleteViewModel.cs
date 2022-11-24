using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaApp.Web.Models.Category
{
    public class CategoryDeleteViewModel
    {
        [JsonProperty("categoriaID")]
        public int CategoryID { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        //[JsonProperty("data")]
        //public CategoryModel Data { get; set; }
    }
}
