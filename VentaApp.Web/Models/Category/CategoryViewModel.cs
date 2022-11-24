using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VentaApp.Web.Models.Category
{
    public class CategoryViewModel
    {
        [JsonProperty("data")]
        public List<CategoryModel> Data { get; set; }
    }
}
