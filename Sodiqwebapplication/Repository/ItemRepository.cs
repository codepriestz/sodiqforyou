using Sodiqwebapplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodiqwebapplication.Repository
{
    public interface ItemRepository
    {

        Item save(Item item);

        void saveAll(ICollection<Item> items);
        Item update(Item item);
        void delete(Item item);
        Item findById(long id);
        List<Item> findAll();

        List<Item> filterBy(Func<Item, Boolean> predicate);

    }
}
