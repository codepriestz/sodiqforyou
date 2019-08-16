using Sodiqwebapplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodiqwebapplication.Services
{
    public interface ItemService
    {
        void syncWithApi();
        void updateItem(long id,ItemDTO itemDTO);
    }
}
