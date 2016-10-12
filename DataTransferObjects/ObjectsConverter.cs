using DataAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class ObjectsConverter
    {

        /// <summary>
        /// COnverts the data access object to the transfer object by hiding unwanted fields from the data access object
        /// </summary>
        /// <param name="oneItem"></param>
        /// <returns></returns>
        public ItemDto ToItemDto(Item oneItem)
        {
            if(oneItem==null)
            {
                return null;
            }
            ItemDto dto = new ItemDto();
            dto.ItemId = oneItem.ItemId;
            dto.Price = oneItem.Price;
            dto.Description = oneItem.Description;
            return dto;
        }


        /// <summary>
        /// COnverting a list of data access objects to dto objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<ItemDto> ToListItemDto(List<Item> items)
        {
            if (items == null || items.Count==0)
            {
                return null;
            }
            List<ItemDto> dtoList = new List<ItemDto>();
            foreach (var item in items)
            {
                ItemDto dto = new ItemDto();
                dto.ItemId = item.ItemId;
                dto.Price = item.Price;
                dto.Description = item.Description;
                dtoList.Add(dto);             
            }
            return dtoList;
        }


        /// <summary>
        /// COnverting a list of dto objects to data access objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<Item> ToListItems(List<ItemDto> itemsDto)
        {
            if (itemsDto == null || itemsDto.Count == 0)
            {
                return null;
            }
            List<Item> daoList = new List<Item>();
            foreach (var item in itemsDto)
            {
                Item dao = new Item();
                dao.ItemId = item.ItemId;
                dao.Price = item.Price;
                dao.Description = item.Description;
                daoList.Add(dao);
            }
            return daoList;
        }

        /// <summary>
        /// Converts the object from transfer object to business object which will add the hidden fields to the object at lower levels
        /// </summary>
        /// <param name="oneDTO"></param>
        /// <returns></returns>
        public Item ToItem(ItemDto oneDTO)
        {
            if (oneDTO == null)
            {
                return null;
            }
            Item oneItem = new Item();
            oneItem.ItemId = oneDTO.ItemId;
            oneItem.Price = oneDTO.Price;
            oneItem.Description = oneDTO.Description;
            return oneItem;
        }

    }
}
