using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodiqwebapplication.Entities
{
    public class Image
    {
        public long Id { get; set; }
        public String ImageId { get; set; }
        public String Url { get; set; }
        public String OtherImagesUrl { get; set; }
        public Dictionary<String,String> OtherImagesUrlMap { get; set; }

     
    }
}
