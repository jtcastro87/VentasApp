using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VentaApp.Web.Models.Category;

namespace VentaApp.Web.Models
{
    public class ServicesResultModel
    {
        [JsonProperty("data")]
        public List<CategoryModel> Data { get; set; }
    }
}
