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
   public class Cuisine_Services
    {
        public IEnumerable<Recipes> GetRecipes()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cuisines
                    .Where(e => 1 == 1)
                    .Select(
                        e =>
                        new Recipes
                        {
                            Id = e.Id,
                            Name = e.CuisineName,
                        });
                return query.ToArray(); 
            }
        }
        public bool CreateCuisine(Create_Cuisine create_Cuisine)
        {
            var entity =
                new Cuisine
                {
                    Id = create_Cuisine.Cuisineid,
                    Name = create_Cuisine.CuisineName,
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Cuisines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateCuisine(Cuisine_update cuisine_Update)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cuisines
                    .Single(e => e.Id == cuisine_Update.Cuisineid);
                entity.CuisineName = cuisine_Update.CuisineName;
                return ctx.SaveChanges() == 1;
            }
        }
        public Cuisine_Detail GetCuisinebyId(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cuisines
                    .Single(e => id == e.Id);
                return new Cuisine_Detail
                {
                    Id = entity.Id,
                    CuisineName = entity.CuisineName,
                };
            }
        }
        public bool DeleteCuisineById(int id)
        {
            using(var ctx = new ApplicationDbContext())
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
