using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessor
{
    public interface IRepository<T> :IDisposable
    {
            IEnumerable<T> GetItems();
           IEnumerable<T> GetItems(string sortOrder,string sortParam);
            Item GetItemByID(int itemId);
            bool InsertItem(T oneItem);
            bool DeleteItem(int itemID);
            bool UpdateItem(T oneItem);
            //void Save();
    }
}
