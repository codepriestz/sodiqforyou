using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Sodiqwebapplication.Model;
using Sodiqwebapplication.Repository;

namespace Sodiqwebapplication.Services.Impl
{
    public class ItemServiceImpl : ItemService
    {
        private readonly ItemRepository _ItemRepository;

        private readonly HttpClient _HttpClient;

        private readonly String _SyncUrl;

        public ItemServiceImpl(ItemRepository itemRepository, IConfiguration configuration)
        {
            this._ItemRepository = itemRepository;
            this._SyncUrl = configuration.GetValue<String>("SyncUrl");
            this._HttpClient = new HttpClient();
        }
        public async void syncWithApi()
        {
            var result = await this._HttpClient.GetAsync(_SyncUrl);
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception($"Error while calling Api, Status Code: {result.StatusCode}, Reason: {result.ReasonPhrase}");
            }
            try{
                //var contentAsString = await result.Content.ReadAsStringAsync();
                //Console.WriteLine(contentAsString);
                var content = (ItemApiData)(await result.Content.ReadAsAsync(typeof(ItemApiData)));
                return;
            }
            catch(Exception e){
                Console.WriteLine(e.StackTrace);
            }
           
            return;
        }

        public void updateItem(long id, ItemDTO itemDTO)
        {
            var item = _ItemRepository.findById(id);
            if (item == null)
            {
                throw new Exception($"Could not find item with Id: {id}");
            }
            var  itemDTOProperties = itemDTO.GetType().GetProperties();
            foreach(var property in itemDTOProperties) {
                var value=property.GetValue(itemDTO);
                if (value == null)
                {
                    continue;
                }
                PropertyInfo prop = item.GetType().GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);

                if (null != prop && prop.CanWrite && prop.PropertyType.Equals(property.GetType()))
                {
                    prop.SetValue(item, value, null);
                }
            }
            this._ItemRepository.update(item);
             
        }
    }
}
