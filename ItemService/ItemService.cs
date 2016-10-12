using DataAccessor;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
   public class ItemService
    {
        private IRepository<Item> repository;
        private ObjectsConverter converter = new ObjectsConverter();

        public ItemService()
        {
            this.repository = new ToyRepository(new ItemEntities());
        }

        public IEnumerable<ItemDto> GetDataSet()
        {
          return  converter.ToListItemDto(repository.GetItems().ToList());
           // return repository.GetItems();
        }

        public bool UpdateData(ItemDto dto)
        {
            var item = converter.ToItem(dto);
            return repository.UpdateItem(item);
        }

        public ItemDto GetData(int id)
        {
            return converter.ToItemDto(repository.GetItemByID(id));
        }

        public bool InsertData(ItemDto dto)
        {
            var item = converter.ToItem(dto);
            return repository.InsertItem(item);
        }

        public bool DeleteItem(int itemId)
        {
            return repository.DeleteItem(itemId);
        }
    }
}
