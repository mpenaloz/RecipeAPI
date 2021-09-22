using Recipe.Data;
using Recipe.Models.FoodModels;
using RecipeAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Services
{
    public class FoodServices
    {
        public bool CreateFoodItem(FoodCreate model)
        {
            var entity =
                new Food
                {
                    Id = model.Id,
                    Ingredients = model.Ingredients,
                    Name = model.Name
                };

            using (var ctx = new ApplicationDbContext())
            {
                    ctx
                    .Foods
                    .Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public FoodDetail FindFoodByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Foods
                    .Single(e => id == e.Id);

                return new FoodDetail
                {
                    Id = entity.Id,
                    Ingredients = entity.Ingredients,
                    Name = entity.Name,
                };
            }        
        }

        public IEnumerable<FoodListItem> GetAllFoodItems()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Foods
                    .Where(e => 1 == 1)
                    .Select(e =>
                    new FoodListItem
                    {
                        Id = e.Id,
                        Ingredients = e.Ingredients,
                        Name = e.Name,
                    });

                return query.ToArray();
            }
        }

        public bool UpdateFoodItemById(FoodEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Foods
                    .Single(e => model.Id == e.Id);

                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Ingredients = model.Ingredients;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFoodItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Foods
                    .Single(e => id == e.Id);

                ctx.Foods.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
