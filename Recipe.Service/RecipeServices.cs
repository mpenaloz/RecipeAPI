using Recipe.Data;
using Recipe.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Service
{
    public class RecipeServices
    {
        public bool CreateRecipe(RecipeCreate model)
        {
            var entity =
                new Recipess
                {
                    CookTime = model.CookTime,
                    CuisineId = model.CuisineId,
                    PrepTime = model.PrepTime,
                    Id = model.Id,
                    Ingredients = model.Ingredients,
                    Name = model.Name,
                    ServingSize = model.ServingSize
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public RecipeDetail GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => id == e.Id);

                return new RecipeDetail
                {
                    Id = entity.Id,
                    CookTime = entity.CookTime,
                    Cuisine = entity.Cuisine,
                    Ingredients = entity.Ingredients,
                    Name = entity.Name,
                    PrepTime = entity.PrepTime,
                    ServingSize = entity.ServingSize,
                    Calories = entity.Calories,
                };
            }
        }

        public IEnumerable<RecipeListItem> GetAllRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Where(e => 1 == 1)
                    .Select(
                        e =>
                        new RecipeListItem
                        {
                            CookTime = e.CookTime,
                            Cuisine = e.Cuisine,
                            Id = e.Id,
                            Ingredients = e.Ingredients,
                            Name = e.Name,
                            PrepTime = e.PrepTime,
                            ServingSize = e.ServingSize,
                            Calories = e.Calories,
                        });

                return query.ToArray();
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => model.Id == e.Id);

                entity.Id = model.Id;
                entity.CookTime = model.CookTime;
                entity.Cuisine = model.Cuisine;
                entity.Ingredients = model.Ingredients;
                entity.Name = model.Name;
                entity.PrepTime = model.PrepTime;
                entity.ServingSize = model.ServingSize;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => id == e.Id);

                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<RecipeListItem> GetRecipesByIngredient(Ingredients model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Where(e => e.Ingredients.Contains(model))
                    .Select(e =>
                    new RecipeListItem
                    {
                        CookTime = e.CookTime,
                        Cuisine = e.Cuisine,
                        Id = e.Id,
                        Ingredients = e.Ingredients,
                        Name = e.Name,
                        PrepTime = e.PrepTime,
                        ServingSize = e.ServingSize,
                        Calories = e.Calories,
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeByCuisineType(Cuisine model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Where(e => e.Cuisine == model)
                    .Select(e =>
                    new RecipeListItem
                    {
                        CookTime = e.CookTime,
                        Cuisine = e.Cuisine,
                        Id = e.Id,
                        Ingredients = e.Ingredients,
                        Name = e.Name,
                        PrepTime = e.PrepTime,
                        ServingSize = e.ServingSize,
                        Calories = e.Calories,
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipesByCalorieRange(int min, int max)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Where(e => e.Calories > min && e.Calories < max)
                    .Select(e =>
                    new RecipeListItem
                    {
                        CookTime = e.CookTime,
                        Cuisine = e.Cuisine,
                        Id = e.Id,
                        Ingredients = e.Ingredients,
                        Name = e.Name,
                        PrepTime = e.PrepTime,
                        ServingSize = e.ServingSize,
                        Calories = e.Calories,
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipesByPrepTime(int min, int max)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Where(e => e.PrepTime > min && e.PrepTime < max)
                    .Select(e =>
                    new RecipeListItem
                    {
                        CookTime = e.CookTime,
                        Cuisine = e.Cuisine,
                        Id = e.Id,
                        Ingredients = e.Ingredients,
                        Name = e.Name,
                        PrepTime = e.PrepTime,
                        ServingSize = e.ServingSize,
                        Calories = e.Calories,
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipesByCookTime(int min, int max)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Where(e => e.CookTime > min && e.CookTime < max)
                    .Select(e =>
                    new RecipeListItem
                    {
                        CookTime = e.CookTime,
                        Cuisine = e.Cuisine,
                        Id = e.Id,
                        Ingredients = e.Ingredients,
                        Name = e.Name,
                        PrepTime = e.PrepTime,
                        ServingSize = e.ServingSize,
                        Calories = e.Calories,
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeByMinimumServingSize(int min)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Where(e => e.ServingSize < min)
                    .Select(e =>
                    new RecipeListItem
                    {
                        CookTime = e.CookTime,
                        Cuisine = e.Cuisine,
                        Id = e.Id,
                        Ingredients = e.Ingredients,
                        Name = e.Name,
                        PrepTime = e.PrepTime,
                        ServingSize = e.ServingSize,
                        Calories = e.Calories,
                    });

                return query.ToArray();
            }
        }
    }
}

