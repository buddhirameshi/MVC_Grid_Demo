using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API;
using DataTransferObjects;
using System.Data;
using PagedList;
using Common;

namespace GridDataDisplay.Controllers
{
    public class ItemController : Controller
    {
        private ItemService service = new ItemService();
        private ObjectConverter converter = new ObjectConverter();
       static int pageNumber=0; //this filed is static in order to keep the track of the page indexes. Useful to keep the track of sorting order in pagingation


        // GET: Items list
        public ActionResult Display(int?page,string sortOrder, string sortParam)

        {
            try
            {
                if(pageNumber==0)
                {
                    ViewBag.CurrentSort = "Descending";
                }
               else if(pageNumber<page)
                {
                    ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "Descending" : sortOrder;
                }
               else 
                {
                    ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "Descending" : this.ReverseSortOrder(sortOrder);
                }
               


                ViewBag.SortParam = string.IsNullOrEmpty(sortParam) ? "ItemId" : sortParam;
                 ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "Descending" : this.ReverseSortOrder(sortOrder);
                sortOrder = ViewBag.CurrentSort;
                int pageSize = ConfigDataReader.GetConfigIntValue("PageSize");
                pageNumber= (page ?? 1);

                return View(service.GetDataSet(sortOrder, sortParam).ToPagedList(pageNumber, pageSize));
            }
            catch (NullReferenceException ex)
            {
                return HttpNotFound();
            }

        }


        /// <summary>
        /// Get the item to be edited by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {

            if (id == null || id == 0||id<0)
            {
                return LoadErrorView();
            }
            int notNullableId = (int)id;
            return View(service.GetData(notNullableId));
        }


        //FOR MULTIPLE SUBMIT BUTTONS
        //[HttpPost]
        //[MultipleButton(Name = "action", Argument = "Save")]
        //public void Edit(ItemDto mm)
        //{
        //    var toin = mm.Description;

        //}

        //[HttpPost]
        //[MultipleButton(Name = "action", Argument = "Clear")]
        //public void Edit(ItemDto mm,string type)
        //{
        //    var toin = mm.Description;

        //}


        /// <summary>
        ///Post the edited values
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Price,Description,ItemId")] ItemDto item)
        {
            //TODO MULTIPLE BUTTON SCENARIO WITH AN INPUT PARAMETER NAMED submit 
            ////if(string.Equals(submit,"Save"))
            ////{
            ////    var t = "";
            ////}
            ////else if (string.Equals(submit, "Clear"))
            ////{
            ////    var t = "";
            ////}
            if (item == null || item.Price == null || item.ItemId == 0 || item.ItemId < 0)
            {
                return LoadErrorView();
            }
            try
            {
                if (service.UpdateData(item))
                {
                    //db.Entry(movie).State = EntityState.Modified;
                    //db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Display");
                }
                else
                {
                    return RedirectToAction("Edit", new { id = item.ItemId });
                }
            }
            catch (DataException ex)
            {

                ModelState.AddModelError(ex.Message, ex.StackTrace);
                return View("Error");
            }
        }


        /// <summary>
        /// Returns the empty form for the user to add data
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// Create a new item with user added data
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Price,Description")] ItemDto item)
        {
            if (item == null || item.Price == null)
            {
                return LoadErrorView();
            }

            try
            {
                if (service.InsertData(item))
                {
                    ModelState.Clear();
                    return RedirectToAction("Display");
                }
                else
                {
                    return RedirectToAction("Create");
                   // return LoadErrorView();
                }
            }
            catch (DataException ex)
            {

                ModelState.AddModelError(ex.Message, ex.StackTrace);
                return View("Error");
            }
        }

        /// <summary>
        /// Displays the view before Deletion
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null || id == 0 || id < 0)
            {
                return LoadErrorView();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            int notNullableId = (int)id;
            return View(service.GetData(notNullableId));
        }

        /// <summary>
        /// Deleted the selected data
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int itemId)
        {
            if (itemId == 0 ||itemId<0)
            {
                return LoadErrorView();
            }
            try
            {
                if (service.DeleteItem(itemId))
                {

                    return RedirectToAction("Display");
                }

                else
                {
                    return RedirectToAction("Delete", new { id = itemId, saveChangesError = true });
                }
            }
            catch(DataException ex)
            {
                ModelState.AddModelError(ex.Message,ex.StackTrace);
                return RedirectToAction("Delete", new { id = itemId, saveChangesError = true });
            }
        }



        private ActionResult LoadErrorView()
        {
            ViewBag.ErroMessage = "Item is empty";
            return View("InputError");
        }


        /// <summary>
        /// Altering the existing sorting direction
        /// </summary>
        /// <param name="sortDir"></param>
        /// <returns></returns>
        private string ReverseSortOrder(string sortDir)
        {
            string dir = string.Empty;
           switch(sortDir)
            {
                case "Descending":
                    {
                        sortDir = "Ascending";
                        break;
                    }
                case "Ascending":
                    {
                        sortDir = "Descending";
                        break;
                    }
                default:
                    {
                        sortDir = "Descending";
                        break;
                    }
            }
            return sortDir;
        }
    }
}