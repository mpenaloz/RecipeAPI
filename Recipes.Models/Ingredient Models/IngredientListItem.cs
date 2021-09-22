using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Models.Ingredient_Models
{
    public class IngredientListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Calories { get; set; }

        public int FoodId { get; set; }
    }
}
