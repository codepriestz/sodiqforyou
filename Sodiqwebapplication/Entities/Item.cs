using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sodiqwebapplication.Entities
{
    public class Item
    {
        [Key]
        public long Id { get; set; }
        public long ItemId { get; set; }
       
        public String Type { get; set; }
        public String SubType { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public DateTime Date { get; set; }
        public String Summary { get; set; }
        public String Content { get; set; }
        public String Url { get; set; }
        public String IsFeatured { get; set; }
        public String SmallThumbnail { get; set; }
        public String Thumbnail { get; set; }
        public String OriginalThumbnail { get; set; }
        public String LargeThumbnail { get; set; }

        public String XLargeThumbnail { get; set; }
        public String XxLargeThumbnail { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }
        public int IsHeadLine { get; set; }
        public String AuthorAvatarUrl { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String PinIconColor { get; set; }
        public String PinIconUrl { get; set; }
        public int PinIconWidth { get; set; }
        public int PinIconHeight { get; set; }
        public String WebSite { get; set; }
        public Boolean CommentsEnabled { get; set; }

        public List<Image> Images { get; set; }
        public String SubSections { get; set; }
    }
}