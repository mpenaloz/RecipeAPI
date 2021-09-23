using Recipe.Data;
using Recipes.Models.Cusine_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Service
{
    public class CuisineServices
    {
        public bool CreateCuisine(CuisineCreate model)
        {
            var entity =
                new Cuisine
                {
                    Id = model.Id,
                    Name = model.Name,
                    Recipes = model.Recipes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cuisines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CuisineListItem> GetAllCuisines()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cuisines
                    .Where(e => 1 == 1)
                    .Select(e =>
                    new CuisineListItem
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Recipes = e.Recipes,
                    });

                return query.ToArray();
            }
        }

        public CuisineDetail GetCuisineById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cuisines
                    .Single(e => id == e.Id);

                return new CuisineDetail
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Recipes = entity.Recipes,
                };
            }
        }

        public bool UpdateCuisine(CuisineEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cuisines
                    .Single(e => model.Id == e.Id);

                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Recipes = model.Recipes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCuisine(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cuisines
                    .Single(e => id == e.Id);

                ctx.Cuisines.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
