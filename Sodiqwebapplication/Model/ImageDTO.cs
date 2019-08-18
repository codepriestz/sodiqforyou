using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sodiqwebapplication.Model
{
    public class ImageDTO
    {
        public ImageDTO()
        {
        }
        [JsonProperty(PropertyName ="id")]
        public String ImageId { get; set; }
        public String Url { get; set; }
        public Dictionary<String, String> OtherImagesUrl { get; set; }
        public Dictionary<String, String> OtherImagesUrlMap { get; set; }
    }
}
