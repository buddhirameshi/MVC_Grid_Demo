using DataAccessor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessor
{
    public class ToyRepository : IRepository<Item>
    {
        private ItemEntities context;
        private enum ItemParams { Price, ItemId, Description };
        private delegate IEnumerable<Item> SortItems(string sortOrder=null,string sortParam=null); 

        public ToyRepository(ItemEntities repository)
        {
            this.context = repository;
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public bool DeleteItem(int itemID)
        {
            if (itemID < 0 || itemID == 0)
            {
                return false;
            }
            try
            {
                //using (context = new ItemEntities())
                //{
                var selectedItem = context.Items.Find(itemID);
                if (selectedItem == null)
                {
                    return false;
                }
                context.Items.Remove(selectedItem);
                return true;
                //  }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the item by given Id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Item GetItemByID(int itemId)
        {
            if (itemId == 0 || itemId < 0)
            {
                return null;
            }
            try
            {
                //using (context = new ItemEntities())
                //{
                var oneItem = context.Items
                    .Where(o => o.ItemId == itemId)
                    .SingleOrDefault();
                return oneItem;
                // }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Item> GetItems()
        {
            try
            {
                //IEnumerable<Item> setOfItems = new List<Item>();
                ////using (context = new ItemEntities())
                ////{
                //var items = context.Items
                //    .Where(someItems => someItems.Description != null)
                //    .OrderBy(someItems => someItems.ItemId);
                //setOfItems = items;
                ////}
                //return setOfItems;
                SortItems sortedItems = new SortItems(SortData);
                return sortedItems();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get items overloaded method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Item> GetItems(string sortOrder, string sortParam)
        {
            try
            {

                SortItems sortedItems = new SortItems(SortData);
               return sortedItems(sortOrder,sortParam);
            }   
            catch (SqlException ex)
            {
                throw ex;
            }
}


/// <summary>
/// Insert an item
/// </summary>
/// <param name="oneItem"></param>
/// <returns></returns>
public bool InsertItem(Item oneItem)
{
    if (oneItem == null)
    {
        return false;
    }
    try
    {
        //using (context = new ItemEntities())
        //{
        context.Items.Add(oneItem);
        return true;
    }
    //}
    catch (SqlException ex)
    {
        throw ex;
    }
}


/// <summary>
/// Update an item
/// </summary>
/// <param name="oneItem"></param>
/// <returns></returns>
public bool UpdateItem(Item oneItem)
{
    if (oneItem == null)
    {
        return false;
    }
    try
    {


        //context.SaveChanges();
        var item = context.Items
                       .Where(n => n.ItemId == oneItem.ItemId)
                       .SingleOrDefault();
        item.Description = oneItem.Description;
        item.Price = oneItem.Price;
        // context.Entry(oneItem).State = System.Data.Entity.EntityState.Modified;
        context.SaveChanges();

        return true;
    }
    catch (SqlException ex)
    {
        throw ex;
    }

}

     private IEnumerable<Item> SortData(string sortOrder=null,string sortParam=null)
        {
            ItemParams enumSortParam;
            SortOrder sortDir = SortOrder.Descending;
            IEnumerable<Item> setOfItems = null;
            if (!Enum.TryParse(sortParam, true, out enumSortParam))
            {
                enumSortParam = ItemParams.ItemId;
            }
            if (!Enum.TryParse(sortOrder, true, out sortDir))
            {
                sortDir = SortOrder.Descending;
            }

            if (enumSortParam == ItemParams.ItemId)
            {
                if (sortDir == SortOrder.Ascending)
                {
                    setOfItems = context.Items
                                .OrderBy(someItems => someItems.ItemId);
                }
                else if (sortDir == SortOrder.Descending)
                {
                    setOfItems = context.Items
                    .OrderByDescending(someItems => someItems.ItemId);
                }
            }

            else if (enumSortParam == ItemParams.Description)
            {
                if (sortDir == SortOrder.Ascending)
                {
                    setOfItems = context.Items
                                .OrderBy(someItems => someItems.Description);
                }
                else if (sortDir == SortOrder.Descending)
                {
                    setOfItems = context.Items
                    .OrderByDescending(someItems => someItems.Description);
                }
            }

            else if (enumSortParam == ItemParams.Price)
            {
                if (sortDir == SortOrder.Ascending)
                {
                    setOfItems = context.Items
                                .OrderBy(someItems => someItems.Price);
                }
                else if (sortDir == SortOrder.Descending)
                {
                    setOfItems = context.Items
                    .OrderByDescending(someItems => someItems.Price);
                }
            }
            return setOfItems;
        }

    }
}
