using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Recipe.Service;
using Recipes.Models.Cusine_Models;

namespace RecipeAPI.Controllers
{
    [Authorize]
    public class CuisineController : ApiController
    {

        private CuisineServices CreateCuisineService()
        {
            var service = new CuisineServices();
            return service;
        }

        [HttpPost]
        public IHttpActionResult CreateCuisine(CuisineCreate model)
        {
            var service = CreateCuisineService();

            if (!service.CreateCuisine(model) || !ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetCuisineById(int id)
        {
            var service = CreateCuisineService();

            if (service.GetCuisineById(id) == null)
                return BadRequest("Id not found within cuisine database");

            var cuisine = service.GetCuisineById(id);

            return Ok(cuisine);
        }

        [HttpGet]
        public IHttpActionResult GetAllCuisines()
        {
            var service = CreateCuisineService();

            var query = service.GetAllCuisines();

            return Ok(query);
        }

        [HttpPut]
        public IHttpActionResult UpdateCuisine(CuisineEdit model)
        {
            var service = CreateCuisineService();

            if (!service.UpdateCuisine(model))
                return InternalServerError();

            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCuisine(int id)
        {
            var service = CreateCuisineService();

            if (!service.DeleteCuisine(id))
                return InternalServerError();

            return Ok("Cuisine successfully deleted");
        }
        
       
    }
}