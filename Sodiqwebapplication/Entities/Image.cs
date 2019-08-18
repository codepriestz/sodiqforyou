using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sodiqwebapplication.Entities
{
    public class Image
    {
        [Key]
        public long Id { get; set; }
        public String ImageId { get; set; }
        public String Url { get; set; }
        public String OtherImagesUrl { get; set; }
        public Item Item { get; set; }

    }
}
