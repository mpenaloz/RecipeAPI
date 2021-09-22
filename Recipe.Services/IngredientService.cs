using Recipe.Data;
using Recipe.Models;
using RecipeAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Services
{
    public class IngredientService
    {
        public bool AddIngredientToRepo(IngredientCreate model)
        {
            var entity =
                new Ingredients()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Calories = model.Calories,
                    FoodId = model.FoodId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ingredients
                    .Single(e => id == e.Id);

                ctx.Ingredients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }  
        }

        public bool UpdateIngredient(IngredientEdit updatedIngredient)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ingredients
                    .Single(e => updatedIngredient.Id == e.Id);

                entity.Id = updatedIngredient.Id;
                entity.Name = updatedIngredient.Name;
                entity.Calories = updatedIngredient.Calories;
                entity.FoodId = updatedIngredient.FoodId;
                return ctx.SaveChanges() == 1;
            }
                
        }

        public IEnumerable<IngredientDisplay> GetAllIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Ingredients
                    .Where(e => 1 == 1)
                    .Select(
                        e =>
                        new IngredientDisplay
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Calories = e.Calories,
                            FoodId = e.FoodId,
                        }
                        );
                return query.ToArray();
            }
        }

        public IngredientDisplay GetIngredientsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ingredients
                    .Single(e => id == e.Id);
                return new IngredientDisplay
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Calories = entity.Calories,
                    FoodId = entity.FoodId
                };
            }
        }


    }
}
