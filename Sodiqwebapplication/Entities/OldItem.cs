using System;
using System.Collections.Generic;

namespace Sodiqwebapplication.Entities
{
    public class OldItem:BaseItemEntity
    {
        public ICollection<OldImage> Images { get; set; }
    }
}
