using Recipe.Data;
using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Recipes.Models.FoodModels
{
    public class FoodDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Ingredients> Ingredients { get; set; }
    }
}
