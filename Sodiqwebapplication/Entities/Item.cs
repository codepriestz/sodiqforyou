using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sodiqwebapplication.Entities
{
    public class Item:BaseItemEntity
    {
        public ICollection<Image> Images { get; set; }

    }
}