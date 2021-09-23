using Recipe.Data;
using Recipe.Models.RecipeModels;
using Recipe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecipeAPI.Controllers
{
    [Authorize]
    public class RecipeController : ApiController
    {
        private RecipeServices CreateRecipeService()
        {
            var service = new RecipeServices();
            return service;
        }

        [HttpPost]
        public IHttpActionResult CreateRecipe(RecipeCreate model)
        {
            var service = CreateRecipeService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!service.CreateRecipe(model))
                return InternalServerError();

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetRecipe(int id)
        {
            var service = CreateRecipeService();

            var recipe = service.GetRecipeById(id);

            if (service.GetRecipeById(id) == null)
                return BadRequest("Id not contained within database.");

            return Ok(recipe);
        }

        [HttpGet]
        public IHttpActionResult GetAllRecipes()
        {
            var service = CreateRecipeService();

            var recipes = service.GetAllRecipes();

            return Ok(recipes);
        }

        [HttpPut]
        public IHttpActionResult UpdateRecipe(RecipeEdit model)
        {
            var service = CreateRecipeService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!service.UpdateRecipe(model))
                return InternalServerError();

            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult DeleteRecipe(int id)
        {
            var service = CreateRecipeService();

            if (!service.DeleteRecipe(id))
                return InternalServerError();

            return Ok("Recipe deleted.");
        }

        [HttpGet]
        public IHttpActionResult GetRecipesByIngredientsType(Ingredients model)
        {
            var service = CreateRecipeService();

            if (service.GetRecipesByIngredient(model) == null)
                return BadRequest("No recipes contain this ingredient.");

            var recipes = service.GetRecipesByIngredient(model);

            return Ok(recipes);
        }

        [HttpGet]
        public IHttpActionResult GetRecipesByCuisine(Cuisine model)
        {
            var service = CreateRecipeService();

            if (service.GetRecipeByCuisineType(model) == null)
                return BadRequest("No recipes containing to this cuisine.");

            var recipes = service.GetRecipeByCuisineType(model);

            return Ok(recipes);
        }

        [HttpGet]
        public IHttpActionResult GetRecipesByCalorieRange(int min, int max)
        {
            var service = CreateRecipeService();

            if (service.GetRecipesByCalorieRange(min, max) == null)
                return BadRequest("No recipes within the given calorie restraints");

            var recipes = service.GetRecipesByCalorieRange(min, max);

            return Ok(recipes);
        }

        [HttpGet]
        public IHttpActionResult GetRecipesByPrepTime(int min, int max)
        {
            var service = CreateRecipeService();

            if (service.GetRecipesByPrepTime(min, max) == null)
                return BadRequest("No recipes within the given prep-time restraints");

            var recipes = service.GetRecipesByPrepTime(min, max);

            return Ok(recipes);
        }

        [HttpGet]
        public IHttpActionResult GetRecipesByCookTime(int min, int max)
        {
            var service = CreateRecipeService();

            if (service.GetRecipesByCookTime(min, max) == null)
                return BadRequest("No recipes within the given cooktime restraints");

            var recipes = service.GetRecipesByCookTime(min, max);

            return Ok(recipes);
        }

        public IHttpActionResult GetRecipesByMinimumServingSize(int min)
        {
            var service = CreateRecipeService();

            if (service.GetRecipeByMinimumServingSize(min) == null)
                return BadRequest("No recipes would serve the minimum serving size");

            var recipes = service.GetRecipeByMinimumServingSize(min);

            return Ok(recipes);
        }

    }
}
