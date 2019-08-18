using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Sodiqwebapplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodiqwebapplication.Config
{
    public class DbManager : DbContext
    {
        public DbManager( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> items { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<OldItem> oldItems { get; set; }
    }
}
