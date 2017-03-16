using AttributeRouting.Web.Http;
//using AttributeRouting.Web.Http;
using BusinessEntities;
using BusinessServices;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiBackend.Controllers
{
    //[RoutePrefix("Items")]

    [EnableCorsAttribute("http://localhost:55747","*","*")]
    public class ItemController : ApiController
    {
        private IItemServices _itemServices;
        public MSIndianAppDataModel db = new MSIndianAppDataModel();
        
        #region Public Constructor
	    /// <summary>
        /// Constructor accepting itemService input
        /// </summary>
        /// <param name="itemServices"></param>
        public ItemController (IItemServices itemServices)
        {
            if (itemServices != null)
                _itemServices = itemServices;
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// 
        /// </summary>
        //public ItemController () : this(new ItemServices())
        //{

        //}
        #endregion
        
        //Get api/Item
        [HttpGet]
        [GET("allItems")] //Attribute routing ie direct localhost:38922/allItems
        //[Route("allItems")] //Using the route prefix localhost:38922/Items/allItems
        //[Route("~/MyRoute/allItems")] //Overriding route prefix localhost:38922/MyRoute/allItems
        public IEnumerable<Item> Get()
        {

            return db.Items;
            //var items = _itemServices.GetAllItems();

            //if(items != null)
            //{
            //    var itemEntities = items as List<ItemEntity> ?? items.ToList();
            //    if (itemEntities.Any())
            //        return Request.CreateResponse(HttpStatusCode.OK, itemEntities);
            //}
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Items not found");
        }

        //Get api/Item/5
          
        [HttpGet] //Routing using verbs
        [GET("itemid/{id?}")] //Attribute routing
        [GET("particularitem/{id:range(1,2)}")] //Fetches data for the ids within given range
        [GET(@"id/{e:regex(^[0-5]$)}")] 
        public HttpResponseMessage Get(int id   )
        {
            var item = _itemServices.GetItemById(id);

            if(item != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
        }

        //Put api/Item
        [HttpPost]
        [POST("Create")]
        [POST("Register")]
        public HttpResponseMessage Post([FromBody] ItemEntity item)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Model state is invalid");

            int itemId = _itemServices.CreateItem(item);

            if(itemId != 0)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Item cannot be created");
        }

        [HttpPut]
        [PUT("Update/itemid/{id}")]
        [PUT("Modify/itemid/{id}")]
        public HttpResponseMessage Put(int id,[FromBody] ItemEntity item)
        {
            if(!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model state is invalid");

            if(id != item.Id)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Id is not correct");
            if(id > 0)
                if(_itemServices.UpdateItem(id,item) == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpDelete]
        [DELETE("Remove/itemid/{id}")]
        [DELETE("Clear/itemid/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            if(id > 0)
            {
                var success = _itemServices.DeleteItem(id);
                if(success == true)
                    return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

    }
}
