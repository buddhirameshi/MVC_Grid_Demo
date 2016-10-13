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
        private enum ItemParams { Price,ItemId,Description};

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
                IEnumerable<Item> setOfItems = new List<Item>();
                //using (context = new ItemEntities())
                //{
                    var items = context.Items
                        .Where(someItems => someItems.Description != null)
                        .OrderBy(someItems => someItems.ItemId)
                        .Take(10);
                    setOfItems = items;
                //}
                return setOfItems;
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
        public IEnumerable<Item> GetItems(int pageId,int pageSize,string parameter,bool isAscending)
        {
            try
            {
                IEnumerable<Item> setOfItems = new List<Item>();
                ItemParams enumParamerer;
                if (!Enum.TryParse(parameter, true, out enumParamerer))
                {
                    return null;
                }
                else
                {

                    if (enumParamerer == ItemParams.Description&&isAscending)
                    {
                        var maxValue = context.Items
                       .Where(someItems => someItems.Description != null)
                       .OrderBy(someItems => someItems.Description).Take((pageId - 1) * pageSize).Max().Description;
                        if (string.IsNullOrEmpty(maxValue))
                        {
                             setOfItems= context.Items
                                         .Where(someItems => someItems.Description != null 
                                         )
                                        .OrderBy(someItems => someItems.Description).Take((pageId - 1) * pageSize);
                        }
                       
                    }

                    //}
                    return setOfItems;
                }
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


    }
}
