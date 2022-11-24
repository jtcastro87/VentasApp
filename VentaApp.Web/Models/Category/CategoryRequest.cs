using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VentaApp.Web.Models.Category
{
    public class CategoryRequest
    {
        [JsonProperty("categoryID")]
        public long CategoryID { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        //[JsonProperty("data")]
        //public object Data { get; set; }

        [JsonProperty("mensaje")]
        public string Mensaje { get; set; }
    }
}
