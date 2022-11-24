using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VentaApp.Web.Models.Category
{
    public class CategoryModel
    {
        //[JsonProperty("$id")]
        //public long Id { get; set; }

        [JsonProperty("categoriaID")]
        public int CategoryID { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        //[JsonProperty("deleted")]
        //public bool Deleted { get; set; }


    }
}
