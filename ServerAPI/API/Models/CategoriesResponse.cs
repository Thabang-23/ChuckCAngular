using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class CategoriesResponse
    {
        [JsonPropertyName("Name")]

        public string[] Name { get; set; }
    }
}