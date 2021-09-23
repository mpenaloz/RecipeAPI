using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using Recipe.Service;
using Recipes.Models.Ingredient_Models;

namespace RecipeAPI.Controllers
{
    [Authorize]
    public class IngredientController : ApiController
    {
        private IngredientServices CreateIngredientService()
        {
            var service = new IngredientServices();
            return service;
        }

        [HttpPost]
        public IHttpActionResult AddIngredientToRepo(IngredientCreate model)
        {
            var service = CreateIngredientService();

            if (!service.AddIngredientToRepo(model) || !ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetIngredientById(int id)
        {
            var service = CreateIngredientService();

            if (service.GetIngredientsById(id) == null)
                return BadRequest("Ingredient not found within the system");

            var ingredient = service.GetIngredientsById(id);

            return Ok(ingredient);
        }

        [HttpGet]
        public IHttpActionResult GetAllIngredients()
        {
            var service = CreateIngredientService();

            var query = service.GetAllIngredients();

            return Ok(query);
        }

        [HttpPut]
        public IHttpActionResult UpdateIngredient(IngredientEdit model)
        {
            var service = CreateIngredientService();

            if (!service.UpdateIngredient(model))
                return InternalServerError();

            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult DeleteIngredientById(int id)
        {
            var service = CreateIngredientService();

            if (!service.DeleteIngredientById(id))
                return InternalServerError();

            return Ok("Ingredient successfully deleted");
        }
  
    }
}