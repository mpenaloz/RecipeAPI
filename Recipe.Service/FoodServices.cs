using Recipe.Data;
using Recipe.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Service
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

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Foods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public FoodDetail GetFoodByID(int id)
        {
            using(var ctx= new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Foods
                    .Single(e => id == e.Id);

                return new FoodDetail
                {
                    Id = entity.Id,
                    Ingredients = entity.Ingredients,
                    Name = entity.Name
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
                            Name = e.Name
                        });

                return query.ToArray();
            }
        }

        public bool UpdateFoodItem(FoodEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Foods
                    .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.Ingredients = model.Ingredients;
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFoodItem(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Foods
                    .Single(e => e.Id == id);

                ctx.Foods.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
