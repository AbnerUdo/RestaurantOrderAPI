using restaurant_order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace restaurant_order.Controllers
{
    public class DishController : ApiController
    {
        static readonly IDishesRepository dishRepository = new DishesRepository();

        public HttpResponseMessage GetAllDishes()
        {
            List<Dish> dishList = dishRepository.GetAll().ToList();
            return Request.CreateResponse<List<Dish>>(HttpStatusCode.OK, dishList);
        }

        public HttpResponseMessage PostDish(string dish)
        {
            bool result = dishRepository.Add(dish);
            if (result)
            {
                var response = Request.CreateResponse<String>(HttpStatusCode.Created, dish);
                string uri = Url.Link("DefaultApi", new { id = dish });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Dish not included with sucess");
            }
        }

    }
}
