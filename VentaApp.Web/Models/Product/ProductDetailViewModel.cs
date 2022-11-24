﻿using Newtonsoft.Json;
using VentaApp.Web.Models.Product.Core;

namespace VentaApp.Web.Models.Product
{
    public class ProductDetailViewModel : ProductModel
    {
        [JsonProperty("data")]
        public ProductDetailViewModel Data { get; set; }
    }
}
