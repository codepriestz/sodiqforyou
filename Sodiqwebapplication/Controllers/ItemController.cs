using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sodiqwebapplication.Model;
using Sodiqwebapplication.Services;

namespace Sodiqwebapplication.Controllers
{
    [Route("api/v1/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly ItemService itemService;
        public ItemController(ItemService itemService)
        {
            this.itemService = itemService;
        }
        [HttpPost]
        [Route("sync")]
        public async void syncItems()
        {
            itemService.syncWithApi();
        }

        [HttpPut("{id}")]
        public void patchItem(long id, [FromBody] ItemDTO itemDTO)
        {
            itemService.updateItem(id, itemDTO);
        }
    }
}
