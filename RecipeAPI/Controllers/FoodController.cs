using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Recipe.Service;
using Recipe.Models.FoodModels;

namespace RecipeAPI.Controllers
{
    [Authorize]
    public class FoodController : ApiController
    {

        private FoodServices CreateFoodService()
        {
            var service = new FoodServices();
            return service;
        }

        [HttpPost]
        public IHttpActionResult CreateFood(FoodCreate model)
        {
            var service = CreateFoodService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!service.CreateFoodItem(model))
                return InternalServerError();

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetFoodItemById(int id)
        {
            var service = CreateFoodService();

            if (service.GetFoodByID(id) == null)
                return BadRequest("Id does not correspond eto existing food item within database");

            var food = service.GetFoodByID(id);

            return Ok(food);
        }

        [HttpGet]
        public IHttpActionResult GetAllFoodItems()
        {
            var service = CreateFoodService();

            var query = service.GetAllFoodItems();

            return Ok(query);
        }

        [HttpPut]
        public IHttpActionResult UpdateFoodItem(FoodEdit model)
        {
            var service = CreateFoodService();

            if (!service.UpdateFoodItem(model))
                return BadRequest(ModelState);

            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult DeleteFooditemByID(int id)
        {
            var service = CreateFoodService();

            if (!service.DeleteFoodItem(id))
                return InternalServerError();

            return Ok("Food item successfully deleted");
        }
       
    }
}