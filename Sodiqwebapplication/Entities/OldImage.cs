using System;
using System.ComponentModel.DataAnnotations;

namespace Sodiqwebapplication.Entities
{
    public class OldImage
    {
        public OldImage()
        {
        }

        [Key]
        public long Id { get; set; }
        public String ImageId { get; set; }
        public String Url { get; set; }
        public String OtherImagesUrl { get; set; }
        public OldItem OldItem { get; set; }
    }
}
