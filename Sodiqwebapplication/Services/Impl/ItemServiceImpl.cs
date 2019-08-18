using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sodiqwebapplication.Entities;
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
                foreach(var itemDTO in content.items){
                    if(itemAlreadyExists(itemDTO.ItemId)){
                        continue;
                    }
                    addItem(itemDTO);
                }
                return;
            }
            catch(Exception e){
                Console.WriteLine(e.StackTrace);
            }
           
            return;
        }

        private void addItem(ItemDTO itemDTO){
            Item item = new Item();
            Utils.Util.propertyCopy(itemDTO, item);
            item = populateWithImages(item, itemDTO.Images);
            item.SubSections = JsonConvert.SerializeObject(itemDTO.SubSections);
            _ItemRepository.save(item);
        }

        private Item populateWithImages(Item item, List<ImageDTO> imageDTOList)
        {
            item.Images = new List<Image>();
            foreach (var imageDTO in imageDTOList)
            {
                Image image = new Image();
                Utils.Util.propertyCopy(imageDTO, image);
                image.OtherImagesUrl = JsonConvert.SerializeObject(imageDTO.OtherImagesUrl);
                item.Images.Add(image);
            }
            return item;
        }
        private bool itemAlreadyExists(long itemId){
            return false;
            //return this._ItemRepository.filterBy(item => item.ItemId == itemId).Count>0;
        }

        public void updateItem(long id, ItemDTO itemDTO)
        {
            var item = _ItemRepository.findById(id);

            if (item == null)
            {
                throw new Exception($"Could not find item with Id: {id}");
            }
            Utils.Util.propertyCopy(itemDTO, item);
            if(itemDTO.SubSections!=null && itemDTO.SubSections.Count>0){
                item = updateWithSubSection(item, itemDTO.SubSections);
            }
            this._ItemRepository.update(item);
             
        }
        private Item updateWithSubSection(Item item,Dictionary<String, List<String>> updatedSubSection){
            Dictionary<String, List<String>> oldSubSections = JsonConvert.DeserializeObject<Dictionary<String, List<String>>>(item.SubSections);
            foreach (var keyValuePair in updatedSubSection)
            {
                oldSubSections.Add(keyValuePair.Key, keyValuePair.Value);
            }
            item.SubSections = JsonConvert.SerializeObject(oldSubSections);
            return item;
        }
    }
}
