using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sodiqwebapplication.Config;
using Sodiqwebapplication.Entities;

namespace Sodiqwebapplication.Repository
{
    public class ItemRepositoryImpl : ItemRepository
    {
        private readonly DbManager _dbManager;

        public ItemRepositoryImpl(DbManager dbManager)
        {
            this._dbManager = dbManager;
        }
        public void delete(Item item)
        {
            this._dbManager.items.Remove(item);
            this._dbManager.SaveChangesAsync();
        }

        public List<Item> filterBy(Func<Item, bool> predicate)
        {
           return this._dbManager.items.Where(predicate).ToList();  
        }

        public List<Item> findAll()
        {
            return this._dbManager.items.ToList();
        }

        public Item findById(long id)
        {
            return this._dbManager.items.Where(item => item.Id == id).First();
         
        }

        public Item save(Item item)
        {
           var entityItem= this._dbManager.Add(item);
            this._dbManager.SaveChanges();
            return entityItem.Entity;
        }

        public void saveAll(ICollection<Item> items)
        {
            this._dbManager.items.AddRange(items);
        }

        public Item update(Item item)
        {
            var entityItem = this._dbManager.Update(item);
            this._dbManager.SaveChanges();
            return entityItem.Entity;
        }
    }
}
